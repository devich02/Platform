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
                     offsetX = 0,
                     offsetY = 0,
                     width = 0,
                     height = 0,
                     vx = 0,
                     vy =0,
                     ax =0,
                     ay = 0;

        public virtual void update(float offsetX, float offsetY, List<GameObject> os, Graphics g)
        {
            this.offsetX = offsetX;
            this.offsetY = offsetY;
            x += vx;
            y += vy;
            vx += ax;
            vy += ay;


        }
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
            g.FillRectangle(new SolidBrush(cPlatformColor), x-offsetX, y-offsetY, width, height);
        }
    }

    class MovingPlatform : Platform
    {
        float minX = 0,
            minY = 0,
            maxX = 0,
            maxY = 0;

        public MovingPlatform() : this(10, 10, 100, 100) { }
        public MovingPlatform(float x, float y, float width, float height) : this(x, y, width, height, Color.Black) {}
        public MovingPlatform(float x, float y, float width, float height, Color color) : this(x, y, width, height, color, 0, 0, 0, 0, 0, 0) { }
        public MovingPlatform (float x, float y, float width, float height, Color color, float vx, float vy, float minX, float minY, float maxX, float maxY)
        {
            cPlatformColor = color;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.vx = vx;
            this.vy = vy;
            this.minX = minX;
            this.minY = minY;
            this.maxX = maxX;
            this.maxY = maxY;
        }

        public override void update(float offsetX, float offsetY, List<GameObject> os, Graphics g)
        {
            base.update(offsetX, offsetY, os, g);
            if (x + width >= maxX || x <= minX)
            {
                vx = -vx;
            }
            if (y + height >= maxY || y <= minY)
            {
                vy = -vy;
            }
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
            g.FillRectangle(new SolidBrush(cPlatformColor), x - offsetX, y - offsetY, width, height);
        }
    }

    class Character : GameObject
    {

    }

    class MainCharacter : Character
    {
        public MainCharacter(float x, float y, float width, float height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }
        public override void draw(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.Black), x,y, width, height);
        }

        public override void update(float offsetX, float offsetY, List<GameObject> os, Graphics g)
        {
            RectangleF me = new RectangleF(x, y, width, height);
            g.DrawRectangle(Pens.Orange, me.X, me.Y, me.Width, me.Height);
            ay = .0001f;
            foreach (GameObject o in os)
            {
                RectangleF other = new RectangleF(o.x - offsetX,o.y - offsetY,o.width,o.height);
                if (me.IntersectsWith(other))
                {
               
                    ay = 0;
                    vy = 0;
                }
                g.DrawRectangle(Pens.Orange, other.X, other.Y, other.Width, other.Height);
            }

        }
    }
}
