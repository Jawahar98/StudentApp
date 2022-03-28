using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentApp
{
    public partial class UserControl1 : UserControl
    {
        
        public UserControl1(int QsnNumber)
        {
            InitializeComponent();
            label1.Text = QsnNumber.ToString();
        }
        public bool iscurrentQsnBookmark
        {
            get
            {
                return (pictureBox1.Visible);
            }
            set
            {
                pictureBox1.Visible = value;
            }
        }

       
    }
}
