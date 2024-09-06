using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Prova01.GameObjects.Shapes;
using Microsoft.Xna.Framework.Input;

namespace Prova01.GameObjects.Prova01
{
    public abstract class Snail : GameObject
    {
        public enum STATE
        { 
            IDLE,
            FRONT,
            ROTATE,
        }

        STATE state;
        Vector3 forward;
        float speed, rotationSpeed;
        const float TARGET_ANGLE = 90;
        float angle;
        float offset;
        int place;
        static Random random = new Random();
        float timer, timer2;
        const float INTERVAL = 2f;
        const float INTERVAL2 = .1f;
        bool winner;
        Track track;

        Stack<STATE> stateStack;
        Stack<Vector3> positionStack;
        Stack<Vector3> rotationStack;
        Stack<float> angleStack;
        Stack<int> placeStack;

        Queue<STATE> stateQueue;
        Queue<Vector3> positionQueue;
        Queue<Vector3> rotationQueue;
        Queue<float> angleQueue;
        Queue<int> placeQueue;

        public static int special = 1;
        bool wasSpacePressed;
        private bool specialDecremented = false;

        public Snail(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, float offset, Color color, Track track, bool colliderVisible = true)
            : base(game, position, rotation, scale, colliderVisible)
        {
            this.offset = offset;
            SetSize(new Vector3(1,1,1));
            children.Add(new Cube(game, new Vector3(0, .5f, 0), Vector3.Zero, new Vector3(1, 1, 1), color, false));
            children.Add(new Cube(game, new Vector3(0, -.25f, 0), Vector3.Zero, new Vector3(.5f, .5f, 2f), Color.LightSalmon, false));

            state = STATE.FRONT;
            speed = random.Next(1, 20) * 0.1f;
            rotationSpeed = speed * 20;
            place = 0;

            this.track = track;
            winner = false;
            wasSpacePressed = false;

            stateStack = new Stack<STATE>();
            positionStack = new Stack<Vector3>();
            rotationStack = new Stack<Vector3>();
            angleStack = new Stack<float>();
            placeStack = new Stack<int>();

            stateStack.Push(this.state);
            positionStack.Push(GetPosition());
            rotationStack.Push(GetRotation());
            angleStack.Push(this.angle);
            placeStack.Push(this.place);

            stateQueue = new Queue<STATE>();
            positionQueue = new Queue<Vector3>();
            rotationQueue = new Queue<Vector3>();
            angleQueue = new Queue<float>();
            placeQueue = new Queue<int>();

            stateQueue.Enqueue(this.state);
            positionQueue.Enqueue(GetPosition());
            rotationQueue.Enqueue(GetRotation());
            angleQueue.Enqueue(this.angle);
            placeQueue.Enqueue(this.place);
        }

        private static bool spaceReleased = false;

        public override void Update(GameTime gameTime)
        {
            timer += gameTime.ElapsedGameTime.Milliseconds * 0.001f;
            timer2 += gameTime.ElapsedGameTime.Milliseconds * 0.001f;

            stateQueue.Enqueue(this.state);
            positionQueue.Enqueue(GetPosition());
            rotationQueue.Enqueue(GetRotation());
            angleQueue.Enqueue(this.angle);
            placeQueue.Enqueue(this.place);

            if (timer >= INTERVAL)
            {
                speed = random.Next(1, 20) * 0.1f;
                rotationSpeed = speed * 20;
                timer = 0;
            }

            var keyboardState = Keyboard.GetState();

            if (winner == true)
            {
                if (stateQueue.Count > 0) this.state = stateQueue.Dequeue();
                if (angleQueue.Count > 0) this.angle = angleQueue.Dequeue();
                if (placeQueue.Count > 0) this.place = placeQueue.Dequeue();
                if (positionQueue.Count > 0) SetPosition(positionQueue.Dequeue());
                if (rotationQueue.Count > 0) SetRotation(rotationQueue.Dequeue());
            }
            else if (keyboardState.IsKeyDown(Keys.Space) && special > 0)
            {
                // Voltar no tempo enquanto a tecla Space está pressionada
                if (stateStack.Count > 0) this.state = stateStack.Pop();
                if (angleStack.Count > 0) this.angle = angleStack.Pop();
                if (placeStack.Count > 0) this.place = placeStack.Pop();
                if (positionStack.Count > 0) SetPosition(positionStack.Pop());
                if (rotationStack.Count > 0) SetRotation(rotationStack.Pop());

                // Indicar que a tecla Space estava pressionada
                wasSpacePressed = true;
                spaceReleased = false;
            }
            else if (wasSpacePressed && keyboardState.IsKeyUp(Keys.Space) && !spaceReleased)
            {
                // Decrementar o special apenas uma vez globalmente quando a tecla Space for liberada
                DecrementSpecial();
                spaceReleased = true;
                wasSpacePressed = false;
            }
            else
            {
                if (timer2 >= INTERVAL2)
                {
                    stateStack.Push(this.state);
                    positionStack.Push(GetPosition());
                    rotationStack.Push(GetRotation());
                    angleStack.Push(this.angle);
                    placeStack.Push(this.place);

                    timer2 = 0;
                }

                UpdateState(gameTime);
                ChangeState();
            }
            base.Update(gameTime);
        }


        public void UpdateState(GameTime gameTime)
        {
            // Calcula o vetor de frente baseado na rotação em torno do eixo Y (yaw)
            forward = new Vector3((float)Math.Sin(MathHelper.ToRadians(GetRotation().Y)), 
                                  0,
                                  (float)Math.Cos(MathHelper.ToRadians(GetRotation().Y)));
            switch (state)
            {
                case STATE.IDLE:
                    break;
                case STATE.FRONT:
                    AddPosition(forward * speed * gameTime.ElapsedGameTime.Milliseconds * 0.001f);
                    break;
                case STATE.ROTATE:
                    angle += rotationSpeed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
                    AddPosition(forward * speed * gameTime.ElapsedGameTime.Milliseconds * 0.001f);
                    AddRotation(new Vector3(0, rotationSpeed * gameTime.ElapsedGameTime.Milliseconds * 0.001f, 0));
                    break;
            }
        }

        public void ChangeState()
        {
            switch (state)
            {
                case STATE.IDLE:
                    break;
                case STATE.FRONT:
                    place %= 4;
                    switch (place)
                    { 
                        case 0:
                            if (GetPosition().X <= -track.GetDimension().X / 3.5f)
                            {
                                state = STATE.ROTATE;
                                place++;
                            }
                            break;
                        case 1:
                            if (GetPosition().Z >= track.GetDimension().Z/4 - offset)
                            {
                                state = STATE.ROTATE;
                                place++;
                            }
                            break;
                        case 2:
                            if (GetPosition().X >= track.GetDimension().X / 3.5f)
                            {
                                state = STATE.ROTATE;
                                place++;
                            }
                            break;
                        case 3:
                            if (GetPosition().Z <= -track.GetDimension().Z / 4 + offset)
                            {
                                state = STATE.ROTATE;
                                place++;
                            }
                            break;
                    };
                    break;
                case STATE.ROTATE:
                    if (angle >= TARGET_ANGLE)
                    {
                        angle = 0;
                        state = STATE.FRONT;
                        FixRotation();
                    }
                    break;
            }

            //if (Keyboard.GetState().IsKeyDown(Keys.U)) state = STATE.FRONT;
            //else if (Keyboard.GetState().IsKeyDown(Keys.Y)) state = STATE.ROTATE;
            //else state = STATE.IDLE;
        }

        public void FixRotation()
        {
            // Arredonda a rotação no eixo Y para 0, 90, 180, ou 270 graus
            //Vector3 currentRotation = GetRotation();
            //float roundedY = MathHelper.ToDegrees(MathHelper.WrapAngle(MathHelper.ToRadians(currentRotation.Y)));
            float roundedY = 0f;
            // Arredonda para os ângulos mais próximos: 0, 90, 180, ou 270
            if (GetRotation().Y >= 0 && GetRotation().Y < 90)
                roundedY = 0;
            else if (GetRotation().Y >= 90 && GetRotation().Y < 180)
                roundedY = 90;
            else if (GetRotation().Y >= 180 && GetRotation().Y < 270)
                roundedY = 180;
            else if (GetRotation().Y >= 270 && GetRotation().Y < 360)
                roundedY = 270;
            else if (GetRotation().Y > 360)
                roundedY = 0;

            // Define a rotação arredondada
            SetRotation(new Vector3(GetRotation().X, roundedY, GetRotation().Z));
        }

        public void SetWinner(bool value)
        {
            state = STATE.IDLE;
            winner = value;
        }

        public void IncrementSpecial()
        {
           special++;
        }

        public void DecrementSpecial()
        {
            if (special <= 0) 
                special = 0;
            else
                special--;
        }

        private bool collidedWithFirstThird = false;
        private bool collidedWithSecondThird = false;
        private bool collidedWithFinish = false;

        public bool HasCollidedWithFirstThird()
        {
            return collidedWithFirstThird;
        }

        public bool HasCollidedWithSecondThird()
        {
            return collidedWithSecondThird;
        }

        public bool HasCollidedWithFinish()
        {
            return collidedWithFinish;
        }

        public void MarkCollisionWithFirstThird()
        {
            collidedWithFirstThird = true;
        }

        public void MarkCollisionWithSecondThird()
        {
            collidedWithSecondThird = true;
        }

        public void MarkCollisionWithFinish()
        {
            collidedWithFinish = true;
        }
    }
}
