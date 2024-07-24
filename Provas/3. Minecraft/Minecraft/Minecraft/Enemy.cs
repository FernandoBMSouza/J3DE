using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Minecraft
{
    class Enemy : Character
    {
        private float currentTime;
        private const float GAP = 1.0f;

        public Enemy(Game1 game)
            : base(game, game.Content.Load<Texture2D>(@"Images\zombie"))
        {
            currentTime = 0;
            state = (STATE)random.Next(1, 5);
        }

        public override void Update(GameTime gameTime)
        {
            oldPosition = Position;
            UpdateState(gameTime);

            currentTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (currentTime >= GAP)
            {
                ChangeState(gameTime);
                currentTime = 0;
            }
        }
    }
}
