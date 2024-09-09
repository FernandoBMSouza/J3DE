using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Minecraft.GameObjects.ShapesTexture;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Minecraft.GameObjects.Mine.BodyParts
{
    public class Head : ShapeTexture
    {
        public Head(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Effect effect, Texture2D texture, bool colliderVisible = true)
            : base(game, position, rotation, scale, effect, texture, colliderVisible)
        {
            Vector3 size = Vector3.One;
            SetSize(size);

            vertices = new VertexPositionTexture[]
            {
                // FRONT
                new VertexPositionTexture(new Vector3(-size.X,-size.Y, size.Z) / 2f, new Vector2(8,16)  / 64f),
                new VertexPositionTexture(new Vector3(-size.X, size.Y, size.Z) / 2f, new Vector2(8,8)   / 64f),
                new VertexPositionTexture(new Vector3( size.X,-size.Y, size.Z) / 2f, new Vector2(16,16) / 64f),

                new VertexPositionTexture(new Vector3(-size.X, size.Y, size.Z) / 2f, new Vector2(8,8)   / 64f),
                new VertexPositionTexture(new Vector3( size.X, size.Y, size.Z) / 2f, new Vector2(16,8)  / 64f),
                new VertexPositionTexture(new Vector3( size.X,-size.Y, size.Z) / 2f, new Vector2(16,16) / 64f),

                // REAR
                new VertexPositionTexture(new Vector3(-size.X,-size.Y,-size.Z) / 2f, new Vector2(24,16) / 64f),
                new VertexPositionTexture(new Vector3( size.X,-size.Y,-size.Z) / 2f, new Vector2(32,16) / 64f),
                new VertexPositionTexture(new Vector3(-size.X, size.Y,-size.Z) / 2f, new Vector2(24,8)  / 64f),

                new VertexPositionTexture(new Vector3(-size.X, size.Y,-size.Z) / 2f, new Vector2(24,8)  / 64f),
                new VertexPositionTexture(new Vector3( size.X,-size.Y,-size.Z) / 2f, new Vector2(32,16) / 64f),
                new VertexPositionTexture(new Vector3( size.X, size.Y,-size.Z) / 2f, new Vector2(32,8)  / 64f),

                // RIGHT
                new VertexPositionTexture(new Vector3( size.X,-size.Y, size.Z) / 2f, new Vector2(8,16) / 64f),
                new VertexPositionTexture(new Vector3( size.X, size.Y, size.Z) / 2f, new Vector2(8,8)  / 64f),
                new VertexPositionTexture(new Vector3( size.X,-size.Y,-size.Z) / 2f, new Vector2(0,16) / 64f),

                new VertexPositionTexture(new Vector3( size.X, size.Y, size.Z) / 2f, new Vector2(8,8)  / 64f),
                new VertexPositionTexture(new Vector3( size.X, size.Y,-size.Z) / 2f, new Vector2(0,8)  / 64f),
                new VertexPositionTexture(new Vector3( size.X,-size.Y,-size.Z) / 2f, new Vector2(0,16) / 64f),

                // LEFT
                new VertexPositionTexture(new Vector3(-size.X, size.Y, size.Z) / 2f, new Vector2(16,8)  / 64f),
                new VertexPositionTexture(new Vector3(-size.X,-size.Y, size.Z) / 2f, new Vector2(16,16) / 64f),
                new VertexPositionTexture(new Vector3(-size.X,-size.Y,-size.Z) / 2f, new Vector2(24,16) / 64f),

                new VertexPositionTexture(new Vector3(-size.X, size.Y, size.Z) / 2f, new Vector2(16,8)  / 64f),
                new VertexPositionTexture(new Vector3(-size.X,-size.Y,-size.Z) / 2f, new Vector2(24,16) / 64f),
                new VertexPositionTexture(new Vector3(-size.X, size.Y,-size.Z) / 2f, new Vector2(24,8)  / 64f),

                // TOP
                new VertexPositionTexture(new Vector3(-size.X, size.Y, size.Z) / 2f, new Vector2(8,8)  / 64f),
                new VertexPositionTexture(new Vector3(-size.X, size.Y,-size.Z) / 2f, new Vector2(8,0)  / 64f),
                new VertexPositionTexture(new Vector3( size.X, size.Y, size.Z) / 2f, new Vector2(16,8) / 64f),

                new VertexPositionTexture(new Vector3(-size.X, size.Y,-size.Z) / 2f, new Vector2(8,0)  / 64f),
                new VertexPositionTexture(new Vector3( size.X, size.Y,-size.Z) / 2f, new Vector2(16,0) / 64f),
                new VertexPositionTexture(new Vector3( size.X, size.Y, size.Z) / 2f, new Vector2(16,8) / 64f),

                // BOT
                new VertexPositionTexture(new Vector3(-size.X,-size.Y, size.Z) / 2f, new Vector2(16,8) / 64f),
                new VertexPositionTexture(new Vector3( size.X,-size.Y, size.Z) / 2f, new Vector2(24,8) / 64f),
                new VertexPositionTexture(new Vector3(-size.X,-size.Y,-size.Z) / 2f, new Vector2(16,0) / 64f),

                new VertexPositionTexture(new Vector3(-size.X,-size.Y,-size.Z) / 2f, new Vector2(16,0) / 64f),
                new VertexPositionTexture(new Vector3( size.X,-size.Y, size.Z) / 2f, new Vector2(24,8) / 64f),
                new VertexPositionTexture(new Vector3( size.X,-size.Y,-size.Z) / 2f, new Vector2(24,1) / 64f),
            };
        }
    }
}
