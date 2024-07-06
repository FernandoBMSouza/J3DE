using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace WorldName
{
    class Name
    {
        Letter[] letters;
        float rotationAngle;
        float speed;

        public Name(GraphicsDevice device)
        {
            letters = new Letter[]
            {
                new F(device),
                new E(device),
                new R(device),
                new N(device),
                new A(device),
                new N(device),
                new D(device),
                new O(device),
            };

            rotationAngle = 0;
            speed = 50;
        }

        public void Update(GameTime gameTime)
        {
            foreach (Letter l in letters)
                l.Update(gameTime);

            rotationAngle += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            letters[0].Translation(new Vector3(-35, 0, 0));
            letters[1].Translation(new Vector3(-25, 0, 0));
            letters[2].Translation(new Vector3(-15, 0, 0));
            letters[3].Translation(new Vector3(-5, 0, 0));
            letters[4].Translation(new Vector3( 5, 0, 0));
            letters[5].Translation(new Vector3(15, 0, 0));
            letters[6].Translation(new Vector3(25, 0, 0));
            letters[7].Translation(new Vector3(35, 0, 0));

            foreach (Letter l in letters)
                l.RotationY(rotationAngle);
        }

        public void Draw(Camera camera)
        {
            foreach (Letter l in letters)
                l.Draw(camera);
        }
    }
}
