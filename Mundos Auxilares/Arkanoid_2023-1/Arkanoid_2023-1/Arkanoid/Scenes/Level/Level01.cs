using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Arkanoid
{
    public class Level01 : BaseLevel
    {
        List<Rect> listRect;
        const int NUM_RECT = 13;
        const int NUM_LINE = 1;
        const int NUM_IMG = 1;
        Texture2D[] textureRect;

        private Background background { get; set; }

        public Level01(Game game)
            : base(game)
        {
            this.background = new Background(Vector2.Zero, game.Content.Load<Texture2D>(@"Images/background"));

            this.textureRect = new Texture2D[NUM_IMG];
            this.textureRect[0] = game.Content.Load<Texture2D>(@"Images/azul");

            this.listRect = new List<Rect>();

            for (int j = 0; j < NUM_LINE; j++)
            {
                for (int i = 0; i < NUM_RECT; i++)
                {
                    Rect rect = new Rect(new Vector2(20 + i * this.textureRect[0].Width + i, j + 100 + (j * (this.textureRect[0].Height))),
                                         ref this.textureRect[j % NUM_IMG],
                                         Vector2.Zero,
                                         j * NUM_RECT + i);
                    this.listRect.Add(rect);
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (listRect.Count <= 0)
            {
                SceneManager.GetInstance(game).ChangeScene();
            }

            foreach (Rect r in listRect)
            {
                if (r.Collision(this.Ball))
                {
                    listRect.Remove(r);
                    this.Ball.Speed = new Vector2(this.Ball.Speed.X, -this.Ball.Speed.Y);
                    break;
                }
            }

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            this.background.Draw(spriteBatch, game.Window.ClientBounds);

            foreach (Rect r in listRect)
            {
                spriteBatch.Draw(r.Texture, r.Rectangle, Color.White);
            }

            base.Draw(spriteBatch);
        }
    }
}
