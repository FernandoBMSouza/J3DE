using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Minecraft
{
    class Player : Character
    {
        public Player(Game1 game, GraphicsDevice device)
            : base(game, device, game.Content.Load<Texture2D>(@"Images\steve"))
        {
            moveSpeed = 8;
        }

        protected override void ChangeState(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                state = STATE.FRONT;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                state = STATE.BACK;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                state = STATE.LEFT;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                state = STATE.RIGHT;
            }
            else
            {
                state = STATE.IDLE;
            }
        }
    }
}
