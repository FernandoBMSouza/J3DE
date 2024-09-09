using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Minecraft.GameObjects.Windmill
{
    class Windmill : GameObject
    {
        public Windmill(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Color buildingColor, Color propellerColor, Effect effect, bool colliderVisible = true)
            : base(game, position, rotation, scale, colliderVisible)
        {
            SetSize(new Vector3(1,2,2.3f));

            children.Add(new Building(game, new Vector3(0, 0, 0), Vector3.Zero, new Vector3(1, 1, 1), buildingColor, effect, false));
            children.Add(new Propeller(game, new Vector3(0, .3f, 1.1f), new Vector3(0, 0, 0), new Vector3(.8f, .8f, 1), propellerColor, effect, true, false));
        }

        public Windmill(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Effect effect, Texture2D buidingTexture, Texture2D propellerTexture, bool colliderVisible = true)
            : base(game, position, rotation, scale, colliderVisible)
        {
            SetSize(new Vector3(1,2,2.3f));

            children.Add(new Building(game, new Vector3(0, 0, 0), Vector3.Zero, new Vector3(1, 1, 1), effect, buidingTexture, false));
            children.Add(new Propeller(game, new Vector3(0, .3f, 1.1f), new Vector3(0, 0, 0), new Vector3(.8f, .8f, 1), effect, propellerTexture, true, false));
        }
    }
}
