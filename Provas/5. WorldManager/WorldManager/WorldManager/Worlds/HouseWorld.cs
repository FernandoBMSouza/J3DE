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
    class HouseWorld : BaseWorld
    {
        public HouseWorld(Game1 game) : base(game)
        {
            objects.AddLast(new Quad(game, game.Textures["grass"]));
            objects.AddLast(new Cube(game, game.Textures["bricks"]));

            objects.ElementAt(0).Scale = new Vector3(20, 1, 20);
            objects.ElementAt(1).Position = new Vector3(0, 1, 0);
        }
    }
}
