using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Dorgas.GameObjects.ShapesTexture;

namespace Dorgas.GameObjects.Drogas
{
    public class Mushroom : GameObject
    {
        public Mushroom(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Texture2D texture, Effect effect, bool colliderVisible = true)
            : base(game, position, rotation, scale, colliderVisible)
        {
            SetSize(new Vector3(1, 2, 1));

            children.Add(new CubeTexture(game, new Vector3(0, .5f, 0), new Vector3(0, 0, 0), new Vector3(2, .5f, 2), effect, texture, false));
            children.Add(new CubeTexture(game, new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(1, 1, 1), effect, texture, false));
        }
    }
}
