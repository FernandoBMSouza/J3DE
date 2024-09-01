using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Mundo01.GameObjects.Primitives;

namespace Mundo01.GameObjects.Windmill
{
    class Blade : GameObject
    {
        public Blade(Game1 game, Color color)
            : base(game)
        {
            Size = new Vector3(.5f,1,0);
            Children = new GameObject[] 
            { 
                new Triangle(game, color),
                new Square(game, color),
            };
        }

        public override void Update(GameTime gameTime)
        {
            foreach (GameObject child in Children)
            {
                child.Update(gameTime);
                child.World = Matrix.Identity;
                child.World = Matrix.CreateScale(child.Size / 2f);
            }
            Children[0].World *= Matrix.CreateRotationZ(MathHelper.ToRadians(180));
            Children[0].World *= Matrix.CreateTranslation(new Vector3(0, -Children[0].Size.Y / 4f, 0));
            Children[1].World *= Matrix.CreateTranslation(new Vector3(0, Children[1].Size.Y / 4f, 0));

            foreach (GameObject child in Children)
                child.World *= World;

            base.Update(gameTime);
        }
    }
}
