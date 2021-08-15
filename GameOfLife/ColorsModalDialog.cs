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
    public partial class ColorsModalDialog : Form
    {
        // Variables to keep track of colors the user wants
        private Color backgroundColor;
        private Color gridColor;
        private Color cellColor;

        public ColorsModalDialog()
        {
            InitializeComponent();

            // Change the title of the modal dialog box
            Text = Properties.Resources.ColorsSettingsTitle;
        }

        // Properties to transfer color changes to the Form1 class
        public Color BackgroundColor
        {
            get
            {
                return backgroundColor;
            }
            set
            {
                backgroundColor = value;
            }
        }

        public Color GridColor
        {
            get
            {
                return gridColor;
            }
            set
            {
                gridColor = value;
            }
        }

        public Color CellColor
        {
            get
            {
                return cellColor;
            }
            set
            {
                cellColor = value;
            }
        }

        private void buttonBC_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();

            dlg.Color = backgroundColor;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                backgroundColor = dlg.Color;
            }
        }

        private void buttonGC_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();

            dlg.Color = gridColor;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                gridColor = dlg.Color;
            }
        }

        private void buttonCC_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();

            dlg.Color = cellColor;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                cellColor = dlg.Color;
            }
        }
    }
}
