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
        ROTATE,
        IDLE,
    }

    class Ship : GameObject
    {
        STATE state;
        Vector3 position;
        float angle, rotationSpeed, speed;

        public Ship(Game1 game, Color bodyColor, Color propellerColor, bool showColliderLines = false)
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
            state = STATE.IDLE;
            rotationSpeed = 50f;
            speed = 2f;
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
            ChangeState();

            foreach (GameObject child in Children)
                child.World *= World;                

            Debug.WriteLine("Position: " + GetPosition());

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
                case STATE.ROTATE:
                    angle += rotationSpeed * gt.ElapsedGameTime.Milliseconds * 0.001f;
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

        void ChangeState()
        {
            switch (state)
            {
                case STATE.UP:
                    if (GetPosition().Y > 10) state = STATE.ROTATE;
                    break;
                case STATE.DOWN:
                    break;
                case STATE.ROTATE:
                    break;
                case STATE.IDLE:
                    state = STATE.UP;
                    break;
                default:
                    break;
            }
        }
    }
}
