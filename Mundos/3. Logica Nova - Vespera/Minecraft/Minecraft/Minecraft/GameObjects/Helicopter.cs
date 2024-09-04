using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Minecraft.GameObjects.Windmill;
using Minecraft.GameObjects.Primitives;
using Microsoft.Xna.Framework.Input;

namespace Minecraft.GameObjects
{
    public enum STATE
    { 
        UP,
        DOWN,
        LEFT,
        RIGHT,
        ROTATE_RIGHT,
        ROTATE_LEFT,
        IDLE,
    }

    class Helicopter : GameObject
    {
        STATE state, previousState;
        float speed, rotationSpeed;

        float timer;
        const float INTERVAL = 1f;

        GameObject home, destination;
        bool atHome;

        public Helicopter(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Color bodyColor, Color propellerColor, GameObject home, GameObject destination, bool colliderVisible = true) 
            : base(game, position, rotation, scale, new Vector3(1, 1, 1), colliderVisible)
        {
            children.Add(new Cube(game, new Vector3(0, 0, 0), Vector3.Zero, new Vector3(1, 1, 1), Vector3.One, bodyColor, false));
            children.Add(new Cube(game, new Vector3(0, 0, -1), Vector3.Zero, new Vector3(.5f, .5f, 1.5f), Vector3.One, bodyColor, false));
            children.Add(new Propeller(game, new Vector3(0, .6f, 0), new Vector3(90, 0, 0), new Vector3(1, 1, 1), propellerColor, true, false));
            children.Add(new Propeller(game, new Vector3(-.3f, 0, -1.7f), new Vector3(0, 90, 0), new Vector3(.3f, .3f, 1), propellerColor, true, false));

            previousState = state = STATE.IDLE;
            speed = 2f;
            rotationSpeed = 50f;

            this.home = home;
            this.destination = destination;
            atHome = false;
        }

        public override void Update(GameTime gameTime)
        {
            UpdateState(gameTime);
            ChangeState(gameTime);
            base.Update(gameTime);
        }

        // CASO QUEIRA INTENCIONALMENTE FAZER O HELICOPTERO GIRAR COM O PIVOT FORA DELE MESMO, BASTA DAR UM OVERRIDE NO CREATEMATRIX() E ALTERAR A ORDEM DAS TRANSFORMACOES COM A ROTACAO APOS A TRANSLACAO
        //protected override void CreateMatrix()
        //{
        //    world = Matrix.Identity;
        //    //world *= Matrix.CreateScale(scale);
        //    world *= Matrix.CreateTranslation(position);
        //    world *= Matrix.CreateFromYawPitchRoll(MathHelper.ToRadians(rotation.Y), MathHelper.ToRadians(rotation.X), MathHelper.ToRadians(rotation.Z));

        //    //base.CreateMatrix();
        //}

        void UpdateState(GameTime gt)
        {
            switch (state)
            {
                case STATE.UP:
                    position.Y += speed * gt.ElapsedGameTime.Milliseconds * 0.001f;
                    break;
                case STATE.DOWN:
                    position.Y -= speed * gt.ElapsedGameTime.Milliseconds * 0.001f;
                    break;
                case STATE.LEFT:
                    position.X -= speed * gt.ElapsedGameTime.Milliseconds * 0.001f;
                    break;
                case STATE.RIGHT:
                    position.X += speed * gt.ElapsedGameTime.Milliseconds * 0.001f;
                    break;
                case STATE.ROTATE_RIGHT:
                    rotation.Y += rotationSpeed * gt.ElapsedGameTime.Milliseconds * 0.001f;
                    break;
                case STATE.ROTATE_LEFT:
                    rotation.Y -= rotationSpeed * gt.ElapsedGameTime.Milliseconds * 0.001f;
                    break;
                case STATE.IDLE:
                    break;
            }
        }

        void ChangeState(GameTime gt)
        {
            //if (Keyboard.GetState().IsKeyDown(Keys.U)) state = STATE.UP;
            //else if (Keyboard.GetState().IsKeyDown(Keys.J)) state = STATE.DOWN;
            //else if (Keyboard.GetState().IsKeyDown(Keys.H)) state = STATE.LEFT;
            //else if (Keyboard.GetState().IsKeyDown(Keys.K)) state = STATE.RIGHT;
            //else if (Keyboard.GetState().IsKeyDown(Keys.I)) state = STATE.ROTATE_RIGHT;
            //else if (Keyboard.GetState().IsKeyDown(Keys.Y)) state = STATE.ROTATE_LEFT;
            //else state = STATE.IDLE;

            switch (state)
            {
                case STATE.UP:
                    if (atHome && position.Y >= destination.GetDimension().Y * 3)
                    {
                        state = STATE.ROTATE_RIGHT;
                        previousState = STATE.UP;
                    }
                    else if (!atHome && position.Y >= destination.GetDimension().Y * 3)
                    {
                        state = STATE.ROTATE_LEFT;
                        previousState = STATE.UP;
                    }
                    break;
                case STATE.DOWN:
                    if (this.GetCollider().Intersects(destination.GetCollider()) || this.GetCollider().Intersects(home.GetCollider()))
                    {
                        previousState = STATE.DOWN;
                        state = STATE.IDLE;
                    }
                    break;
                case STATE.LEFT:
                    if (position.X <= home.GetPosition().X)
                    {
                        state = STATE.ROTATE_RIGHT;
                        previousState = STATE.LEFT;
                    }
                    break;
                case STATE.RIGHT:
                    if (position.X >= destination.GetPosition().X)
                    {
                        state = STATE.ROTATE_LEFT;
                        previousState = STATE.RIGHT;
                    }
                    break;
                case STATE.ROTATE_RIGHT:
                    if (previousState == STATE.UP && rotation.Y >= 90)
                    {
                        state = STATE.RIGHT;
                        previousState = STATE.ROTATE_RIGHT;
                    }
                    else if (previousState == STATE.LEFT && rotation.Y >= 0)
                    {
                        state = STATE.DOWN;
                        previousState = STATE.ROTATE_RIGHT;
                    }
                    break;
                case STATE.ROTATE_LEFT:
                    if (previousState == STATE.RIGHT && rotation.Y <= 0)
                    {
                        state = STATE.DOWN;
                        previousState = STATE.ROTATE_LEFT;
                    }
                    if (previousState == STATE.UP && rotation.Y <= -90)
                    {
                        state = STATE.LEFT;
                        previousState = STATE.ROTATE_LEFT;
                    }
                    break;
                case STATE.IDLE:
                    ((Propeller)children[2]).SetWorking(false);
                    ((Propeller)children[3]).SetWorking(false);
                    timer += gt.ElapsedGameTime.Milliseconds * 0.001f;
                    if (timer >= INTERVAL)
                    {
                        atHome = !atHome;
                        previousState = STATE.IDLE;
                        state = STATE.UP;
                        timer = 0;
                        ((Propeller)children[2]).SetWorking(true);
                        ((Propeller)children[3]).SetWorking(true);
                    }
                    break;
            }
        }
    }
}
