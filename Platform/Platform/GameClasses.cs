using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Platform
{

    class GameObject
    {
        public float x = 0, 
                     y = 0, 
                     width = 0, 
                     height = 0;
        public virtual void update() { }
        public virtual void draw(Graphics g) { }
    }

    class Platform : GameObject
    {
        public Color cPlatformColor;
        public Platform() : this(10, 10, 100, 100) {}
        public Platform(float x, float y, float width, float height) : this(x, y, width, height, Color.Black) {}
        public Platform(float x, float y, float width, float height, Color color)
        {
            cPlatformColor = color;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public override void draw(Graphics g)
        {
            g.FillRectangle(new SolidBrush(cPlatformColor), x, y, width, height);
        }
    }

    class Scenery : GameObject
    {
        public Color cPlatformColor;
        public Scenery() : this(10, 10, 100, 100) {}
        public Scenery(float x, float y, float width, float height) : this(x, y, width, height, Color.Black) {}
        public Scenery(float x, float y, float width, float height, Color color)
        {
            cPlatformColor = color;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public override void draw(Graphics g)
        {
            g.FillRectangle(new SolidBrush(cPlatformColor), x, y, width, height);
        }
    }

}
