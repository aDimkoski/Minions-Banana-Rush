using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minions_Banana_Rush
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            Level1 l = new Level1();
            var d = l.ShowDialog();
            if (d == DialogResult.OK)
            {
                Level2 l2 = new Level2();
                var rez = l2.ShowDialog();
                if (rez == DialogResult.OK)
                {
                    Level3 l3 = new Level3();
                    var rezl3= l3.ShowDialog();
                    if (rezl3 == DialogResult.OK)
                    {
                        Level4 l4 = new Level4();
                        var rezl4 = l4.ShowDialog();
                        if (rezl4 == DialogResult.Yes)
                        {
                            Application.Restart();
                        }
                        else if (rezl4 == DialogResult.No)
                        {
                            this.Close();
                        }
                    }
                }
                if (rez == DialogResult.Cancel)
                {
                    l2.Close();
                }
            }
            else if (d == DialogResult.Cancel)
            {
                l.Close();
            }
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/aDimkoski/Minions-Banana-Rush");
        }
    }
}
