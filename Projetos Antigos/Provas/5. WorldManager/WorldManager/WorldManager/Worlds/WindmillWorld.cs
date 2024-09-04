using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using WorldManager.GameObjects;
using WorldManager.GameObjects.WindmillObjects;

namespace WorldManager.Worlds
{
    class WindmillWorld : BaseWorld
    {
        Random random;

        public WindmillWorld(Game1 game)
            : base(game)
        {
            int seed = (int)DateTime.Now.Ticks % int.MaxValue;
            random = new Random(seed);

            objects.AddLast(new Quad(game, game.Textures["grass"]));
            objects.AddLast(new Cube(game, game.Textures["bricks"]));
            objects.AddLast(new Windmill(game, random.Next(1, 10)));
            objects.AddLast(new Windmill(game, random.Next(1, 10)));


            objects.ElementAt(0).Scale = new Vector3(20, 1, 20);
            objects.ElementAt(1).Position = new Vector3(0, 1, 0);

            objects.ElementAt(2).Position = new Vector3(-8, 2, 0);
            objects.ElementAt(2).Rotation = new Vector3(0, MathHelper.ToRadians(45), 0);

            objects.ElementAt(3).Position = new Vector3(8, 2, 0);
            objects.ElementAt(3).Rotation = new Vector3(0, MathHelper.ToRadians(-45), 0);
        }
    }
}
