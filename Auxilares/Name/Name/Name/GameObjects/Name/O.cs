using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Name.GameObjects.Shapes;

namespace Name.GameObjects.Name
{
    class O : GameObject
    {
        float speed;
        public O(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Color color, bool colliderVisible = true)
            : base(game, position, rotation, scale, colliderVisible)
        {
            SetSize(new Vector3(3, 5, 1));

            children.Add(new RightTriangle3D(game, new Vector3(-1, -2, 0), new Vector3(0, 0, 180), new Vector3(1), color, false));
            children.Add(new Cube(game, new Vector3(-1, -1, 0), new Vector3(0, 0, 0), new Vector3(1), color, false));
            children.Add(new Cube(game, new Vector3(-1, 0, 0), new Vector3(0, 0, 0), new Vector3(1), color, false));
            children.Add(new Cube(game, new Vector3(-1, 1, 0), new Vector3(0, 0, 0), new Vector3(1), color, false));
            children.Add(new RightTriangle3D(game, new Vector3(-1, 2, 0), new Vector3(0, 0, 90), new Vector3(1), color, false));

            children.Add(new Cube(game, new Vector3(0, 2, 0), new Vector3(0, 0, 0), new Vector3(1), color, false));
            children.Add(new Cube(game, new Vector3(0, -2, 0), new Vector3(0, 0, 0), new Vector3(1), color, false));

            children.Add(new RightTriangle3D(game, new Vector3(1, 2, 0), new Vector3(0, 0, 0), new Vector3(1, 1, 1), color, false));
            children.Add(new Cube(game, new Vector3(1, -1, 0), new Vector3(0, 0, 0), new Vector3(1), color, false));
            children.Add(new Cube(game, new Vector3(1, 0, 0), new Vector3(0, 0, 0), new Vector3(1), color, false));
            children.Add(new Cube(game, new Vector3(1, 1, 0), new Vector3(0, 0, 0), new Vector3(1), color, false));
            children.Add(new RightTriangle3D(game, new Vector3(1, -2, 0), new Vector3(0, 0, 270), new Vector3(1, 1, 1), color, false));

            speed = 100f;
        }

        public override void Update(GameTime gameTime)
        {
            rotation.Y += speed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
            base.Update(gameTime);
        }
    }
}
