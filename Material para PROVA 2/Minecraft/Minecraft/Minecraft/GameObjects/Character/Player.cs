using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Minecraft.GameObjects.Character
{
    public class Player : Character
    {
        public Player(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Color color, bool colliderVisible = true)
            : base(game, position, rotation, scale, color, colliderVisible)
        {
            speed = 10f;
        }
    }
}
