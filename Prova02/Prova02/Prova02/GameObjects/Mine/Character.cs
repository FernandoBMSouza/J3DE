using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Prova02.GameObjects.Shapes;
using Microsoft.Xna.Framework.Graphics;
using Prova02.GameObjects.ShapesTexture;
using Prova02.GameObjects.Mine.BodyParts;

namespace Prova02.GameObjects.Mine
{
    public class Character : GameObject
    {
        public enum STATE
        {
            FRONT,
            ROTATE,
            IDLE,
        }

        protected STATE state;
        protected float speed;

        float timer = 0;
        const float INTERVAL = .5f;

        float angle;
        float rotationSpeed;
        Vector3 forward;

        static Random random = new Random(); 

        private Vector3 oldPosition;

        public Character(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Texture2D texture, Texture2D textureAlgodao, Texture2D textureNose, Effect effect, bool colliderVisible = true)
            : base(game, position, rotation, scale, colliderVisible)
        {
            SetSize(new Vector3(1, 6, 1));

            children.Add(new Head(game, new Vector3(0, 2, 0), Vector3.Zero, new Vector3(2, 1, 2), effect, textureAlgodao, false));
            children.Add(new Head(game, new Vector3(0, 2, 1.2f), Vector3.Zero, new Vector3(.5f), effect, textureNose, false));
            children.Add(new Body(game, new Vector3(0, 0, 0), Vector3.Zero, new Vector3(1, 3, 1), effect, texture, false));
            children.Add(new Head(game, new Vector3(0, -2, 0), Vector3.Zero, new Vector3(2, 1, 2), effect, textureAlgodao, false));

            state = STATE.FRONT;
            speed = random.Next(5,11);
            rotationSpeed = speed * 100f;
            //children[2].SetPivot(new Vector3(0, .7f, 0));
            //children[3].SetPivot(new Vector3(0, .7f, 0));
            //children[4].SetPivot(new Vector3(0, .7f, 0));
            //children[5].SetPivot(new Vector3(0, .7f, 0));

            oldPosition = GetPosition();
        }

        public override void Update(GameTime gameTime)
        {
            oldPosition = GetPosition();

            if (state != STATE.IDLE) angle += rotationSpeed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
            // rotacao da cabeca
            //children[0].SetRotation(new Vector3(0, 30f * (float)Math.Sin(MathHelper.ToRadians(angle)), 0));
            // rotacao dos membros
            //children[2].SetRotation(new Vector3(45f * (float)Math.Sin(MathHelper.ToRadians(angle)), 0, 0));
            //children[3].SetRotation(new Vector3(-(45f * (float)Math.Sin(MathHelper.ToRadians(angle))), 0, 0));
            //children[4].SetRotation(new Vector3(-(45f * (float)Math.Sin(MathHelper.ToRadians(angle))), 0, 0));
            //children[5].SetRotation(new Vector3(45f * (float)Math.Sin(MathHelper.ToRadians(angle)), 0, 0));

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
            forward = new Vector3((float)Math.Sin(MathHelper.ToRadians(GetRotation().Y)),
                                  0,
                                  (float)Math.Cos(MathHelper.ToRadians(GetRotation().Y)));
            switch (state)
            {
                case STATE.IDLE:
                    break;
                case STATE.FRONT:
                    AddPosition(forward * speed * gt.ElapsedGameTime.Milliseconds * 0.001f);

                    timer += gt.ElapsedGameTime.Milliseconds * 0.001f;
                    if (timer > INTERVAL)
                    {
                        AddRotation(new Vector3(90, 0, 0));
                        timer = 0;
                    }
                    break;
                case STATE.ROTATE:
                    angle += rotationSpeed * gt.ElapsedGameTime.Milliseconds * 0.001f;
                    AddPosition(forward * speed * gt.ElapsedGameTime.Milliseconds * 0.001f);
                    AddRotation(new Vector3(0, rotationSpeed * gt.ElapsedGameTime.Milliseconds * 0.001f, 0));
                    break;
            }
        }

        protected virtual void ChangeState(GameTime gt)
        {
            switch (state)
            {
                case STATE.FRONT:
                    break;
                case STATE.ROTATE:
                    break;
                case STATE.IDLE:
                    break;
            }

            //if (Keyboard.GetState().IsKeyDown(Keys.U)) state = STATE.FRONT;
            //else if (Keyboard.GetState().IsKeyDown(Keys.Y)) state = STATE.ROTATE;
            //else state = STATE.IDLE;
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

        public void SetState(int state)
        {
            this.state = (STATE)state;
        }
    }
}
