using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Minecraft.GameObjects.Shapes;
using Microsoft.Xna.Framework.Input;

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

        private Vector3 oldPosition;

        public Character(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Color color, bool colliderVisible = true)
            : base(game, position, rotation, scale, colliderVisible)
        {
            SetSize(new Vector3(1, 3, 1));

            children.Add(new Cube(game, new Vector3(0, 1.25f, 0), Vector3.Zero, new Vector3(1, 1, 1), color, false));
            children.Add(new Cube(game, new Vector3(0, 0, 0), Vector3.Zero, new Vector3(1, 1.5f, .7f), Color.LightBlue, false));
            children.Add(new Cube(game, new Vector3(-.78f, 0, 0), Vector3.Zero, new Vector3(.5f, 1.5f, .5f), Color.DarkOliveGreen, false));
            children.Add(new Cube(game, new Vector3(.78f, 0, 0), Vector3.Zero, new Vector3(.5f, 1.5f, .5f), Color.DarkOliveGreen, false));
            children.Add(new Cube(game, new Vector3(-.25f, -1.75f, 0), Vector3.Zero, new Vector3(.5f, 2f, .5f), Color.DarkBlue, false));
            children.Add(new Cube(game, new Vector3(.25f, -1.75f, 0), Vector3.Zero, new Vector3(.5f, 2f, .5f), Color.DarkBlue, false));


            state = STATE.IDLE;
            speed = 2f;
            rotationSpeed = speed * 100f;
            children[2].SetPivot(new Vector3(0, .7f, 0));
            children[3].SetPivot(new Vector3(0, .7f, 0));
            children[4].SetPivot(new Vector3(0, .7f, 0));
            children[5].SetPivot(new Vector3(0, .7f, 0));

            oldPosition = GetPosition();
        }

        public override void Update(GameTime gameTime)
        {
            oldPosition = GetPosition();

            if (state != STATE.IDLE) angle += rotationSpeed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
            // rotacao da cabeca
            children[0].SetRotation(new Vector3(0, 30f * (float)Math.Sin(MathHelper.ToRadians(angle)), 0));
            // rotacao dos membros
            children[2].SetRotation(new Vector3(45f * (float)Math.Sin(MathHelper.ToRadians(angle)), 0, 0));
            children[3].SetRotation(new Vector3(-(45f * (float)Math.Sin(MathHelper.ToRadians(angle))), 0, 0));
            children[4].SetRotation(new Vector3(-(45f * (float)Math.Sin(MathHelper.ToRadians(angle))), 0, 0));
            children[5].SetRotation(new Vector3(45f * (float)Math.Sin(MathHelper.ToRadians(angle)), 0, 0));

            UpdateState(gameTime);
            ChangeState(gameTime);
            base.Update(gameTime);
        }

        public void RestorePosition()
        {
            SetPosition(oldPosition);
            angle = 0;
        }


        void UpdateState(GameTime gt)
        {
            switch (state)
            {
                case STATE.FRONT:
                    SetRotation(Vector3.Zero);
                    AddPosition(new Vector3(0,0, speed * gt.ElapsedGameTime.Milliseconds * 0.001f));
                    break;
                case STATE.BACK:
                    SetRotation(new Vector3(0, 180, 0));
                    AddPosition(new Vector3(0, 0, -(speed * gt.ElapsedGameTime.Milliseconds * 0.001f)));
                    break;
                case STATE.LEFT:
                    SetRotation(new Vector3(0, 270, 0));
                    AddPosition(new Vector3((speed * gt.ElapsedGameTime.Milliseconds * 0.001f), 0, 0));
                    break;
                case STATE.RIGHT:
                    SetRotation(new Vector3(0, 90, 0));
                    AddPosition(new Vector3(-(speed * gt.ElapsedGameTime.Milliseconds * 0.001f), 0, 0));
                    break;
                case STATE.IDLE:
                    angle = 0;
                    break;
            }
        }

        protected virtual void ChangeState(GameTime gt)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W)) state = STATE.FRONT;
            else if (Keyboard.GetState().IsKeyDown(Keys.S)) state = STATE.BACK;
            else if (Keyboard.GetState().IsKeyDown(Keys.A)) state = STATE.LEFT;
            else if (Keyboard.GetState().IsKeyDown(Keys.D)) state = STATE.RIGHT;
            else state = STATE.IDLE;
        }
    }
}
