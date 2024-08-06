
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    public class _Animation
    {
        Game game;
        Texture2D[] image;
        Vector2 position, speed;
        Point size;

        int numFrames;
        float currentTime;
        int currentFrame;
        bool flip;
        int fps;
        
        public _Animation(Game game, Vector2 position, Point size, Vector2 speed)
        {
            this.game = game;
            this.image = new Texture2D[4];
            
            for ( int i = 0; i < this.image.Length; i++)
            {
                this.image[i] = this.game.Content.Load<Texture2D>(@"Animation\WalkCycle\walk" + i);
            }

            this.position = position;
            this.size = size;
            this.speed = speed;

            this.numFrames = this.image.Length;
            this.currentTime = 0;
            this.currentFrame = 0;
            this.flip = false;
            this.fps = 12;
        }

        public void Update(GameTime gameTime)
        {
            float t = gameTime.ElapsedGameTime.Milliseconds * 0.001f;

            this.position.X += this.speed.X * t;

            if (this.position.X + this.size.X < 0 || this.position.X > this.game.Window.ClientBounds.Width)
            {
                this.speed.X = -this.speed.X;
                this.flip = !this.flip;
            }

            this.UpdateAnimaton(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (flip)
            {
                spriteBatch.Draw(this.image[this.currentFrame],
                                 new Rectangle((int)this.position.X, (int)this.position.Y, this.size.X, this.size.Y),
                                 null,
                                 Color.White,
                                 0,
                                 Vector2.Zero,
                                 SpriteEffects.FlipHorizontally,
                                 0);
            }
            else
            {
                spriteBatch.Draw(this.image[this.currentFrame],
                                 new Rectangle((int)this.position.X, (int)this.position.Y, this.size.X, this.size.Y),
                                 Color.White);
            }
        }

        private void UpdateAnimaton(GameTime gt)
        {
            currentTime += gt.ElapsedGameTime.Milliseconds * 0.001f;
            if (currentTime > 1f / fps)
            {
                currentFrame++;
                currentFrame %= numFrames;
                currentTime = 0;
            }
        }

    }
}