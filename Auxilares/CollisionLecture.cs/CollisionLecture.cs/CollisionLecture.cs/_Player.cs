using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace CollisionLecture.cs
{
    class _Player : _Collider
    {
        Vector3 oldPosition;
        float speed;

        public _Player(Game game, Vector3 position, Vector3 dimension, Color color, bool visible = true)
            : base(game, position, dimension, color, visible)
        {
            oldPosition = position;
            speed = 5;
        }

        public void Update(GameTime gt)
        {
            float deltaTime = gt.ElapsedGameTime.Milliseconds * 0.001f;
            oldPosition = position;

            if (Keyboard.GetState().IsKeyDown(Keys.Left )) position.X -= speed * deltaTime;
            if (Keyboard.GetState().IsKeyDown(Keys.Right)) position.X += speed * deltaTime;
            if (Keyboard.GetState().IsKeyDown(Keys.Up   )) position.Z -= speed * deltaTime;
            if (Keyboard.GetState().IsKeyDown(Keys.Down )) position.Z += speed * deltaTime;
            SetPosition(position);
        }

        public void RestorePosition()
        {
            position = oldPosition;
        }
    }
}
