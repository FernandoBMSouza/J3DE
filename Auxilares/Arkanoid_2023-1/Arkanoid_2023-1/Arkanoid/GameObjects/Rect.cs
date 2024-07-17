using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Arkanoid
{
    public class Rect : GameObject
    {
        public int ID { get; set; }

        public Rect(Vector2 position, ref Texture2D texture, Vector2 speed, int id)
            : base(position, texture)
        {
            this.ID = id;
        }
    }
}
