using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mundo02
{
    class Windmill : ITransform
    {
        Building building;
        Propeller[] propellers;
        const int PROPELLERS_NUMBER = 4;
        float rotationAngle;
        float speed;
        bool isWorking;

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

        public Windmill(GraphicsDevice device, float speed, bool isWorking = true)
        {
            building = new Building(device);
            this.isWorking = isWorking;

            propellers = new Propeller[PROPELLERS_NUMBER];
            for (int i = 0; i < propellers.Length; i++) propellers[i] = new Propeller(device);

            rotationAngle = 0;
            this.speed = speed;
            SetIdentity();
        }

        public void Update(GameTime gameTime)
        {
            if (isWorking)
            {
                rotationAngle = -speed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
                foreach (Propeller p in propellers)
                    p.Rotation('Z', rotationAngle);
            }
        }

        public void Draw(Camera camera)
        {
            building.Draw(camera);
            foreach (Propeller p in propellers)
                p.Draw(camera);
        }

        public void SetIdentity()
        {
            Position = Vector3.Zero;
            Angle = Vector3.Zero;
            Size = Vector3.One;

            building.SetIdentity();
            foreach (Propeller p in propellers)
            {
                p.SetIdentity();
                p.Scale(new Vector3(.4f, .5f, 1));
            } 
            propellers[0].Rotation('Z', 0);
            propellers[1].Rotation('Z', 90);
            propellers[2].Rotation('Z', 180);
            propellers[3].Rotation('Z', 270);
            foreach (Propeller p in propellers) p.Translation(new Vector3(0, 1, 3.5f));
        }

        public void Translation(Vector3 position, bool aux = false)
        {
            Position = position;
            if (aux)
            {
                building.Translation(position, true);
                foreach (Propeller p in propellers)
                    p.Translation(position, true);
            }
            else
            {
                building.Translation(position);
                foreach (Propeller p in propellers)
                    p.Translation(position);
            }
        }

        public void Scale(Vector3 scale, bool aux = false)
        {
            Size *= scale;
            if (aux)
            {
                building.Scale(scale, true);
                foreach (Propeller p in propellers)
                    p.Scale(scale, true);
            }
            else
            {
                building.Scale(scale);
                foreach (Propeller p in propellers)
                    p.Scale(scale);
            }
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
                        foreach (Propeller p in propellers) p.Rotation('X', angle, true);
                    }
                    else
                    {
                        building.Rotation('X', angle);
                        foreach (Propeller p in propellers) p.Rotation('X', angle);
                    }
                    break;
                case 'Y':
                case 'y':
                    Angle += new Vector3(0, angle, 0);
                    if (aux)
                    {
                        building.Rotation('Y', angle, true);
                        foreach (Propeller p in propellers) p.Rotation('Y', angle, true);
                    }
                    else
                    {
                        building.Rotation('Y', angle);
                        foreach (Propeller p in propellers) p.Rotation('Y', angle);
                    }
                    break;
                case 'Z':
                case 'z':
                    Angle += new Vector3(0, 0, angle);
                    if (aux)
                    {
                        building.Rotation('Z', angle, true);
                        foreach (Propeller p in propellers) p.Rotation('Z', angle, true);
                    }
                    else
                    {
                        building.Rotation('Z', angle);
                        foreach (Propeller p in propellers) p.Rotation('Z', angle);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
