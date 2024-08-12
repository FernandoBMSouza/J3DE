using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Collision2
{
    class Player : Cube
    {
        float speed;

        Vector3 oldPosition;

        public Player(ref GraphicsDeviceManager graphics, Vector3 position)
            : base(ref graphics, position)
        {
            this.speed = 10;

            this.oldPosition = position;

            this.UseWireframe(false);
        }

        public override void Update(GameTime gameTime)
        {
            this.Input(gameTime);

            base.Update(gameTime);
        }

        public override void Draw(ref BasicEffect effect, ref Matrix view, ref Matrix projection)
        {
            base.Draw(ref effect, ref view, ref projection);
        }

        private void Input(GameTime gameTime)
        {
            this.oldPosition = this.position;
            bool update = false;

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                this.position += Vector3.Left * this.speed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
                update = true;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                this.position += Vector3.Right * this.speed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
                update = true;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                this.position += Vector3.Forward * this.speed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
                update = true;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                this.position += Vector3.Backward * this.speed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
                update = true;
            }

            if (update)
            {
                this.UpdateBoundingBox();
            }
        }

        public void RestorePosition(GameTime gameTime)
        {
            this.position = this.oldPosition;

            base.Update(gameTime);
        }
    }
}
