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
        ROTATE_RIGHT,
        ROTATE_LEFT,
        RIGHT,
        LEFT,
        IDLE,
    }

    class Ship : GameObject
    {
        STATE state, previousState;
        Vector3 position;
        float angle, rotationSpeed, speed, timer;
        const float GAP = 2f;
        GameObject building1, building2, destination;

        public Ship(Game1 game, Color bodyColor, Color propellerColor, GameObject building1, GameObject building2, bool showColliderLines = false)
            : base(game, showColliderLines)
        {
            Children = new GameObject[]
            {
                new Cube(game, bodyColor, showColliderLines),
                new Cube(game, bodyColor, showColliderLines),
                new Propeller(game, propellerColor, false, showColliderLines),
                new Propeller(game, propellerColor, false, showColliderLines),
            };
            Size = Children[0].Size;
            previousState = state = STATE.IDLE;
            rotationSpeed = 50f;
            speed = 2f;
            this.building1 = destination = building1;
            this.building2 = building2;
        }

        public override void Update(GameTime gameTime)
        {
            foreach (GameObject child in Children)
            {
                child.Update(gameTime);
                child.World = Matrix.Identity;
            }

            Children[1].World *= Matrix.CreateScale(new Vector3(.5f, .5f, 1.5f));
            Children[2].World *= Matrix.CreateScale(new Vector3(1.3f, 1.3f, 1));
            Children[3].World *= Matrix.CreateScale(new Vector3(.4f, .4f, 1));

            Children[2].World *= Matrix.CreateRotationX(MathHelper.ToRadians(90));
            Children[3].World *= Matrix.CreateRotationY(MathHelper.ToRadians(90));

            Children[0].World *= Matrix.CreateTranslation(new Vector3(0, 0, 0));
            Children[1].World *= Matrix.CreateTranslation(new Vector3(0, 0, -Children[1].Size.Z - 0.2f));
            Children[2].World *= Matrix.CreateTranslation(new Vector3(0, .6f, 0));
            Children[3].World *= Matrix.CreateTranslation(new Vector3(-.35f, 0, -2));
            
            UpdateState(gameTime);
            ChangeState(gameTime);

            foreach (GameObject child in Children)
                child.World *= World;

            base.Update(gameTime);
        }

        void UpdateState(GameTime gt)
        {
            // Aplica as translações de acordo com o estado
            switch (state)
            {
                case STATE.UP:
                    position.Y += speed * gt.ElapsedGameTime.Milliseconds * 0.001f;
                    break;
                case STATE.DOWN:
                    position.Y -= speed * gt.ElapsedGameTime.Milliseconds * 0.001f;
                    break;
                case STATE.RIGHT:
                    position.X += speed * gt.ElapsedGameTime.Milliseconds * 0.001f;
                    break;
                case STATE.LEFT:
                    position.X -= speed * gt.ElapsedGameTime.Milliseconds * 0.001f;
                    break;
                case STATE.ROTATE_RIGHT:
                    angle += rotationSpeed * gt.ElapsedGameTime.Milliseconds * 0.001f;
                    break;
                case STATE.ROTATE_LEFT:
                    angle -= rotationSpeed * gt.ElapsedGameTime.Milliseconds * 0.001f;
                    break;
                case STATE.IDLE:
                    break;
            }

            // Salva a posição atual
            Vector3 originalPosition = World.Translation;

            // Resetar World para aplicar a rotação no centro
            World = Matrix.Identity;

            // Aplicar a rotação
            Matrix rotation = Matrix.CreateRotationY(MathHelper.ToRadians(angle));
            World *= rotation;

            // Translada de volta para a posição original
            World *= Matrix.CreateTranslation(originalPosition);

            // Finalmente, aplica a posição atualizada
            World *= Matrix.CreateTranslation(position);
        }

        void ChangeState(GameTime gt)
        {
            switch (state)
            {
                case STATE.UP:
                    if (GetPosition().Y > (building2.Size.Y * building2.GetScale().Y) * 2)
                    {
                        if (destination == building1) state = STATE.ROTATE_LEFT;
                        else if (destination == building2) state = STATE.ROTATE_RIGHT;
                        previousState = STATE.UP;
                    }
                    break;
                case STATE.DOWN:
                    if (IsColliding(destination))
                    {
                        state = STATE.IDLE;
                        previousState = STATE.DOWN;
                    }
                    break;
                case STATE.RIGHT:
                    if (previousState == STATE.ROTATE_RIGHT && GetPosition().X >= destination.GetPosition().X)
                    {
                        state = STATE.ROTATE_LEFT;
                        previousState = STATE.RIGHT;
                    }
                    break;
                case STATE.LEFT:
                    if (previousState == STATE.ROTATE_LEFT && GetPosition().X <= destination.GetPosition().X)
                    {
                        state = STATE.ROTATE_RIGHT;
                        previousState = STATE.LEFT;
                    }
                    break;
                case STATE.ROTATE_RIGHT:
                    if (previousState == STATE.UP && MathHelper.ToRadians(angle) >= MathHelper.ToRadians(90))
                    {
                        state = STATE.RIGHT;
                        previousState = STATE.ROTATE_RIGHT;
                    }
                    if (previousState == STATE.LEFT && MathHelper.ToRadians(angle) >= MathHelper.ToRadians(0))
                    {
                        state = STATE.DOWN;
                        previousState = STATE.ROTATE_RIGHT;
                    }
                    break;
                case STATE.ROTATE_LEFT:
                    if (previousState == STATE.RIGHT && MathHelper.ToRadians(angle) <= MathHelper.ToRadians(0))
                    {
                        state = STATE.DOWN;
                        previousState = STATE.ROTATE_LEFT;
                    }
                    else if (previousState == STATE.UP && MathHelper.ToRadians(angle) <= MathHelper.ToRadians(-90))
                    {
                        state = STATE.LEFT;
                        previousState = STATE.ROTATE_LEFT;
                    }
                    break;
                case STATE.IDLE:
                    ((Propeller)Children[2]).SetOnAndOff(false);
                    ((Propeller)Children[3]).SetOnAndOff(false);
                    timer += gt.ElapsedGameTime.Milliseconds * 0.001f;
                    if (timer >= GAP)
                    {
                        timer = 0;
                        state = STATE.UP;
                        previousState = STATE.IDLE;
                        ((Propeller)Children[2]).SetOnAndOff(true);
                        ((Propeller)Children[3]).SetOnAndOff(true);
                        if (destination == building1) destination = building2;
                        else if (destination == building2) destination = building1;
                    }
                    break;
            }
        }
    }
}
