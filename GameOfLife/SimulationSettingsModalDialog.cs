using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class SimulationSettingsModalDialog : Form
    {
        public SimulationSettingsModalDialog()
        {
            InitializeComponent();

            Text = Properties.Resources.SimulationSettingsTitle;
        }

        public decimal Time
        {
            get
            {
                return numericUpDownTime.Value;
            }
            set
            {
                numericUpDownTime.Value = value;
            }
        }

        public decimal UHeight
        {
            get
            {
                return numericUpDownUHeight.Value;
            }
            set
            {
                numericUpDownUHeight.Value = value;
            }
        }

        public decimal UWidth
        {
            get
            {
                return numericUpDownUWidth.Value;
            }
            set
            {
                numericUpDownUWidth.Value = value;
            }
        }
    }
}
