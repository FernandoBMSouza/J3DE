using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Estudo.GameObjects.Mine.BodyParts;

namespace Estudo.GameObjects.Mine
{
    public class Spider : Character
    {
        STATE previousState;
        Helicopter helicopter;

        public Spider(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Effect effect, Texture2D texture, Helicopter helicopter, bool colliderVisible = true)
            : base(game, position, rotation, scale, texture, effect, colliderVisible)
        {
            SetSize(new Vector3(3,1,4));
            speed = 10f;
            state = previousState = STATE.LEFT;
            this.helicopter = helicopter;

            children.Add(new Head(game, new Vector3(0, 0, .5f), Vector3.Zero, new Vector3(1, 1, 1), effect, texture, false));
            children.Add(new Body(game, new Vector3(0, 0, -1.5f), new Vector3(90, 0, 0), new Vector3(1, 3, 1), effect, texture, false));

            children.Add(new Arm(game, new Vector3(1.5f, 0, 0), new Vector3(0, 0, 25), new Vector3(.5f, 3, .5f), effect, texture, false));
            children.Add(new Arm(game, new Vector3(.7f, 1, 0), new Vector3(0, 0, 45), new Vector3(1f, .5f, .5f), effect, texture, false));

            children.Add(new Arm(game, new Vector3(-1.5f, 0, 0), new Vector3(0, 0, -25), new Vector3(.5f, 3, .5f), effect, texture, false));
            children.Add(new Arm(game, new Vector3(-.7f, 1, 0), new Vector3(0, 0, -45), new Vector3(1f, .5f, .5f), effect, texture, false));

            children.Add(new Arm(game, new Vector3(1.5f, 0, -2), new Vector3(0, 0, 25), new Vector3(.5f, 3, .5f), effect, texture, false));
            children.Add(new Arm(game, new Vector3(.7f, 1, -2), new Vector3(0, 0, 45), new Vector3(1f, .5f, .5f), effect, texture, false));

            children.Add(new Arm(game, new Vector3(-1.5f, 0, -2), new Vector3(0, 0, -25), new Vector3(.5f, 3, .5f), effect, texture, false));
            children.Add(new Arm(game, new Vector3(-.7f, 1, -2), new Vector3(0, 0, -45), new Vector3(1f, .5f, .5f), effect, texture, false));


            children[2].SetPivot(new Vector3(0, 1, 0));
            children[4].SetPivot(new Vector3(0, 1, 0));
            children[6].SetPivot(new Vector3(0, 1, 0));
            children[8].SetPivot(new Vector3(0, 1, 0));

        }

        public override void Update(GameTime gameTime)
        {
            if (state != STATE.IDLE) angle += rotationSpeed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
            // rotacao da cabeca
            //children[0].SetRotation(new Vector3(0, 30f * (float)Math.Sin(MathHelper.ToRadians(angle)), 0));
            // rotacao dos membros
            children[2].SetRotation(new Vector3(45f * (float)Math.Sin(MathHelper.ToRadians(angle)), 0, 25));
            children[4].SetRotation(new Vector3(-45f * (float)Math.Sin(MathHelper.ToRadians(angle)), 0, -25));
            children[6].SetRotation(new Vector3(45f * (float)Math.Sin(MathHelper.ToRadians(angle)), 0, 25));
            children[8].SetRotation(new Vector3(-45f * (float)Math.Sin(MathHelper.ToRadians(angle)), 0, -25));

            base.Update(gameTime);
        }

        protected override void ChangeState(GameTime gt)
        {
            switch (state)
            {
                case STATE.FRONT:
                    if (GetPosition().Z >= 25)
                    {
                        previousState = state;
                        state = STATE.LEFT;
                    }
                    else if(previousState == STATE.IDLE)
                    {
                        previousState = state;
                        state = STATE.DOWN;
                    }
                    break;
                case STATE.BACK:
                    if (GetPosition().Z <= 0)
                    {
                        previousState = state;
                        state = STATE.UP;
                    }
                    break;
                case STATE.LEFT:
                    if (GetPosition().X <= -25) 
                    {
                        previousState = state;
                        state = STATE.BACK;
                    }
                    break;
                case STATE.RIGHT:
                    if (GetPosition().X >= /*5*/25)
                    {
                        previousState = state;
                        state = STATE.DOWN;
                    }
                    break;
                case STATE.IDLE:
                    previousState = state;
                    if (this.IsColliding(helicopter.GetCollider()))
                    {
                        SetPosition(helicopter.GetPosition());
                        if (GetPosition().X >= 25 && GetPosition().Y <= 11) state = STATE.FRONT;
                    }
                    break;
                case STATE.UP:
                    previousState = state;
                    if (GetPosition().X <= 0)
                    {
                        if(GetPosition().Y > 5)
                            state = STATE.IDLE;
                    }
                    else if (GetPosition().X > 0)
                    {
                        if (GetPosition().Y > 25)
                            state = STATE.IDLE;
                    }
                    break;
                case STATE.DOWN:
                    if (GetPosition().Y <= .5f)
                    {
                        previousState = state;
                        state = STATE.FRONT;
                    }
                    break;
            }
        }
    }
}
