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
    public partial class frmInput : Form
    {
        public string input;

        public void askInput(string _title, string _default)
        {
            lblTitle.Text = _title;
            txtName.Text = _default;
        }

        public frmInput()
        {
            InitializeComponent();
        }

        private void frmEdit_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            input = txtName.Text;
            this.Close();
        }
    }
}
