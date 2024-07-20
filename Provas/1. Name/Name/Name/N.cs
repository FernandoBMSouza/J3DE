using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Name
{
    public class N : Letter
    {
        public N(Game1 game, GraphicsDevice device)
            : base(game, device)
        {
            Pieces = new GameObject[13];
            for (int i = 0; i < 11; i++) Pieces[i] = new Cube(game, device);
            for (int i = 11; i < Pieces.Length; i++) Pieces[i] = new Triangle(game, device);

            // CUBES
            Pieces[0].Position = new Vector3(-2, 4, 0);
            Pieces[1].Position = new Vector3(-2, 2, 0);
            Pieces[2].Position = new Vector3(-2, 0, 0);
            Pieces[3].Position = new Vector3(-2, -2, 0);
            Pieces[4].Position = new Vector3(-2, -4, 0);

            Pieces[5].Position = new Vector3(2, 4, 0);
            Pieces[6].Position = new Vector3(2, 2, 0);
            Pieces[7].Position = new Vector3(2, 0, 0);
            Pieces[8].Position = new Vector3(2, -2, 0);
            Pieces[9].Position = new Vector3(2, -4, 0);

            Pieces[10].Position = new Vector3(0, 0, 0);

            // TRIANGLES
            Pieces[11].Position = new Vector3(0, 3, 0);
            Pieces[11].Scale = new Vector3(1, 2, 1);
            Pieces[12].Position = new Vector3(0, -3, 0);
            Pieces[12].Rotation = new Vector3(0, 0, 180);
            Pieces[12].Scale = new Vector3(1, 2, 1);
        }
    }
}
