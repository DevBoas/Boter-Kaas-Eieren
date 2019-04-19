using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// This is the code for your desktop app.
// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

namespace Boter_Kaas_Eieren
{
    public partial class Form1 : Form
    {
        int turn_count = 0; // even = X odd = O

        public Form1()
        {
            InitializeComponent();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Opdracht 8", "About");
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private Boolean is_odd()
        {
            return ((turn_count % 2) > 0);
        }
        private void disable_Buttons()
        {
            foreach (Control c in Controls)
            {
                if (c.GetType() == typeof(Button))
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
        }
        private void reset_Buttons()
        {
            foreach (Control c in Controls)
            {
                if (c.GetType() == typeof(Button))
                {
                    Button b = (Button) c;
                    b.Text = "";
                    b.Enabled = true;
                }
            }
        }
        private void checkGame()
        {
            Boolean endGame = false;

            // horizontal
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                endGame = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                endGame = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                endGame = true;

            // vertical
            if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                endGame = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                endGame = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                endGame = true;

            // diagonal
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                endGame = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
                endGame = true;

            if (endGame)
            {
                String winner = "";
                if (is_odd())
                    winner = "O";
                else
                    winner = "X";
                MessageBox.Show(winner + " wins this round!", "Congratulations!");
                disable_Buttons();
            }
            else
            {
                if ((turn_count) == 9)
                    MessageBox.Show("It's a draw!", "Draw!");
            }
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Text == String.Empty)
            {
                b.Enabled = false;
                turn_count++;
                if (is_odd())
                    b.Text = "O";
                else
                    b.Text = "X";
                checkGame();
            }
        }

        private void NewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn_count = 0;
            reset_Buttons();
        }
    }
}
