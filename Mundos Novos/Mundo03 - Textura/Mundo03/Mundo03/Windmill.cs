using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mundo03
{
    class Windmill : ICollider
    {
        Building building;
        Blade[] blades;

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
            get { return rotation; }
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

        public Windmill(Game1 game, GraphicsDevice device, float speed, bool isWorking = true)
        {
            building = new Building(game, device);
            blades = new Blade[2];

            for (int i = 0; i < blades.Length; i++) 
                blades[i] = new Blade(game, device);

            foreach (Blade blade in blades)
            {
                blade.Position = new Vector3(0, 1, 3.5f);
                blade.Scale = new Vector3(.4f, .5f, 1); 
            }

            blades[1].Rotation = new Vector3(0, 0, 90);

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
            }
        }

        public void Draw(Camera camera)
        {
            Matrix world = Matrix.CreateScale(Scale)
                         * Matrix.CreateFromYawPitchRoll(Rotation.Y, Rotation.X, Rotation.Z)
                         * Matrix.CreateTranslation(Position);

            building.Draw(camera, world);
            foreach (Blade blade in blades) blade.Draw(camera, world);
        }

        public bool IsColliding(BoundingBox other)
        {
            foreach (Blade blade in blades)
            {
                if (blade.IsColliding(other)) 
                    return true;
            }
            if (building.IsColliding(other))
                return true;

            return false;
        }

        public void SetColliderColor(Color color)
        {
            building.LBox.SetColor(color);
            foreach (Blade blade in blades) blade.LBox.SetColor(color);
        }

        public BoundingBox BBox
        {
            get 
            {
                BoundingBox combined = building.BBox;

                foreach (Blade blade in blades)
                    combined = BoundingBox.CreateMerged(combined, blade.BBox);

                return combined;
            }
        }

        public void UpdateComponentsBoundingBox()
        {
            building.UpdateBoundingBox(building.Position + Position, building.Size * Scale);
            foreach (Blade blade in blades) 
                blade.UpdateBoundingBox(blade.Position + Position, blade.Size * Scale);
        }
    }
}
