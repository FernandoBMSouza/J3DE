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
        bool working;

        public Propeller(Game1 game, Color color, bool working = true)
            : base()
        {
            this.working = working;
            speed = random.Next(10, 200);

            Children = new Blade[4];
            for (int i = 0; i < Children.Length; i++)
                Children[i] = new Blade(game, color);
        }

        public override void Update(GameTime gameTime)
        {
            if(working) angle += speed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
            for (int i = 0; i < Children.Length; i++)
            {
                Children[i].Update(gameTime);

                Children[i].World = Matrix.Identity;
                Children[i].World *= Matrix.CreateTranslation(new Vector3(0, 1, 0));
                Children[i].World *= Matrix.CreateRotationZ(MathHelper.ToRadians(angle + i * 90));
                Children[i].World *= World;
            }
        }
    }
}
