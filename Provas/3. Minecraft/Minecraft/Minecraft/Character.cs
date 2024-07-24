using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Minecraft
{
    public enum STATE
    {
        IDLE,

        FRONT,
        BACK,
        RIGHT,
        LEFT,
    };

    public abstract class Character : GameObject
    {
        Cube[] cubes;
        protected Vector3 oldPosition;
        protected STATE state;
        protected float moveSpeed;
        protected static Random random;

        Effect defaultEffect;
        Effect redEffect;

        public Character(Game1 game, Texture2D texture)
            : base(game)
        {
            state = STATE.IDLE;
            random = new Random();
            moveSpeed = 2;
            Size = new Vector3(4, 8, 2);
            oldPosition = Position;

            defaultEffect = game.Content.Load<Effect>(@"Effects\Effect1");
            redEffect = game.Content.Load<Effect>(@"Effects\RedEffect");

            cubes = new Cube[]
            {
                new Head(game, texture),             
                new Body(game, texture),              
                new Arm(game, texture),              
                new Arm(game, texture),              
                new Leg(game, texture),              
                new Leg(game, texture),              
            };

            //SETUP
            cubes[0].Position = new Vector3( 0,  3, 0);
            cubes[1].Position = new Vector3( 0,.5f, 0);
            cubes[2].Position = new Vector3(-1.5f,.5f, 0);
            cubes[3].Position = new Vector3( 1.5f,.5f, 0);
            cubes[4].Position = new Vector3(-.5f,-2.5f, 0);
            cubes[5].Position = new Vector3( .5f,-2.5f, 0);

            cubes[0].Scale = new Vector3(  1,    1, 1);
            cubes[1].Scale = new Vector3(  1, 1.5f,.5f);
            cubes[2].Scale = new Vector3(.5f, 1.5f,.5f);
            cubes[3].Scale = new Vector3(.5f, 1.5f,.5f);
            cubes[4].Scale = new Vector3(.5f, 1.5f,.5f);
            cubes[5].Scale = new Vector3(.5f, 1.5f,.5f);

            Scale = new Vector3(.2f, .2f, .2f);
        }

        public override void Update(GameTime gameTime)
        {
            oldPosition = Position;
            UpdateState(gameTime);
            ChangeState(gameTime);
        }

        protected void UpdateState(GameTime gameTime)
        {
            float moveAmount = moveSpeed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;

            switch (state)
            {
                case STATE.IDLE:
                    break;
                case STATE.FRONT:
                    Rotation = new Vector3(0, 0, 0);
                    Position += new Vector3(0, 0, moveAmount);
                    break;
                case STATE.BACK:
                    Rotation = new Vector3(0, MathHelper.ToRadians(180), 0);
                    Position += new Vector3(0, 0, -moveAmount);
                    break;
                case STATE.RIGHT:
                    Rotation = new Vector3(0, MathHelper.ToRadians(90), 0);
                    Position += new Vector3(moveAmount, 0, 0);
                    break;
                case STATE.LEFT:
                    Rotation = new Vector3(0, MathHelper.ToRadians(-90), 0);
                    Position += new Vector3(-moveAmount, 0, 0);
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

        public override void Draw(Camera camera, Matrix parentWorld, bool showColliders = false)
        {
            Matrix localMatrix = Matrix.CreateScale(Scale)
                                 * Matrix.CreateFromYawPitchRoll(Rotation.Y, Rotation.X, Rotation.Z)
                                 * Matrix.CreateTranslation(Position);

            Matrix result = localMatrix * parentWorld;

            effect.CurrentTechnique = effect.Techniques["Technique1"];
            effect.Parameters["World"].SetValue(result);
            effect.Parameters["View"].SetValue(camera.View);
            effect.Parameters["Projection"].SetValue(camera.Projection);
            //effect.Parameters["colorTexture"].SetValue(texture);

            foreach (Cube cube in cubes) cube.Draw(camera, result, false);
            if (showColliders) LBox.Draw(result, camera);
        }

        public void RestorePosition()
        {
            Position = oldPosition;
        }

        public void RestoreEffect()
        {
            foreach (Cube c in cubes) c.effect = defaultEffect;           
        }

        public void HitEffect()
        {
            foreach (Cube c in cubes) c.effect = redEffect;
        }
    }
}
