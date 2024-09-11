using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Estudo.GameObjects.Mine
{
    public class Player : Character
    {

        public Player(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Effect effect, Texture2D texture, bool colliderVisible = true)
            : base(game, position, rotation, scale, texture, effect, colliderVisible)
        {
            speed = 15f;
        }
    }
}
