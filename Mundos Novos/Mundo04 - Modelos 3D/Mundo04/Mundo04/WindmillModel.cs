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
        PropellerModel[] propellers;
        const int PROPELLERS_NUMBER = 4;
        float rotationAngle;
        float speed;
        bool isWorking;

        public BoundingBox BBox { get; private set; }
        public LineBox LBox { get { return building.LBox; } private set { } }
        bool lineBoxVisible;

        public Vector3 Position { get; protected set; }
        public Vector3 Size { get; protected set; }
        private Vector3 angle;
        public Vector3 Angle
        {
            get { return angle; }
            protected set
            {
                angle = new Vector3(
                (value.X % 360 + 360) % 360,
                (value.Y % 360 + 360) % 360,
                (value.Z % 360 + 360) % 360);
            }
        }

        public WindmillModel(Game1 game, GraphicsDevice device, float speed, bool isWorking = true, bool lineBoxVisible = false)
        {
            this.lineBoxVisible = lineBoxVisible;
            this.isWorking = isWorking;

            building = new BuildingModel(game, device, lineBoxVisible);

            propellers = new PropellerModel[PROPELLERS_NUMBER];
            for (int i = 0; i < propellers.Length; i++) propellers[i] = new PropellerModel(game, device, lineBoxVisible);

            rotationAngle = 0;
            this.speed = speed;
            SetIdentity();

            UpdateBoundingBox();
        }

        public void Update(GameTime gameTime)
        {
            if (isWorking)
            {
                rotationAngle = -speed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
                foreach (PropellerModel p in propellers)
                    p.Rotation('Z', rotationAngle);
                UpdateBoundingBox();
            }
        }

        public void Draw(Camera camera)
        {
            building.Draw(camera);
            foreach (PropellerModel p in propellers)
                p.Draw(camera);
        }

        public void UpdateBoundingBox()
        {
            BoundingBox combinedBBox = building.BBox;

            foreach (PropellerModel p in propellers)
                combinedBBox = BoundingBox.CreateMerged(combinedBBox, p.BBox);

            BBox = combinedBBox;
        }

        public bool IsColliding(BoundingBox other)
        {
            if (building.IsColliding(other))
                return true;

            foreach (PropellerModel p in propellers)
            {
                if (p.IsColliding(other))
                    return true;
            }

            return false;
        }

        public void SetColliderColor(Color color)
        {
            building.LBox.SetColor(color);
            foreach (PropellerModel p in propellers) p.LBox.SetColor(color);
        }

        public void SetIdentity()
        {
            Position = Vector3.Zero;
            Angle = Vector3.Zero;
            Size = Vector3.One;

            foreach (PropellerModel p in propellers)
            {
                p.Scale(new Vector3(.4f, .4f, 1));
            }
            propellers[0].Rotation('Z', 0);
            propellers[1].Rotation('Z', 90);
            propellers[2].Rotation('Z', 180);
            propellers[3].Rotation('Z', 270);

            foreach (PropellerModel p in propellers) p.Translation(new Vector3(0, 1, 1.5f));
            UpdateBoundingBox();
        }

        public void Translation(Vector3 position, bool aux = false)
        {
            Position = position;
            if (aux)
            {
                building.Translation(position, true);
                foreach (PropellerModel p in propellers)
                    p.Translation(position, true);
            }
            else
            {
                building.Translation(position);
                foreach (PropellerModel p in propellers)
                    p.Translation(position);
            }
            UpdateBoundingBox();
        }

        public void Scale(Vector3 scale, bool aux = false)
        {
            Size *= scale;
            if (aux)
            {
                building.Scale(scale, true);
                foreach (PropellerModel p in propellers)
                    p.Scale(scale, true);
            }
            else
            {
                building.Scale(scale);
                foreach (PropellerModel p in propellers)
                    p.Scale(scale);
            }
            UpdateBoundingBox();
        }

        public void Rotation(char axis, float angle, bool aux = false)
        {
            switch (axis)
            {
                case 'X':
                case 'x':
                    Angle += new Vector3(angle, 0, 0);
                    if (aux)
                    {
                        building.Rotation('X', angle, true);
                        foreach (PropellerModel p in propellers) p.Rotation('X', angle, true);
                    }
                    else
                    {
                        building.Rotation('X', angle);
                        foreach (PropellerModel p in propellers) p.Rotation('X', angle);
                    }
                    break;
                case 'Y':
                case 'y':
                    Angle += new Vector3(0, angle, 0);
                    if (aux)
                    {
                        building.Rotation('Y', angle, true);
                        foreach (PropellerModel p in propellers) p.Rotation('Y', angle, true);
                    }
                    else
                    {
                        building.Rotation('Y', angle);
                        foreach (PropellerModel p in propellers) p.Rotation('Y', angle);
                    }
                    break;
                case 'Z':
                case 'z':
                    Angle += new Vector3(0, 0, angle);
                    if (aux)
                    {
                        building.Rotation('Z', angle, true);
                        foreach (PropellerModel p in propellers) p.Rotation('Z', angle, true);
                    }
                    else
                    {
                        building.Rotation('Z', angle);
                        foreach (PropellerModel p in propellers) p.Rotation('Z', angle);
                    }
                    break;
                default:
                    break;
            }
            UpdateBoundingBox();
        }
    }
}
