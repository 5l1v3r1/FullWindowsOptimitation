using FullWindowsOptimitation_FWO.Form_Features;
using FullWindowsOptimitation_FWO.Libs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FullWindowsOptimitation_FWO {
    public partial class Form_Main: Form {
        public Form_Main() {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e) {
    
        }

        private void button6_Click(object sender, EventArgs e) {
            ModeOptimitationSEPH OptimitationSEPH = new ModeOptimitationSEPH();
            OptimitationSEPH.Show();


        }
    }
}
