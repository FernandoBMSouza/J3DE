using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Mundo01.Utilities;

namespace Mundo01.GameObjects.Primitives
{
    abstract class Primitive : GameObject
    {
        Game1 game;
        VertexBuffer buffer;
        protected VertexPositionColor[] vertices;
        protected Color color;

        public Primitive(Game1 game, Color color)
            : base(game)
        {
            this.game = game;
            this.color = color;

            if (vertices != null)
            {
                buffer = new VertexBuffer(this.game.GraphicsDevice,
                                          typeof(VertexPositionColor),
                                          vertices.Length,
                                          BufferUsage.None);

                buffer.SetData<VertexPositionColor>(vertices);
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

                effect.VertexColorEnabled = true;
                foreach (EffectPass pass in effect.CurrentTechnique.Passes)
                {
                    pass.Apply();
                    game.GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList,
                                                                                vertices,
                                                                                0,
                                                                                vertices.Length / 3);
                }
                effect.VertexColorEnabled = false;
            }
            base.Draw(camera);
        }
    }
}
