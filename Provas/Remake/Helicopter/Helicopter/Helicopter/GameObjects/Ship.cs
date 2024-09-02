using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Helicopter.GameObjects.Primitives;
using Helicopter.GameObjects.Windmill;
using System.Diagnostics;

namespace Helicopter.GameObjects
{
    public enum STATE
    { 
        UP,
        DOWN,
        RIGHT,
        LEFT,
        IDLE,
        ROTATE_RIGHT,
        ROTATE_LEFT,
    }

    class Ship : GameObject
    {
        STATE state = STATE.UP;
        GameObject destination;
        GameObject home;
        float speed, rotationSpeed;
        float timer;
        const float GAP = 2f;
        Vector3 position;
        float angle;
        bool arrived;

        public Ship(Game1 game, Color bodyColor, Color propellerColor, GameObject home, GameObject destination, bool showColliderLines = false)
            : base(game, showColliderLines)
        {
            Children = new GameObject[]
            {
                new Cube(game, bodyColor, showColliderLines),
                new Cube(game, bodyColor, showColliderLines),
                new Propeller(game, propellerColor, true, showColliderLines),
                new Propeller(game, propellerColor, true, showColliderLines),
            };
            Size = Children[0].Size;
            state = STATE.UP;
            this.home = home;
            this.destination = destination;
            speed = 10f;
            rotationSpeed = 50f;
            position = GetPosition();
            arrived = false;
        }

        public override void Update(GameTime gameTime)
        {
            UpdateState(gameTime);
            ChangeState(gameTime);

            foreach (GameObject child in Children)
            {
                child.Update(gameTime);
                child.World = Matrix.Identity;
            }

            Children[0].World *= Matrix.CreateTranslation(new Vector3(0, 0, 0));

            Children[1].World *= Matrix.CreateScale(new Vector3(.5f, .5f, 1.5f));
            Children[1].World *= Matrix.CreateTranslation(new Vector3(0, 0, -Children[1].Size.Z - 0.2f));

            Children[2].World *= Matrix.CreateScale(new Vector3(1.3f, 1.3f, 1));
            Children[2].World *= Matrix.CreateRotationX(MathHelper.ToRadians(90));
            Children[2].World *= Matrix.CreateTranslation(new Vector3(0, .6f, 0));

            Children[3].World *= Matrix.CreateScale(new Vector3(.4f,.4f,1));
            Children[3].World *= Matrix.CreateRotationY(MathHelper.ToRadians(90));
            Children[3].World *= Matrix.CreateTranslation(new Vector3(-.35f, 0, -2));

            foreach (GameObject child in Children)
                child.World *= World;

            base.Update(gameTime);
        }

        public void UpdateState(GameTime gameTime)
        {
            World = Matrix.Identity;
            World *= Matrix.CreateRotationY(MathHelper.ToRadians(angle));
            World *= Matrix.CreateTranslation(position);

            switch (state)
            {
                case STATE.UP:
                    ((Propeller)Children[2]).SetOnAndOff(true);
                    ((Propeller)Children[3]).SetOnAndOff(true);
                    position.Y += speed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
                    break;
                case STATE.RIGHT:
                    position.X += speed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;;
                    break;
                case STATE.LEFT:
                    position.X -= speed * gameTime.ElapsedGameTime.Milliseconds * 0.001f; ;
                    break;
                case STATE.DOWN:
                    position.Y -= speed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;;
                    break;
                case STATE.IDLE:
                    ((Propeller)Children[2]).SetOnAndOff(false);
                    ((Propeller)Children[3]).SetOnAndOff(false);
                    break;
                case STATE.ROTATE_RIGHT:
                    angle += rotationSpeed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;;
                    break;
                case STATE.ROTATE_LEFT:
                    angle -= rotationSpeed * gameTime.ElapsedGameTime.Milliseconds * 0.001f; ;
                    break;
            }
        }

        public void ChangeState(GameTime gameTime)
        {
            switch (state)
            {
                case STATE.UP:
                    if (position.Y > destination.Size.Y * destination.GetScale().Y + 5)
                    {
                        if (arrived)
                        {
                            state = STATE.ROTATE_LEFT;
                        }
                        else
                        {
                            state = STATE.ROTATE_RIGHT;                            
                        }
                    }
                    break;
                case STATE.RIGHT:
                    if (position.X >= destination.GetPosition().X)
                    {
                        if (!arrived)
                        {
                            state = STATE.ROTATE_LEFT;
                        }
                        else
                        {
                            state = STATE.ROTATE_RIGHT;
                        }
                    }
                    break;
                case STATE.LEFT:
                    if (position.X <= home.GetPosition().X)
                    {
                        if (arrived)
                        {
                            state = STATE.ROTATE_LEFT;
                        }
                        else
                        {
                            state = STATE.ROTATE_RIGHT;
                        }
                    }
                    break;
                case STATE.DOWN:
                    if (IsColliding(home) || IsColliding(destination)) state = STATE.IDLE;
                    break;
                case STATE.IDLE:
                    arrived = !arrived;
                    timer += gameTime.ElapsedGameTime.Milliseconds * 0.001f;
                    if (timer >= GAP)
                    {
                        state = STATE.UP;
                        timer = 0;                    
                    }
                    break;
                case STATE.ROTATE_RIGHT:
                    if (MathHelper.ToRadians(angle) >= MathHelper.ToRadians(90))
                    {
                        if (arrived)
                        {
                            state = STATE.DOWN;
                        }
                        else
                        {
                            state = STATE.RIGHT;
                        }
                    }
                    break;
                case STATE.ROTATE_LEFT:
                    if (MathHelper.ToRadians(angle) <= MathHelper.ToRadians(-90))
                    {
                        if (arrived)
                        {
                            state = STATE.DOWN;
                        }
                        else
                        {
                            state = STATE.LEFT;
                        }
                    }
                    break;
            }
        }
    }
}
