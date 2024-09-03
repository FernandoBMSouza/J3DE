using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mundo03.GameObjects.Windmill
{
    class Windmill : GameObject
    {
        public Windmill(Game1 game, Texture2D buildingTexture, Texture2D propellerTexture, bool showColliderLines = false)
            : base(game, showColliderLines)
        {
            Children = new GameObject[]
            {
                new Building(game, buildingTexture),
                new Propeller(game, propellerTexture),
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

            Children[1].World *= Matrix.CreateTranslation(new Vector3(0, Children[1].Size.Y / 4f, Children[0].Size.Z / 2 + .07f));

            foreach (GameObject child in Children)
                child.World *= World;

            base.Update(gameTime);
        }
    }
}
