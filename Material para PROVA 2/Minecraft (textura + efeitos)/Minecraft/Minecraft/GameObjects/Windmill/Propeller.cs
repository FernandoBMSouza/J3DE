using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Minecraft.GameObjects.Windmill
{
    class Propeller : GameObject
    {
        float rotationSpeed;
        bool working;
        static Random random = new Random();

        public Propeller(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Color color, Effect effect, bool working = true, bool colliderVisible = true)
            : base(game, position, rotation, scale, colliderVisible)
        {
            SetSize(new Vector3(2, 2, .1f));
            this.working = working;
            rotationSpeed = random.Next(50, 500);

            children.Add(new Blade(game, new Vector3(0, .5f, 0), new Vector3(0, 0, 0), new Vector3(1, 1, 1), color, effect, false));
            children.Add(new Blade(game, new Vector3(0, -.5f, 0), new Vector3(0, 0, 180), new Vector3(1, 1, 1), color, effect, false));
            children.Add(new Blade(game, new Vector3(-.5f, 0, 0), new Vector3(0, 0, 90), new Vector3(1, 1, 1), color, effect, false));
            children.Add(new Blade(game, new Vector3(.5f, 0, 0), new Vector3(0, 0, 270), new Vector3(1, 1, 1), color, effect, false));
        }

        public Propeller(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Effect effect, Texture2D texture, bool working = true, bool colliderVisible = true)
            : base(game, position, rotation, scale, colliderVisible)
        {
            SetSize(new Vector3(2, 2, .1f));
            this.working = working;
            rotationSpeed = random.Next(50, 500);

            children.Add(new Blade(game, new Vector3(0, .5f, 0), new Vector3(0, 0, 0), new Vector3(1, 1, 1), effect, texture, false));
            children.Add(new Blade(game, new Vector3(0, -.5f, 0), new Vector3(0, 0, 180), new Vector3(1, 1, 1), effect, texture, false));
            children.Add(new Blade(game, new Vector3(-.5f, 0, 0), new Vector3(0, 0, 90), new Vector3(1, 1, 1), effect, texture, false));
            children.Add(new Blade(game, new Vector3(.5f, 0, 0), new Vector3(0, 0, 270), new Vector3(1, 1, 1), effect, texture, false));
        }

        public override void Update(GameTime gameTime)
        {
            if (working) //rotation.Z += rotationSpeed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
                AddRotation(new Vector3(0,0,rotationSpeed * gameTime.ElapsedGameTime.Milliseconds * 0.001f));
            base.Update(gameTime);
        }
    }
}
