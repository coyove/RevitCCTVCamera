using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CameraPlugin
{
    public partial class frmEdit : Form
    {
        public Autodesk.Revit.DB.ElementId cid;
        public double oldPan;
        public frmMain main;

        public void setCamera(Autodesk.Revit.DB.ElementId id, string name, double pan, double tilt, double w, double h, double fl)
        {
            cid = id;

            tbPan.Value = (int)pan;
            oldPan = pan;

            tbTilt.Value = (int)tilt;
            txtName.Text = name;
            txtWidth.Text = w.ToString("0.00");
            txtHeight.Text = h.ToString("0.00");
            txtFocal.Text = fl.ToString("0.0");
        }

        public frmEdit()
        {
            InitializeComponent();
        }

        private void frmEdit_Load(object sender, EventArgs e)
        {

        }
    }
}
