using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

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

    class Helicopter : ITransform
    {
        Cube[] cubes;
        Propeller[] propellers;
        STATE state;
        STATE previousState;
        float moveSpeed;
        float rotateSpeed;
        bool arrived;
        bool isFlying;
        float currentTime;
        const float GAP = 1f;

        float propRotationAngle;
        float propRotationSpeed;

        public Vector3 Position { get; private set; }
        public Vector3 Angle { get; private set; }

        public Helicopter(GraphicsDevice device)
        {
            state = STATE.IDLE;
            previousState = state;
            currentTime = 0f;

            cubes = new Cube[2];
            propellers = new Propeller[12];

            moveSpeed = 10;
            rotateSpeed = 100;
            arrived = true;
            isFlying = false;

            propRotationSpeed = 400;
            propRotationAngle = 0;

            for (int i = 0; i < cubes.Length; i++) cubes[i] = new Cube(device);
            for (int i = 0; i < propellers.Length; i++) propellers[i] = new Propeller(device);

            Translation(new Vector3(-7, 3, 0));
        }

        public void Update(GameTime gameTime)
        {
            SetIdentity();

            cubes[1].Scale(new Vector3(.5f, .5f, 2f));
            cubes[1].Translation(new Vector3(0, 0, -3));

            for (int i = 0; i < 4; i++) propellers[i].Scale(new Vector3(.6f, .7f, 1));

            propellers[0].RotationZ(0);
            propellers[1].RotationZ(90);
            propellers[2].RotationZ(180);
            propellers[3].RotationZ(270);

            for (int i = 0; i < 4; i++) propellers[i].RotationX(-90);
            for (int i = 0; i < 4; i++) propellers[i].RotationY(propRotationAngle);
            for (int i = 0; i < 4; i++) propellers[i].Translation(new Vector3(0, 1.2f, 0)); //HELICE 1

            //HELICE 2
            for (int i = 4; i < 8; i++) propellers[i].Scale(new Vector3(.2f, .3f, 1));

            propellers[4].RotationZ(0);
            propellers[5].RotationZ(90);
            propellers[6].RotationZ(180);
            propellers[7].RotationZ(270);

            for (int i = 4; i < 8; i++) propellers[i].RotationY(-90);
            for (int i = 4; i < 8; i++) propellers[i].RotationX(propRotationAngle);
            for (int i = 4; i < 8; i++) propellers[i].Translation(new Vector3(-.6f, 0, -4.5f));

            //HELICE 3
            for (int i = 8; i < 12; i++) propellers[i].Scale(new Vector3(.2f, .3f, 1));

            propellers[8].RotationZ(0);
            propellers[9].RotationZ(90);
            propellers[10].RotationZ(180);
            propellers[11].RotationZ(270);

            for (int i = 8; i < 12; i++) propellers[i].RotationY(90);
            for (int i = 8; i < 12; i++) propellers[i].RotationX(propRotationAngle);
            for (int i = 8; i < 12; i++) propellers[i].Translation(new Vector3(.6f, 0, -4.5f));

            if(isFlying)
                propRotationAngle += propRotationSpeed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;


            UpdateState(gameTime);
            ChangeState(gameTime);
            RotationY(Angle.Y);
            Translation(Position);
        }

        public void Draw(Camera camera)
        {
            foreach (Cube c in cubes) c.Draw(camera);
            foreach (Propeller p in propellers) p.Draw(camera);
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
                    Angle += new Vector3(0, rotateOffset, 0);
                    break;
                case STATE.ROTATE_LEFT:
                    Angle += new Vector3(0, -rotateOffset, 0);
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
                            if (Position.Y >= 8) 
                            {
                                previousState = STATE.UP;
                                state = arrived ? STATE.ROTATE_LEFT : STATE.ROTATE_RIGHT;
                            }
                            break;
                        case (STATE.DOWN):break;
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
                            if (Angle.Y >= 90)
                            {
                                previousState = STATE.ROTATE_RIGHT;
                                state = STATE.RIGHT;
                            }
                            break;
                        case (STATE.RIGHT): break;
                        case (STATE.LEFT):
                            if (Angle.Y >= 0)
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
                            if (Position.X >= 7)
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
                            if (Angle.Y <= -90)
                            {
                                previousState = STATE.ROTATE_LEFT;
                                state = STATE.LEFT;
                            }
                            break;
                        case (STATE.RIGHT):
                            if (Angle.Y <= 0)
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
                            if (Position.Y <= 3)
                            {
                                previousState = STATE.DOWN;
                                state = STATE.IDLE;
                            }
                            break;
                        case (STATE.ROTATE_LEFT):
                            if (Position.Y <= 5)
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
                            if (Position.X <= -7)
                            {
                                previousState = STATE.LEFT;
                                state = STATE.ROTATE_RIGHT;
                            }
                            break;
                    }
                    break;
            }
        }

        public void SetIdentity()
        {
            foreach (Cube c in cubes) c.SetIdentity();
            foreach (Propeller p in propellers) p.SetIdentity();
        }

        public void Translation(Vector3 position)
        {
            Position = position;
            foreach (Cube c in cubes) c.Translation(position);
            foreach (Propeller p in propellers) p.Translation(position);
        }

        public void Scale(Vector3 scale)
        {
            foreach (Cube c in cubes) c.Scale(scale);
            foreach (Propeller p in propellers) p.Scale(scale);
        }

        public void RotationX(float angle)
        {
            Angle = new Vector3(angle, Angle.Y, Angle.Z);
            foreach (Cube c in cubes) c.RotationX(angle);
            foreach (Propeller p in propellers) p.RotationX(angle);
        }

        public void RotationY(float angle)
        {
            Angle = new Vector3(Angle.X, angle, Angle.Z);
            foreach (Cube c in cubes) c.RotationY(angle);
            foreach (Propeller p in propellers) p.RotationY(angle);
        }

        public void RotationZ(float angle)
        {
            Angle = new Vector3(Angle.X, Angle.Y, angle);
            foreach (Cube c in cubes) c.RotationZ(angle);
            foreach (Propeller p in propellers) p.RotationZ(angle);
        }
    }
}