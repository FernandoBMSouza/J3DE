using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using WorldManager.GameObjects;

namespace WorldManager.Worlds
{
    public abstract class BaseWorld
    {
        protected LinkedList<GameObject> objects;

        public BaseWorld(Game1 game)
        {
            objects = new LinkedList<GameObject>();
        }

        public void Update(GameTime gameTime, Camera camera)
        {
            foreach (GameObject obj in objects)
            {
                obj.Update(gameTime);

                if (camera.IsColliding(obj.BBox))
                {
                    camera.RestorePosition();
                    obj.SetColliderColor(Color.Red);
                }
                else obj.SetColliderColor(Color.Green);
            }
        }

        public void Draw(Camera camera)
        {
            foreach (GameObject obj in objects) obj.Draw(camera);
        }
    }
}
