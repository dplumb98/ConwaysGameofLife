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
    public partial class ModalDialog : Form
    {
        public ModalDialog()
        {
            InitializeComponent();

            Text = Properties.Resources.ModalDialogTitle;
        }

        public decimal Seed
        {
            get
            {
                return numericUpDownSeed.Value;
            }
            set
            {
                numericUpDownSeed.Value = value;
            }
        }
    }
}
