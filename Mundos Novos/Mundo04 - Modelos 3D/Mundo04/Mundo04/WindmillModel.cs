using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mundo04
{
    public class WindmillModel : ICollider
    {
        BuildingModel building;
        BladeModel[] blades;

        Vector3 scale;
        Vector3 rotation;
        Vector3 position;

        public Vector3 Scale
        {
            get { return scale; }
            set
            {
                scale = value;
                UpdateComponentsBoundingBox();
            }
        }
        public Vector3 Rotation
        {
            get
            {
                return rotation;
            }
            set
            {
                rotation = new Vector3(MathHelper.ToRadians(value.X),
                                       MathHelper.ToRadians(value.Y),
                                       MathHelper.ToRadians(value.Z));
                UpdateComponentsBoundingBox();
            }
        }
        public Vector3 Position
        {
            get { return position; }
            set
            {
                position = value;
                UpdateComponentsBoundingBox();
            }
        }

        bool isWorking;
        float speed;
        float rotationAngle;

        public WindmillModel(Game1 game, GraphicsDevice device, float speed, bool isWorking = true)
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

            Scale = Vector3.One;
            Rotation = Vector3.Zero;
            Position = Vector3.Zero;

            this.isWorking = isWorking;
            this.speed = speed;
            rotationAngle = 0;
        }

        public void Update(GameTime gameTime)
        {
            if (isWorking)
            {
                rotationAngle += -speed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
                blades[0].Rotation = new Vector3(blades[0].Rotation.X, blades[0].Rotation.Y, blades[0].Rotation.Z + rotationAngle);
                blades[1].Rotation = new Vector3(blades[1].Rotation.X, blades[1].Rotation.Y, blades[1].Rotation.Z + rotationAngle + 90);
                blades[2].Rotation = new Vector3(blades[1].Rotation.X, blades[1].Rotation.Y, blades[1].Rotation.Z + rotationAngle + 180);
                blades[3].Rotation = new Vector3(blades[1].Rotation.X, blades[1].Rotation.Y, blades[1].Rotation.Z + rotationAngle + 270);
            }
        }

        public void Draw(Camera camera)
        {
            Matrix world = Matrix.CreateScale(Scale)
                         * Matrix.CreateFromYawPitchRoll(Rotation.Y, Rotation.X, Rotation.Z)
                         * Matrix.CreateTranslation(Position);

            building.Draw(camera, world);
            foreach (BladeModel blade in blades) blade.Draw(camera, world);
        }

        public bool IsColliding(BoundingBox other)
        {
            return BBox.Intersects(other);
        }

        public void SetColliderColor(Color color)
        {
            building.LBox.SetColor(color);
            foreach (BladeModel blade in blades) blade.LBox.SetColor(color);
        }

        public BoundingBox BBox
        {
            get
            {
                BoundingBox combined = building.BBox;

                foreach (BladeModel blade in blades)
                    combined = BoundingBox.CreateMerged(combined, blade.BBox);

                return building.BBox;

                // O certo seria retornar o combined, fica certo, mas se eu mover o windmill o BBox fica muito maior que deveria
                // pelo que parece ele pega desde a posicao antiga e soma com a nova, faz o colisor ficar totalmente errado
                // return combined;
            }
        }

        public void UpdateComponentsBoundingBox()
        {
            building.UpdateBoundingBox(building.Position + Position, building.Size);
            foreach (BladeModel blade in blades)
                blade.UpdateBoundingBox(blade.Position + Position, blade.Size);
        }
    }
}
