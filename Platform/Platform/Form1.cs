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
        float cameraX = -100,
            cameraY = -400;
        bool[] keys; 

        public Form1()
        {
            InitializeComponent();
            keys = new bool[Enum.GetValues(typeof(Keys)).Length];
            MC.x = ClientRectangle.Width / 2 - MC.width / 2;
            MC.y = ClientRectangle.Height / 2 - MC.height / 2;
            MC.ay = .001f;

        }
    List<GameObject> objs = new List<GameObject>() { new MovingPlatform(20,20,100,40,Color.Black ,1,0,0,0,500,0), new Platform(20,200,400,40), new Scenery(400,400,20,20,Color.Green) };
    MainCharacter MC = new MainCharacter(10, 10, 20, 60);
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (keys[(int)Keys.Up])
            {
                cameraY -= 1;
            }
            if (keys[(int)Keys.Down])
            {
                cameraY += 1;
            }
            if (keys[(int)Keys.Left])
            {
                cameraX -= 1;
            }
            if (keys[(int)Keys.Right])
            {
                cameraX += 1;
            }

            foreach (GameObject g in objs)
            {
                g.update(cameraX, cameraY, objs, e.Graphics);
                g.draw(e.Graphics);
            }
            cameraX += MC.vx;
            cameraY += MC.vy;
            MC.vx += MC.ax;
            MC.vy += MC.ay;
            MC.update(cameraX, cameraY, objs, e.Graphics);
            MC.draw(e.Graphics);

            this.Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            keys[(int)e.KeyCode] = true;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            keys[(int)e.KeyCode] = false;
        }

    }
}
