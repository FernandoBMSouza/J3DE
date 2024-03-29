using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace Mundo04
{
    // Não herda de GameObject, pois é apenas uma composição de dois objetos
    class Windmill
    {
        GameObject building;
        GameObject[] propellers;
        Random random;
        Matrix world;

        public Windmill(Game1 game, GraphicsDevice device, Vector3 position, float angle)
        {
            random = new Random();
            float speed = random.Next(1, 11);

            world = Matrix.Identity;
            world *= Matrix.CreateRotationY(MathHelper.ToRadians(angle));
            world *= Matrix.CreateTranslation(position);

            building = new Building(game, device, position, angle);

            propellers = new Propeller[]
            {
                new Propeller(game, device,   0, new Vector3(0,2,3.5f), speed, world),
                new Propeller(game, device, 180, new Vector3(0,2,3.5f), speed, world),
                new Propeller(game, device, -90, new Vector3(0,2,3.5f), speed, world),
                new Propeller(game, device,  90, new Vector3(0,2,3.5f), speed, world),
            };
        }

        public void Update(GameTime gameTime)
        {
            foreach (GameObject propeller in propellers)
                propeller.Update(gameTime);
        }

        public void Draw(Camera camera)
        {
            building.Draw(camera);

            foreach (GameObject propeller in propellers)
                propeller.Draw(camera);
        }
    }
}
