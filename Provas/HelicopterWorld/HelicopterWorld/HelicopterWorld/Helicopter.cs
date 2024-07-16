using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace HelicopterWorld
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

    class Helicopter
    {
        Cube[] cubes;
        Blade[] blades;

        bool isFlying;
        float propRotationSpeed;

        STATE state;
        STATE previousState;
        float moveSpeed;
        float rotateSpeed;
        bool arrived;
        float currentTime;
        const float GAP = 1f;
        Cube initialLocation;
        Cube destinationLocation;
        int altitude;

        Vector3 scale;
        Vector3 rotation;
        Vector3 position;

        public Vector3 Size { get; private set; }
        public Vector3 Scale
        {
            get { return scale; }
            set 
            {
                scale = value;
                Size *= scale;
            }
        }
        public Vector3 Rotation
        {
            get 
            { 
                return new Vector3(MathHelper.ToDegrees(rotation.X),
                                   MathHelper.ToDegrees(rotation.Y),
                                   MathHelper.ToDegrees(rotation.Z)); 
            }
            set
            {
                rotation = new Vector3(MathHelper.ToRadians(value.X),
                                       MathHelper.ToRadians(value.Y),
                                       MathHelper.ToRadians(value.Z));
            }
        }
        public Vector3 Position
        {
            get { return position; }
            set { position = value; }
        }

        public Helicopter(GraphicsDevice device, Cube initialLocation, Cube destinationLocation)
        {
            cubes = new Cube[2];
            for (int i = 0; i < cubes.Length; i++)
                cubes[i] = new Cube(device);

            blades = new Blade[6];
            for (int i = 0; i < blades.Length; i++)
                blades[i] = new Blade(device);

            Size = cubes[0].Size;
            Scale = Vector3.One;
            Rotation = Vector3.Zero;
            Position = Vector3.Zero;

            isFlying = false;
            propRotationSpeed = 400;

            state = STATE.IDLE;
            previousState = state;
            currentTime = 0f;
            moveSpeed = 10;
            rotateSpeed = 1;
            arrived = true;
            this.initialLocation = initialLocation;
            this.destinationLocation = destinationLocation;
            altitude = 3;

            // SETUP

            // Cubes
            cubes[1].Scale = new Vector3(.5f, .5f, 2f);
            cubes[1].Position = new Vector3(0, 0, -3);

            // Blades 0 and 1
            for (int i = 0; i < 2; i++)
            {
                blades[i].Scale = new Vector3(.6f, .7f, 1);
                blades[i].Position = new Vector3(0, 1.2f, 0);
                blades[i].Rotation = new Vector3(-90, 0, 0);
            }

            blades[1].Rotation = new Vector3(blades[1].Rotation.X, blades[1].Rotation.Y, blades[1].Rotation.Z + 90);

            // Blades 2 and 3
            for (int i = 2; i < 4; i++)
            {
                blades[i].Scale = new Vector3(.2f, .3f, 1);
                blades[i].Position = new Vector3(-0.6f, 0, -4.5f);
                blades[i].Rotation = new Vector3(0, 270, 0);
            }
            blades[3].Rotation = new Vector3(blades[3].Rotation.X, blades[3].Rotation.Y, blades[3].Rotation.Z + 90);

            // Blades 4 and 5
            for (int i = 4; i < 6; i++)
            {
                blades[i].Scale = new Vector3(.2f, .3f, 1);
                blades[i].Position = new Vector3(0.6f, 0, -4.5f);
                blades[i].Rotation = new Vector3(0, 90, 0);
            }
            blades[5].Rotation = new Vector3(blades[5].Rotation.X, blades[5].Rotation.Y, blades[5].Rotation.Z + 90);
        }

        public void Update(GameTime gameTime)
        {
            if (isFlying)
            {
                float propRotationAngle = propRotationSpeed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
                foreach (Blade blade in blades)
                    blade.Rotation = new Vector3(blade.Rotation.X, blade.Rotation.Y, blade.Rotation.Z + propRotationAngle);
            }
            UpdateState(gameTime);
            ChangeState(gameTime);
        }

        public void Draw(Camera camera)
        {
            Matrix world = Matrix.CreateScale(Scale)
                         * Matrix.CreateFromYawPitchRoll(Rotation.Y, Rotation.X, Rotation.Z)
                         * Matrix.CreateTranslation(Position);

            foreach (Cube cube in cubes) cube.Draw(camera, world);
            foreach (Blade blade in blades) blade.Draw(camera, world);
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
                            isFlying = false;
                            if (currentTime >= GAP)
                            {
                                isFlying = true;
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
                            if (Position.Y <= initialLocation.Size.Y + Size.Y/2)
                            {
                                previousState = STATE.DOWN;
                                state = STATE.IDLE;
                            }
                            break;
                        case (STATE.ROTATE_LEFT):
                            if (Position.Y <= destinationLocation.Size.Y + Size.Y/2)
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