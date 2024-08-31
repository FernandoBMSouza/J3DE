using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Helicopter
{
    class Blade : GameObject
    {
        Primitive[] primitives;

        public Blade(Game1 game, Color color)
            : base()
        {
            primitives = new Primitive[] 
            { 
                new Triangle(game, color),
                new Square(game, color),
            };
        }

        public override void Update(GameTime gameTime)
        {
            foreach (Primitive primitive in primitives)
                primitive.World = Matrix.Identity;                

            primitives[0].World *= Matrix.CreateRotationZ(MathHelper.ToRadians(180));
            primitives[0].World *= Matrix.CreateTranslation(new Vector3(0,-.5f, 0));
            primitives[1].World *= Matrix.CreateTranslation(new Vector3(0, .5f, 0));
            
            foreach (Primitive primitive in primitives)
                primitive.World *= World;
        }

        public override void Draw(Camera camera)
        {
            foreach (Primitive primitive in primitives)
                primitive.Draw(camera);
        }
    }
}
