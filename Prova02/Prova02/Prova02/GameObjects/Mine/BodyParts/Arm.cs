using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Prova02.GameObjects.ShapesTexture;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Prova02.GameObjects.Mine.BodyParts
{
    public class Arm : ShapeTexture
    {
        public Arm(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Effect effect, Texture2D texture, bool colliderVisible = true)
            : base(game, position, rotation, scale, effect, texture, colliderVisible)
        {
            Vector3 size = Vector3.One;
            SetSize(size);

            vertices = new VertexPositionTexture[]
            {
                // FRONT
                new VertexPositionTexture(new Vector3(-size.X,-size.Y, size.Z) / 2f, new Vector2(44,32) / 64f),
                new VertexPositionTexture(new Vector3(-size.X, size.Y, size.Z) / 2f, new Vector2(44,20) / 64f),
                new VertexPositionTexture(new Vector3( size.X,-size.Y, size.Z) / 2f, new Vector2(48,32) / 64f),

                new VertexPositionTexture(new Vector3(-size.X, size.Y, size.Z) / 2f, new Vector2(44,20) / 64f),
                new VertexPositionTexture(new Vector3( size.X, size.Y, size.Z) / 2f, new Vector2(48,20) / 64f),
                new VertexPositionTexture(new Vector3( size.X,-size.Y, size.Z) / 2f, new Vector2(48,32) / 64f),

                // REAR
                new VertexPositionTexture(new Vector3(-size.X,-size.Y,-size.Z) / 2f, new Vector2(52,32) / 64f),
                new VertexPositionTexture(new Vector3( size.X,-size.Y,-size.Z) / 2f, new Vector2(56,32) / 64f),
                new VertexPositionTexture(new Vector3(-size.X, size.Y,-size.Z) / 2f, new Vector2(52,20) / 64f),

                new VertexPositionTexture(new Vector3(-size.X, size.Y,-size.Z) / 2f, new Vector2(52,20) / 64f),
                new VertexPositionTexture(new Vector3( size.X,-size.Y,-size.Z) / 2f, new Vector2(56,32) / 64f),
                new VertexPositionTexture(new Vector3( size.X, size.Y,-size.Z) / 2f, new Vector2(56,20) / 64f),

                // RIGHT
                new VertexPositionTexture(new Vector3( size.X,-size.Y, size.Z) / 2f, new Vector2(48,32) / 64f),
                new VertexPositionTexture(new Vector3( size.X, size.Y, size.Z) / 2f, new Vector2(48,20) / 64f),
                new VertexPositionTexture(new Vector3( size.X,-size.Y,-size.Z) / 2f, new Vector2(52,32) / 64f),

                new VertexPositionTexture(new Vector3( size.X, size.Y, size.Z) / 2f, new Vector2(48,20) / 64f),
                new VertexPositionTexture(new Vector3( size.X, size.Y,-size.Z) / 2f, new Vector2(52,20) / 64f),
                new VertexPositionTexture(new Vector3( size.X,-size.Y,-size.Z) / 2f, new Vector2(52,32) / 64f),

                // LEFT
                new VertexPositionTexture(new Vector3(-size.X, size.Y, size.Z) / 2f, new Vector2(40,20) / 64f),
                new VertexPositionTexture(new Vector3(-size.X,-size.Y, size.Z) / 2f, new Vector2(40,32) / 64f),
                new VertexPositionTexture(new Vector3(-size.X,-size.Y,-size.Z) / 2f, new Vector2(44,32) / 64f),

                new VertexPositionTexture(new Vector3(-size.X, size.Y, size.Z) / 2f, new Vector2(40,20) / 64f),
                new VertexPositionTexture(new Vector3(-size.X,-size.Y,-size.Z) / 2f, new Vector2(44,32) / 64f),
                new VertexPositionTexture(new Vector3(-size.X, size.Y,-size.Z) / 2f, new Vector2(44,20) / 64f),

                // TOP
                new VertexPositionTexture(new Vector3(-size.X, size.Y, size.Z) / 2f, new Vector2(44,20) / 64f),
                new VertexPositionTexture(new Vector3(-size.X, size.Y,-size.Z) / 2f, new Vector2(44,16) / 64f),
                new VertexPositionTexture(new Vector3( size.X, size.Y, size.Z) / 2f, new Vector2(48,20) / 64f),

                new VertexPositionTexture(new Vector3(-size.X, size.Y,-size.Z) / 2f, new Vector2(44,16) / 64f),
                new VertexPositionTexture(new Vector3( size.X, size.Y,-size.Z) / 2f, new Vector2(48,16) / 64f),
                new VertexPositionTexture(new Vector3( size.X, size.Y, size.Z) / 2f, new Vector2(48,20) / 64f),

                // BOT
                new VertexPositionTexture(new Vector3(-size.X,-size.Y, size.Z) / 2f, new Vector2(48,20) / 64f),
                new VertexPositionTexture(new Vector3( size.X,-size.Y, size.Z) / 2f, new Vector2(52,20) / 64f),
                new VertexPositionTexture(new Vector3(-size.X,-size.Y,-size.Z) / 2f, new Vector2(48,16) / 64f),

                new VertexPositionTexture(new Vector3(-size.X,-size.Y,-size.Z) / 2f, new Vector2(48,16) / 64f),
                new VertexPositionTexture(new Vector3( size.X,-size.Y, size.Z) / 2f, new Vector2(52,20) / 64f),
                new VertexPositionTexture(new Vector3( size.X,-size.Y,-size.Z) / 2f, new Vector2(52,16) / 64f),
            };
        }
    }
}