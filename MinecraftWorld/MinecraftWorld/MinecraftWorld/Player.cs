using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MinecraftWorld
{
    class Player : Character
    {
        public Player(GraphicsDevice device)
            : base(device)
        {
            moveSpeed = 8;
        }

        protected override void ChangeState(GameTime gameTime)
        {
            if(Keyboard.GetState().IsKeyDown(Keys.W))
            {
                state = STATE.FRONT;
            }
            else if(Keyboard.GetState().IsKeyDown(Keys.S))
            {
                state = STATE.BACK;
            }
            else if(Keyboard.GetState().IsKeyDown(Keys.A))
            {
                state = STATE.LEFT;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
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
