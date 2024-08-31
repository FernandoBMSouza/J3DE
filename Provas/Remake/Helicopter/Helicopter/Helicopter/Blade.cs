using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Helicopter
{
    class Blade : GameObject
    {
        public Blade(Game1 game, Color color)
            : base()
        {
            Children = new Primitive[] 
            { 
                new Triangle(game, color),
                new Square(game, color),
            };
        }

        public override void Update(GameTime gameTime)
        {
            foreach (Primitive child in Children)
            {
                child.Update(gameTime);
                child.World = Matrix.Identity;            
            }

            Children[0].World *= Matrix.CreateRotationZ(MathHelper.ToRadians(180));
            Children[0].World *= Matrix.CreateTranslation(new Vector3(0,-.5f, 0));
            Children[1].World *= Matrix.CreateTranslation(new Vector3(0, .5f, 0));

            foreach (Primitive child in Children)
                child.World *= World;
        }
    }
}
