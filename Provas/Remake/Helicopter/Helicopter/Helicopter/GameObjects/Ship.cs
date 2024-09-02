using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Helicopter.GameObjects.Primitives;
using Helicopter.GameObjects.Windmill;
using System.Diagnostics;

namespace Helicopter.GameObjects
{
    class Ship : GameObject
    {
        public Ship(Game1 game, Color bodyColor, Color propellerColor, bool showColliderLines = false)
            : base(game, showColliderLines)
        {
            Children = new GameObject[]
            {
                new Cube(game, bodyColor, showColliderLines),
                new Cube(game, bodyColor, showColliderLines),
                new Propeller(game, propellerColor, true, showColliderLines),
                new Propeller(game, propellerColor, true, showColliderLines),
            };
            Size = Children[0].Size;
        }

        public override void Update(GameTime gameTime)
        {
            foreach (GameObject child in Children)
            {
                child.Update(gameTime);
                child.World = Matrix.Identity;
            }

            Children[1].World *= Matrix.CreateScale(new Vector3(.5f, .5f, 1.5f));
            Children[2].World *= Matrix.CreateScale(new Vector3(1.3f, 1.3f, 1));
            Children[3].World *= Matrix.CreateScale(new Vector3(.4f, .4f, 1));

            Children[2].World *= Matrix.CreateRotationX(MathHelper.ToRadians(90));
            Children[3].World *= Matrix.CreateRotationY(MathHelper.ToRadians(90));

            Children[0].World *= Matrix.CreateTranslation(new Vector3(0, 0, 0));
            Children[1].World *= Matrix.CreateTranslation(new Vector3(0, 0, -Children[1].Size.Z - 0.2f));
            Children[2].World *= Matrix.CreateTranslation(new Vector3(0, .6f, 0));
            Children[3].World *= Matrix.CreateTranslation(new Vector3(-.35f, 0, -2));

            foreach (GameObject child in Children)
                child.World *= World;

            base.Update(gameTime);
        }
    }
}
