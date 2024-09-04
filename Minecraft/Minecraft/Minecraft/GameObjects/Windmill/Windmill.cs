using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Minecraft.GameObjects.Windmill
{
    class Windmill : GameObject
    {
        public Windmill(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Color buildingColor, Color propellerColor, bool colliderVisible = true)
            : base(game, position, rotation, scale, new Vector3(.5f, 1, .1f), colliderVisible)
        {
            children.Add(new Building(game, new Vector3(0, 0, 0), Vector3.Zero, new Vector3(1, 1, 1), buildingColor, colliderVisible));
            children.Add(new Propeller(game, new Vector3(0, .3f, 1.1f), new Vector3(0, 0, 0), new Vector3(.8f, .8f, 1), propellerColor, true, colliderVisible));
        }
    }
}
