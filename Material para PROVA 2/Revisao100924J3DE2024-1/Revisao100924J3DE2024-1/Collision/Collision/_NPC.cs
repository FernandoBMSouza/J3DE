using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Collision
{
    public enum STATE
    {
        FRONT = 0,
        BACK = 1,
        RIGHT = 2,
        LEFT = 3        
    };

    public class _NPC : _Cube
    {
        Vector3 oldPosition;
        float speed;
        STATE state;
        static Random random = new Random();
        float cooldown;
        const float INTERVAL = 1.0f;
        float speedRotY;

        public _NPC(Game game, Vector3 position, Vector3 dimension, Color color, bool visible)
            : base(game, position, dimension, color, visible)
        {
            this.oldPosition = this.position;
            this.speed = 2;
            this.state = (STATE)random.Next(4);
            this.cooldown = INTERVAL;
            this.speedRotY = 0;
        }

        public override void Update(GameTime gt)
        {
            float deltaTime = gt.ElapsedGameTime.Milliseconds * 0.001f;
            this.oldPosition = this.position;

            this.angle += this.speedRotY * gt.ElapsedGameTime.Milliseconds * 0.001f;

            this.cooldown -= deltaTime;
            if (cooldown <= 0)
            {
                this.ChangeState();
                //this.cooldown = INTERVAL;
            }

            this.UpdateState(gt);

            this.SetPosition(this.position);
            base.Update(gt);
        }

        public void RestorePosition()
        {
            this.position = this.oldPosition;
        }

        private void UpdateState(GameTime gt)
        {
            float deltaTime = gt.ElapsedGameTime.Milliseconds * 0.001f;

            switch (this.state)
            {
                case STATE.LEFT:
                    this.position.X -= this.speed * deltaTime;
                break;

                case STATE.RIGHT:
                    this.position.X += this.speed * deltaTime;
                break;

                case STATE.BACK:
                    this.position.Z -= this.speed * deltaTime;
                    break;

                case STATE.FRONT:
                    this.position.Z += this.speed * deltaTime;
                break;

                default:
                    this.position.Z -= this.speed * deltaTime;
                break;
            }
        }

        public void ChangeState()
        {
            switch (this.state)
            {
                case STATE.FRONT:
                case STATE.BACK:
                case STATE.RIGHT:
                case STATE.LEFT:
                    this.state = (STATE)random.Next(4);
                break;
            }
            this.cooldown = INTERVAL;
        }
    }
}
