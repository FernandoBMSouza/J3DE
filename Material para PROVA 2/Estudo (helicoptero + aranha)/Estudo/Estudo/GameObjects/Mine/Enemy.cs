using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Estudo.GameObjects.Mine
{
    public class Enemy : Character
    {
        static Random random = new Random();
        const float INTERVAL = 1f;
        float cooldown = 0;

        public Enemy(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Effect effect, Texture2D texture, bool colliderVisible = true)
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
