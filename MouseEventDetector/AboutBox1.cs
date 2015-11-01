using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseEventDetector
{
    //Standard AboutBox form of VS2015 
    partial class AboutBox1 : Form
    {
        public AboutBox1()
        {
            InitializeComponent();
            
            
            this.Text = String.Format("About {0}", AssemblyTitle);
            this.labelProductName.Text = AssemblyProduct;
            this.labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
            this.labelCopyright.Text = AssemblyCopyright;
            this.labelCompanyName.Text = AssemblyCompany;
            //Customized part
            this.textBoxDescription.DetectUrls = true;
            this.textBoxDescription.AppendText(":" + Environment.NewLine + Environment.NewLine);
            this.textBoxDescription.AppendText("Test project to see mouse events" + Environment.NewLine);
            this.textBoxDescription.AppendText("See:" + Environment.NewLine);
            this.textBoxDescription.AppendText("http://answers.microsoft.com/de-de/windows/forum/windows_10-hardware/problem-windows-10-with-logitech-usb-mouse-with/c0d1e06c-7d4c-4351-96c6-196ababd014d?tm=1446333047742" + Environment.NewLine);
            this.textBoxDescription.AppendText("and" + Environment.NewLine);
            this.textBoxDescription.AppendText("http://www.deskmodder.de/phpBB3/viewtopic.php?f=204&t=16480" + Environment.NewLine);
            this.textBoxDescription.AppendText("" + Environment.NewLine + Environment.NewLine);
            this.textBoxDescription.AppendText("Distributed under MIT License");

            this.textBoxDescription.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler (this.textBoxDescription_LinkClicked);
        }


        //Link in descriptionBox was klicked -> open URL in Brwoswe
        private void textBoxDescription_LinkClicked(object sender, System.Windows.Forms.LinkClickedEventArgs e)
        {
          System.Diagnostics.Process.Start(e.LinkText);
        }


        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
