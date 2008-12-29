namespace Twarph
{
    partial class frmMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mmuMain;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.mmuMain = new System.Windows.Forms.MainMenu();
            this.mitPost = new System.Windows.Forms.MenuItem();
            this.mitMenu = new System.Windows.Forms.MenuItem();
            this.pnlTweets = new System.Windows.Forms.Panel();
            this.pnlPost = new System.Windows.Forms.Panel();
            this.btnPost = new System.Windows.Forms.Button();
            this.txtPost = new System.Windows.Forms.TextBox();
            this.mitOptions = new System.Windows.Forms.MenuItem();
            this.pnlPost.SuspendLayout();
            this.SuspendLayout();
            // 
            // mmuMain
            // 
            this.mmuMain.MenuItems.Add(this.mitPost);
            this.mmuMain.MenuItems.Add(this.mitMenu);
            // 
            // mitPost
            // 
            this.mitPost.Text = "Nothing happens";
            // 
            // mitMenu
            // 
            this.mitMenu.MenuItems.Add(this.mitOptions);
            this.mitMenu.Text = "Menu";
            // 
            // pnlTweets
            // 
            this.pnlTweets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTweets.Location = new System.Drawing.Point(0, 30);
            this.pnlTweets.Name = "pnlTweets";
            this.pnlTweets.Size = new System.Drawing.Size(240, 238);
            this.pnlTweets.GotFocus += new System.EventHandler(this.pnlTweets_GotFocus);
            // 
            // pnlPost
            // 
            this.pnlPost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPost.Controls.Add(this.btnPost);
            this.pnlPost.Controls.Add(this.txtPost);
            this.pnlPost.Location = new System.Drawing.Point(0, 0);
            this.pnlPost.Name = "pnlPost";
            this.pnlPost.Size = new System.Drawing.Size(240, 27);
            // 
            // btnPost
            // 
            this.btnPost.Location = new System.Drawing.Point(197, 3);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(40, 21);
            this.btnPost.TabIndex = 1;
            this.btnPost.Text = "OK";
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // txtPost
            // 
            this.txtPost.Location = new System.Drawing.Point(3, 3);
            this.txtPost.Name = "txtPost";
            this.txtPost.Size = new System.Drawing.Size(188, 21);
            this.txtPost.TabIndex = 0;
            // 
            // mitOptions
            // 
            this.mitOptions.Text = "Options";
            this.mitOptions.Click += new System.EventHandler(this.mitOptions_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.pnlPost);
            this.Controls.Add(this.pnlTweets);
            this.Menu = this.mmuMain;
            this.Name = "frmMain";
            this.Text = "Twarph";
            this.pnlPost.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTweets;
        private System.Windows.Forms.Panel pnlPost;
        private System.Windows.Forms.Button btnPost;
        private System.Windows.Forms.TextBox txtPost;
        private System.Windows.Forms.MenuItem mitPost;
        private System.Windows.Forms.MenuItem mitMenu;
        private System.Windows.Forms.MenuItem mitOptions;

    }
}

