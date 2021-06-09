using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minions_Banana_Rush
{
    public partial class Level4 : Form
    {
        public Level4()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }
        bool left;
        bool right;
        bool jumping;
        int score = 0;
        int minionSpeed = 7;
        int horizontalSpeed = 4;
        int horizontalSpeed2 = 3;
        int minionJumpSpeed;
        int gravity;
        private void Level4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                left = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                right = true;
            }
            if (e.KeyCode == Keys.Space)
            {
                jumping = true;
            }
        }

        private void Level4_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                left = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                right = false;
            }
            if (jumping == true)
            {
                jumping = false;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            minion.Top += minionJumpSpeed;
            if (left == true)
            {
                if (minion.Left >= 0)
                {
                    minion.Left -= minionSpeed;
                }
            }
            if (right == true)
            {
                if (minion.Left <= this.Width - minion.Width)
                {
                    minion.Left += minionSpeed;
                }
            }
            if (jumping == true && gravity < 0)
            {
                jumping = false;
            }
            if (jumping == true)
            {
                minionJumpSpeed = -10;
                gravity -= 1;
            }
            else
            {
                minionJumpSpeed = 10;
            }

            foreach (Control c in this.Controls)
            {
                if (c is PictureBox)
                {
                    if (c.Name.Equals("ground"))
                    {
                        if (minion.Bounds.IntersectsWith(c.Bounds))
                        {
                            gravity = 5;
                            minion.Top = c.Top - minion.Height;
                        }
                        c.BringToFront();
                    }
                    if ((string)c.Tag == "platform")
                    {
                        if (minion.Bounds.IntersectsWith(c.Bounds))
                        {
                            gravity = 5;
                            minion.Top = c.Top - minion.Height;
                            if(c.Name=="h1" && jumping==false)
                            {
                                 minion.Left -= horizontalSpeed;
                            }
                            if (c.Name == "h2" && jumping==false)
                            {
                                 minion.Left -= horizontalSpeed2;
                            }
                        }
                        c.BringToFront();
                    }
                    if ((string)c.Tag == "banana")
                    {
                        if (minion.Bounds.IntersectsWith(c.Bounds) && c.Visible == true)
                        {
                            c.Visible = false;
                            score++;
                            lbScore.Text = "Bananas collected: " + score;
                        }
                    }
                    if (c.Name.Equals("moon"))
                    {
                        if (minion.Bounds.IntersectsWith(c.Bounds) && score == 19)
                        {
                            timer.Stop();
                            var rez = MessageBox.Show("Congrats you passed all of the levels! " +
                                "You took the minions to the moon!!! If you want to play again click yes, and if you want to exit click no.", "Game over", MessageBoxButtons.YesNo);
                            if (rez == DialogResult.Yes)
                            {
                                DialogResult = DialogResult.Yes;
                            }
                            else if (rez == DialogResult.No)
                            {
                                DialogResult = DialogResult.No;
                            }
                        }
                        if (minion.Bounds.IntersectsWith(c.Bounds) && score != 19)
                        {
                            lbError.Text = "Please collect all of the bananas!";
                            lbError.Visible = true;
                        }
                        if (!minion.Bounds.IntersectsWith(c.Bounds))
                        {
                            lbError.Visible = false;
                        }
                    }
                }
            }
            h1.Left -= horizontalSpeed;
            if (h1.Left < 0 || h1.Left+h1.Width > this.Width)
            {
                horizontalSpeed = -horizontalSpeed;
            }
            h2.Left -= horizontalSpeed2;
            if (h2.Left < 0 || h2.Left+h1.Width > this.Width)
            {
                horizontalSpeed2 = -horizontalSpeed2;
            }
        }
    }
}
