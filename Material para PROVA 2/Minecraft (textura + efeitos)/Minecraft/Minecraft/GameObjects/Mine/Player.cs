using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Minecraft.GameObjects.Mine
{
    public class Player : Character
    {
        public Player(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Color color, Effect effect, bool colliderVisible = true)
            : base(game, position, rotation, scale, color, effect, colliderVisible)
        {
            speed = 15f;
        }

        public Player(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Texture2D texture, Effect effect, bool colliderVisible = true)
            : base(game, position, rotation, scale, texture, effect, colliderVisible)
        {
            speed = 15f;
        }
    }
}
