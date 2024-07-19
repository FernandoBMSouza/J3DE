using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Name
{
    public abstract class Letter : GameObject
    {
        protected GameObject[] Pieces { get; set; }
        float speed;
        float rotationAngle;

        public Letter(Game1 game, GraphicsDevice device)
            : base(game, device)
        { 
            Pieces = null;
            Size = new Vector3(6, 10, 2);
            speed = 100;
            rotationAngle = 0;

            Scale = new Vector3(1, 1, .5f);
        }

        public override void Update(GameTime gameTime)
        {
            rotationAngle += speed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
            Rotation = new Vector3(Rotation.X, Rotation.Y + rotationAngle, Rotation.Z); 
        }

        public override void Draw(Camera camera, Matrix parentWorld, bool showCollider = false)
        {
            Matrix localMatrix = Matrix.CreateScale(Scale)
                                 * Matrix.CreateFromYawPitchRoll(Rotation.Y, Rotation.X, Rotation.Z)
                                 * Matrix.CreateTranslation(Position);

            Matrix result = localMatrix * parentWorld;

            effect.World = result;
            effect.View = camera.View;
            effect.Projection = camera.Projection;

            foreach (GameObject obj in Pieces) obj.Draw(camera, result, false);
            if (showCollider) LBox.Draw(effect);

        }        
    }
}
