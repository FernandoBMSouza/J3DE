using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Dorgas.GameObjects.Shapes;
using Microsoft.Xna.Framework.Graphics;
using Dorgas.GameObjects.ShapesTexture;

namespace Dorgas.GameObjects.Windmill
{
    public class Building : GameObject
    {
        public Building(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Color color, Effect effect, bool colliderVisible = true)
            : base(game, position, rotation, scale, colliderVisible)
        {
            SetSize(new Vector3(1, 2, 2));

            children.Add(new Cube(game, new Vector3(0, 0, .5f), new Vector3(0, 0, 0), new Vector3(1, 2, 1), color, effect, false));
            children.Add(new RightTriangle3D(game, new Vector3(0, 0, -.5f), new Vector3(0, 90, 0), new Vector3(1, 2, 1), color, effect, false));
        }

         public Building(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Effect effect, Texture2D texture, bool colliderVisible = true)
            : base(game, position, rotation, scale, colliderVisible)
        {
            SetSize(new Vector3(1, 2, 2));

            children.Add(new CubeTexture(game, new Vector3(0, 0, .5f), new Vector3(0, 0, 0), new Vector3(1, 2, 1), effect, texture, false));
            children.Add(new RightTriangle3DTexture(game, new Vector3(0, 0, -.5f), new Vector3(0, 90, 0), new Vector3(1, 2, 1), effect, texture, false));
        }
    }
}
