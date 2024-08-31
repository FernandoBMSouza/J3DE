using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Helicopter
{
    abstract class Primitive : GameObject
    {
        Game1 game;
        VertexBuffer buffer;
        BasicEffect effect;
        protected VertexPositionColor[] vertices;
        protected Color color;

        public Primitive(Game1 game, Color color)
        {
            this.game = game;
            this.color = color;
            effect = new BasicEffect(game.GraphicsDevice);

            if (vertices != null)
            {
                buffer = new VertexBuffer(game.GraphicsDevice,
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
