using System;

using System.Collections.Generic;
using System.Text;

namespace Twarph
{
    public class Tweet
    {
        int id;
        string nick;
        string text;

        public int ID
        {
            get { return (this.id); }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Tweet ID may not be less than zero.");
                this.id = value;
            }
        }

        public string Nick
        {
            get { return (string.Copy(this.nick)); }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Nick");
                this.nick = value;
            }
        }

        public string Text
        {
            get { return (string.Copy(this.text)); }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Text");
                this.text = value;
            }
        }
    }
}
