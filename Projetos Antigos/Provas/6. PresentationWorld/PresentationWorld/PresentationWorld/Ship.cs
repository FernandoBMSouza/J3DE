using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace PresentationWorld
{
    class Ship : GameObject
    {
        private float speed;
        private Vector3 oldPosition;

        public Ship(Game1 game, GraphicsDevice device)
            : base(game, device)
        {
            Collider = ColliderType.BoundingBox;
            Size = new Vector3(1, .2f, 1.5f);
            Model = game.Content.Load<Model>(@"Models\Ship");
            Texture = game.Content.Load<Texture2D>(@"Images\ShipTexture");
            speed = 10f;
        }

        public override void Update(GameTime gameTime)
        {
            oldPosition = Position;
            Move(gameTime);
            base.Update(gameTime);
        }

        public void Move(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            Vector3 direction = Vector3.Zero;

            // Movimenta a nave para frente e para trás
            if (state.IsKeyDown(Keys.W))
            {
                direction -= Vector3.Forward;
            }
            if (state.IsKeyDown(Keys.S))
            {
                direction -= Vector3.Backward;
            }

            // Rotaciona a nave ao redor do eixo Y
            if (state.IsKeyDown(Keys.A))
            {
                Rotation += new Vector3(0, (speed/2) * deltaTime, 0);
            }
            if (state.IsKeyDown(Keys.D))
            {
                Rotation -= new Vector3(0, (speed/2) * deltaTime, 0);
            }

            // Aplica a rotação à direção de movimento
            Matrix rotationMatrix = Matrix.CreateRotationY(Rotation.Y);
            direction = Vector3.Transform(direction, rotationMatrix);

            // Normaliza a direção para garantir que a velocidade seja consistente
            if (direction != Vector3.Zero)
            {
                direction.Normalize();
            }

            // Atualiza a posição com base na direção e na velocidade
            Position += direction * speed * deltaTime;

            // Controle de altitude: Space para subir, Shift para descer
            if (state.IsKeyDown(Keys.Space))
            {
                Position += Vector3.Up * (speed / 2) * deltaTime;
            }
            if (state.IsKeyDown(Keys.LeftShift))
            {
                Position += Vector3.Down * (speed / 2) * deltaTime;
            }

            // Atualiza o bounding box após o movimento
            UpdateCollider();
        }

        public void RestorePosition()
        {
            Position = oldPosition;
        }
    }
}
