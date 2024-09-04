using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Minecraft.GameObjects.Primitives;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace Minecraft.GameObjects.Character
{
    public abstract class Character : GameObject
    {
        public enum STATE
        {
            FRONT,
            BACK,
            LEFT,
            RIGHT,
            IDLE,
        }

        protected STATE state;
        protected float speed;

        float angle;
        float rotationSpeed;

        public Character(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Color color, bool colliderVisible = true) 
            : base(game, position, rotation, scale, new Vector3(1, 3, 1), colliderVisible)
        {
            children.Add(new Cube(game, new Vector3(0, 1.25f, 0), Vector3.Zero, new Vector3(1, 1, 1), Vector3.One, Color.DarkRed, false));
            children.Add(new Cube(game, new Vector3(0, 0, 0),    Vector3.Zero, new Vector3(1, 1.5f, .7f), Vector3.One, color, false));
            children.Add(new Cube(game, new Vector3(-.78f, 0, 0), Vector3.Zero, new Vector3(.5f, 1.5f, .5f), Vector3.One, Color.DarkOliveGreen, false));
            children.Add(new Cube(game, new Vector3( .78f, 0, 0), Vector3.Zero, new Vector3(.5f, 1.5f, .5f), Vector3.One, Color.DarkOliveGreen, false));
            children.Add(new Cube(game, new Vector3(-.25f, -1.75f, 0), Vector3.Zero, new Vector3(.5f, 2f, .5f), Vector3.One, Color.DarkBlue, false));
            children.Add(new Cube(game, new Vector3(.25f, -1.75f, 0), Vector3.Zero, new Vector3(.5f, 2f, .5f), Vector3.One, Color.DarkBlue, false));

            state = STATE.IDLE;
            speed = 2f;
            rotationSpeed = 50f;
        }

        public override void Update(GameTime gameTime)
        {
            angle += rotationSpeed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
            children[0].SetRotationY(45f * (float)Math.Sin(MathHelper.ToRadians(angle)));
            children[2].SetRotationX(45f * (float)Math.Sin(MathHelper.ToRadians(angle)));
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
                case STATE.FRONT:
                    rotation = new Vector3(0, 0, 0);
                    position.Z += speed * gt.ElapsedGameTime.Milliseconds * 0.001f;
                    break;
                case STATE.BACK:
                    rotation = new Vector3(0, 180, 0);
                    position.Z -= speed * gt.ElapsedGameTime.Milliseconds * 0.001f;
                    break;
                case STATE.LEFT:
                    rotation = new Vector3(0, 270, 0);
                    position.X -= speed * gt.ElapsedGameTime.Milliseconds * 0.001f;
                    break;
                case STATE.RIGHT:
                    rotation = new Vector3(0, 90, 0);
                    position.X += speed * gt.ElapsedGameTime.Milliseconds * 0.001f;
                    break;
                case STATE.IDLE:
                    break;
            }
        }

        protected virtual void ChangeState(GameTime gt)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.U)) state = STATE.FRONT;
            else if (Keyboard.GetState().IsKeyDown(Keys.J)) state = STATE.BACK;
            else if (Keyboard.GetState().IsKeyDown(Keys.H)) state = STATE.LEFT;
            else if (Keyboard.GetState().IsKeyDown(Keys.K)) state = STATE.RIGHT;
            else state = STATE.IDLE;
        }
    }
}
