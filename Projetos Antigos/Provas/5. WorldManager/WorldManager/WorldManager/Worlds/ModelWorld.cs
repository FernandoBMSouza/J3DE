using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

using WorldManager.GameObjects;
using WorldManager.GameObjects.WindmillObjects;
using WorldManager.GameObjects.ModelObjects;

namespace WorldManager.Worlds
{
    public class ModelWorld : BaseWorld
    {
        Random random;

        public ModelWorld(Game1 game)
            : base(game)
        {
            int seed = (int)DateTime.Now.Ticks % int.MaxValue;
            random = new Random(seed);

            objects.AddLast(new Quad(game, game.Textures["grass"]));
            objects.AddLast(new Cube(game, game.Textures["bricks"]));
            objects.AddLast(new Windmill(game, random.Next(1, 10)));
            objects.AddLast(new Windmill(game, random.Next(1, 10)));

            objects.AddLast(new Hero(game));
            objects.AddLast(new Tower(game));
            objects.AddLast(new WindmillModel(game, random.Next(1, 10)));
            objects.AddLast(new WindmillModel(game, random.Next(1, 10)));


            objects.ElementAt(0).Scale = new Vector3(20, 1, 20);

            objects.ElementAt(1).Position = new Vector3(0, 1, 0);

            objects.ElementAt(2).Position = new Vector3(-8, 2, -8);
            objects.ElementAt(2).Rotation = new Vector3(0, MathHelper.ToRadians(45), 0);

            objects.ElementAt(3).Position = new Vector3(8, 2, -8);
            objects.ElementAt(3).Rotation = new Vector3(0, MathHelper.ToRadians(-45), 0);

            objects.ElementAt(4).Scale = new Vector3(.2f);
            objects.ElementAt(4).Position = new Vector3(0, 1.5f, 6);

            objects.ElementAt(5).Scale = new Vector3(1, 4, 1);
            objects.ElementAt(5).Position = new Vector3(0, 4, -8);

            objects.ElementAt(6).Position = new Vector3(-8, 2, 8);
            objects.ElementAt(6).Rotation = new Vector3(0, MathHelper.ToRadians(135), 0);

            objects.ElementAt(7).Position = new Vector3(8, 2, 8);
            objects.ElementAt(7).Rotation = new Vector3(0, MathHelper.ToRadians(-135), 0);
        }
    }
}
