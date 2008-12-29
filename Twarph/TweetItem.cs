using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Twarph
{
    public partial class TweetItem : UserControl
    {
        Tweet tweet;

        public Tweet Tweet
        {
            get { return (this.tweet); }
        }

        public TweetItem(Tweet t)
        {
            InitializeComponent();
            this.tweet = t;
            this.UpdateData();
        }

        public void UpdateData()
        {
            this.lblUser.Text = this.Tweet.Nick;
            this.lblText.Text = this.Tweet.Text.Replace("&", "&&");
        }
    }
}
