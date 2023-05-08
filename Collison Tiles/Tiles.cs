using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Collison_Tiles
{
    internal class Tiles
    {

        protected Texture2D texture;

        private Rectangle rectangle;

        public Rectangle Rectangle
        {

            get { return rectangle; }
            protected set { rectangle = value; }
        }

        private static ContentManager content;
        public static ContentManager Content
        {
            protected get { return content; }
            set { content = value; }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);

        }
    }


    class CollisionTiles : Tiles
    {
        public CollisionTiles(int i, Rectangle newrectangle)
        {
            texture = Content.Load<Texture2D>("Collision Tiles/Tile" + i);
            this.Rectangle = newrectangle;
        }
    }
}
