using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Helicopter
{
    public enum STATE
    {
        IDLE,
        UP,
        DOWN,
        RIGHT,
        LEFT,
        ROTATE_RIGHT,
        ROTATE_LEFT,
    };

    class Helicopter : GameObject
    {
        Cube[] cubes;
        Blade[] blades;

        bool flying;
        bool arrived;
        int altitude;
        float bladeSpeed;
        float moveSpeed;
        float rotateSpeed;
        float currentTime;
        const float GAP = 1f;
        Cube initialLocation;
        Cube destinationLocation;
        STATE state;
        STATE previousState;

        public Helicopter(Game1 game, GraphicsDevice device, Cube initialLocation, Cube destinationLocation)
            : base(game, device)
        {
            Size = new Vector3(2, 2, 6);
            flying = false;
            bladeSpeed = 400;

            cubes = new Cube[2];
            blades = new Blade[6];

            state = STATE.IDLE;
            previousState = state;
            currentTime = 0f;
            moveSpeed = 10;
            rotateSpeed = 1;
            arrived = true;
            this.initialLocation = initialLocation;
            this.destinationLocation = destinationLocation;
            altitude = 3;

            for (int i = 0; i < cubes.Length; i++)
                cubes[i] = new Cube(game, device);

            for (int i = 0; i < blades.Length; i++)
                blades[i] = new Blade(game, device);

            Setup();
        }

        void Setup()
        {
            cubes[0].Position = new Vector3(0, 0, 2);
            cubes[1].Scale = new Vector3(.5f, .5f, 2);

            blades[0].Position = new Vector3(0, 1.25f, 2);
            blades[1].Position = new Vector3(0, 1.25f, 2);
            blades[0].Rotation = new Vector3(MathHelper.ToRadians(270), 0, 0);
            blades[1].Rotation = new Vector3(MathHelper.ToRadians(270), 0, MathHelper.ToRadians(90));
            blades[0].Scale = new Vector3(.5f, .7f, 1);
            blades[1].Scale = new Vector3(.5f, .7f, 1);

            blades[2].Scale = new Vector3(.15f, .2f, 1);
            blades[3].Scale = new Vector3(.15f, .2f, 1);
            blades[2].Rotation = new Vector3(0, MathHelper.ToRadians(90), 0);
            blades[3].Rotation = new Vector3(0, MathHelper.ToRadians(90), MathHelper.ToRadians(90));
            blades[2].Position = new Vector3(.7f, 0, -2);
            blades[3].Position = new Vector3(.7f, 0, -2);

            blades[4].Scale = new Vector3(.15f, .2f, 1);
            blades[5].Scale = new Vector3(.15f, .2f, 1);
            blades[4].Rotation = new Vector3(0, MathHelper.ToRadians(270), 0);
            blades[5].Rotation = new Vector3(0, MathHelper.ToRadians(270), MathHelper.ToRadians(90));
            blades[4].Position = new Vector3(-.7f, 0, -2);
            blades[5].Position = new Vector3(-.7f, 0, -2);
        }

        public override void Update(GameTime gameTime)
        {
            if (flying)
            {
                float bladesRotationAngle = bladeSpeed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
                foreach (Blade blade in blades)
                {
                    blade.Rotation = new Vector3(blade.Rotation.X,
                                                 blade.Rotation.Y,
                                                 blade.Rotation.Z + bladesRotationAngle);
                }
                    
            }
            UpdateState(gameTime);
            ChangeState(gameTime);
        }

        public override void Draw(Camera camera, Matrix parentWorld, bool showColliders = false)
        {
            Matrix localMatrix = Matrix.CreateScale(Scale)
                                 * Matrix.CreateFromYawPitchRoll(Rotation.Y, Rotation.X, Rotation.Z)
                                 * Matrix.CreateTranslation(Position);

            Matrix result = localMatrix * parentWorld;
            effect.World = result;
            effect.View = camera.View;
            effect.Projection = camera.Projection;

            foreach (Cube cube in cubes) cube.Draw(camera, result, false);
            foreach (Blade blade in blades) blade.Draw(camera, result, false);
            if (showColliders) LBox.Draw(effect);
        }

        private void UpdateState(GameTime gameTime)
        {
            float moveOffset = moveSpeed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
            float rotateOffset = rotateSpeed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;

            switch (state)
            {
                case STATE.IDLE:
                    break;
                case STATE.UP:
                    Position += new Vector3(0, moveOffset, 0);
                    break;
                case STATE.DOWN:
                    Position += new Vector3(0, -moveOffset, 0);
                    break;
                case STATE.RIGHT:
                    Position += new Vector3(moveOffset, 0, 0);
                    break;
                case STATE.LEFT:
                    Position += new Vector3(-moveOffset, 0, 0);
                    break;
                case STATE.ROTATE_RIGHT:
                    Rotation += new Vector3(0, rotateOffset, 0);
                    break;
                case STATE.ROTATE_LEFT:
                    Rotation += new Vector3(0, -rotateOffset, 0);
                    break;
            }
        }

        private void ChangeState(GameTime gameTime)
        {
            switch (state)
            {
                case STATE.IDLE:
                    switch (previousState)
                    {
                        case (STATE.IDLE):
                        case (STATE.DOWN):
                            currentTime += gameTime.ElapsedGameTime.Milliseconds * 0.001f;
                            flying = false;
                            if (currentTime >= GAP)
                            {
                                flying = true;
                                previousState = STATE.IDLE;
                                arrived = !arrived;
                                state = STATE.UP;
                                currentTime = 0;
                            }
                            break;
                        case (STATE.UP): break;
                        case (STATE.RIGHT): break;
                        case (STATE.LEFT): break;
                        case (STATE.ROTATE_RIGHT): break;
                        case (STATE.ROTATE_LEFT): break;
                    }
                    break;
                case STATE.UP:
                    switch (previousState)
                    {
                        case (STATE.IDLE):
                            if (Position.Y >= destinationLocation.Size.Y + Size.Y + altitude)
                            {
                                previousState = STATE.UP;
                                state = arrived ? STATE.ROTATE_LEFT : STATE.ROTATE_RIGHT;
                            }
                            break;
                        case (STATE.DOWN): break;
                        case (STATE.UP): break;
                        case (STATE.RIGHT): break;
                        case (STATE.LEFT): break;
                        case (STATE.ROTATE_RIGHT): break;
                        case (STATE.ROTATE_LEFT): break;
                    }
                    break;
                case STATE.ROTATE_RIGHT:
                    switch (previousState)
                    {
                        case (STATE.IDLE): break;
                        case (STATE.DOWN): break;
                        case (STATE.UP):
                            if (Rotation.Y >= MathHelper.ToRadians(90))
                            {
                                previousState = STATE.ROTATE_RIGHT;
                                state = STATE.RIGHT;
                            }
                            break;
                        case (STATE.RIGHT): break;
                        case (STATE.LEFT):
                            if (Rotation.Y >= MathHelper.ToRadians(0))
                            {
                                previousState = STATE.ROTATE_RIGHT;
                                state = STATE.DOWN;
                            }
                            break;
                        case (STATE.ROTATE_RIGHT): break;
                        case (STATE.ROTATE_LEFT): break;
                    }
                    break;
                case STATE.RIGHT:
                    switch (previousState)
                    {
                        case (STATE.IDLE): break;
                        case (STATE.DOWN): break;
                        case (STATE.UP): break;
                        case (STATE.RIGHT): break;
                        case (STATE.LEFT): break;
                        case (STATE.ROTATE_RIGHT):
                            if (Position.X >= destinationLocation.Position.X)
                            {
                                previousState = STATE.RIGHT;
                                state = STATE.ROTATE_LEFT;
                            }
                            break;
                        case (STATE.ROTATE_LEFT): break;
                    }
                    break;
                case STATE.ROTATE_LEFT:
                    switch (previousState)
                    {
                        case (STATE.IDLE): break;
                        case (STATE.DOWN): break;
                        case (STATE.UP):
                            if (Rotation.Y <= MathHelper.ToRadians(-90))
                            {
                                previousState = STATE.ROTATE_LEFT;
                                state = STATE.LEFT;
                            }
                            break;
                        case (STATE.RIGHT):
                            if (Rotation.Y <= MathHelper.ToRadians(0))
                            {
                                previousState = STATE.ROTATE_LEFT;
                                state = STATE.DOWN;
                            }
                            break;
                        case (STATE.LEFT): break;
                        case (STATE.ROTATE_RIGHT): break;
                        case (STATE.ROTATE_LEFT): break;
                    }
                    break;
                case STATE.DOWN:
                    switch (previousState)
                    {
                        case (STATE.IDLE): break;
                        case (STATE.DOWN): break;
                        case (STATE.UP): break;
                        case (STATE.RIGHT): break;
                        case (STATE.LEFT): break;
                        case (STATE.ROTATE_RIGHT):
                            if (Position.Y <= initialLocation.Size.Y + Size.Y / 2)
                            {
                                previousState = STATE.DOWN;
                                state = STATE.IDLE;
                            }
                            break;
                        case (STATE.ROTATE_LEFT):
                            if (Position.Y <= destinationLocation.Size.Y + Size.Y / 2)
                            {
                                previousState = STATE.DOWN;
                                state = STATE.IDLE;
                            }
                            break;
                    }
                    break;
                case STATE.LEFT:
                    switch (previousState)
                    {
                        case (STATE.IDLE): break;
                        case (STATE.DOWN): break;
                        case (STATE.UP): break;
                        case (STATE.RIGHT): break;
                        case (STATE.LEFT): break;
                        case (STATE.ROTATE_RIGHT): break;
                        case (STATE.ROTATE_LEFT):
                            if (Position.X <= initialLocation.Position.X)
                            {
                                previousState = STATE.LEFT;
                                state = STATE.ROTATE_RIGHT;
                            }
                            break;
                    }
                    break;
            }
        }
    }
}
