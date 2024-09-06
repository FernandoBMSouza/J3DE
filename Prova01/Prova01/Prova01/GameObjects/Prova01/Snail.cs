using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Prova01.GameObjects.Shapes;
using Microsoft.Xna.Framework.Input;

namespace Prova01.GameObjects.Prova01
{
    class Snail : GameObject
    {
        public enum STATE
        { 
            IDLE,
            FRONT,
            ROTATE,
        }

        STATE state;
        Vector3 forward;
        float speed, rotationSpeed;
        const float TARGET_ANGLE = 90;
        float angle;
        int places = 0;

        public Snail(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Color color, bool colliderVisible = true)
            : base(game, position, rotation, scale, colliderVisible)
        {
            SetSize(new Vector3(1,1,1));
            children.Add(new Cube(game, new Vector3(0, .5f, 0), Vector3.Zero, new Vector3(1, 1, 1), color, false));
            children.Add(new Cube(game, new Vector3(0, -.25f, 0), Vector3.Zero, new Vector3(.5f, .5f, 2f), Color.LightSalmon, false));

            state = STATE.FRONT;
            speed = 10f;
            rotationSpeed = 200;
        }

        public override void Update(GameTime gameTime)
        {
            UpdateState(gameTime);
            ChangeState();
            base.Update(gameTime);
        }

        public void UpdateState(GameTime gameTime)
        {
            // Calcula o vetor de frente baseado na rotação em torno do eixo Y (yaw)
            forward = new Vector3((float)Math.Sin(MathHelper.ToRadians(GetRotation().Y)), 
                                  0,
                                  (float)Math.Cos(MathHelper.ToRadians(GetRotation().Y)));
            switch (state)
            {
                case STATE.IDLE:
                    break;
                case STATE.FRONT:
                    AddPosition(forward * speed * gameTime.ElapsedGameTime.Milliseconds * 0.001f);
                    break;
                case STATE.ROTATE:
                    angle += rotationSpeed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
                    //AddPosition(forward * speed * gameTime.ElapsedGameTime.Milliseconds * 0.001f);
                    AddRotation(new Vector3(0, rotationSpeed * gameTime.ElapsedGameTime.Milliseconds * 0.001f, 0));
                    break;
            }
        }

        public void ChangeState()
        {
            switch (state)
            {
                case STATE.IDLE:
                    break;
                case STATE.FRONT:
                    places %= 4;
                    switch (places)
                    { 
                        case 0:
                            if (GetPosition().X <= -26)
                            {
                                state = STATE.ROTATE;
                                places++;
                            }
                            break;
                        case 1:
                            if (GetPosition().Z >= 12)
                            {
                                state = STATE.ROTATE;
                                places++;
                            }
                            break;
                        case 2:
                            if (GetPosition().X >= 26)
                            {
                                state = STATE.ROTATE;
                                places++;
                            }
                            break;
                        case 3:
                            if (GetPosition().Z <= -12)
                            {
                                state = STATE.ROTATE;
                                places++;
                            }
                            break;
                    };
                    break;
                case STATE.ROTATE:
                    if (angle >= TARGET_ANGLE)
                    {
                        angle = 0;
                        state = STATE.FRONT;
                    }
                    break;
            }

            //if (Keyboard.GetState().IsKeyDown(Keys.U)) state = STATE.FRONT;
            //else if (Keyboard.GetState().IsKeyDown(Keys.Y)) state = STATE.ROTATE;
            //else state = STATE.IDLE;
        }
    }
}
