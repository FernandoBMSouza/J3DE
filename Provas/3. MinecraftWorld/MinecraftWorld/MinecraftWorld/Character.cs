using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MinecraftWorld
{
    public enum STATE
    {
        IDLE,

        FRONT,
        BACK,
        RIGHT,
        LEFT,
    };

    abstract class Character : ITransform
    {
        protected Cube[] cubes;
        protected STATE state;
        protected float moveSpeed;
        protected static Random random;

        public Vector3 Position { get; protected set; }
        public Vector3 Angle { get; protected set; }

        public Character(GraphicsDevice device)
        {
            cubes = new Cube[6];
            for (int i = 0; i < cubes.Length; i++) cubes[i] = new Cube(device);

            state = STATE.IDLE;
            random = new Random();
            moveSpeed = 2;

            Translation(new Vector3(0, 1.5f, 0));
        }


        public virtual void Update(GameTime gameTime)
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

            Scale(new Vector3(.2f,.2f,.2f));

            UpdateState(gameTime);
            ChangeState(gameTime);

            RotationY(Angle.Y);
            Translation(Position);
        }

        protected void UpdateState(GameTime gameTime)
        {
            float moveOffset = moveSpeed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;

            switch (state)
            {
                case STATE.IDLE: 
                    break;
                case STATE.FRONT:
                    Angle = new Vector3(0, 0, 0);
                    Position += new Vector3(0, 0, moveOffset); 
                    break;
                case STATE.BACK:
                    Angle = new Vector3(0, 180, 0); 
                    Position += new Vector3(0, 0,-moveOffset); 
                    break;
                case STATE.RIGHT:
                    Angle = new Vector3(0, 90, 0);
                    Position += new Vector3(moveOffset, 0, 0); 
                    break;
                case STATE.LEFT:
                    Angle = new Vector3(0, -90, 0); 
                    Position += new Vector3(-moveOffset, 0, 0);
                    break;
            }
        }

        protected virtual void ChangeState(GameTime gameTime)
        {
            int aux = random.Next(3);
            switch (state)
            {
                case STATE.FRONT:
                    switch (aux)
                    {
                        case 0: state = STATE.BACK; break;
                        case 1: state = STATE.RIGHT; break;
                        case 2: state = STATE.LEFT; break;
                    }
                    break;
                case STATE.BACK:
                    switch (aux)
                    {
                        case 0: state = STATE.FRONT; break;
                        case 1: state = STATE.RIGHT; break;
                        case 2: state = STATE.LEFT; break;
                    }
                    break;
                case STATE.RIGHT:
                    switch (aux)
                    {
                        case 0: state = STATE.BACK; break;
                        case 1: state = STATE.FRONT; break;
                        case 2: state = STATE.LEFT; break;
                    }
                    break;
                case STATE.LEFT:
                    switch (aux)
                    {
                        case 0: state = STATE.BACK; break;
                        case 1: state = STATE.RIGHT; break;
                        case 2: state = STATE.FRONT; break;
                    }
                    break;
            }
        }

        public void Draw(Camera camera)
        {
            foreach (Cube c in cubes) c.Draw(camera);
        }

        public void SetIdentity()
        {
            foreach (Cube c in cubes) c.SetIdentity();
        }

        public void Translation(Vector3 position)
        {
            Position = position;
            foreach (Cube c in cubes) c.Translation(position);
        }

        public void Scale(Vector3 scale)
        {
            foreach (Cube c in cubes) c.Scale(scale);
        }

        public void RotationX(float angle)
        {
            Angle = new Vector3(angle, Angle.Y, Angle.Z);
            foreach (Cube c in cubes) c.RotationX(angle);
        }

        public void RotationY(float angle)
        {
            Angle = new Vector3(Angle.X, angle, Angle.Z);
            foreach (Cube c in cubes) c.RotationY(angle);
        }

        public void RotationZ(float angle)
        {
            Angle = new Vector3(Angle.X, Angle.Y, angle);
            foreach (Cube c in cubes) c.RotationZ(angle);
        }
    }
}
