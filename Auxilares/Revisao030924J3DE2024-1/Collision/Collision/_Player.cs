using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Collision
{
    public class _Player : _Cube //_Collider
    {
        Vector3 oldPosition;
        float speed;

        public _Player(Game game, Vector3 position, Vector3 dimension, Color color, bool visible)
            : base(game, position, dimension, color, visible)
        {
            this.oldPosition = this.position;
            this.speed = 5;
        }

        public override void Update(GameTime gt)
        {
            float deltaTime = gt.ElapsedGameTime.Milliseconds * 0.001f;
            this.oldPosition = this.position;

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                this.position.X -= this.speed * deltaTime;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                this.position.X += this.speed * deltaTime;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                this.position.Z -= this.speed * deltaTime;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                this.position.Z += this.speed * deltaTime;
            }
            this.SetPosition(this.position);
            base.Update(gt);
        }

        public void RestorePosition()
        {
            this.position = this.oldPosition;
        }
    }
}
