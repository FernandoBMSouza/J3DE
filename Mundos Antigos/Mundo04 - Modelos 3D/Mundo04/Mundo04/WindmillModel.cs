using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mundo04
{
    class WindmillModel : ITransform
    {
        BuildingModel building;
        PropellerModel[] propellers;
        float rotationAngle;
        float speed;

        public WindmillModel(Game1 game, float speed)
        {
            building = new BuildingModel(game);

            propellers = new PropellerModel[]
            {
                new PropellerModel(game),
                new PropellerModel(game),
                new PropellerModel(game),
                new PropellerModel(game),
            };

            rotationAngle = 0;
            this.speed = speed;
        }

        public void Update(GameTime gameTime)
        {
            building.SetIdentity();
            foreach (PropellerModel p in propellers)
            {
                p.SetIdentity();
                p.Scale(new Vector3(0.4f));
            }

            propellers[0].RotationZ(0);
            propellers[1].RotationZ(90);
            propellers[2].RotationZ(180);
            propellers[3].RotationZ(270);

            rotationAngle += -speed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
            foreach (PropellerModel p in propellers)
                p.RotationZ(rotationAngle);

            foreach (PropellerModel p in propellers)
                p.Translation(new Vector3(0, 1.5f, 1.5f));
        }

        public void Draw(Camera camera)
        {
            building.Draw(camera);
            foreach (PropellerModel p in propellers)
                p.Draw(camera);
        }

        public void SetIdentity()
        {
            building.SetIdentity();
            foreach (PropellerModel p in propellers)
                p.SetIdentity();
        }

        public void Translation(Vector3 position)
        {
            building.Translation(position);
            foreach (PropellerModel p in propellers)
                p.Translation(position);
        }

        public void Scale(Vector3 scale)
        {
            building.Scale(scale);
            foreach (PropellerModel p in propellers)
                p.Scale(scale);
        }

        public void RotationX(float angle)
        {
            building.RotationX(angle);
            foreach (PropellerModel p in propellers)
                p.RotationX(angle);
        }

        public void RotationY(float angle)
        {
            building.RotationY(angle);
            foreach (PropellerModel p in propellers)
                p.RotationY(angle);
        }

        public void RotationZ(float angle)
        {
            building.RotationZ(angle);
            foreach (PropellerModel p in propellers)
                p.RotationZ(angle);
        }
    }
}
