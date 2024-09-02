using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Helicopter.GameObjects.Primitives;
using Helicopter.GameObjects.Windmill;

namespace Helicopter.GameObjects
{
    public enum STATE
    { 
        TRAVEL,
        BACK_HOME,
    }

    class Ship : GameObject
    {
        STATE state = STATE.TRAVEL;
        GameObject destination;
        GameObject home;
        float speed;
        float acceleration;

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
            state = STATE.TRAVEL;
            this.home = home;
            this.destination = destination;
            speed = 10;
        }

        public override void Update(GameTime gameTime)
        {
            acceleration += speed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;

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
            Children[2].World *= Matrix.CreateTranslation(new Vector3(0, Children[0].Size.Y / 2 + .05f, 0));

            Children[3].World *= Matrix.CreateScale(new Vector3(.4f,.4f,1));
            Children[3].World *= Matrix.CreateRotationY(MathHelper.ToRadians(90));
            Children[3].World *= Matrix.CreateTranslation(new Vector3(.25f, 0, -2));

            foreach (GameObject child in Children)
                child.World *= World;

            base.Update(gameTime);

            UpdateState();
            ChangeState();
        }

        public void UpdateState()
        {
            if (state == STATE.TRAVEL)
            {
                if (this.GetPosition().Y < destination.GetPosition().Y + destination.Size.Y)
                {
                    World *= Matrix.CreateTranslation(new Vector3(0, acceleration, 0));
                }
                else if (this.GetPosition().X < destination.GetPosition().X)
                {
                    World *= Matrix.CreateTranslation(new Vector3(acceleration, 0, 0));
                }
                else if (this.GetPosition().Y > destination.GetPosition().Y)
                {
                    World *= Matrix.CreateTranslation(new Vector3(0, -acceleration, 0));
                }
            }
            else if (state == STATE.BACK_HOME)
            {
                if (this.GetPosition().Y <= destination.GetPosition().Y + destination.Size.Y)
                {
                    World *= Matrix.CreateTranslation(new Vector3(0, acceleration, 0));
                }
                else if (this.GetPosition().X > home.GetPosition().X)
                {
                    World *= Matrix.CreateTranslation(new Vector3(-acceleration, 0, 0));
                }
                else if (this.GetPosition().Y > home.GetPosition().Y)
                {
                    World *= Matrix.CreateTranslation(new Vector3(0, -acceleration, 0));
                }
            }
        }

        public void ChangeState()
        {
            if (state == STATE.TRAVEL)
            {
                if(this.IsColliding(destination))
                    state = STATE.BACK_HOME;
            }
            else if (state == STATE.BACK_HOME)
            {
                if(this.IsColliding(home))
                    state = STATE.TRAVEL;
            }
        }
    }
}
