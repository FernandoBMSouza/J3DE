using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace HMap20241
{
    public class _Camera
    {
        private Matrix view;
        private Matrix projection;

        private Vector3 position;
        private Vector3 target;
        private Vector3 up;

        float speed = 10;

        float angleY = 0;
        float speedY = 100;

        public _Camera()
        {
            this.position = new Vector3(0, 50, 75);
            this.target = Vector3.Zero;
            this.up = Vector3.Up;
            this.SetupView(this.position, this.target, this.up);

            this.SetupProjection();
        }

        public void SetupView(Vector3 position, Vector3 target, Vector3 up)
        {
            this.view = Matrix.CreateLookAt(position, target, up);
        }

        public void SetupProjection()
        {
            _Screen screen = _Screen.GetInstance();

            this.projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4,
                                                                  screen.GetWidth() / (float)screen.GetHeight(),
                                                                  0.1f,
                                                                  1000);
        }

        public Matrix GetView()
        {
            return this.view;
        }

        public Matrix GetProjection()
        {
            return this.projection;
        }

        public Vector3 GetPosition()
        {
            return this.position;
        }

        public void Update(GameTime gameTime)
        {
            this.Rotation(gameTime);
            this.Translation(gameTime);

            this.view = Matrix.Identity;
            this.view *= Matrix.CreateRotationY(MathHelper.ToRadians(this.angleY));
            this.view *= Matrix.CreateTranslation(this.position);
            this.view = Matrix.Invert(this.view);
        }

        private void Rotation(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                this.angleY += this.speedY * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.E))
            {
                this.angleY -= this.speedY * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
            }
        }

        private void Translation(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                this.position.X -= (float)Math.Sin(MathHelper.ToRadians(this.angleY)) * gameTime.ElapsedGameTime.Milliseconds * 0.001f * this.speed;
                this.position.Z -= (float)Math.Cos(MathHelper.ToRadians(this.angleY)) * gameTime.ElapsedGameTime.Milliseconds * 0.001f * this.speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                this.position.X += (float)Math.Sin(MathHelper.ToRadians(this.angleY)) * gameTime.ElapsedGameTime.Milliseconds * 0.001f * this.speed;
                this.position.Z += (float)Math.Cos(MathHelper.ToRadians(this.angleY)) * gameTime.ElapsedGameTime.Milliseconds * 0.001f * this.speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                this.position.X += (float)Math.Sin(MathHelper.ToRadians(this.angleY + 90)) * gameTime.ElapsedGameTime.Milliseconds * 0.001f * this.speed;
                this.position.Z += (float)Math.Cos(MathHelper.ToRadians(this.angleY + 90)) * gameTime.ElapsedGameTime.Milliseconds * 0.001f * this.speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                this.position.X += (float)Math.Sin(MathHelper.ToRadians(this.angleY - 90)) * gameTime.ElapsedGameTime.Milliseconds * 0.001f * this.speed;
                this.position.Z += (float)Math.Cos(MathHelper.ToRadians(this.angleY - 90)) * gameTime.ElapsedGameTime.Milliseconds * 0.001f * this.speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.PageUp))
            {
                this.position.Y += gameTime.ElapsedGameTime.Milliseconds * 0.001f * this.speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.PageDown))
            {
                this.position.Y -= gameTime.ElapsedGameTime.Milliseconds * 0.001f * this.speed;
            }
        }
    }
}
