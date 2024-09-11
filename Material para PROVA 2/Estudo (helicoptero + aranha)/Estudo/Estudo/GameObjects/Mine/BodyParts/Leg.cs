using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Estudo.GameObjects.ShapesTexture;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Estudo.GameObjects.Mine.BodyParts
{
    public class Leg : ShapeTexture
    {
        public Leg(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Effect effect, Texture2D texture, bool colliderVisible = true)
            : base(game, position, rotation, scale, effect, texture, colliderVisible)
        {
            Vector3 size = Vector3.One;
            SetSize(size);

            vertices = new VertexPositionTexture[]
            {
                // FRONT
                new VertexPositionTexture(new Vector3(-size.X,-size.Y, size.Z) / 2f, new Vector2(4,32) / 64f),
                new VertexPositionTexture(new Vector3(-size.X, size.Y, size.Z) / 2f, new Vector2(4,20) / 64f),
                new VertexPositionTexture(new Vector3( size.X,-size.Y, size.Z) / 2f, new Vector2(8,32) / 64f),

                new VertexPositionTexture(new Vector3(-size.X, size.Y, size.Z) / 2f, new Vector2(4,20) / 64f),
                new VertexPositionTexture(new Vector3( size.X, size.Y, size.Z) / 2f, new Vector2(8,20) / 64f),
                new VertexPositionTexture(new Vector3( size.X,-size.Y, size.Z) / 2f, new Vector2(8,32) / 64f),

                // REAR
                new VertexPositionTexture(new Vector3(-size.X,-size.Y,-size.Z) / 2f, new Vector2(12,32) / 64f),
                new VertexPositionTexture(new Vector3( size.X,-size.Y,-size.Z) / 2f, new Vector2(16,32) / 64f),
                new VertexPositionTexture(new Vector3(-size.X, size.Y,-size.Z) / 2f, new Vector2(12,20) / 64f),

                new VertexPositionTexture(new Vector3(-size.X, size.Y,-size.Z) / 2f, new Vector2(12,20) / 64f),
                new VertexPositionTexture(new Vector3( size.X,-size.Y,-size.Z) / 2f, new Vector2(16,32) / 64f),
                new VertexPositionTexture(new Vector3( size.X, size.Y,-size.Z) / 2f, new Vector2(16,20) / 64f),

                // RIGHT
                new VertexPositionTexture(new Vector3( size.X,-size.Y, size.Z) / 2f, new Vector2(4,32) / 64f),
                new VertexPositionTexture(new Vector3( size.X, size.Y, size.Z) / 2f, new Vector2(4,20) / 64f),
                new VertexPositionTexture(new Vector3( size.X,-size.Y,-size.Z) / 2f, new Vector2(0,32) / 64f),

                new VertexPositionTexture(new Vector3( size.X, size.Y, size.Z) / 2f, new Vector2(4,20) / 64f),
                new VertexPositionTexture(new Vector3( size.X, size.Y,-size.Z) / 2f, new Vector2(0,20) / 64f),
                new VertexPositionTexture(new Vector3( size.X,-size.Y,-size.Z) / 2f, new Vector2(0,32) / 64f),

                // LEFT
                new VertexPositionTexture(new Vector3(-size.X, size.Y, size.Z) / 2f, new Vector2(8,20)  / 64f),
                new VertexPositionTexture(new Vector3(-size.X,-size.Y, size.Z) / 2f, new Vector2(8,32)  / 64f),
                new VertexPositionTexture(new Vector3(-size.X,-size.Y,-size.Z) / 2f, new Vector2(12,32) / 64f),

                new VertexPositionTexture(new Vector3(-size.X, size.Y, size.Z) / 2f, new Vector2(8,20)  / 64f),
                new VertexPositionTexture(new Vector3(-size.X,-size.Y,-size.Z) / 2f, new Vector2(12,32) / 64f),
                new VertexPositionTexture(new Vector3(-size.X, size.Y,-size.Z) / 2f, new Vector2(12,20) / 64f),

                // TOP
                new VertexPositionTexture(new Vector3(-size.X, size.Y, size.Z) / 2f, new Vector2(4,20) / 64f),
                new VertexPositionTexture(new Vector3(-size.X, size.Y,-size.Z) / 2f, new Vector2(4,16) / 64f),
                new VertexPositionTexture(new Vector3( size.X, size.Y, size.Z) / 2f, new Vector2(8,16) / 64f),

                new VertexPositionTexture(new Vector3(-size.X, size.Y,-size.Z) / 2f, new Vector2(4,16) / 64f),
                new VertexPositionTexture(new Vector3( size.X, size.Y,-size.Z) / 2f, new Vector2(8,16) / 64f),
                new VertexPositionTexture(new Vector3( size.X, size.Y, size.Z) / 2f, new Vector2(8,20) / 64f),

                // BOT
                new VertexPositionTexture(new Vector3(-size.X,-size.Y, size.Z) / 2f, new Vector2(8,20)  / 64f),
                new VertexPositionTexture(new Vector3( size.X,-size.Y, size.Z) / 2f, new Vector2(12,20) / 64f),
                new VertexPositionTexture(new Vector3(-size.X,-size.Y,-size.Z) / 2f, new Vector2(8,16)  / 64f),

                new VertexPositionTexture(new Vector3(-size.X,-size.Y,-size.Z) / 2f, new Vector2(8,16)  / 64f),
                new VertexPositionTexture(new Vector3( size.X,-size.Y, size.Z) / 2f, new Vector2(12,20) / 64f),
                new VertexPositionTexture(new Vector3( size.X,-size.Y,-size.Z) / 2f, new Vector2(12,16) / 64f),
            };
        }
    }
}
