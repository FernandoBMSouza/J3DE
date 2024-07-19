using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Name
{
    class Fernando : GameObject
    {
        Letter[] letters;
        float speed;
        float rotationAngle;

        public Fernando(Game1 game, GraphicsDevice device)
            : base(game, device)
        {
            speed = 50;
            rotationAngle = 0;
            Size = new Vector3(62, 10, 1);
            letters = new Letter[]
            {
                new F(game, device),
                new E(game, device),
                new R(game, device),
                new N(game, device),
                new A(game, device),
                new N(game, device),
                new D(game, device),
                new O(game, device),
            };

            letters[0].Position = new Vector3(-28, 0, 0);
            letters[1].Position = new Vector3(-20, 0, 0);
            letters[2].Position = new Vector3(-12, 0, 0);
            letters[3].Position = new Vector3( -4, 0, 0);
            letters[4].Position = new Vector3(  4, 0, 0);
            letters[5].Position = new Vector3( 12, 0, 0);
            letters[6].Position = new Vector3( 20, 0, 0);
            letters[7].Position = new Vector3( 28, 0, 0);
        }

        public override void Update(GameTime gameTime)
        {
            rotationAngle += speed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
            foreach (Letter letter in letters)
            {
                letter.Update(gameTime);
            }
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

            foreach (Letter letter in letters) letter.Draw(camera, result, false);            
            if (showCollider) LBox.Draw(effect);
        }     
    }
}
