using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using System.Windows.Media.Imaging;
using System.Reflection;

namespace CameraPlugin
{
    public class Camera : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication application)
        {
            // Add a new ribbon panel
            RibbonPanel ribbonPanel = application.CreateRibbonPanel("CCTV Camera");

            // Create a push button to trigger a command add it to the ribbon panel.
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;
            PushButtonData buttonData = new PushButtonData("cmdCCTVCamera",
               "Inspector", thisAssemblyPath, "CameraPlugin._Camera");

            PushButton pushButton = ribbonPanel.AddItem(buttonData) as PushButton;
            
            pushButton.ToolTip = "List all cameras inside current document";

            Uri uriImage = new Uri(@"D:\trade\haha.jpg");
            BitmapImage largeImage = new BitmapImage(uriImage);
            pushButton.LargeImage = largeImage;

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            // nothing to clean up in this simple case
            return Result.Succeeded;
        }
    }

    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class _Camera : IExternalCommand
    {
        public Autodesk.Revit.UI.Result Execute(ExternalCommandData revit,
           ref string message, ElementSet elements)
        {
            UIApplication uiApplication = revit.Application;
            UIDocument uiDocument = revit.Application.ActiveUIDocument;
            Document doc = uiDocument.Document;

            List<Element> elems = new List<Element>();
            ElementClassFilter filter = new ElementClassFilter(typeof(FamilyInstance));

            // Apply the filter to the elements in the active document
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            collector.WherePasses(filter);
            
            var query = from element in collector
                        where element.Name == "camera"
                        select element;

            List<FamilyInstance> familyInstances = query.Cast<FamilyInstance>().ToList<FamilyInstance>();

            string ret = "";

            frmMain frm = new frmMain();
            frmMain.document = doc;

            FilteredElementCollector doors = new FilteredElementCollector(doc);
            FilteredElementCollector windows = new FilteredElementCollector(doc);
            doors.OfCategory(BuiltInCategory.OST_Doors);
            doors.UnionWith(windows.OfCategory(BuiltInCategory.OST_Windows));

            frmMain.idCouple = new Dictionary<string, List<ElementId>>();
            foreach (Element elem in doors)
            {
                var tmp = elem as FamilyInstance;
                if(tmp != null)
                {
                    string p = tmp.Host?.Id.ToString();

                    if (!frmMain.idCouple.ContainsKey(p))
                    {
                        frmMain.idCouple[p] = new List<ElementId>();
                    }

                    frmMain.idCouple[p].Add(tmp.Id);
                }
            }

            FilteredElementCollector rooms = new FilteredElementCollector(doc);
            rooms.OfCategory(BuiltInCategory.OST_Rooms);
            foreach (Element elem in rooms)
            {
                Room room = elem as Room;
                if (room != null)
                {
                    frm.addRoom(room);
                }
            }

            foreach (FamilyInstance e in familyInstances)
            {
                if (null != e.Category && e.Category.HasMaterialQuantities)
                {
                    XYZ center = GetElementCenter(e);

                    Room tmp = GetRoomOfGroup(doc, center);
                    if(tmp != null)
                    {
                        frm.addCamera(tmp, e);
                    }
                }
            }

            frm.ShowDialog();


            return Autodesk.Revit.UI.Result.Succeeded;
        }

        Room GetRoomOfGroup(Document doc, XYZ point)
        {
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            collector.OfCategory(BuiltInCategory.OST_Rooms);
            Room room = null;
            foreach (Element elem in collector)
            {
                room = elem as Room;
                if (room != null)
                {
                    // Decide if this point is in the picked room                  
                    if (room.IsPointInRoom(point))
                    {
                        break;
                    }
                }
            }
            return room;
        }

        public XYZ GetElementCenter(Element elem)
        {
            BoundingBoxXYZ bounding = elem.get_BoundingBox(null);
            XYZ center = (bounding.Max + bounding.Min) * 0.5;
            return center;
        }
    }
}