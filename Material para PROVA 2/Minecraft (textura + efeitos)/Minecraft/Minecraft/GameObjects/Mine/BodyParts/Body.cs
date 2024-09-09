using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Minecraft.GameObjects.ShapesTexture;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Minecraft.GameObjects.Mine.BodyParts
{
    public class Body : ShapeTexture
    {
        public Body(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Effect effect, Texture2D texture, bool colliderVisible = true)
            : base(game, position, rotation, scale, effect, texture, colliderVisible)
        {
            Vector3 size = Vector3.One;
            SetSize(size);

            vertices = new VertexPositionTexture[]
            {
                // FRONT
                new VertexPositionTexture(new Vector3(-size.X,-size.Y, size.Z) / 2f, new Vector2(20,32) / 64f),
                new VertexPositionTexture(new Vector3(-size.X, size.Y, size.Z) / 2f, new Vector2(20,20) / 64f),
                new VertexPositionTexture(new Vector3( size.X,-size.Y, size.Z) / 2f, new Vector2(28,32) / 64f),

                new VertexPositionTexture(new Vector3(-size.X, size.Y, size.Z) / 2f, new Vector2(20,20) / 64f),
                new VertexPositionTexture(new Vector3( size.X, size.Y, size.Z) / 2f, new Vector2(28,20) / 64f),
                new VertexPositionTexture(new Vector3( size.X,-size.Y, size.Z) / 2f, new Vector2(28,32) / 64f),

                // REAR
                new VertexPositionTexture(new Vector3(-size.X,-size.Y,-size.Z) / 2f, new Vector2(32,32) / 64f),
                new VertexPositionTexture(new Vector3( size.X,-size.Y,-size.Z) / 2f, new Vector2(40,32) / 64f),
                new VertexPositionTexture(new Vector3(-size.X, size.Y,-size.Z) / 2f, new Vector2(32,20) / 64f),

                new VertexPositionTexture(new Vector3(-size.X, size.Y,-size.Z) / 2f, new Vector2(32,20) / 64f),
                new VertexPositionTexture(new Vector3( size.X,-size.Y,-size.Z) / 2f, new Vector2(40,32) / 64f),
                new VertexPositionTexture(new Vector3( size.X, size.Y,-size.Z) / 2f, new Vector2(40,20) / 64f),

                // RIGHT
                new VertexPositionTexture(new Vector3( size.X,-size.Y, size.Z) / 2f, new Vector2(28,32) / 64f),
                new VertexPositionTexture(new Vector3( size.X, size.Y, size.Z) / 2f, new Vector2(28,20) / 64f),
                new VertexPositionTexture(new Vector3( size.X,-size.Y,-size.Z) / 2f, new Vector2(32,32) / 64f),

                new VertexPositionTexture(new Vector3( size.X, size.Y, size.Z) / 2f, new Vector2(28,20) / 64f),
                new VertexPositionTexture(new Vector3( size.X, size.Y,-size.Z) / 2f, new Vector2(32,20) / 64f),
                new VertexPositionTexture(new Vector3( size.X,-size.Y,-size.Z) / 2f, new Vector2(32,32) / 64f),

                // LEFT
                new VertexPositionTexture(new Vector3(-size.X, size.Y, size.Z) / 2f, new Vector2(20,20) / 64f),
                new VertexPositionTexture(new Vector3(-size.X,-size.Y, size.Z) / 2f, new Vector2(20,32) / 64f),
                new VertexPositionTexture(new Vector3(-size.X,-size.Y,-size.Z) / 2f, new Vector2(16,32) / 64f),

                new VertexPositionTexture(new Vector3(-size.X, size.Y, size.Z) / 2f, new Vector2(20,20)  / 64f),
                new VertexPositionTexture(new Vector3(-size.X,-size.Y,-size.Z) / 2f, new Vector2(16,32) / 64f),
                new VertexPositionTexture(new Vector3(-size.X, size.Y,-size.Z) / 2f, new Vector2(16,20)  / 64f),

                // TOP
                new VertexPositionTexture(new Vector3(-size.X, size.Y, size.Z) / 2f, new Vector2(20,20) / 64f),
                new VertexPositionTexture(new Vector3(-size.X, size.Y,-size.Z) / 2f, new Vector2(20,16) / 64f),
                new VertexPositionTexture(new Vector3( size.X, size.Y, size.Z) / 2f, new Vector2(28,20) / 64f),

                new VertexPositionTexture(new Vector3(-size.X, size.Y,-size.Z) / 2f, new Vector2(20,16) / 64f),
                new VertexPositionTexture(new Vector3( size.X, size.Y,-size.Z) / 2f, new Vector2(28,16) / 64f),
                new VertexPositionTexture(new Vector3( size.X, size.Y, size.Z) / 2f, new Vector2(28,20) / 64f),

                // BOT
                new VertexPositionTexture(new Vector3(-size.X,-size.Y, size.Z) / 2f, new Vector2(28,16) / 64f),
                new VertexPositionTexture(new Vector3( size.X,-size.Y, size.Z) / 2f, new Vector2(36,16) / 64f),
                new VertexPositionTexture(new Vector3(-size.X,-size.Y,-size.Z) / 2f, new Vector2(28,20) / 64f),

                new VertexPositionTexture(new Vector3(-size.X,-size.Y,-size.Z) / 2f, new Vector2(28,20) / 64f),
                new VertexPositionTexture(new Vector3( size.X,-size.Y, size.Z) / 2f, new Vector2(36,16) / 64f),
                new VertexPositionTexture(new Vector3( size.X,-size.Y,-size.Z) / 2f, new Vector2(36,20) / 64f),
            };
        }
    }
}
