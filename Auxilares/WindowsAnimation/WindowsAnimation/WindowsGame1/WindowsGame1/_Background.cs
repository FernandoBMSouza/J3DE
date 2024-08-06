
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace WindowsGame1
{
    public class _Background
    {
        Game game;
        Texture2D image;
        Vector2 position;
        Point size;

        public _Background(Game game, Vector2 position, Point size)
        {
            this.game = game;
            this.image = this.game.Content.Load<Texture2D>(@"Images\ForestBackground");
            this.position = position;
            this.size = size;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.image,
                             new Rectangle((int)this.position.X,
                                           (int)this.position.Y,
                                           this.size.X,
                                           this.size.Y),
                             Color.White);
        }
    }
}