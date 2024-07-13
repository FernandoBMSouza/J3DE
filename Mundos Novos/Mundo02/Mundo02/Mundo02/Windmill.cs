using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mundo02
{
    class Windmill : ICollider
    {
        Building building;
        Blade blade;

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

        public Windmill(Game1 game, GraphicsDevice device)
        {
            building = new Building(game, device);
            blade = new Blade(game, device);

            blade.Position = new Vector3(0, 1, 3.5f);
            blade.Scale = new Vector3(.4f, .5f, 1);

            Scale = Vector3.One;
            Rotation = Vector3.Zero;
            Position = Vector3.Zero;
        }

        public void Draw(Camera camera)
        {
            Matrix world = Matrix.CreateScale(Scale)
                         * Matrix.CreateFromYawPitchRoll(Rotation.Y, Rotation.X, Rotation.Z)
                         * Matrix.CreateTranslation(Position);

            building.Draw(camera, world);
            blade.Draw(camera, world);
        }

        public bool IsColliding(BoundingBox other)
        {
            return (blade.IsColliding(other) || building.IsColliding(other));
        }

        public void SetColliderColor(Color color)
        {
            building.LBox.SetColor(color);
            blade.LBox.SetColor(color);
        }

        public BoundingBox BBox
        {
            get { return BoundingBox.CreateMerged(blade.BBox, building.BBox); }
        }

        public void UpdateComponentsBoundingBox()
        {
            building.UpdateBoundingBox(building.Position + Position, building.Size * Scale);
            blade.UpdateBoundingBox(blade.Position + Position, blade.Size * Scale);
        }
    }
}
