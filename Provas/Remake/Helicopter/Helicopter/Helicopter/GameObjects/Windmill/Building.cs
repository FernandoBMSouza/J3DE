using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Helicopter.GameObjects.Primitives;

namespace Helicopter.GameObjects.Windmill
{
    class Building : GameObject
    {
        public Building(Game1 game, Color color, bool showColliderLines = false)
            : base(game, showColliderLines)
        {
            Children = new GameObject[] 
            { 
                new Cube(game, color),
                new RightTriangle3D(game, color),
            };
            Size = new Vector3(Children[0].Size.X, Children[0].Size.Y * 2, Children[0].Size.Z + Children[1].Size.Z);
        }

        public override void Update(GameTime gameTime)
        {
            foreach (GameObject child in Children)
            {
                child.Update(gameTime);
                child.World = Matrix.Identity;
                child.World *= Matrix.CreateScale(1, child.Size.Y * 2, 1);
            }

            Children[0].World *= Matrix.CreateTranslation(new Vector3(0, 0, Children[0].Size.Z / 2f));
            Children[1].World *= Matrix.CreateRotationY(MathHelper.ToRadians(90));
            Children[1].World *= Matrix.CreateTranslation(new Vector3(0, 0, -Children[0].Size.Z / 2f));

            foreach (GameObject child in Children)
                child.World *= World;

            base.Update(gameTime);
        }
    }
}
