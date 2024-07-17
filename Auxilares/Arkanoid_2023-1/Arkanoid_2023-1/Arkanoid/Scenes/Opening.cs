using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Arkanoid
{
    public class Opening : Scene
    {
        float count;
        const int MAX = 3;

        Background background { get; set; }

        public Opening(Game game) : base(game)
        {
            this.background = new Background(Vector2.Zero, game.Content.Load<Texture2D>(@"Images/bgOpening"));
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
