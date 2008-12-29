using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace Twarph
{
    public class Settings
    {
        protected RegistryKey twarph = null;
        protected static Settings instance = null;

        protected bool ignoreQuit;

        protected string user;
        protected string pass;

        public static Settings GetInstance()
        {
            if (instance == null)
                instance = new Settings();
            return (instance);
        }

        protected Settings()
        {
            this.twarph = Registry.CurrentUser.CreateSubKey("Software\\scytale.name\\Twarph");
            this.Read();
        }

        public RegistryKey RegKey
        {
            get { return (this.twarph); }
        }

        public void Read()
        {
            this.user = this.GetString("User", "");
            this.pass = this.GetString("Pass", "");
        }

        public void Write()
        {
            this.SetString("User", this.user);
            this.SetString("Pass", this.pass);
        }

        protected bool GetBool(string name, bool def)
        {
            try
            {
                byte[] bytes = (byte[])twarph.GetValue(name, new byte[] { ((def) ? ((byte)1) : ((byte)0)) });
                return (bytes[0] != 0);
            }
            catch (Exception)
            {
                return (def);
            }
        }

        protected byte GetEnum(string name, byte def)
        {
            try
            {
                byte[] bytes = (byte[])twarph.GetValue(name, new byte[] { def });
                return (bytes[0]);
            }
            catch (Exception)
            {
                return (def);
            }
        }

        protected string GetString(string name, string def)
        {
            try
            {
                string res = (string)twarph.GetValue(name, def);
                return (res);
            }
            catch (Exception)
            {
                return (def);
            }
        }

        protected void SetBool(string name, bool val)
        {
            byte[] bytes = new byte[] { ((val) ? ((byte)1) : ((byte)0)) };
            twarph.SetValue(name, bytes, RegistryValueKind.Binary);
        }

        protected void SetEnum(string name, byte val)
        {
            byte[] bytes = new byte[] { val };
            twarph.SetValue(name, bytes, RegistryValueKind.Binary);
        }

        protected void SetString(string name, string val)
        {
            twarph.SetValue(name, val, RegistryValueKind.String);
        }

        public string User
        {
            get { return ((string)this.user.Clone()); }
            set { this.user = (string)value.Clone(); }
        }

        public string Pass
        {
            get { return ((string)this.pass.Clone()); }
            set { this.pass = (string)value.Clone(); }
        }

    }
}
