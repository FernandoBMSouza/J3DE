using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Helicopter
{
    class Propeller : GameObject
    {
        static Random random = new Random();
        float speed;
        float angle;
        Blade[] blades;

        public Propeller(Game1 game, Color color)
            : base()
        {
            speed = random.Next(10, 200);

            blades = new Blade[4];
            for (int i = 0; i < blades.Length; i++)
                blades[i] = new Blade(game, color);
        }

        public override void Update(GameTime gameTime)
        {
            foreach (Blade blade in blades)
                blade.Update(gameTime);

            angle += speed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
            for (int i = 0; i < blades.Length; i++)
            {
                blades[i].World = Matrix.Identity;
                blades[i].World *= Matrix.CreateTranslation(new Vector3(0, 1, 0));
                blades[i].World *= Matrix.CreateRotationZ(MathHelper.ToRadians(angle + i * 90));
                blades[i].World *= World;
            }
        }

        public override void Draw(Camera camera)
        {
            foreach (Blade blade in blades)
                blade.Draw(camera);
        }
    }
}
