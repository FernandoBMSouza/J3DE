using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Mundo02.GameObjects.Windmill
{
    class Windmill : GameObject
    {
        public Windmill(Game1 game, Color buildingColor, Color propellerColor)
            : base()
        {
            Children = new GameObject[]
            {
                new Building(game, buildingColor),
                new Propeller(game, propellerColor),
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

            Children[1].World *= Matrix.CreateTranslation(new Vector3(0,Children[1].Size.Y/4f,Children[0].Size.Z/2 + .07f));

            foreach (GameObject child in Children)
                child.World *= World;
        }
    }
}
