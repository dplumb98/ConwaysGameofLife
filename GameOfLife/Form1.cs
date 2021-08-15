using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class Form1 : Form
    {
        // The universe array
        bool[,] universe = new bool[5, 5];
        bool[,] scratchPad = new bool[5, 5];

        // Drawing colors
        Color gridColor = Color.Black;
        Color cellColor = Color.Gray;

        // The Timer class
        Timer timer = new Timer();

        // Generation count
        int generations = 0;

        // Keeps track of the seed the user entered
        decimal seedEntered = 0;

        // Keeps track of the time interval the user entered
        decimal timeInterval = 100;

        // Keeps track of the universe height and width the user entered
        decimal universeHeight = 5;
        decimal universeWidth = 5;

        // Keeps track of whether the user wants to use torodial or finite
        bool useTorodial = true;
        bool useFinite = false;

        // Keeps track of the living cells in the universe
        int livingCells = 0;

        // Used to generate a random number
        Random rnd = new Random();

        // Font used for drawing count in the rectangles
        Font font = new Font("Arial", 20f);

        // Font used for drawing the HUD
        Font hudFont = new Font("Arial", 15f);

        // Bools to turn features off and on using the View menu
        bool displayNeighborCount = true;
        bool displayGrid = true;
        bool displayHUD = true;

        public Form1()
        {
            InitializeComponent();

            // Initialize the application title
            Text = Properties.Resources.AppTitle;

            // Read settings
            graphicsPanel1.BackColor = Properties.Settings.Default.BackgroundColor;
            gridColor = Properties.Settings.Default.GridColor;
            cellColor = Properties.Settings.Default.CellColor;
            universeHeight = Properties.Settings.Default.UniverseHeight;
            universeWidth = Properties.Settings.Default.UniverseWidth;
            timeInterval = Properties.Settings.Default.TimerInterval;

            // Resize the universe and scratchpad
            universe = new bool[(int)universeHeight, (int)universeWidth];
            scratchPad = new bool[(int)universeHeight, (int)universeWidth];


            // Setup the timer
            timer.Interval = (int)timeInterval; // milliseconds
            timer.Tick += Timer_Tick;
            timer.Enabled = false; // Initialize the timer to not start when the program runs
        }

        // Calculate the next generation of cells
        private void NextGeneration()
        {
            int count = 0;
            livingCells = 0;
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    scratchPad[x, y] = false;
                    if (useTorodial == true)
                    {
                        count = CountNeighborsTorodial(x, y);
                    }
                    else if (useFinite == true)
                    {
                        count = CountNeighborsFinite(x, y);
                    }
                    // Apply rules
                    if (universe[x, y] == true)
                    {
                        if (count < 2)
                        {
                            scratchPad[x, y] = false;
                        }
                        else if (count > 3)
                        {
                            scratchPad[x, y] = false;
                        }
                        else if (count == 2 || count == 3)
                        {
                            scratchPad[x, y] = true;
                        }
                        // Increment the living cells variable for each cell that is alive
                        livingCells++;
                    }

                    if (universe[x, y] == false)
                    {
                        if (count == 3)
                        {
                            scratchPad[x, y] = true;
                        }
                    }
                }
            }

            // Copy scratchpad array to universe 
            bool[,] temp = universe;
            universe = scratchPad;
            scratchPad = temp;

            // Increment generation count
            generations++;

            // Update status strip generations
            toolStripStatusLabelGenerations.Text = "Generations = " + generations.ToString();
            // Update status strip living cells
            toolStripStatusLabelLivingCells.Text = "Living Cells = " + livingCells.ToString();

            graphicsPanel1.Invalidate();
        }

        private int CountNeighborsFinite(int x, int y)
        {
            int count = 0; // Initialize the count variable which we will later return to the function
            int xLen = universe.GetLength(0); // Set xLen equal to the first dimension of the universe array
            int yLen = universe.GetLength(1); // Set yLen equal to the second dimension of the universe array

            // Iterate through the 2D array
            for (int yOffset = -1; yOffset <= 1; yOffset++)
            {
                for (int xOffset = -1; xOffset <= 1; xOffset++)
                {
                    int xCheck = x + xOffset;
                    int yCheck = y + yOffset;

                    // if xOffset and yOffset are both equal to 0 then continue
                    if (xOffset == 0 && yOffset == 0)
                    {
                        continue;
                    }

                    // if xCheck is less than 0 then continue
                    if (xCheck < 0)
                    {
                        continue;
                    }

                    // if yCheck is less than 0 then continue
                    if (yCheck < 0)
                    {
                        continue;
                    }

                    // if xCheck is greater than or equal too xLen then continue
                    if (xCheck >= xLen)
                    {
                        continue;
                    }

                    // if yCheck is greater than or equal too yLen then continue
                    if (yCheck >= yLen)
                    {
                        continue;
                    }

                    if (universe[xCheck, yCheck] == true) // If both xCheck and yCheck are true, then increment count
                    {
                        count++;
                    }
                }
            }
            return count; // Return count to the function
        }

        private int CountNeighborsTorodial(int x, int y)
        {
            int count = 0; // Initialize the count variable which we will later return to the function
            int xLen = universe.GetLength(0); // Set xLen equal to the first dimension of the universe array
            int yLen = universe.GetLength(1); // Set yLen equal to the second dimension of the universe array

            // Iterate through the 2D array
            for (int yOffset = -1; yOffset <= 1; yOffset++)
            {
                for (int xOffset = -1; xOffset <= 1; xOffset++)
                {
                    int xCheck = x + xOffset;
                    int yCheck = y + yOffset;

                    if (xOffset == 0 && yOffset == 0) // if xOffset and yOffset are both equal to 0 then continue
                    {
                        continue;
                    }

                    if (xCheck < 0) // if xCheck is less than 0 then set to xLen - 1
                    {
                        xCheck = xLen - 1;
                    }
                    else if (xCheck >= xLen) // if xCheck is greater than or equal too xLen then set to 0
                    {
                        xCheck = 0;
                    }

                    if (yCheck < 0) // if yCheck is less than 0 then set to yLen - 1
                    {
                        yCheck = yLen - 1;
                    }
                    else if (yCheck >= yLen) // if yCheck is greater than or equal too yLen then set to 0
                    {
                        yCheck = 0;
                    }

                    if (universe[xCheck, yCheck] == true) // If both xCheck and yCheck are true, then increment count
                    {
                        count++;
                    }
                }
            }
            return count; // Return count to the function
        }

        // The event called by the timer every Interval milliseconds.
        private void Timer_Tick(object sender, EventArgs e)
        {
            NextGeneration();
        }

        private void graphicsPanel1_Paint(object sender, PaintEventArgs e)
        {
            // Align everything properly
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            // Keeps track of the amount of neighbors a cell has
            int neighbors = 0;

            // Calculate the width and height of each cell in pixels
            // CELL WIDTH = WINDOW WIDTH / NUMBER OF CELLS IN X
            int cellWidth = graphicsPanel1.ClientSize.Width / universe.GetLength(0);
            // CELL HEIGHT = WINDOW HEIGHT / NUMBER OF CELLS IN Y
            int cellHeight = graphicsPanel1.ClientSize.Height / universe.GetLength(1);

            // A Pen for drawing the grid lines (color, width)
            Pen gridPen = new Pen(gridColor, 1);

            // A Brush for filling living cells interiors (color)
            Brush cellBrush = new SolidBrush(cellColor);

            // Iterate through the universe in the y, top to bottom
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                // Iterate through the universe in the x, left to right
                for (int x = 0; x < universe.GetLength(0); x++)
                {

                    // A rectangle to represent each cell in pixels
                    Rectangle cellRect = Rectangle.Empty;
                    cellRect.X = x * cellWidth;
                    cellRect.Y = y * cellHeight;
                    cellRect.Width = cellWidth;
                    cellRect.Height = cellHeight;

                    Rectangle rect = Rectangle.Empty;
                    rect.X = x * cellWidth;
                    rect.Y = y * cellHeight;
                    rect.Width = cellWidth;
                    rect.Height = cellHeight;

                    neighbors = CountNeighborsTorodial(x, y);

                    // Fill the cell with a brush if alive
                    if (universe[x, y] == true)
                    {
                        e.Graphics.FillRectangle(cellBrush, cellRect);
                    }

                    if (displayGrid == true)
                    {
                        // Outline the cell with a pen
                        e.Graphics.DrawRectangle(gridPen, cellRect.X, cellRect.Y, cellRect.Width, cellRect.Height);
                    }

                    if (displayNeighborCount == true)
                    {
                        if (universe[x, y] == true)
                        {
                            // Draw numbers in each individual cell that displays the amount of neighbors
                            e.Graphics.DrawString(neighbors.ToString(), font, Brushes.Green, rect, stringFormat);
                        }
                        else
                        {
                            // Draw numbers in each individual cell that displays the amount of neighbors
                            e.Graphics.DrawString(neighbors.ToString(), font, Brushes.Red, rect, stringFormat);
                        }
                    }
                }
            }

            if (displayHUD == true)
            {
                // Draw the generations for the HUD
                e.Graphics.DrawString("Generations = " + generations.ToString(), hudFont, Brushes.Blue, 80, 150, stringFormat);
                // Draw the living cells for the HUD
                e.Graphics.DrawString("Living Cells = " + livingCells.ToString(), hudFont, Brushes.Blue, 78, 180, stringFormat);
                // Draw the boundry type for the HUD
                if (useTorodial == true)
                {
                    e.Graphics.DrawString("Boundry Type = Torodial", hudFont, Brushes.Blue, 119, 206, stringFormat);
                }
                else
                {
                    e.Graphics.DrawString("Boundry Type = Finite", hudFont, Brushes.Blue, 107, 206, stringFormat);
                }
                // Draw universe size for the HUD
                if (universeHeight >= 10 && universeWidth >= 10)
                {
                    e.Graphics.DrawString("Universe Size = [" + universeHeight.ToString() + ", " + universeWidth.ToString() + "]", hudFont, Brushes.Blue, 116, 233, stringFormat);
                }
                else
                {
                    e.Graphics.DrawString("Universe Size = [" + universeHeight.ToString() + ", " + universeWidth.ToString() + "]", hudFont, Brushes.Blue, 106, 233, stringFormat);
                }
            }

            // Cleaning up pens and brushes
            gridPen.Dispose();
            cellBrush.Dispose();
        }

        private void graphicsPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            // If the left mouse button was clicked
            if (e.Button == MouseButtons.Left)
            {
                // Calculate the width and height of each cell in pixels
                int cellWidth = graphicsPanel1.ClientSize.Width / universe.GetLength(0);
                int cellHeight = graphicsPanel1.ClientSize.Height / universe.GetLength(1);

                // Calculate the cell that was clicked in
                // CELL X = MOUSE X / CELL WIDTH
                int x = e.X / cellWidth;
                // CELL Y = MOUSE Y / CELL HEIGHT
                int y = e.Y / cellHeight;

                // Toggle the cell's state
                universe[x, y] = !universe[x, y];

                // Tell Windows you need to repaint
                graphicsPanel1.Invalidate();
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Iterate through the universe in the y, top to bottom
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                // Iterate through the universe in the x, left to right
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    universe[x, y] = false; // Turn off all cells
                }
            }
            toolStripStatusLabelGenerations.Text = "Generations = " + 0; // Reset generations to 0 on the Windows Form
            generations = 0; // Reset generataions value to 0 so the timer starts again at 0
            graphicsPanel1.Invalidate();
        }

        private void toolStripButtonStart_Click(object sender, EventArgs e)
        {
            // Turn the timer off, which stops the simulation
            timer.Enabled = true;
        }

        private void toolStripButtonPause_Click(object sender, EventArgs e)
        {
            // Turn the timer on, which starts the simulation
            timer.Enabled = false;
        }

        private void toolStripButtonNext_Click(object sender, EventArgs e)
        {
            NextGeneration();
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = graphicsPanel1.BackColor;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                graphicsPanel1.BackColor = dlg.Color;
            }
        }

        private void gridColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = gridColor;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                gridColor = dlg.Color;
            }
            graphicsPanel1.Invalidate();
        }

        private void cellColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = cellColor;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                cellColor = dlg.Color;
            }
            graphicsPanel1.Invalidate();
        }

        private void randomizeBySeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModalDialog dlg = new ModalDialog();

            dlg.Seed = seedEntered;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                seedEntered = dlg.Seed;
                Random rndm = new Random((int)seedEntered);
                // Iterate through the universe in the y, top to bottom
                for (int y = 0; y < universe.GetLength(1); y++)
                {
                    // Iterate through the universe in the x, left to right
                    for (int x = 0; x < universe.GetLength(0); x++)
                    {
                        int num = rndm.Next(0, 2);
                        if (num == 0)
                        {
                            universe[x, y] = true;
                        }
                        else
                        {
                            universe[x, y] = false;
                        }
                    }
                }
            }
            graphicsPanel1.Invalidate();
        }

        private void simulationSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SimulationSettingsModalDialog dlg = new SimulationSettingsModalDialog();

            dlg.Time = timeInterval;
            dlg.UHeight = universeHeight;
            dlg.UWidth = universeWidth;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                timeInterval = dlg.Time;
                universeHeight = dlg.UHeight;
                universeWidth = dlg.UWidth;

                universe = new bool[(int)universeHeight, (int)universeWidth];
                scratchPad = new bool[(int)universeHeight, (int)universeWidth];
                timer.Interval = (int)timeInterval; // Set the timer's interval to the new selected value, cast as int
            }
            graphicsPanel1.Invalidate();
        }

        private void colorSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorsModalDialog dlg = new ColorsModalDialog();

            dlg.BackgroundColor = graphicsPanel1.BackColor;
            dlg.GridColor = gridColor;
            dlg.CellColor = cellColor;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                graphicsPanel1.BackColor = dlg.BackgroundColor;
                gridColor = dlg.GridColor;
                cellColor = dlg.CellColor;
            }
            graphicsPanel1.Invalidate();
        }

        private void toolStripButtonTorodial_Click(object sender, EventArgs e)
        {
            // Switch to using Torodial
            useTorodial = true;
            useFinite = false;
            graphicsPanel1.Invalidate();
        }

        private void toolStripButtonFinite_Click(object sender, EventArgs e)
        {
            // Switch to using Finite
            useTorodial = false;
            useFinite = true;
            graphicsPanel1.Invalidate();
        }

        private void randomizeByTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Number used to impose randomness on the cells
            int randomNum = 0;

            // Iterate through the universe in the y, top to bottom
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                // Iterate through the universe in the x, left to right
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    randomNum = rnd.Next(0, 2);
                    if (randomNum == 0)
                    {
                        universe[x, y] = true;
                    }
                    else
                    {
                        universe[x, y] = false;
                    }
                }
            }
            graphicsPanel1.Invalidate();
        }

        private void displayNeighborCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (displayNeighborCount == true)
            {
                displayNeighborCount = false;
            }
            else
            {
                displayNeighborCount = true;
            }
            graphicsPanel1.Invalidate();
        }

        private void displayGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (displayGrid == true)
            {
                displayGrid = false;
            }
            else
            {
                displayGrid = true;
            }
            graphicsPanel1.Invalidate();
        }

        private void displayHUDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (displayHUD == true)
            {
                displayHUD = false;
            }
            else
            {
                displayHUD = true;
            }
            graphicsPanel1.Invalidate();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Set the back color of the graphics panel to the settings color
            Properties.Settings.Default.BackgroundColor = graphicsPanel1.BackColor;
            Properties.Settings.Default.GridColor = gridColor;
            Properties.Settings.Default.CellColor = cellColor;
            Properties.Settings.Default.UniverseHeight = (int)universeHeight;
            Properties.Settings.Default.UniverseWidth = (int)universeWidth;
            Properties.Settings.Default.TimerInterval = (int)timeInterval;

            // Save the changes to persist
            Properties.Settings.Default.Save();
        }

        private void resetSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Reset settings to default
            Properties.Settings.Default.Reset();

            // Read settings
            graphicsPanel1.BackColor = Properties.Settings.Default.BackgroundColor;
            gridColor = Properties.Settings.Default.GridColor;
            cellColor = Properties.Settings.Default.CellColor;
            universeHeight = Properties.Settings.Default.UniverseHeight;
            universeWidth = Properties.Settings.Default.UniverseWidth;
            timeInterval = Properties.Settings.Default.TimerInterval;

            // Resize the universe and scratchpad
            universe = new bool[(int)universeHeight, (int)universeWidth];
            scratchPad = new bool[(int)universeHeight, (int)universeWidth];

            // Change the timer's interval to the timeInterval value
            timer.Interval = (int)timeInterval;

            // Repaint the graphics panel
            graphicsPanel1.Invalidate();
        }

        private void reloadSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Reset settings to default
            Properties.Settings.Default.Reload();

            // Read settings
            graphicsPanel1.BackColor = Properties.Settings.Default.BackgroundColor;
            gridColor = Properties.Settings.Default.GridColor;
            cellColor = Properties.Settings.Default.CellColor;
            universeHeight = Properties.Settings.Default.UniverseHeight;
            universeWidth = Properties.Settings.Default.UniverseWidth;
            timeInterval = Properties.Settings.Default.TimerInterval;

            // Resize the universe and scratchpad
            universe = new bool[(int)universeHeight, (int)universeWidth];
            scratchPad = new bool[(int)universeHeight, (int)universeWidth];

            // Change the timer's interval to the timeInterval value
            timer.Interval = (int)timeInterval;

            // Repaint the graphics panel
            graphicsPanel1.Invalidate();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "All Files|*.*|Cells|*.cells";
            dlg.FilterIndex = 2; dlg.DefaultExt = "cells";


            if (DialogResult.OK == dlg.ShowDialog())
            {
                StreamWriter writer = new StreamWriter(dlg.FileName);

                // Write any comments you want to include first.
                // Prefix all comment strings with an exclamation point.
                // Use WriteLine to write the strings to the file. 
                // It appends a CRLF for you.
                writer.WriteLine("!The following is the universe:");

                // Iterate through the universe one row at a time.
                for (int y = 0; y < universe.GetLength(1); y++)
                {
                    // Create a string to represent the current row.
                    String currentRow = string.Empty;

                    // Iterate through the current row one cell at a time.
                    for (int x = 0; x < universe.GetLength(0); x++)
                    {
                        // If the universe[x,y] is alive then append 'O' (capital O)
                        // to the row string.
                        if (universe[x, y] == true)
                        {
                            currentRow += "O";
                        }

                        // Else if the universe[x,y] is dead then append '.' (period)
                        // to the row string.
                        if (universe[x, y] == false)
                        {
                            currentRow += ".";
                        }
                    }

                    // Once the current row has been read through and the 
                    // string constructed then write it to the file using WriteLine.
                    writer.WriteLine(currentRow);
                }

                // After all rows and columns have been written then close the file.
                writer.Close();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All Files|*.*|Cells|*.cells";
            dlg.FilterIndex = 2;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                StreamReader reader = new StreamReader(dlg.FileName);

                // Create a couple variables to calculate the width and height
                // of the data in the file.
                int maxWidth = 0;
                int maxHeight = 0;

                // Iterate through the file once to get its size.
                while (!reader.EndOfStream)
                {
                    // Read one row at a time.
                    string row = reader.ReadLine();

                    // If the row begins with '!' then it is a comment
                    // and should be ignored.
                    if (row[0] == '!')
                    {
                        continue;
                    }

                    // If the row is not a comment then it is a row of cells.
                    // Increment the maxHeight variable for each row read.
                    if (row[0] != '!')
                    {
                        maxHeight++;
                    }


                    // Get the length of the current row string
                    // and adjust the maxWidth variable if necessary.
                    int rowLengthCheck = row.Length;
                    if (rowLengthCheck >= row.Length)
                    {
                        maxWidth = row.Length;
                    }
                }

                // Resize the current universe and scratchPad
                // to the width and height of the file calculated above.
                universe = new bool[maxHeight, maxWidth];
                scratchPad = new bool[maxHeight, maxWidth];

                // Reset the file pointer back to the beginning of the file.
                reader.BaseStream.Seek(0, SeekOrigin.Begin);

                // Keeps track of the y position with each iteration
                int yPos = 0;

                // Iterate through the file again, this time reading in the cells.
                while (!reader.EndOfStream)
                {
                    // Read one row at a time.
                    string row = reader.ReadLine();

                    // If the row begins with '!' then
                    // it is a comment and should be ignored.
                    if (row[0] == '!')
                    {
                        continue;
                    }
                    else if (row[0] != '!') // If the row is not a comment then it is a row of cells and needs to be iterated through.
                    {
                        for (int xPos = 0; xPos < row.Length; xPos++)
                        {
                            // If row[xPos] is a 'O' (capital O) then
                            // set the corresponding cell in the universe to alive.
                            if (row[xPos] == 'O')
                            {
                                universe[xPos, yPos] = true;
                            }

                            // If row[xPos] is a '.' (period) then
                            // set the corresponding cell in the universe to dead.
                            if (row[xPos] == '.')
                            {
                                universe[xPos, yPos] = false;
                            }
                        }
                    }
                    // Increment the yPos variable
                    yPos++;
                }

                // Close the file.
                reader.Close();
                graphicsPanel1.Invalidate();
            }
        }
    }
}
