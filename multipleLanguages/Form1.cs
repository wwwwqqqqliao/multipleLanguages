using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace multipleLanguages
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void SetLanguage()
        {
            foreach (Form f in Application.OpenForms)
            {
                //这里"中英文界面"要命名空间

                ResourceManager rs = new ResourceManager("multipleLanguages." + f.Name, this.GetType().Assembly);

                foreach (Control c in f.Controls)
                {
                    c.Text = rs.GetString(c.Name + ".Text");
                }
                f.Text = rs.GetString("$this.Text");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("zh");
            SetLanguage();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
            SetLanguage();
        }
    }
}
