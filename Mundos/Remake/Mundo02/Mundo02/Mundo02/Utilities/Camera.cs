using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Mundo02.Utilities
{
    class Camera
    {
        Vector3 position;
        Vector3 target;
        Vector3 up;

        Vector3 size;
        Vector3 oldPosition;

        float translationSpeed;
        float rotationSpeed;
        Vector3 angle;

        public Matrix View { get; private set; }
        public Matrix Projection { get; private set; }

        public BoundingBox BBox { get; private set; }

        public Camera(Game game)
        {
            position = new Vector3(0, 1, 7);
            oldPosition = position;
            target = Vector3.Zero;
            up = Vector3.Up;

            translationSpeed = 10;
            rotationSpeed = 100;
            angle = new Vector3(MathHelper.ToRadians(0),
                                MathHelper.ToRadians(0),
                                MathHelper.ToRadians(0));

            View = Matrix.CreateLookAt(position, target, up);
            Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4,
                                                             Screen.GetInstance().Width / (float)Screen.GetInstance().Height,
                                                             .001f, 1000);
            size = Vector3.One;
            UpdateBoundingBox();
        }

        public void Update(GameTime gameTime)
        {
            oldPosition = position;
            Rotation(gameTime);
            Translation(gameTime);

            View = Matrix.Identity;
            View *= Matrix.CreateRotationY(MathHelper.ToRadians(angle.Y));
            View *= Matrix.CreateRotationX(MathHelper.ToRadians(angle.X));
            View *= Matrix.CreateTranslation(position);
            View = Matrix.Invert(View);

            UpdateBoundingBox();
        }

        private void Rotation(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Q))
                angle.Y += rotationSpeed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
            if (Keyboard.GetState().IsKeyDown(Keys.E))
                angle.Y -= rotationSpeed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                angle.X += rotationSpeed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
                angle.X -= rotationSpeed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
        }

        private void Translation(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                position.X -= (float)Math.Sin(MathHelper.ToRadians(angle.Y)) * gameTime.ElapsedGameTime.Milliseconds * 0.001f * translationSpeed;
                position.Z -= (float)Math.Cos(MathHelper.ToRadians(angle.Y)) * gameTime.ElapsedGameTime.Milliseconds * 0.001f * translationSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                position.X += (float)Math.Sin(MathHelper.ToRadians(angle.Y)) * gameTime.ElapsedGameTime.Milliseconds * 0.001f * translationSpeed;
                position.Z += (float)Math.Cos(MathHelper.ToRadians(angle.Y)) * gameTime.ElapsedGameTime.Milliseconds * 0.001f * translationSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                position.X += (float)Math.Sin(MathHelper.ToRadians(angle.Y - 90)) * gameTime.ElapsedGameTime.Milliseconds * 0.001f * translationSpeed;
                position.Z += (float)Math.Cos(MathHelper.ToRadians(angle.Y - 90)) * gameTime.ElapsedGameTime.Milliseconds * 0.001f * translationSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                position.X += (float)Math.Sin(MathHelper.ToRadians(angle.Y + 90)) * gameTime.ElapsedGameTime.Milliseconds * 0.001f * translationSpeed;
                position.Z += (float)Math.Cos(MathHelper.ToRadians(angle.Y + 90)) * gameTime.ElapsedGameTime.Milliseconds * 0.001f * translationSpeed;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                position.Y += gameTime.ElapsedGameTime.Milliseconds * 0.001f * translationSpeed;
            if (Keyboard.GetState().IsKeyDown(Keys.LeftShift))
                position.Y -= gameTime.ElapsedGameTime.Milliseconds * 0.001f * translationSpeed;

            //if (Keyboard.GetState().IsKeyDown(Keys.Space))
            //{
            //    position.Y += (float)Math.Sin(MathHelper.ToRadians(angle.X)) * gameTime.ElapsedGameTime.Milliseconds * 0.001f * translationSpeed;
            //    position.Y += (float)Math.Cos(MathHelper.ToRadians(angle.X)) * gameTime.ElapsedGameTime.Milliseconds * 0.001f * translationSpeed;
            //}
            //if (Keyboard.GetState().IsKeyDown(Keys.LeftShift))
            //{
            //    position.Y -= (float)Math.Sin(MathHelper.ToRadians(angle.X)) * gameTime.ElapsedGameTime.Milliseconds * 0.001f * translationSpeed;
            //    position.Y -= (float)Math.Cos(MathHelper.ToRadians(angle.X)) * gameTime.ElapsedGameTime.Milliseconds * 0.001f * translationSpeed;
            //}
        }

        public void UpdateBoundingBox()
        {
            BBox = new BoundingBox(position - size,
                                   position + size);

        }

        public bool IsColliding(BoundingBox other)
        {
            return BBox.Intersects(other);
        }

        public void RestorePosition()
        {
            position = oldPosition;
        }
    }
}
