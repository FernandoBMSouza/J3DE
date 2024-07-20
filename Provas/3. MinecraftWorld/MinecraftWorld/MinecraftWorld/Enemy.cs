using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MinecraftWorld
{
    class Enemy : Character
    {
        private float currentTime;
        private const float GAP = 1.0f; // Defina o intervalo de tempo desejado em segundos

        public Enemy(GraphicsDevice device)
            : base(device)
        {
            currentTime = 0;
            state = (STATE)random.Next(1, 5);
            Translation(new Vector3(random.Next(-8, 9), 1.5f, random.Next(-8, 9)));
        }

        public override void Update(GameTime gameTime)
        {
            SetIdentity();

            cubes[0].Scale(new Vector3(1.1f, 1.1f, 1.1f)); // HEAD
            cubes[1].Scale(new Vector3(1, 1.5f, 1)); // BODY
            cubes[2].Scale(new Vector3(.5f, 1.5f, .5f)); // L_ARM
            cubes[3].Scale(new Vector3(.5f, 1.5f, .5f)); // R_ARM
            cubes[4].Scale(new Vector3(.5f, 2, .5f)); // L_LEG
            cubes[5].Scale(new Vector3(.5f, 2, .5f)); // R_LEG

            cubes[0].Translation(new Vector3(0, 0, 0)); // HEAD
            cubes[1].Translation(new Vector3(0, -2.6f, 0)); // BODY
            cubes[2].Translation(new Vector3(-1.5f, -2.6f, 0)); // L_ARM
            cubes[3].Translation(new Vector3(1.5f, -2.6f, 0)); // R_ARM
            cubes[4].Translation(new Vector3(-.5f, -6f, 0)); // L_LEG
            cubes[5].Translation(new Vector3(.5f, -6f, 0)); // R_LEG

            Scale(new Vector3(.2f, .2f, .2f));

            UpdateState(gameTime);

            currentTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (currentTime >= GAP)
            {
                ChangeState(gameTime);
                currentTime = 0;
            }

            RotationY(Angle.Y);
            Translation(Position);
        }
    }
}
