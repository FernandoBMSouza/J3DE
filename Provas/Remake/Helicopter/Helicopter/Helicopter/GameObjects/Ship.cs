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
        TAKE_OFF,
        FLY,
        LAND,
        STOP,
    }

    class Ship : GameObject
    {
        STATE state = STATE.TAKE_OFF;
        GameObject destination;
        GameObject home;
        float speed;
        Vector3 position;

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
            state = STATE.TAKE_OFF;
            this.home = home;
            this.destination = destination;
            speed = 0.1f;
            position = this.GetPosition();
            Debug.WriteLine("Destinhation Size = " + destination.Size * destination.GetScale());
        }

        public override void Update(GameTime gameTime)
        {
            UpdateState();
            ChangeState();
            World *= Matrix.CreateTranslation(position);

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
            Children[3].World *= Matrix.CreateTranslation(new Vector3(.25f, 0, -2));

            foreach (GameObject child in Children)
                child.World *= World;

            base.Update(gameTime);
            Debug.WriteLine("Destinhation Size = " + destination.Size * destination.GetScale());
        }

        public void UpdateState()
        {
            switch (state)
            {
                case STATE.TAKE_OFF:
                    position.Y += speed;
                    break;
                case STATE.FLY:
                    position.X += speed;
                    break;
                case STATE.LAND:
                    position.Y -= speed;
                    break;
                case STATE.STOP:
                    break;
            }
        }

        public void ChangeState()
        {
            switch (state)
            {
                case STATE.TAKE_OFF:
                    if (position.Y > destination.Size.Y * destination.GetScale().Y) state = STATE.FLY;
                    break;
                case STATE.FLY:
                    if (position.X >= 30) state = STATE.LAND;
                    break;
                case STATE.LAND:
                    if (IsColliding(destination)) state = STATE.STOP;
                    break;
                case STATE.STOP:
                    break;
            }
        }
    }
}
