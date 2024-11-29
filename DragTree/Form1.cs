using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace DragTree
{
    public partial class Form1 : Form
    {
        //create an int variable to track currentRow,
        int currentRow;

        // create a Stopwatch object called stopwatch
        Stopwatch myWatch = new Stopwatch();

        public Form1()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            //start the timer
            lightTimer.Start();

        }

        private void goButton_Click(object sender, EventArgs e)
        {
            //stop the stopwatch
            myWatch.Stop();

            // check if the ellapsed time in milliseconds is > 0. 
            // If yes show the time.
            if (myWatch.ElapsedMilliseconds > 0)
            {
                timeLabel.Text = myWatch.Elapsed.ToString(@"m\:ss\:ff");
            }
            // If no show "FOUL START" 
            else
            {
                timeLabel.Text = "FOUL START";
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {

            //reset the stopwatch
            myWatch.Reset();

            //put rows 1-3 colours back to DimGray and row 4 back to DarkOliveGreen
            row1col1.BackColor = Color.DimGray;
            row1col2.BackColor = Color.DimGray;
            row2col1.BackColor = Color.DimGray;
            row2col2.BackColor = Color.DimGray;
            row3col1.BackColor = Color.DimGray;
            row3col2.BackColor = Color.DimGray;
            row4col1.BackColor = Color.DarkOliveGreen;
            row4col2.BackColor = Color.DarkOliveGreen;

            //reset row value and timeLabel text
            currentRow = 0;
            timeLabel.Text = "0.000";
        }

        //create the tick event for the lightTimer
        private void lightTimer_Tick(object sender, EventArgs e)
        {
            // create a switch block that checks currentRow. In each case
            // it will light up the appropriate lights, (labels). 
            switch (currentRow)
            {
                case 0:
                    break;
                case 1:
                    row1col1.BackColor = Color.Orange;
                    row1col2.BackColor = Color.Orange;
                    break;
                case 2:
                    row2col1.BackColor = Color.Orange;
                    row2col2.BackColor = Color.Orange;
                    break;
                case 3:
                    row3col1.BackColor = Color.Orange;
                    row3col2.BackColor = Color.Orange;
                    break;
                case 4:
                    row4col1.BackColor = Color.Lime;
                    row4col2.BackColor = Color.Lime;
                    lightTimer.Stop();
                    myWatch.Start();
                    break;
            }
            //increment the currentRow value by 1
            currentRow++;
        }
    }
}
