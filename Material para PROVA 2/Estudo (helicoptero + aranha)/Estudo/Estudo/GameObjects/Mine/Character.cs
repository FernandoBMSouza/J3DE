using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Estudo.GameObjects.Shapes;
using Microsoft.Xna.Framework.Graphics;
using Estudo.GameObjects.ShapesTexture;
using Estudo.GameObjects.Mine.BodyParts;

namespace Estudo.GameObjects.Mine
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
            UP,
            DOWN,
        }

        protected STATE state;
        protected float speed;

        protected float angle;
        protected float rotationSpeed;

        private Vector3 oldPosition;

        public Character(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Texture2D texture, Effect effect, bool colliderVisible = true)
            : base(game, position, rotation, scale, colliderVisible)
        {
            SetSize(new Vector3(1, 1, 1));
            state = STATE.IDLE;
            speed = 2f;
            rotationSpeed = speed * 100f;
            oldPosition = GetPosition();  
        }

        public override void Update(GameTime gameTime)
        {
            oldPosition = GetPosition();
   
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
                    SetRotation(new Vector3(0, 270, 0));
                    AddPosition(new Vector3(-(speed * gt.ElapsedGameTime.Milliseconds * 0.001f), 0, 0));
                    break;
                case STATE.RIGHT:
                    SetRotation(new Vector3(0, 90, 0));
                    AddPosition(new Vector3(+(speed * gt.ElapsedGameTime.Milliseconds * 0.001f), 0, 0));
                    break;
                case STATE.IDLE:
                    angle = 0;
                    break;
                case STATE.UP:
                    AddPosition(new Vector3(0, +(speed * gt.ElapsedGameTime.Milliseconds * 0.001f), 0));
                    break;
                case STATE.DOWN:
                    AddPosition(new Vector3(0, -(speed * gt.ElapsedGameTime.Milliseconds * 0.001f), 0));
                    break;
            }
        }

        protected virtual void ChangeState(GameTime gt)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.U)) state = STATE.FRONT;
            else if (Keyboard.GetState().IsKeyDown(Keys.J)) state = STATE.BACK;
            else if (Keyboard.GetState().IsKeyDown(Keys.K)) state = STATE.LEFT;
            else if (Keyboard.GetState().IsKeyDown(Keys.H)) state = STATE.RIGHT;
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
