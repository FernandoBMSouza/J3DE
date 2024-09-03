using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Mundo03.Utilities;

namespace Mundo03.GameObjects.Primitives
{
    abstract class Primitive : GameObject
    {
        Game1 game;
        VertexBuffer buffer;
        protected VertexPositionTexture[] vertices;
        protected Texture2D texture;

        public Primitive(Game1 game, Texture2D texture, bool showColliderLines = false)
            : base(game, showColliderLines)
        {
            this.game = game;
            this.texture = texture;

            if (vertices != null)
            {
                buffer = new VertexBuffer(this.game.GraphicsDevice,
                                          typeof(VertexPositionTexture),
                                          vertices.Length,
                                          BufferUsage.None);

                buffer.SetData<VertexPositionTexture>(vertices);
            }
        }

        public override void Draw(Camera camera)
        {
            if (vertices != null)
            {
                game.GraphicsDevice.SetVertexBuffer(buffer);
                effect.World = World;
                effect.View = camera.View;
                effect.Projection = camera.Projection;

                effect.TextureEnabled = true;
                effect.Texture = texture;
                foreach (EffectPass pass in effect.CurrentTechnique.Passes)
                {
                    pass.Apply();
                    game.GraphicsDevice.DrawUserPrimitives<VertexPositionTexture>(PrimitiveType.TriangleList,
                                                                                  vertices,
                                                                                  0,
                                                                                  vertices.Length / 3);
                }
                effect.TextureEnabled = false;
            }
            base.Draw(camera);
        }
    }
}
