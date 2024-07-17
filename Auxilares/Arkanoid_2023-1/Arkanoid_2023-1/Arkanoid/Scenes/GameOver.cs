using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Arkanoid
{
    public class GameOver : Scene
    {
        float count;
        const int MAX = 3;

        Background background { get; set; }

        public GameOver(Game game) : base(game)
        {
            this.background = new Background(Vector2.Zero, game.Content.Load<Texture2D>(@"Images/bgGameOver"));
        }

        public override void Update(GameTime gameTime)
        {
            count += gameTime.ElapsedGameTime.Milliseconds * 0.001f;
            if (count >= MAX)
                SceneManager.GetInstance(game).ChangeScene();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            this.background.Draw(spriteBatch, game.Window.ClientBounds);
        }
    }
}
