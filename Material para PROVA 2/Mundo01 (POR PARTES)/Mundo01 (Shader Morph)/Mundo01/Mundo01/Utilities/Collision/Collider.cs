﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Mundo01.Utilities.Collision
{
    public class Collider
    {
        BoundingBox boundingBox;
        LineBox lineBox;
        bool visible;

        Vector3 position, scale, size;

        public Collider(Game1 game, Vector3 position, Vector3 scale, Vector3 size, Color color, bool visible = true)
        {
            this.position = position;
            this.scale = scale;
            this.size = size;
            this.visible = visible;

            Update();
            lineBox = new LineBox(game, position, scale, size, color);
        }

        public void Update()
        {
            this.boundingBox = new BoundingBox(position - (size * scale) / 2f,
                                               position + (size * scale) / 2f);
        }

        public void Draw(Camera camera)
        {
            if (visible) lineBox.Draw(camera);
        }

        public void SetPosition(Vector3 position)
        {
            this.position = position;
            lineBox.SetPosition(this.position);
            Update();
        }

        public void SetScale(Vector3 scale)
        {
            this.scale = scale;
            lineBox.SetScale(this.scale);
            Update();
        }

        public void SetColor(Color color)
        {
            lineBox.SetColor(color);
        }

        public BoundingBox GetBoundingBox()
        {
            return boundingBox;
        }
    }
}
