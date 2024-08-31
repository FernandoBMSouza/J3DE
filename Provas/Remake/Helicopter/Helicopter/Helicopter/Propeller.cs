using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Helicopter
{
    class Propeller : GameObject
    {
        Blade[] blades;

        public Propeller(Game1 game, Color color)
            : base()
        {
            blades = new Blade[4];
            for (int i = 0; i < blades.Length; i++)
            {
                blades[i] = new Blade(game, color);
                blades[i].Parent = this;
            }
        }

        public override void Update(GameTime gameTime)
        {
            foreach (Blade blade in blades)
            {
                blade.World = Matrix.Identity;
                blade.World *= Matrix.CreateTranslation(new Vector3(0, 1, 0));            
            }

            blades[0].World *= Matrix.CreateRotationZ(MathHelper.ToRadians(0));
            blades[1].World *= Matrix.CreateRotationZ(MathHelper.ToRadians(90));
            blades[2].World *= Matrix.CreateRotationZ(MathHelper.ToRadians(180));
            blades[3].World *= Matrix.CreateRotationZ(MathHelper.ToRadians(270));

            foreach (Blade blade in blades)
                blade.Update(gameTime);

            base.Update(gameTime);
        }

        public override void Draw(Camera camera)
        {
            foreach (Blade blade in blades)
                blade.Draw(camera);
        }
    }
}
