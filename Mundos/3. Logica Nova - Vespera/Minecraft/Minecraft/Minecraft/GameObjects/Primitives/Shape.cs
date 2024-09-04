using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Minecraft.Utilities;

namespace Minecraft.GameObjects.Primitives
{
    public abstract class Shape : GameObject
    {
        Game1 game;
        VertexBuffer buffer;
        protected VertexPositionColor[] vertices;

        public Shape(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Vector3 size, bool colliderVisible = true)
            : base(game, position, rotation, scale, size, colliderVisible)
        {
            this.game = game;

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
                effect.World = world;
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
