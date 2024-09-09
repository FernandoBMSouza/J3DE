﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Minecraft.GameObjects.ShapesTexture
{
    public class SquareTexture : ShapeTexture
    {
        public SquareTexture(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Effect effect, Texture2D texture, bool colliderVisible = true)
            : base(game, position, rotation, scale, effect, texture, colliderVisible)
        {
            Vector3 size = new Vector3(1,1,0);
            SetSize(size);

            vertices = new VertexPositionTexture[]
            {
                new VertexPositionTexture(new Vector3(-size.X, -size.Y, size.Z) / 2f, new Vector2(0,1)),
                new VertexPositionTexture(new Vector3(-size.X,  size.Y, size.Z) / 2f, new Vector2(0,0)),
                new VertexPositionTexture(new Vector3( size.X, -size.Y, size.Z) / 2f, new Vector2(1,1)),

                new VertexPositionTexture(new Vector3(-size.X,  size.Y, size.Z) / 2f, new Vector2(0,0)),
                new VertexPositionTexture(new Vector3( size.X,  size.Y, size.Z) / 2f, new Vector2(1,0)),
                new VertexPositionTexture(new Vector3( size.X, -size.Y, size.Z) / 2f, new Vector2(1,1)),
            };
        }
    }
}
