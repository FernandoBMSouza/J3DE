using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace WorldOfWorlds
{
    class World : ITransform
    {
        ITransform[] gameObjects;
        Random random;

        public World(Game1 game, GraphicsDevice device)
        {
            int seed = (int)DateTime.Now.Ticks % int.MaxValue;
            random = new Random(seed);

            gameObjects = new ITransform[]
            {
                new Quad(game, device),
                new Cube(game, device),
                new Windmill(game, device, random.Next(5,100)),
                new Windmill(game, device, random.Next(5,100)),
            };

            if (Game1.DEPTH >= 0)
                Game1.DEPTH--;
        }

        public void Update(GameTime gameTime)
        {
            foreach (ITransform g in gameObjects)
            {
                g.SetIdentity();
                g.Update(gameTime);            
            }

            gameObjects[0].Scale(new Vector3(15, 0, 10));

            gameObjects[2].RotationY(45);
            gameObjects[3].RotationY(-45);

            gameObjects[1].Translation(new Vector3(0, 1, 0));

            gameObjects[2].Translation(new Vector3(-8, 2, 0));
            gameObjects[3].Translation(new Vector3(8, 2, 0));
        }

        public void Draw(Camera camera)
        {
            foreach (ITransform g in gameObjects)
                g.Draw(camera);
        }

        public void SetIdentity()
        {
            foreach (ITransform g in gameObjects)
                g.SetIdentity();
        }

        public void Translation(Vector3 position)
        {
            foreach (ITransform g in gameObjects)
                g.Translation(position);
        }

        public void Scale(Vector3 scale)
        {
            foreach (ITransform g in gameObjects)
                g.Scale(scale);
        }

        public void RotationX(float angle)
        {
            foreach (ITransform g in gameObjects)
                g.RotationX(angle);
        }

        public void RotationY(float angle)
        {
            foreach (ITransform g in gameObjects)
                g.RotationY(angle);
        }

        public void RotationZ(float angle)
        {
            foreach (ITransform g in gameObjects)
                g.RotationZ(angle);
        }
    }
}
