using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClipperLib;

namespace CameraPlugin
{
    public partial class frmMain : Form
    {
        private Point startingPoint = Point.Empty;
        private Point movingPoint = Point.Empty;
        private bool panning = false;

        public Dictionary<string, CCTVCamera> cameras;
        public Dictionary<string, CCTVRoom> rooms;

        public string curCamera = "0";
        public string curRoom = "0";
        public int curMode = 0;

        public float zoomRatio = 1;

        public static Autodesk.Revit.DB.Document document;
        public static Dictionary<string, List<Autodesk.Revit.DB.ElementId>> idCouple;

        private double tmpOldPan;

        public void addCamera(Autodesk.Revit.DB.Architecture.Room r, Autodesk.Revit.DB.Element e)
        {
            CCTVCamera tmp = new CCTVCamera();
            tmp.room = r;
            tmp.camera = e;
            cameras[e.Id.ToString()] = tmp;
        }

        public void addRoom(Autodesk.Revit.DB.Architecture.Room r)
        {
            CCTVRoom tmp = new CCTVRoom();
            tmp.room = r;
            rooms[r.Id.ToString()] = tmp;
        }

        public frmMain()
        {
            InitializeComponent();
            this.picRooms.MouseWheel += picRooms_MouseWheel;
            rooms = new Dictionary<string, CCTVRoom>();
            cameras = new Dictionary<string, CCTVCamera>();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        private void refreshRoom(CCTVRoom r, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Bitmap b = new Bitmap(picRooms.Width, picRooms.Height);
            Graphics dc = Graphics.FromImage((System.Drawing.Image)b);

            Font drawFont = new Font("Tahoma", 12);
            StringFormat sf = new StringFormat();
            StringFormat sfc = new StringFormat();
            sfc.LineAlignment = sf.LineAlignment = StringAlignment.Center;
            sfc.Alignment = StringAlignment.Center;

            dc.TranslateTransform(r.initShift + movingPoint.X, r.initShift + movingPoint.Y);
            dc.Clear(Color.White);
            dc.SmoothingMode = SmoothingMode.AntiAlias;
            dc.TextRenderingHint = TextRenderingHint.AntiAlias;

            Pen myPen = new Pen(Color.Black);
            myPen.Width = 2;

            foreach(var dp in r.drawablePoints)
            {
                dc.DrawLines(myPen, dp);
            }
            dc.DrawString(r.room.Name + "(" + r.zoomRatioX.ToString("0.0") + "x)", 
                drawFont, Brushes.Black, 0, (float)r.Height / 2 * r.zoomRatioX, sfc);

            foreach (var dr in r.doors)
            {
                var loc = dr.Location as Autodesk.Revit.DB.LocationPoint;
                var d = dr.get_BoundingBox(null).Max - dr.get_BoundingBox(null).Min;
                var radius = (float)Math.Sqrt(d.X * d.X + d.Y * d.Y) * r.zoomRatioX / 2;

                Brush br;
                if (dr.Category.Id.IntegerValue == (int)Autodesk.Revit.DB.BuiltInCategory.OST_Doors)
                    br = new SolidBrush(Color.FromArgb(80, 255, 0, 0));
                else
                    br = new SolidBrush(Color.FromArgb(120, 255, 255, 0));

                dc.FillEllipse(br, (float)loc.Point.X * r.zoomRatioX - radius / 2,
                    (float)loc.Point.Y * r.zoomRatioY - radius / 2, radius, radius);

                dc.DrawString(dr.Name, drawFont, new SolidBrush(Color.FromArgb(120, 0, 0, 0)), 
                    (float)loc.Point.X * r.zoomRatioX, (float)loc.Point.Y * r.zoomRatioY, sfc);
            }

            Pen cameraPen = new Pen(Color.Blue);
            cameraPen.Width = 2;
            Pen dirPen = new Pen(Color.DarkGreen);
            dirPen.Width = 2;

            foreach (var c in cameras)
            {
                var cam = c.Value;
                if(cam.room.Id.Equals(r.room.Id))
                {
                    
                    int cx = (int)(cam.cameraCenter.X * r.zoomRatioX), cy = (int)(cam.cameraCenter.Y * r.zoomRatioY);
                    dc.DrawEllipse(cameraPen, new Rectangle(cx - 5, cy - 5, 10, 10));

                    List<Point> cbp = new List<Point>();
                    foreach (PointF pf in cam.clippedBoundaryPoints)
                    {
                        cbp.Add(new Point((int)(pf.X * r.zoomRatioX), (int)(pf.Y * r.zoomRatioY)));
                    }
                    cbp.Add(new Point(cx, cy));

                    dc.DrawPolygon(dirPen, cbp.ToArray());

                    Brush brush = new SolidBrush(Color.FromArgb(120, 0, 255, 0));
                    Brush brush2 = new SolidBrush(Color.FromArgb(120, 0, 128, 255));

                    dc.FillPolygon(brush, cbp.ToArray()); 
                    //dc.FillPolygon(brush2, new Point[] { new Point(cx, cy), cam.rightNear, cam.leftNear, new Point(cx, cy) });
      
                    string _name = cam.camera.ParametersMap.get_Item("camera_name").AsString();
                    if(_name != null)
                    {
                        SizeF stringSize = e.Graphics.MeasureString(_name, drawFont);

                        dc.DrawRectangle(Pens.Black, cx + 10, cy - stringSize.Height / 2, stringSize.Width, stringSize.Height);

                        if (cam.camera.Id.ToString() == curCamera)
                        {
                            dc.FillRectangle(Brushes.Black, cx + 10, cy - stringSize.Height / 2, stringSize.Width, stringSize.Height);
                            dc.DrawString(_name, drawFont, Brushes.White, cx + 10, cy, sf);
                        }
                        else
                        {
                            dc.FillRectangle(Brushes.LightBlue, cx + 10, cy - stringSize.Height / 2, stringSize.Width, stringSize.Height);
                            dc.DrawString(_name, drawFont, Brushes.Black, cx + 10, cy, sf);
                        }

                        
                    }

                    g.DrawImage(b, 0, 0);
                }
            }

            drawFont.Dispose();
            dc.Dispose();
        }

        private void refreshAll(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Bitmap b = new Bitmap(picRooms.Width, picRooms.Height);
            Graphics dc = Graphics.FromImage((System.Drawing.Image)b);

            Font drawFont = new Font("Tahoma", 12);
            StringFormat sf = new StringFormat();
            StringFormat sfc = new StringFormat();
            sfc.LineAlignment = sf.LineAlignment = StringAlignment.Center;
            sfc.Alignment = StringAlignment.Center;

            dc.TranslateTransform(movingPoint.X, movingPoint.Y);
            dc.Clear(Color.White);
            dc.SmoothingMode = SmoothingMode.AntiAlias;
            dc.TextRenderingHint = TextRenderingHint.AntiAlias;

            Pen myPen = new Pen(Color.Black);
            myPen.Width = 2;

            foreach (var r in rooms)
            {
                if (!r.Value.validRoom) continue;

                foreach (var dp in r.Value.boundaryPoints)
                {
                    dc.DrawLines(myPen, (from i in dp select new Point((int)(i.X * zoomRatio), (int)(i.Y * -zoomRatio))).ToArray());
                }

                foreach (var dr in r.Value.doors)
                {
                    var loc = dr.Location as Autodesk.Revit.DB.LocationPoint;
                    var d = dr.get_BoundingBox(null).Max - dr.get_BoundingBox(null).Min;
                    var radius = (float)Math.Sqrt(d.X * d.X + d.Y * d.Y) * zoomRatio / 2;

                    Brush br;
                    if (dr.Category.Id.IntegerValue == (int)Autodesk.Revit.DB.BuiltInCategory.OST_Doors)
                        br = new SolidBrush(Color.FromArgb(80, 255, 0, 0));
                    else
                        br = new SolidBrush(Color.FromArgb(120, 255, 255, 0));

                    dc.FillEllipse(br, (float)loc.Point.X * zoomRatio  - radius / 2,
                        (float)loc.Point.Y * -zoomRatio - radius / 2, radius, radius);

                    dc.DrawString(dr.Name, drawFont, new SolidBrush(Color.FromArgb(120, 0, 0, 0)),
                        (float)loc.Point.X * zoomRatio , (float)loc.Point.Y * -zoomRatio, sfc);
                }
            }

            Pen cameraPen = new Pen(Color.Blue);
            cameraPen.Width = 2;
            Pen dirPen = new Pen(Color.DarkGreen);
            dirPen.Width = 2;

            foreach (var c in cameras)
            {
                var cam = c.Value;
                int cx = (int)(cam.cameraCenter.X * zoomRatio), cy = (int)(cam.cameraCenter.Y * -zoomRatio);
                dc.DrawEllipse(cameraPen, new Rectangle(cx - 5, cy - 5, 10, 10));

                List<Point> cbp = new List<Point>();
                foreach (PointF pf in cam.clippedBoundaryPoints)
                {
                    cbp.Add(new Point((int)(pf.X * zoomRatio), (int)(pf.Y * -zoomRatio)));
                }
                cbp.Add(new Point(cx, cy));

                dc.DrawPolygon(dirPen, cbp.ToArray());

                Brush brush = new SolidBrush(Color.FromArgb(120, 0, 255, 0));
                Brush brush2 = new SolidBrush(Color.FromArgb(120, 0, 128, 255));

                dc.FillPolygon(brush, cbp.ToArray());
                //dc.FillPolygon(brush2, new Point[] { new Point(cx, cy), cam.rightNear, cam.leftNear, new Point(cx, cy) });

                string _name = cam.camera.ParametersMap.get_Item("camera_name").AsString();
                if (_name != null)
                {
                    SizeF stringSize = e.Graphics.MeasureString(_name, drawFont);

                    dc.DrawRectangle(Pens.Black, cx + 10, cy - stringSize.Height / 2, stringSize.Width, stringSize.Height);

                    if (cam.camera.Id.ToString() == curCamera)
                    {
                        dc.FillRectangle(Brushes.Black, cx + 10, cy - stringSize.Height / 2, stringSize.Width, stringSize.Height);
                        dc.DrawString(_name, drawFont, Brushes.White, cx + 10, cy, sf);
                    }
                    else
                    {
                        dc.FillRectangle(Brushes.LightBlue, cx + 10, cy - stringSize.Height / 2, stringSize.Width, stringSize.Height);
                        dc.DrawString(_name, drawFont, Brushes.Black, cx + 10, cy, sf);
                    }


                }

                g.DrawImage(b, 0, 0);
            }

            drawFont.Dispose();
            dc.Dispose();
        }

        private double calcRoomCoverage(CCTVRoom r)
        {
            double ret = 0.0;
            var output = new List<List<IntPoint>>();
            Clipper c = new Clipper();
            int factor = 1000000;

            foreach (var _cam in cameras)
            {
                var cam = _cam.Value;
                if (cam.room.Id.Equals(r.room.Id))
                {
                    var paths = new List<List<IntPoint>>();
                    var path = new List<IntPoint>();

                    path.Add(new IntPoint(cam.center.X * factor, cam.center.Y * factor));
                    path.AddRange((from i in cam.clippedBoundaryPoints select new IntPoint(i.X * factor, i.Y * factor)).Reverse());
                    
                    paths.Add(path);

                    c.AddPaths(paths, PolyType.ptSubject, true);
                }
            }

            c.Execute(ClipType.ctUnion, output, PolyFillType.pftNonZero, PolyFillType.pftNonZero);

            foreach(var op in output)
                ret += Area.calc((from i in op select new PointF(i.X / factor, i.Y / factor)).ToArray());

            return ret;
        }

        private void picRooms_MouseDown(object sender, MouseEventArgs e)
        {
            panning = true;
            startingPoint = new Point(e.Location.X - movingPoint.X,
                                        e.Location.Y - movingPoint.Y);
            
        }

        private void picRooms_MouseUp(object sender, MouseEventArgs e)
        {
            panning = false;
        }

        private void picRooms_MouseMove(object sender, MouseEventArgs e)
        {
            if (panning)
            {
                movingPoint = new Point(e.Location.X - startingPoint.X,
                                        e.Location.Y - startingPoint.Y);
                picRooms.Invalidate();
            }
        }

        private void picRooms_MouseWheel(object sender, MouseEventArgs e)
        {
            if (curMode == 0)
            {
                if (e.Delta > 0)
                {
                    rooms[curRoom].zoomRatioX *= 1.2f;
                    rooms[curRoom].zoomRatioY *= 1.2f;
                }
                else
                {
                    rooms[curRoom].zoomRatioX /= 1.2f;
                    rooms[curRoom].zoomRatioY /= 1.2f;
                }
                rooms[curRoom].updatePoints();
            }
            else if(curMode == 1)
            {
                if (e.Delta > 0)
                {
                    zoomRatio *= 1.2f;
                }
                else
                {
                    zoomRatio /= 1.2f;
                }
            }

            if (e.Delta > 0)
            {
                movingPoint.X = (int)(movingPoint.X * 1.2);
                movingPoint.Y = (int)(movingPoint.Y * 1.2);
            }
            else
            {
                movingPoint.X = (int)(movingPoint.X / 1.2);
                movingPoint.Y = (int)(movingPoint.Y / 1.2);
            }

            picRooms.Invalidate();
        }

        private void picRooms_Paint(object sender, PaintEventArgs e)
        {
            if (curRoom != "0" && curMode == 0)
                refreshRoom(rooms[curRoom], e);
            else if (curMode == 1)
                refreshAll(e);

            this.Invalidate();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            foreach(var room in rooms)
            {
                ListViewItem lvt = new ListViewItem(room.Key);
                lvt.SubItems.Add(room.Value.room.Name);
                lvt.SubItems.Add(room.Value.room.Level.Elevation.ToString());

                double area = room.Value.room.Area;
                lvt.SubItems.Add(area.ToString("0.000"));
                lvt.SubItems.Add((calcRoomCoverage(room.Value) / area * 100).ToString("0") + "%");
                lvRooms.Items.Add(lvt);
            }

            foreach (var cam in cameras)
            {
                ListViewItem lvt = new ListViewItem(cam.Key);
                string _name = cam.Value.camera.ParametersMap.get_Item("camera_name").AsString();

                lvt.SubItems.Add(_name);
                lvt.SubItems.Add(rooms[cam.Value.room.Id.ToString()].room.Name);
                lvt.SubItems.Add((cam.Value.hAngle / Math.PI * 180).ToString("0") + "x" + (cam.Value.vAngle / Math.PI * 180).ToString("0"));
                lvt.SubItems.Add(CCTVCamera.GetElementCenter(cam.Value.camera).Z.ToString());

                var t = cam.Value.clippedBoundaryPoints;
                t.Add(new PointF(cam.Value.center.X, cam.Value.center.Y));
                lvt.SubItems.Add(Area.calc(t.ToArray()).ToString());
                lvCameras.Items.Add(lvt);
                
            }
        }

        private void listRooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            //curRoom = listRooms.GetItemText(listRooms.SelectedItem);
            movingPoint = Point.Empty;
            this.Invalidate();
        }

        private void picRooms_Click(object sender, EventArgs e)
        {

        }

        private void lvRooms_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvRooms_DoubleClick(object sender, EventArgs e)
        {
            curRoom = (lvRooms.SelectedItems[0].Text);

            if (checkBox2.Checked) movingPoint = Point.Empty;
            picRooms.Invalidate();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void lvCameras_DoubleClick(object sender, EventArgs e)
        {
            string cid = (lvCameras.SelectedItems[0].Text);
            curRoom = cameras[cid].room.Id.ToString();

            tbPan.Value = (int)(cameras[cid].cameraPan / Math.PI * 180);
            tbTilt.Value = (int)(cameras[cid].cameraTilt / Math.PI * 180);
            curCamera = cid;

            if(checkBox2.Checked) movingPoint = Point.Empty;
            picRooms.Invalidate();
        }

        private void tbPan_Scroll(object sender, EventArgs e)
        {
            if (!cameras.ContainsKey(curCamera)) return;

            double new_v = tbPan.Value * Math.PI / 180;

            cameras[curCamera].cameraPan = new_v;
            cameras[curCamera].updateCamera();
            picRooms.Invalidate();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string cid = (lvCameras.SelectedItems[0].Text);
            frmEdit frm = new frmEdit();

            frm.setCamera(cameras[cid].camera.Id,
                cameras[cid].camera.ParametersMap.get_Item("camera_name").AsString(),
                cameras[cid].cameraPan / Math.PI * 180,
                cameras[cid].cameraTilt / Math.PI * 180,
                cameras[cid].camera.ParametersMap.get_Item("sensor_width").AsDouble(),
                cameras[cid].camera.ParametersMap.get_Item("sensor_height").AsDouble(),
                cameras[cid].camera.ParametersMap.get_Item("focal_length").AsDouble());

            frm.Show();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            curMode = Math.Abs(curMode - 1);
            movingPoint = Point.Empty;

            picRooms.Invalidate();
        }

        private void tbTilt_Scroll(object sender, EventArgs e)
        {
            if (!cameras.ContainsKey(curCamera)) return;

            double new_v = tbTilt.Value * Math.PI / 180;

            cameras[curCamera].cameraTilt = new_v;
            cameras[curCamera].updateCamera();
            picRooms.Invalidate();
        }

        private void tbTilt_ValueChanged(object sender, EventArgs e)
        {
        }

        private void tbTilt_MouseUp(object sender, MouseEventArgs e)
        {
            if (!cameras.ContainsKey(curCamera)) return;

            Autodesk.Revit.DB.Transaction trans = new Autodesk.Revit.DB.Transaction(document);
            trans.Start("Update camera tilt value");
            cameras[curCamera].camera.ParametersMap.get_Item("tilt").Set(tbTilt.Value * Math.PI / 180);
            trans.Commit();

            updateCoverage();
        }

        private void tbPan_MouseDown(object sender, MouseEventArgs e)
        {
            if (!cameras.ContainsKey(curCamera)) return;

            tmpOldPan = cameras[curCamera].cameraPan;
        }

        private void tbPan_MouseUp(object sender, MouseEventArgs e)
        {
            if (!cameras.ContainsKey(curCamera)) return;

            double new_v = tbPan.Value * Math.PI / 180;
            double d_angle = new_v - tmpOldPan;

            Autodesk.Revit.DB.Transaction trans = new Autodesk.Revit.DB.Transaction(document);
            trans.Start("Update camera pan value");

            Autodesk.Revit.DB.LocationPoint loc = cameras[curCamera].camera.Location as Autodesk.Revit.DB.LocationPoint;
            Autodesk.Revit.DB.XYZ point1 = new Autodesk.Revit.DB.XYZ(loc.Point.X, loc.Point.Y, loc.Point.Z);
            Autodesk.Revit.DB.XYZ point2 = new Autodesk.Revit.DB.XYZ(loc.Point.X, loc.Point.Y, loc.Point.Z + 1);
            Autodesk.Revit.DB.Line axis = Autodesk.Revit.DB.Line.CreateBound(point1, point2);
            Autodesk.Revit.DB.ElementTransformUtils.RotateElement(document, cameras[curCamera].camera.Id, axis, -d_angle);

            trans.Commit();

            updateCoverage();
        }

        private void updateCoverage()
        {
            var t = cameras[curCamera].clippedBoundaryPoints;
            t.Add(new PointF(cameras[curCamera].center.X, cameras[curCamera].center.Y));
            lvCameras.FindItemWithText(curCamera).SubItems[5].Text = Area.calc(t.ToArray()).ToString();

            string roomID = cameras[curCamera].room.Id.ToString();
            lvRooms.FindItemWithText(roomID).SubItems[4].Text =
                (calcRoomCoverage(rooms[roomID]) / rooms[roomID].room.Area * 100).ToString("0") + "%";
        }

        private void lvCameras_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvRooms_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void tbPan_Scroll_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }

    public class CCTVCamera
    {
        public Autodesk.Revit.DB.XYZ cameraCenter;
        public PointF center;

        public double cameraTilt;
        public double cameraPan;

        public double vAngle;
        public double hAngle;
        public double nearDistance;
        public double farDistance;

        public PointF rightNear;
        public PointF rightFar;
        public PointF leftNear;
        public PointF leftFar;

        public double baseAngle;

        //public int zoomRatioX;
        //public int zoomRatioY;
        //public float initShift;

        //public IList<Autodesk.Revit.DB.BoundarySegment> ibs;
        public List<List<PointF>> boundaryPoints;
        public List<PointF> clippedBoundaryPointsNear;
        public List<PointF> clippedBoundaryPoints;

        private Autodesk.Revit.DB.Architecture.Room _room;
        public Autodesk.Revit.DB.Architecture.Room room
        {
            get
            {
                return _room;
            }
            set
            {
                _room = value;
                //ibs = _room.GetBoundarySegments(new Autodesk.Revit.DB.SpatialElementBoundaryOptions()).First();

                boundaryPoints = new List<List<PointF>>();

                foreach (var _ibs in _room.GetBoundarySegments(new Autodesk.Revit.DB.SpatialElementBoundaryOptions()))
                {
                    foreach (Autodesk.Revit.DB.BoundarySegment bs in _ibs)
                    {
                        List<PointF> lpf = new List<PointF>();

                        foreach (Autodesk.Revit.DB.XYZ xyz in bs.GetCurve().Tessellate())
                        {
                            lpf.Add(new PointF((float)(xyz.X), (float)(xyz.Y)));
                        }
                        boundaryPoints.Add(lpf);
                    }
                }
            }
        }

        private Autodesk.Revit.DB.Element _camera;
        public Autodesk.Revit.DB.Element camera
        {
            get
            {
                return _camera;
            }
            set
            {
                _camera = value;
                cameraCenter = GetElementCenter(_camera);
                center = new PointF();
                center.X = (float)cameraCenter.X;
                center.Y = (float)cameraCenter.Y;

                Autodesk.Revit.DB.FamilyInstance tmp = _camera as Autodesk.Revit.DB.FamilyInstance;

                cameraPan = tmp.GetTransform().BasisX.AngleOnPlaneTo(
                    new Autodesk.Revit.DB.XYZ(1, 0, 0),
                    tmp.GetTransform().BasisZ) + Math.PI / 2;

                cameraTilt = _camera.ParametersMap.get_Item("tilt").AsDouble();

                updateCamera();
            }
        }

        public void updateCamera()
        {
            vAngle = Math.Atan(_camera.ParametersMap.get_Item("sensor_height").AsDouble() / _camera.ParametersMap.get_Item("focal_length").AsDouble() / 2);
            hAngle = Math.Atan(_camera.ParametersMap.get_Item("sensor_width").AsDouble() / _camera.ParametersMap.get_Item("focal_length").AsDouble() / 2);

            nearDistance = cameraCenter.Z / Math.Tan(vAngle + cameraTilt);
            farDistance = cameraCenter.Z / Math.Tan(cameraTilt - vAngle);

            rightNear = new PointF((float)(Math.Cos(cameraPan - hAngle) * nearDistance) + center.X,
                (float)(Math.Sin(cameraPan - hAngle) * nearDistance) + center.Y);

            leftNear = new PointF((float)(Math.Cos(cameraPan + hAngle) * nearDistance) + center.X,
                (float)(Math.Sin(cameraPan + hAngle) * nearDistance) + center.Y);
            
            clippedBoundaryPoints = new List<PointF>();

            int hAngleDegree = (int)(hAngle / Math.PI * 180);
            baseAngle = Math.PI * 2 - cameraPan;

            for (double i = -hAngleDegree; i <= hAngleDegree; i += 0.5)
            {
                double aa = baseAngle + i * Math.PI / 180;
                double nd = nearDistance / Math.Cos(Math.Abs(i) * Math.PI / 180);
                double fd = farDistance / Math.Cos(Math.Abs(i) * Math.PI / 180);

                PointF near = new PointF((float)(cameraCenter.X + nd * Math.Cos(aa)), (float)(cameraCenter.Y + nd * Math.Sin(aa)));
                PointF far = new PointF((float)(cameraCenter.X + fd * Math.Cos(aa)), (float)(cameraCenter.Y + fd * Math.Sin(aa)));

                double minDistance = -1;

                foreach (var bp in boundaryPoints)
                    for (int ib = 0; ib < bp.Count - 1; ib++)
                    {
                        PointF l2Start = bp[ib];
                        PointF l2End = bp[ib + 1];
                        double? d = lineIntersectionInfinity(center, new PointF((float)Math.Cos(aa), (float)Math.Sin(aa)), l2Start, l2End);

                        if (d != null)
                        {
                            if (minDistance == -1 || d < minDistance)
                                minDistance = (double)d;
                        }
                    }

                if (minDistance < fd)
                {
                    clippedBoundaryPoints.Add(new PointF(
                        (float)(cameraCenter.X + minDistance * Math.Cos(aa)),
                        (float)(cameraCenter.Y + minDistance * Math.Sin(aa)))
                        );
                }
                else
                {
                    clippedBoundaryPoints.Add(far);
                }
            }

        }

        public static Autodesk.Revit.DB.XYZ GetElementCenter(Autodesk.Revit.DB.Element elem)
        {
            Autodesk.Revit.DB.BoundingBoxXYZ bounding = elem.get_BoundingBox(null);
            Autodesk.Revit.DB.XYZ center; //= (bounding.Max + bounding.Min) * 0.5;
            center = new Autodesk.Revit.DB.XYZ(
                (bounding.Max.X + bounding.Min.X) * 0.5,
                (bounding.Max.Y + bounding.Min.Y) * 0.5,
                bounding.Max.Z < bounding.Min.Z ? bounding.Max.Z : bounding.Min.Z);
            return center;
        }

        public static PointF lineIntersection(PointF line1Start, PointF line1End, PointF line2Start, PointF line2End)
        {
            float s1_x, s1_y, s2_x, s2_y;
            float p0_x = line1Start.X;
            float p0_y = line1Start.Y;
            float p1_x = line1End.X;
            float p1_y = line1End.Y;
            float p2_x = line2Start.X;
            float p2_y = line2Start.Y;
            float p3_x = line2End.X;
            float p3_y = line2End.Y;

            s1_x = p1_x - p0_x; s1_y = p1_y - p0_y;
            s2_x = p3_x - p2_x; s2_y = p3_y - p2_y;

            float s, t;
            s = (-s1_y * (p0_x - p2_x) + s1_x * (p0_y - p2_y)) / (-s2_x * s1_y + s1_x * s2_y);
            t = (s2_x * (p0_y - p2_y) - s2_y * (p0_x - p2_x)) / (-s2_x * s1_y + s1_x * s2_y);

            if (s >= 0 && s <= 1 && t >= 0 && t <= 1)
            {
                return new PointF(p0_x + (t * s1_x), p0_y + (t * s1_y));
            }

            return PointF.Empty;
        }

        public static double? lineIntersectionInfinity(PointF rayOrigin, PointF rayDirection, PointF point1, PointF point2)
        {
            var v1 = new System.Windows.Vector(rayOrigin.X - point1.X, rayOrigin.Y - point1.Y);
            var v2 = new System.Windows.Vector(point2.X - point1.X, point2.Y - point1.Y);
            var v3 = new System.Windows.Vector(-rayDirection.Y, rayDirection.X);

            var t1 = System.Windows.Vector.CrossProduct(v2, v1) / (v2 * v3);
            var t2 = (v1 * v3) / (v2 * v3);

            if (t1 >= 0.0 && (t2 >= 0.0 && t2 <= 1.0))
                return t1;

            return null;
        }

    }

    public class CCTVRoom
    {
        public float zoomRatioX;
        public float zoomRatioY;
        public double Width;
        public double Height;
        public float initShift;

        public bool validRoom;
        public List<List<PointF>> boundaryPoints;
        public List<Point[]> drawablePoints;

        public List<Autodesk.Revit.DB.Element> doors;
        public List<Autodesk.Revit.DB.Element> windows;

        private Autodesk.Revit.DB.Architecture.Room _room;
        public Autodesk.Revit.DB.Architecture.Room room
        {
            get
            {
                return _room;
            }
            set
            {
                _room = value;
                //ibs = _room.GetBoundarySegments(new Autodesk.Revit.DB.SpatialElementBoundaryOptions()).First();

                Autodesk.Revit.DB.BoundingBoxXYZ b = _room.get_BoundingBox(null);
                validRoom = true;
                if(b == null)
                {
                    validRoom = false;
                    return;
                }

                double dy = b.Max.Y - b.Min.Y;
                double dx = b.Max.X - b.Min.X;
                double dw = dy > dx ? dy : dx;

                Width = dx;
                Height = dy;

                zoomRatioX = (int)(500 / dw / 1.5);
                zoomRatioY = -zoomRatioX;
                initShift = (float)(dw / 2 * zoomRatioX * 1.5);

                updatePoints();
            }
        }

        public void updatePoints()
        {
            boundaryPoints = new List<List<PointF>>();
            drawablePoints = new List<Point[]>();
            doors = new List<Autodesk.Revit.DB.Element>();

            foreach (var _ibs in _room.GetBoundarySegments(new Autodesk.Revit.DB.SpatialElementBoundaryOptions()))
            {
                foreach (Autodesk.Revit.DB.BoundarySegment bs in _ibs)
                {
                    List<Point> lp = new List<Point>();
                    List<PointF> lpf = new List<PointF>();

                    foreach (Autodesk.Revit.DB.XYZ xyz in bs.GetCurve().Tessellate())
                    {
                        lp.Add(new Point((int)(xyz.X * this.zoomRatioX), (int)(xyz.Y * this.zoomRatioY)));
                        lpf.Add(new PointF((float)(xyz.X), (float)(xyz.Y)));
                    }

                    var _wall = frmMain.document.GetElement(bs.ElementId);
                    if (_wall is Autodesk.Revit.DB.Wall)
                    {
                        string wall = _wall.Id.ToString();
                        if (frmMain.idCouple.ContainsKey(wall))
                        {
                            doors.AddRange(from i in frmMain.idCouple[wall] select frmMain.document.GetElement(i));
                        }
                    }

                    drawablePoints.Add(lp.ToArray());
                    boundaryPoints.Add(lpf);
                }
            }
        }
    }
}
