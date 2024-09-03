using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Mundo02.GameObjects.Primitives;

namespace Mundo02.GameObjects.Windmill
{
    class Blade : GameObject
    {
        public Blade(Game1 game, Color color, bool showColliderLines = false)
            : base(game, showColliderLines)
        {
            Children = new GameObject[] 
            { 
                new Triangle3D(game, color),
                new Cube(game, color),
            };
            Size = new Vector3(Children[0].Size.X / 2, Children[0].Size.Y, Children[0].Size.Z / 25);
        }

        public override void Update(GameTime gameTime)
        {
            foreach (GameObject child in Children)
            {
                child.Update(gameTime);
                child.World = Matrix.Identity;
                child.World = Matrix.CreateScale(new Vector3(child.Size.X / 2f, child.Size.Y / 2f, child.Size.Z / 25f));
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
