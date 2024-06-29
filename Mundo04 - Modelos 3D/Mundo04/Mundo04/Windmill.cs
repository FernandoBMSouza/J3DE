using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mundo04
{
    class Windmill : ITransform
    {
        Building building;
        Propeller[] propellers;
        float rotationAngle;
        float speed;

        public Windmill(Game1 game, GraphicsDevice device, float speed)
        {
            building = new Building(game, device);

            propellers = new Propeller[]
            {
                new Propeller(game, device),
                new Propeller(game, device),
                new Propeller(game, device),
                new Propeller(game, device),
            };

            rotationAngle = 0;
            this.speed = speed;
        }

        public void Update(GameTime gameTime)
        {
            building.SetIdentity();
            foreach (Propeller p in propellers)
            {
                p.SetIdentity();
                p.Scale(new Vector3(.4f, .5f, 1));                
            }

            propellers[0].RotationZ(0);
            propellers[1].RotationZ(90);
            propellers[2].RotationZ(180);
            propellers[3].RotationZ(270);

            rotationAngle += -speed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
            foreach (Propeller p in propellers)
                p.RotationZ(rotationAngle);

            foreach (Propeller p in propellers)
                p.Translation(new Vector3(0, 1, 3.5f));
        }

        public void Draw(Camera camera)
        {
            building.Draw(camera);
            foreach (Propeller p in propellers)
                p.Draw(camera);
        }

        public void SetIdentity()
        {
            building.SetIdentity();
            foreach (Propeller p in propellers)
                p.SetIdentity();
        }

        public void Translation(Vector3 position)
        {
            building.Translation(position);
            foreach (Propeller p in propellers)
                p.Translation(position);
        }

        public void Scale(Vector3 scale)
        {
            building.Scale(scale);
            foreach (Propeller p in propellers)
                p.Scale(scale);
        }

        public void RotationX(float angle)
        {
            building.RotationX(angle);
            foreach (Propeller p in propellers)
                p.RotationX(angle);
        }

        public void RotationY(float angle)
        {
            building.RotationY(angle);
            foreach (Propeller p in propellers)
                p.RotationY(angle);
        }

        public void RotationZ(float angle)
        {
            building.RotationZ(angle);
            foreach (Propeller p in propellers)
                p.RotationZ(angle);            
        }
    }
}
