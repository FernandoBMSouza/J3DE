using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Minecraft.GameObjects.Mine
{
    public class Enemy : Character
    {
        static Random random = new Random();
        const float INTERVAL = 1f;
        float cooldown = 0;

        public Enemy(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Color color, Effect effect, bool colliderVisible = true)
            : base(game, position, rotation, scale, color, effect, colliderVisible)
        {
            state = (STATE)random.Next(4);
        }

        public Enemy(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Texture2D texture, Effect effect, bool colliderVisible = true)
            : base(game, position, rotation, scale, texture, effect, colliderVisible)
        {
            state = (STATE)random.Next(4);
        }

        protected override void ChangeState(GameTime gt)
        {
            cooldown += gt.ElapsedGameTime.Milliseconds * 0.001f;
            if (cooldown >= INTERVAL)
            {
                switch (state)
                {
                    case STATE.FRONT:
                    case STATE.BACK:
                    case STATE.LEFT:
                    case STATE.RIGHT:
                        state = (STATE)random.Next(4);
                        break;
                }
                cooldown = 0;
            }
        }
    }
}
