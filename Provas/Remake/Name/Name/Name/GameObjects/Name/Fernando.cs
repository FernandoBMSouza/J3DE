using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Name.GameObjects.Name.Letters;
using Microsoft.Xna.Framework;

namespace Name.GameObjects.Name
{
    class Fernando : GameObject
    {
        float speed, angle;
        public Fernando(Game1 game, Color color, Color colorBorder, bool showColliderLines = false)
            : base(game, showColliderLines)
        {
            speed = 100;
            Children = new GameObject[]
            {
                new F(game, color, colorBorder),
                new E(game, color, colorBorder),
                new R(game, color, colorBorder),
                new N(game, color, colorBorder),
                new A(game, color, colorBorder),
                new N(game, color, colorBorder),
                new D(game, color, colorBorder),
                new O(game, color, colorBorder),
            };
            Size = new Vector3(Children[0].Size.X * (Children.Length + 2.35f), Children[0].Size.Y, Children[0].Size.Z);
        }

        public override void Update(GameTime gameTime)
        {
            angle += speed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
            foreach (GameObject child in Children)
            {
                child.Update(gameTime);
                child.World = Matrix.Identity;
                child.World *= Matrix.CreateRotationY(MathHelper.ToRadians(angle));
            }

            Children[0].World *= Matrix.CreateTranslation(new Vector3(-14, 0, 0));
            Children[1].World *= Matrix.CreateTranslation(new Vector3(-10, 0, 0));
            Children[2].World *= Matrix.CreateTranslation(new Vector3(-6, 0, 0));
            Children[3].World *= Matrix.CreateTranslation(new Vector3(-2, 0, 0));
            Children[4].World *= Matrix.CreateTranslation(new Vector3( 2, 0, 0));
            Children[5].World *= Matrix.CreateTranslation(new Vector3( 6, 0, 0));
            Children[6].World *= Matrix.CreateTranslation(new Vector3( 10, 0, 0));
            Children[7].World *= Matrix.CreateTranslation(new Vector3( 14, 0, 0));


            foreach (GameObject child in Children)
                child.World *= World;

            base.Update(gameTime);
        }
    }
}
