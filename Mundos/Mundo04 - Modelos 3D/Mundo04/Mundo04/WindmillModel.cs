using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mundo04
{
    class WindmillModel : GameObject
    {
        BuildingModel building;
        BladeModel[] blades;

        bool isWorking;
        float speed;
        float rotationAngle;

        public WindmillModel(Game1 game, GraphicsDevice device, float speed, bool isWorking = true)
            : base(game, device)
        {
            building = new BuildingModel(game, device);
            blades = new BladeModel[4];

            for (int i = 0; i < blades.Length; i++)
                blades[i] = new BladeModel(game, device);

            foreach (BladeModel blade in blades)
            {
                blade.Position = new Vector3(0, 1, 1.5f);
                blade.Scale = new Vector3(.4f, .5f, 1);
            }
            building.Position = new Vector3(0, -0.6f, 0);

            blades[0].Rotation = new Vector3(0, 0, 0);
            blades[1].Rotation = new Vector3(0, 0, 90);
            blades[2].Rotation = new Vector3(0, 0, 180);
            blades[3].Rotation = new Vector3(0, 0, 270);

            this.isWorking = isWorking;
            this.speed = speed;
            rotationAngle = 0;
            Size = new Vector3(2, 4, 4);
        }

        public override void Update(GameTime gameTime)
        {
            if (isWorking)
            {
                rotationAngle += -speed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
                blades[0].Rotation = new Vector3(blades[0].Rotation.X, blades[0].Rotation.Y, blades[0].Rotation.Z + rotationAngle);
                blades[1].Rotation = new Vector3(blades[1].Rotation.X, blades[1].Rotation.Y, blades[1].Rotation.Z + rotationAngle + 90);
                blades[2].Rotation = new Vector3(blades[2].Rotation.X, blades[2].Rotation.Y, blades[2].Rotation.Z + rotationAngle + 180);
                blades[3].Rotation = new Vector3(blades[3].Rotation.X, blades[3].Rotation.Y, blades[3].Rotation.Z + rotationAngle + 270);
            }
        }

        public override void Draw(Camera camera, Matrix parentWorld, bool showColliders = false)
        {
            Matrix localMatrix = Matrix.CreateScale(Scale)
                                 * Matrix.CreateFromYawPitchRoll(Rotation.Y, Rotation.X, Rotation.Z)
                                 * Matrix.CreateTranslation(Position);

            Matrix result = localMatrix * parentWorld;
            effect.World = result;
            effect.View = camera.View;
            effect.Projection = camera.Projection;

            building.Draw(camera, localMatrix, false);
            foreach (BladeModel blade in blades) blade.Draw(camera, result, false);
            if (showColliders) LBox.Draw(effect);
        }
    }
}
