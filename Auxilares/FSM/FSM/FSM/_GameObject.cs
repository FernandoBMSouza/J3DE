using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FSM
{
    public enum STATE
    { 
        UP,
        DOWN,
        LEFT,
        RIGHT
    };


    public class _GameObject
    {
        Vector2 position;
        Point size;
        Texture2D texture;
        STATE state;
        Vector2 speed;
        static Random random;
        float currentTime;
        const float GAP = 0.005f;
        //Color color;

        public _GameObject(Vector2 position, Point size, ref Texture2D texture)
        {
            this.position = position;
            this.size = size;
            this.texture = texture;
            state = STATE.UP;
            speed = new Vector2(100, 100);
            random = new Random();
            currentTime = 0;
            //color = new Color(random.Next(256), random.Next(256), random.Next(256));
        }

        public void Update(GameTime gameTime)
        {
            UpdateState(gameTime);

            currentTime += gameTime.ElapsedGameTime.Milliseconds * 0.001f;
            if (currentTime >= GAP)
            {
                ChangeState(gameTime);
                currentTime = 0;
            }
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(texture, new Rectangle((int)position.X, (int)position.Y, size.X, size.Y), Color.White);
        }

        private void UpdateState(GameTime gameTime)
        {
            switch (state)
            { 
                case STATE.UP:
                    this.position.Y -= speed.Y * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
                    break;
                case STATE.DOWN:
                    this.position.Y += speed.Y * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
                    break;
                case STATE.RIGHT:
                    this.position.X += speed.X * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
                    break;
                case STATE.LEFT:
                    this.position.X -= speed.X * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
                    break;
            }
        }

        private void ChangeState(GameTime gameTime)
        {
            int aux = random.Next(3);
            switch(state)
            {
                case STATE.UP:
                    switch (aux)
                    {
                        case 0: state = STATE.DOWN; break;
                        case 1: state = STATE.RIGHT; break;
                        case 2: state = STATE.LEFT; break;
                    }
                    break;
                case STATE.DOWN:
                    switch (aux)
                    {
                        case 0: state = STATE.UP; break;
                        case 1: state = STATE.RIGHT; break;
                        case 2: state = STATE.LEFT; break;
                    }
                    break;
                case STATE.RIGHT:
                    switch (aux)
                    {
                        case 0: state = STATE.DOWN; break;
                        case 1: state = STATE.UP; break;
                        case 2: state = STATE.LEFT; break;
                    }
                    break;
                case STATE.LEFT:
                    switch (aux)
                    {
                        case 0: state = STATE.DOWN; break;
                        case 1: state = STATE.RIGHT; break;
                        case 2: state = STATE.UP; break;
                    }
                    break;
            }
        }
    }
}
