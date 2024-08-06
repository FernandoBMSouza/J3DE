using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mundo05
{
    class Windmill : GameObject
    {
        Building building;
        Blade[] blades;

        bool isWorking;
        float speed;

        public Windmill(Game1 game, float speed, bool isWorking = true)
            : base(game)
        {
            building = new Building(game);
            blades = new Blade[2];

            for (int i = 0; i < blades.Length; i++) 
                blades[i] = new Blade(game);

            foreach (Blade blade in blades)
            {
                blade.Position = new Vector3(0, 1, 3.5f);
                blade.Scale = new Vector3(.4f, .5f, 1); 
            }

            blades[1].Rotation = new Vector3(0, 0, MathHelper.ToRadians(90));

            this.isWorking = isWorking;
            this.speed = speed;
            Size = new Vector3(2, 4, 6);
        }

        public override void Update(GameTime gameTime)
        {
            if (isWorking)
            {
                float rotationAngle = -speed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
                foreach (Blade blade in blades)
                {
                    blade.Rotation = new Vector3(blade.Rotation.X,
                                                 blade.Rotation.Y,
                                                 blade.Rotation.Z + rotationAngle);
                }
            }
        }

        public override void Draw(Camera camera, Matrix parentWorld, GameTime gameTime, bool showColliders = false)
        {
            Matrix localMatrix = Matrix.CreateScale(Scale)
                                 * Matrix.CreateFromYawPitchRoll(Rotation.Y, Rotation.X, Rotation.Z)
                                 * Matrix.CreateTranslation(Position);
            
            Matrix result = localMatrix * parentWorld;
            //effect.World = result;
            //effect.View = camera.View;
            //effect.Projection = camera.Projection;

            building.Draw(camera, localMatrix, gameTime, false);
            foreach (Blade blade in blades) blade.Draw(camera, result, gameTime, false);
            if (showColliders) LBox.Draw(result, camera);
        }
    }
}
