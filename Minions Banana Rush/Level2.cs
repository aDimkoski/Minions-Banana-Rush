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
    public partial class Level2 : Form
    {
        public Level2()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }
        bool left;
        bool right;
        bool jumping;
        int score = 0;
        int minionSpeed = 7;
        int minionJumpSpeed;
        int gravity;
        int horizontalSpeed = 2;
        int horizontalSpeed2 = 2;
        int horizontalSpeed3 = 2;


        private void Level2_KeyUp(object sender, KeyEventArgs e)
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

        private void Level2_KeyDown(object sender, KeyEventArgs e)
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
                        if (minion.Bounds.IntersectsWith(c.Bounds) && score == 21)
                        {
                            timer.Stop();
                            var rez = MessageBox.Show("Congrats, you won this level! Would you like to " +
                                "proceed to the next one?", "Level successfully done", MessageBoxButtons.OKCancel);
                            if (rez == DialogResult.OK)
                            {
                                DialogResult = DialogResult.OK;
                            }
                            if (rez == DialogResult.Cancel)
                            {
                                DialogResult = DialogResult.Cancel;
                            }
                        }
                        if (minion.Bounds.IntersectsWith(c.Bounds) && score != 21)
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
            if(h1.Left<-83 || h1.Left + h1.Width > 72)
            {
                horizontalSpeed = -horizontalSpeed;
            }
            h2.Left -= horizontalSpeed2;
            if (h2.Left < 728 || h2.Left > this.Width+15)
            {
                horizontalSpeed2 = -horizontalSpeed2;
            }
            h3.Left -= horizontalSpeed3;
            if (h3.Left < 728 || h3.Left > this.Width+15)
            {
                horizontalSpeed3 = -horizontalSpeed3;
            }
        }
    }
}
