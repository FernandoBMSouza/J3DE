using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Name
{
    public class E : Letter
    {
        public E(Game1 game, GraphicsDevice device)
            : base(game, device)
        {
            Pieces = new Cube[10];
            for (int i = 0; i < Pieces.Length; i++)
                Pieces[i] = new Cube(game, device);

            Pieces[0].Position = new Vector3(-2, 4, 0);
            Pieces[1].Position = new Vector3(-2, 2, 0);
            Pieces[2].Position = new Vector3(-2, 0, 0);
            Pieces[3].Position = new Vector3(-2, -2, 0);
            Pieces[4].Position = new Vector3(-2, -4, 0);

            Pieces[5].Position = new Vector3(0, 4, 0);
            Pieces[6].Position = new Vector3(2, 4, 0);

            Pieces[7].Position = new Vector3(0, 0, 0);

            Pieces[8].Position = new Vector3(0, -4, 0);
            Pieces[9].Position = new Vector3(2, -4, 0);
        }
    }
}
