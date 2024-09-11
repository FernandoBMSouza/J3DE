using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Estudo.GameObjects.Shapes;
using Estudo.Utilities.Collision;
using Microsoft.Xna.Framework.Graphics;
using Estudo.GameObjects.ShapesTexture;

namespace Estudo.GameObjects.Windmill
{
    public class Blade : GameObject
    {
        // Sem Texturas
        public Blade(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Color color, Effect effect, bool colliderVisible = true)
            : base(game, position, rotation, scale, colliderVisible)
        {
            SetSize(new Vector3(.5f, 1, .1f));

            children.Add(new Cube(game, new Vector3(0, .25f, 0), Vector3.Zero, new Vector3(.5f, .5f, .05f), color, effect, false));
            children.Add(new Triangle3D(game, new Vector3(0, -.25f, 0), new Vector3(0, 0, 180), new Vector3(.5f, .5f, .05f), color, effect, false));
        }

        // Com Texturas
        public Blade(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Effect effect, Texture2D texture, bool colliderVisible = true)
            : base(game, position, rotation, scale, colliderVisible)
        {
            SetSize(new Vector3(.5f, 1, .1f));

            children.Add(new CubeTexture(game, new Vector3(0, .25f, 0), Vector3.Zero, new Vector3(.5f, .5f, .05f), effect, texture, false));
            children.Add(new Triangle3DTexture(game, new Vector3(0, -.25f, 0), new Vector3(0, 0, 180), new Vector3(.5f, .5f, .05f), effect, texture, false));
        }
    }
}
