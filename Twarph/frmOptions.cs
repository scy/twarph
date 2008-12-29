using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Twarph
{
    public partial class frmOptions : Form
    {
        public frmOptions()
        {
            InitializeComponent();
            Settings s = Settings.GetInstance();
            s.Read();
            txtUser.Text = s.User;
            txtPass.Text = s.Pass;
        }

        private void mitOK_Click(object sender, EventArgs e)
        {
            Settings s = Settings.GetInstance();
            s.User = txtUser.Text;
            s.Pass = txtPass.Text;
            s.Write();
            this.Close();
        }
    }
}