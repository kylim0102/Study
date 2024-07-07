using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test12.ucPanel
{
    public partial class ucScreen2 : UserControl
    {
        public event delLogSender eLogSender;

        public ucScreen2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            eLogSender("Screen2 Button", enLogLevel.Info, "Button Click");
        }
    }
}
