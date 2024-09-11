using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Dorgas.GameObjects.Shapes;
using Microsoft.Xna.Framework.Graphics;
using Dorgas.GameObjects.ShapesTexture;
using Dorgas.GameObjects.Mine.BodyParts;

namespace Dorgas.GameObjects.Mine
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

        public Character(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Color color, Effect effect, bool colliderVisible = true)
            : base(game, position, rotation, scale, colliderVisible)
        {
            SetSize(new Vector3(1, 3, 1));

            children.Add(new Cube(game, new Vector3(0, 1.25f, 0), Vector3.Zero, new Vector3(1, 1, 1), color, effect, false));
            children.Add(new Cube(game, new Vector3(0, 0, 0), Vector3.Zero, new Vector3(1, 1.5f, .7f), Color.LightBlue, effect, false));
            children.Add(new Cube(game, new Vector3(-.78f, 0, 0), Vector3.Zero, new Vector3(.5f, 1.5f, .5f), Color.DarkOliveGreen, effect, false));
            children.Add(new Cube(game, new Vector3(.78f, 0, 0), Vector3.Zero, new Vector3(.5f, 1.5f, .5f), Color.DarkOliveGreen, effect, false));
            children.Add(new Cube(game, new Vector3(-.25f, -1.75f, 0), Vector3.Zero, new Vector3(.5f, 2f, .5f), Color.DarkBlue, effect, false));
            children.Add(new Cube(game, new Vector3(.25f, -1.75f, 0), Vector3.Zero, new Vector3(.5f, 2f, .5f), Color.DarkBlue, effect, false));


            state = STATE.IDLE;
            speed = 2f;
            rotationSpeed = speed * 100f;
            children[2].SetPivot(new Vector3(0, .7f, 0));
            children[3].SetPivot(new Vector3(0, .7f, 0));
            children[4].SetPivot(new Vector3(0, .7f, 0));
            children[5].SetPivot(new Vector3(0, .7f, 0));

            oldPosition = GetPosition();
        }

        public Character(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Texture2D texture, Effect effect, bool colliderVisible = true)
            : base(game, position, rotation, scale, colliderVisible)
        {
            SetSize(new Vector3(1, 3, 1));

            children.Add(new Head(game, new Vector3(0, 1.25f, 0), Vector3.Zero, new Vector3(1, 1, 1), effect, texture, false));
            children.Add(new Body(game, new Vector3(0, 0, 0), Vector3.Zero, new Vector3(1, 1.5f, .7f), effect, texture, false));
            children.Add(new Arm(game, new Vector3(-.75f, 0, 0), Vector3.Zero, new Vector3(.5f, 1.5f, .5f), effect, texture, false));
            children.Add(new Arm(game, new Vector3(.75f, 0, 0), Vector3.Zero, new Vector3(.5f, 1.5f, .5f), effect, texture, false));
            children.Add(new Leg(game, new Vector3(-.25f, -1.75f, 0), Vector3.Zero, new Vector3(.5f, 2f, .5f), effect, texture, false));
            children.Add(new Leg(game, new Vector3(.25f, -1.75f, 0), Vector3.Zero, new Vector3(.5f, 2f, .5f), effect, texture, false));


            state = STATE.IDLE;
            speed = 2f;
            rotationSpeed = speed * 100f;
            children[2].SetPivot(new Vector3(0, .7f, 0));
            children[3].SetPivot(new Vector3(0, .7f, 0));
            children[4].SetPivot(new Vector3(0, .7f, 0));
            children[5].SetPivot(new Vector3(0, .7f, 0));

            oldPosition = GetPosition();
        }

        public void SetEffect(Effect effect)
        {
            foreach(GameObject child in children)
            {
                ((ShapeTexture)child).SetEffect(effect);
            }
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
                    AddPosition(new Vector3(0, 0, speed * gt.ElapsedGameTime.Milliseconds * 0.001f));
                    break;
                case STATE.BACK:
                    SetRotation(new Vector3(0, 180, 0));
                    AddPosition(new Vector3(0, 0, -(speed * gt.ElapsedGameTime.Milliseconds * 0.001f)));
                    break;
                case STATE.LEFT:
                    SetRotation(new Vector3(0, 90, 0));
                    AddPosition(new Vector3((speed * gt.ElapsedGameTime.Milliseconds * 0.001f), 0, 0));
                    break;
                case STATE.RIGHT:
                    SetRotation(new Vector3(0, 270, 0));
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

        public void HitEffect(Effect effect)
        {
            foreach (GameObject child in children)
            {
                ((ShapeTexture)child).SetEffect(effect);
            }
        }

        public void RestoreEffect(Effect effect)
        {
            foreach (GameObject child in children)
            {
                ((ShapeTexture)child).SetEffect(effect);
            }
        }
    }
}
