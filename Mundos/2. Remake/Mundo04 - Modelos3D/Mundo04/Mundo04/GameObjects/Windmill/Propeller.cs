using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mundo04.GameObjects.Windmill
{
    class Propeller : GameObject
    {
        static Random random = new Random();
        float speed;
        float angle;
        bool working;

        public Propeller(Game1 game, Texture2D texture, bool working = true, bool showColliderLines = false)
            : base(game, showColliderLines)
        {
            this.working = working;
            speed = random.Next(50, 500);
            //speed = 0;

            Children = new GameObject[]
            {
                new Blade(game, texture),
                new Blade(game, texture),
                new Blade(game, texture),
                new Blade(game, texture),
            };

            Size = new Vector3(Children[0].Size.X * 4, Children[0].Size.Y * 2, 0) ;
        }

        public override void Update(GameTime gameTime)
        {
            if (working) angle += speed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
            for (int i = 0; i < Children.Length; i++)
            {
                Children[i].Update(gameTime);
                Children[i].World = Matrix.Identity;
                Children[i].World *= Matrix.CreateTranslation(new Vector3(0, Children[i].Size.Y / 2f, 0));
                Children[i].World *= Matrix.CreateRotationZ(MathHelper.ToRadians(angle + i * 90));
                Children[i].World *= World;
            }
            base.Update(gameTime);
        }
    }
}
