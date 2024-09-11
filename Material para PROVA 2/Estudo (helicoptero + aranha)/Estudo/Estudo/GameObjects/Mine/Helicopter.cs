using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Estudo.GameObjects.ShapesTexture;
using Estudo.GameObjects.Windmill;

namespace Estudo.GameObjects.Mine
{
    public class Helicopter : Character    
    {
        STATE previousState;

        public Helicopter(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Effect effect, Texture2D texture, Texture2D propellerTexture, bool colliderVisible = true)
            : base(game, position, rotation, scale, texture, effect, colliderVisible)
        {
            SetSize(new Vector3(1,1,1));
            speed = 5f;
            state = previousState = STATE.IDLE;

            children.Add(new CubeTexture(game, new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(1, 1, 1), effect, texture, false));
            children.Add(new CubeTexture(game, new Vector3(0, 0, -1.2f), new Vector3(0, 0, 0), new Vector3(.5f, .5f, 1.5f), effect, texture, false));
            children.Add(new Propeller(game, new Vector3(-.3f, 0,-2), new Vector3(0, 90, 0), new Vector3(.3f), effect, propellerTexture, true, false));
            children.Add(new Propeller(game, new Vector3(0, .6f, 0), new Vector3(90, 0, 0), new Vector3(1, 1, 1), effect, propellerTexture, true, false));
        }


        protected override void ChangeState(GameTime gt)
        {
            switch (state)
            {
                case STATE.FRONT:
                    if (GetPosition().X <= -25 || GetPosition().X >= 25)
                    {
                        previousState = state;
                        state = STATE.DOWN;
                    }
                    break;
                case STATE.BACK:
                    break;
                case STATE.LEFT:
                    if (GetPosition().X <= -25)
                    {
                        previousState = state;
                        state = STATE.FRONT;
                    }
                    break;
                case STATE.RIGHT:
                    if (GetPosition().X >= 25)
                    {
                        previousState = state;
                        state = STATE.FRONT;
                    }
                    break;
                case STATE.IDLE:
                    previousState = state;
                    state = STATE.UP;
                    break;
                case STATE.UP:
                    if (GetPosition().Y >= 25)
                    {
                        previousState = state;

                        if (GetPosition().X <= 0) state = STATE.RIGHT;
                        else if (GetPosition().X > 0) state = STATE.LEFT;
                    }
                    break;
                case STATE.DOWN:
                    if (GetPosition().X >= 0)
                    {
                        previousState = state;

                        if (GetPosition().Y <= 11)
                            state = STATE.IDLE;
                    }
                    else if (GetPosition().X < 0)
                    {
                        previousState = state;

                        if (GetPosition().Y <= 6)
                            state = STATE.IDLE;
                    }
                    break;
            }
        }
    }
}
