using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace Mundo04
{
    class Camera
    {
        private Game1 game;

        private Matrix view;
        private Matrix projection;

        private Vector3 position;
        private Vector3 target;
        private Vector3 up;

        private float angle;
        private float rotationSpeed;
        private float translationSpeed;

        public Camera(Game1 game)
        {
            this.game = game;

            position = new Vector3(0, 5, 20);
            target = Vector3.Zero;
            up = Vector3.Up;
            SetupView(this.position, this.target, this.up);

            angle = MathHelper.ToRadians(0);
            translationSpeed = 10;
            rotationSpeed = 100;

            SetupProjection();
        }

        public void Update(GameTime gameTime)
        {
            game.Window.Title = "CAMERA - angle: " + angle.ToString("F");

            // Rotation
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
                angle += rotationSpeed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
            if (Keyboard.GetState().IsKeyDown(Keys.E))
                angle -= rotationSpeed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;

            // Translation
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                position.X -= (float)Math.Sin(MathHelper.ToRadians(angle)) * gameTime.ElapsedGameTime.Milliseconds * 0.001f * translationSpeed;
                position.Z -= (float)Math.Cos(MathHelper.ToRadians(angle)) * gameTime.ElapsedGameTime.Milliseconds * 0.001f * translationSpeed;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                position.X += (float)Math.Sin(MathHelper.ToRadians(angle)) * gameTime.ElapsedGameTime.Milliseconds * 0.001f * translationSpeed;
                position.Z += (float)Math.Cos(MathHelper.ToRadians(angle)) * gameTime.ElapsedGameTime.Milliseconds * 0.001f * translationSpeed;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                position.X += (float)Math.Sin(MathHelper.ToRadians(angle - 90)) * gameTime.ElapsedGameTime.Milliseconds * 0.001f * translationSpeed;
                position.Z += (float)Math.Cos(MathHelper.ToRadians(angle - 90)) * gameTime.ElapsedGameTime.Milliseconds * 0.001f * translationSpeed;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                position.X += (float)Math.Sin(MathHelper.ToRadians(angle + 90)) * gameTime.ElapsedGameTime.Milliseconds * 0.001f * translationSpeed;
                position.Z += (float)Math.Cos(MathHelper.ToRadians(angle + 90)) * gameTime.ElapsedGameTime.Milliseconds * 0.001f * translationSpeed;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space)) // Move up
                position += Vector3.Up * gameTime.ElapsedGameTime.Milliseconds * 0.001f * translationSpeed;

            if (Keyboard.GetState().IsKeyDown(Keys.LeftShift)) // Move down
                position -= Vector3.Up * gameTime.ElapsedGameTime.Milliseconds * 0.001f * translationSpeed;

            view = Matrix.Identity;
            view *= Matrix.CreateRotationY(MathHelper.ToRadians(angle));
            view *= Matrix.CreateTranslation(position);
            view = Matrix.Invert(view);
        }

        public void SetupView(Vector3 position, Vector3 target, Vector3 up)
        {
            view = Matrix.CreateLookAt(position, target, up);
        }

        public void SetupProjection()
        {
            Screen screen = Screen.GetInstance();

            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4,
                                                                  screen.Width/(float)screen.Height,
                                                                  1,
                                                                  100);
        }

        public Matrix GetView() { return view; }

        public Matrix GetProjection() { return projection; }
    }
}
