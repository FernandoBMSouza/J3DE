using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Name.GameObjects.Primitives;
using Microsoft.Xna.Framework;

namespace Name.GameObjects.Name.Letters
{
    class E : GameObject
    {
        public E(Game1 game, Color color, Color colorBorder, bool showColliderLines = false)
            : base(game, showColliderLines)
        {
            Children = new GameObject[10];
            for (int i = 0; i < Children.Length; i++)
                Children[i] = new Cube(game, color, colorBorder, showColliderLines);

            Size = new Vector3(Children[0].Size.X * 3, Children[0].Size.Y * 5, Children[0].Size.Z);
        }

        public override void Update(GameTime gameTime)
        {
            foreach (GameObject child in Children)
            {
                child.Update(gameTime);
                child.World = Matrix.Identity;
            }

            Children[0].World *= Matrix.CreateTranslation(new Vector3(Children[0].Size.Y * -1, Children[0].Size.Y * 0, 0));
            Children[1].World *= Matrix.CreateTranslation(new Vector3(Children[1].Size.Y * -1, Children[1].Size.Y * 1, 0));
            Children[2].World *= Matrix.CreateTranslation(new Vector3(Children[2].Size.Y * -1, Children[2].Size.Y * 2, 0));
            Children[3].World *= Matrix.CreateTranslation(new Vector3(Children[3].Size.Y * -1, Children[3].Size.Y * -1, 0));
            Children[4].World *= Matrix.CreateTranslation(new Vector3(Children[4].Size.Y * -1, Children[4].Size.Y * -2, 0));

            Children[5].World *= Matrix.CreateTranslation(new Vector3(0, 0, 0));

            Children[6].World *= Matrix.CreateTranslation(new Vector3(Children[6].Size.Y * 0, Children[6].Size.Y * 2f, 0));
            Children[7].World *= Matrix.CreateTranslation(new Vector3(Children[7].Size.Y * 1, Children[7].Size.Y * 2f, 0));

            Children[8].World *= Matrix.CreateTranslation(new Vector3(Children[8].Size.Y * 0, Children[8].Size.Y * -2f, 0));
            Children[9].World *= Matrix.CreateTranslation(new Vector3(Children[9].Size.Y * 1, Children[9].Size.Y * -2f, 0));


            foreach (GameObject child in Children)
                child.World *= World;

            base.Update(gameTime);
        }
    }
}
