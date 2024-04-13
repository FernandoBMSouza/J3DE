using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace WorldOfWorlds
{
    class Windmill : ITransform
    {
        Building building;
        PropellerWorld[] propellers;
        float rotationAngle;
        float speed;

        public Windmill(Game1 game, GraphicsDevice device, float speed)
        {
            building = new Building(game, device);

            propellers = new PropellerWorld[]
            {
                new PropellerWorld(game, device),
                new PropellerWorld(game, device),
                new PropellerWorld(game, device),
                new PropellerWorld(game, device),
            };

            rotationAngle = 0;
            this.speed = speed;
        }

        public void Update(GameTime gameTime)
        {
            rotationAngle += -speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            building.SetIdentity();
            foreach (PropellerWorld p in propellers)
            {
                p.SetIdentity();
                p.Update(gameTime);
                p.Scale(new Vector3(.4f, .5f, 1));
            }

            propellers[0].RotationZ(0);
            propellers[1].RotationZ(90);
            propellers[2].RotationZ(180);
            propellers[3].RotationZ(270);

            propellers[0].Translation(new Vector3(0, 1, 0));
            propellers[1].Translation(new Vector3(-1, 0, 0));
            propellers[2].Translation(new Vector3(0, -1, 0));
            propellers[3].Translation(new Vector3(1, 0, 0));

            foreach (PropellerWorld p in propellers)
            {
                p.RotationZ(rotationAngle);
            }

            foreach (PropellerWorld p in propellers)
                p.Translation(new Vector3(0, 1, 3.5f));
        }

        public void Draw(Camera camera)
        {
            building.Draw(camera);
            foreach (PropellerWorld p in propellers)
                p.Draw(camera);
        }

        public void SetIdentity()
        {
            building.SetIdentity();
            foreach (PropellerWorld p in propellers)
                p.SetIdentity();
        }

        public void Translation(Vector3 position)
        {
            building.Translation(position);
            foreach (PropellerWorld p in propellers)
                p.Translation(position);
        }

        public void Scale(Vector3 scale)
        {
            building.Scale(scale);
            foreach (PropellerWorld p in propellers)
                p.Scale(scale);
        }

        public void RotationX(float angle)
        {
            building.RotationX(angle);
            foreach (PropellerWorld p in propellers)
                p.RotationX(angle);
        }

        public void RotationY(float angle)
        {
            building.RotationY(angle);
            foreach (PropellerWorld p in propellers)
                p.RotationY(angle);
        }

        public void RotationZ(float angle)
        {
            building.RotationZ(angle);
            foreach (PropellerWorld p in propellers)
                p.RotationZ(angle);            
        }
    }
}
