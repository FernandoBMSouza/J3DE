using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Prova01.GameObjects.Shapes;
using Prova01.Utilities.Collision;
using Microsoft.Xna.Framework.Graphics;

namespace Prova01.GameObjects.Prova01
{
    class Track : GameObject
    {
        public Track(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Color color, bool colliderVisible = true)
            : base(game, position, rotation, scale, colliderVisible)
        {
            SetSize(new Vector3(16, 1, 9));

            children.Add(new Cube(game, new Vector3(0, 0,-3), new Vector3(0, 0, 0), new Vector3(10, 1, 3), color, false));
            children.Add(new Cube(game, new Vector3(0, 0, 3), new Vector3(0, 0, 0), new Vector3(10, 1, 3), color, false));

            children.Add(new Cube(game, new Vector3(-6.5f, 0, 0), new Vector3(0, 0, 0), new Vector3(3, 1, 3f), color, false));
            children.Add(new Cube(game, new Vector3(6.5f, 0, 0), new Vector3(0, 0, 0), new Vector3(3, 1, 3f), color, false));

            children.Add(new RightTriangle3D(game, new Vector3(-6.5f, 0, 3), new Vector3(90, 0, 90), new Vector3(3, 3, 1), color, false));
            children.Add(new RightTriangle3D(game, new Vector3( 6.5f, 0, 3), new Vector3(90, 0, 0), new Vector3(3, 3, 1), color, false));

            children.Add(new RightTriangle3D(game, new Vector3(-6.5f,0,-3), new Vector3(90, 0, 180), new Vector3(3, 3, 1), color, false));
            children.Add(new RightTriangle3D(game, new Vector3( 6.5f,0,-3), new Vector3(90, 0, 270), new Vector3(3, 3, 1), color, false));

            children.Add(new GameObject(game, new Vector3( 0,0,-3), new Vector3(0,0,0), new Vector3(1,3,3), true));
            children.Add(new GameObject(game, new Vector3(-4,0, 3), new Vector3(0,0,0), new Vector3(1,3,3), true));
            children.Add(new GameObject(game, new Vector3( 4,0, 3), new Vector3(0,0,0), new Vector3(1,3,3), true));
        }
    }
}
