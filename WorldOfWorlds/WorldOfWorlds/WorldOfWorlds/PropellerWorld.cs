#define USE_TEXTURE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace WorldOfWorlds
{
    class PropellerWorld : ITransform
    {
        Propeller propeller;
        World world;

        public float Angle { get; set; }

        public PropellerWorld(Game1 game, GraphicsDevice device)
        {
            propeller = new Propeller(game, device);

            if (Game1.DEPTH < Game1.MAX_DEPTH)
            {
                Game1.DEPTH++;
                world = new World(game, device);
            }
        }

        public void Update(GameTime gameTime)
        {
            propeller.SetIdentity();
            if (world != null)
            {
                world.SetIdentity();
                world.Update(gameTime);
                world.Scale(new Vector3(.1f,.1f,.1f));
                world.RotationZ(Angle);
                world.Translation(new Vector3(0, 2, 1));
            }
        }

        public void Draw(Camera camera)
        {
            propeller.Draw(camera);
            if (world != null)
                world.Draw(camera);
        }

        public void SetIdentity()
        {
            propeller.SetIdentity();
            if (world != null)
                world.SetIdentity();
        }

        public void Translation(Vector3 position)
        {
            propeller.Translation(position);
            if (world != null)
                world.Translation(position);
        }

        public void Scale(Vector3 scale)
        {
            propeller.Scale(scale);
            if (world != null)
                world.Scale(scale);
        }

        public void RotationX(float angle)
        {
            propeller.RotationX(angle);
            if (world != null)
                world.RotationX(angle);
        }

        public void RotationY(float angle)
        {
            propeller.RotationY(angle);
            if (world != null)
                world.RotationY(angle);
        }

        public void RotationZ(float angle)
        {
            propeller.RotationZ(angle);
            if (world != null)
                world.RotationZ(angle);
        }
    }
}
