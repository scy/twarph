using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Twarph.Actions;

namespace Twarph
{
    public partial class frmMain : Form
    {
        UserAccount account;

        public frmMain()
        {
            InitializeComponent();
            Settings s = Settings.GetInstance();
            account = new UserAccount(s.User, s.Pass);
            DisplayManager.Container = this.pnlTweets;
            this.InitQueue();
        }

        void InitQueue()
        {
            BackgroundLoop.Add(new Search("Scytale OR 25C3 OR Mannheim -steamroller"));
            BackgroundLoop.Fork();
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            this.account.Post(txtPost.Text);
            this.txtPost.Text = string.Empty;
        }

        private void pnlTweets_GotFocus(object sender, EventArgs e)
        {
            DisplayManager.UpdateContainer();
        }

        private void mitOptions_Click(object sender, EventArgs e)
        {
            new frmOptions().ShowDialog();
            Settings s = Settings.GetInstance();
            this.account.Quit();
            this.account = new UserAccount(s.User, s.Pass);
        }
    }
}