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
    public partial class UserControl2 : UserControl
    {
        public UserControl2(int Snumber)
        {
            InitializeComponent();
            label1.Text = "Section"+ Snumber;
        }

        public bool issectionchanged
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
