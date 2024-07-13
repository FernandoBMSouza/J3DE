using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Mundo02
{
    class Windmill
    {
        public Building building;
        Blade blade;

        public Vector3 Scale { get; set; }
        public Vector3 Rotation { get; set; }
        public Vector3 Position { get; set; }

        public Windmill(Game1 game, GraphicsDevice device)
        {
            building = new Building(game, device);
            blade = new Blade(game, device);

            blade.Position = new Vector3(0, 1, 3.5f);
            blade.Scale = new Vector3(.4f, .5f, 1);

            Rotation = Vector3.Zero;
            Position = Vector3.Zero;
            Scale = Vector3.One;
        }

        public void Draw(Camera camera)
        {
            Matrix world = Matrix.CreateScale(Scale)
                         * Matrix.CreateFromYawPitchRoll(Rotation.Y, Rotation.X, Rotation.Z)
                         * Matrix.CreateTranslation(Position);

            building.Draw(camera, world);
            blade.Draw(camera, world);
        }
    }
}
