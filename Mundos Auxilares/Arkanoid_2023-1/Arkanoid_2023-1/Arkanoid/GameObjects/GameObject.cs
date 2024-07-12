#define USE_REDUCED_FORM

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Arkanoid
{
    public abstract class GameObject
    {
#if USE_REDUCED_FORM
        // propriedades C# reduzidas não necessitam da criação de atributos
        public Vector2   Position  { get; set; }
        public Texture2D Texture   { get; set; }
        public Rectangle Rectangle { get; set; }
#else
        // atributos
        private Vector2 position;
        private Texture2D texture;
        private Rectangle rectangle;

        // propriedades C# completa = métodos get e set de outras linguagens e precisam de atributos
        public Vector2 Position    { get { return position;  } set { position  = value; } }
        public Texture2D Texture   { get { return texture;   } set { texture   = value; } }
        public Rectangle Rectangle { get { return rectangle; } set { rectangle = value; } }

        // outras linguagens que usam atributos
        // public Vector2 getPosition(){ return position; }
        // public void setPosition(Vector2 vector2) { position = vector2; }

#endif
        public GameObject(Vector2 position, Texture2D texture)
        {
            this.Position  = position;
            this.Texture   = texture;
            this.Rectangle = new Rectangle((int)this.Position.X,
                                           (int)this.Position.Y,
                                           this.Texture.Width,
                                           this.Texture.Height);
        }

        public virtual void Update(GameTime gameTime, Rectangle clientBounds)
        {
            this.Rectangle = new Rectangle((int)this.Position.X,
                                           (int)this.Position.Y,
                                           this.Rectangle.Width,
                                           this.Rectangle.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture,
                             this.Rectangle,
                             Color.White);
        }

        public bool Collision(GameObject gameObject)
        {
            return this.Rectangle.Intersects(gameObject.Rectangle);     
        }
    }
}
