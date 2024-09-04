using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Name.GameObjects.Shapes;

namespace Name.GameObjects.Name
{
    class Fernando : GameObject
    {
        float speed;
        public Fernando(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Color color, bool colliderVisible = true)
            : base(game, position, rotation, scale, colliderVisible)
        {
            SetSize(new Vector3(31, 5, 1));

            children.Add(new F(game, new Vector3(-14, 0, 0), new Vector3(0, 0, 0), new Vector3(1, 1, 1), color, false));
            children.Add(new E(game, new Vector3(-10, 0, 0), new Vector3(0, 0, 0), new Vector3(1, 1, 1), color, false));
            children.Add(new R(game, new Vector3(-6, 0, 0), new Vector3(0, 0, 0), new Vector3(1, 1, 1), color, false));
            children.Add(new N(game, new Vector3(-2, 0, 0), new Vector3(0, 0, 0), new Vector3(1, 1, 1), color, false));
            children.Add(new A(game, new Vector3( 2, 0, 0), new Vector3(0, 0, 0), new Vector3(1, 1, 1), color, false));
            children.Add(new N(game, new Vector3( 6, 0, 0), new Vector3(0, 0, 0), new Vector3(1, 1, 1), color, false));
            children.Add(new D(game, new Vector3( 10, 0, 0), new Vector3(0, 0, 0), new Vector3(1, 1, 1), color, false));
            children.Add(new O(game, new Vector3( 14, 0, 0), new Vector3(0, 0, 0), new Vector3(1, 1, 1), color, false));
            
            speed = 50f;
        }

        public override void Update(GameTime gameTime)
        {
            scale.Z = .5f;
            rotation.Y += speed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
            base.Update(gameTime);
        }
    }
}
