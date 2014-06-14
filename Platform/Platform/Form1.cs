using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Platform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            List<GameObject> objs = new List<GameObject>() { new Platform(20,20,400,40), new Platform(20,200,400,40), new Scenery(400,400,20,20,Color.Green) };

            foreach (GameObject g in objs)
            {
                g.draw(e.Graphics);
            }

            this.Invalidate();
        }

    }
}
