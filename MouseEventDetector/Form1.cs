using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseEventDetector
{

    //Simple Form that has a panel in which mose movements and events are detected.
    //These events are shown in a TextBox and in CheckBoxes
    //Icons used is CC and from http://www.iconarchive.com/show/farm-fresh-icons-by-fatcow/mouse-2-icon.html
    //Limitations:
    //- wheelUp & Down are not cleard
    // - Standard .Net / c# posibilties used, no Hardware direct access. For that not all Buttons are detected. Depending on configuratio n withuin windows
    // - Quick Hack - for personal use - to detect mouse problem

    public partial class Form1 : Form
    {
        int mouseX = 0;
        int mouseY = 0;
        public Form1()
        {
            InitializeComponent();

            richTextBox1.VisibleChanged += (sender, e) =>
            {
                if (richTextBox1.Visible)
                {
                    richTextBox1.SelectionStart = richTextBox1.Text.Length;
                    richTextBox1.ScrollToCaret();
                }
            };

            richTextBox1.BulletIndent = 10;
            checkBox6.Enabled = false;
            checkBox9.Enabled = false;
            checkBox10.Enabled = false;
            button1.Text = "Exit";
            button2.Text = "About";
            this.Text="MED" + String.Format(" V{0}", Assembly.GetExecutingAssembly().GetName().Version.ToString());

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            MouseEvent(e, "Down");
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            richTextBox1.SelectionBullet = true;
            richTextBox1.SelectionColor = Color.DarkBlue;
            richTextBox1.SelectedText=DateTime.Now.ToString("hh:mm:ss.fff ", System.Globalization.DateTimeFormatInfo.InvariantInfo) + "Event: Entered TestBox" + Environment.NewLine;
            richTextBox1.SelectionBullet = false;
            //richTextBox1.AppendText(DateTime.Now.ToString("hh:mm:ss.fff ", System.Globalization.DateTimeFormatInfo.InvariantInfo) + "Event: Entered TestBox" + Environment.NewLine);
            richTextBox1.ScrollToCaret();

        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            richTextBox1.SelectionBullet = true;
            richTextBox1.SelectionColor = Color.Orange;
            richTextBox1.SelectedText = DateTime.Now.ToString("hh:mm:ss.fff ", System.Globalization.DateTimeFormatInfo.InvariantInfo) + "Event: " + sender.GetType().ToString() + "- MouseHover" + Environment.NewLine;
            richTextBox1.SelectionBullet = false;
            //MouseEvent(e);
            richTextBox1.ScrollToCaret();
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            
            richTextBox1.SelectionBullet = true;
            richTextBox1.SelectionColor = Color.DarkBlue;
            richTextBox1.SelectedText = DateTime.Now.ToString("hh:mm:ss.fff ", System.Globalization.DateTimeFormatInfo.InvariantInfo) + "Event: Left TestBox" + Environment.NewLine;
            richTextBox1.SelectionBullet = false;
            
            richTextBox1.ScrollToCaret();

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;
            label3.Text = mouseX.ToString();
            label4.Text = mouseY.ToString();
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            MouseEvent(e, "UP");
        }

        //Point mouseDownLocation = new Point(e.X, e.Y);
        private void MouseEvent(MouseEventArgs e, String mType)
        {

            switch (e.Button)
            {
                case MouseButtons.Left:
                    checkBox1.Checked = mType.Equals("UP")?false:true;
                    //eventString = "L";
                    break;
                case MouseButtons.Right:
                    checkBox3.Checked = mType.Equals("UP") ? false : true;
                //checkBox1.Checked = true;
                //eventString = "R";
                break;
                case MouseButtons.Middle:
                    checkBox2.Checked = mType.Equals("UP") ? false : true;
                    //eventString = "M";
                break;
                case MouseButtons.XButton1:
                    checkBox4.Checked = mType.Equals("UP") ? false : true;
                //eventString = "X1";
                break;
                case MouseButtons.XButton2:
                    //eventString = "X2";
                    checkBox5.Checked = mType.Equals("UP") ? false : true;
                    break;
                case MouseButtons.None:
                default:
                   
                    break;
                    
            }
            richTextBox1.SelectionBullet = true;
            richTextBox1.SelectionColor = Color.Red;
            richTextBox1.SelectedText = DateTime.Now.ToString("hh:mm:ss.fff ", System.Globalization.DateTimeFormatInfo.InvariantInfo) + "Event: " + e.Button.ToString() + " " + mType + Environment.NewLine;
            richTextBox1.SelectionBullet = false;
            richTextBox1.ScrollToCaret();
        }

        private void panel1_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            richTextBox1.SelectionBullet = true;
            richTextBox1.SelectionColor = Color.Green;
            richTextBox1.SelectedText = DateTime.Now.ToString("hh:mm:ss.fff ", System.Globalization.DateTimeFormatInfo.InvariantInfo) + "Event: MouseWheel " + ((e.Delta / 120) > 0 ? "UP" : "DOWN") + Environment.NewLine;
            richTextBox1.SelectionBullet = false;
            richTextBox1.ScrollToCaret();
            checkBox8.Checked = (e.Delta / 120) > 0 ? true : false;
            checkBox7.Checked = (e.Delta / 120) < 0 ? true : false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AboutBox1 frm = new AboutBox1();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog(this);

        }
    }
}
