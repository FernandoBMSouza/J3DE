using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CollisionLecture.cs
{
    public class _Collider
    {
        protected Vector3 position;
        protected Vector3 dimension;
        BoundingBox bb;
        _LineBox lineBox;
        bool visible;

        public _Collider(Game game, Vector3 position, Vector3 dimension, Color color, bool visible = true)
        {
            this.position = position;
            this.dimension = dimension;

            UpddateBoundingBox();

            this.visible = visible;
            this.lineBox = new _LineBox(game, position, dimension, color);
        }

        private void UpddateBoundingBox()
        {
            bb = new BoundingBox(position - (dimension / 2f),
                                 position + (dimension / 2f));
                                 
        }

        public void Draw(BasicEffect effect)
        {
            if (visible) lineBox.Draw(effect);
        }

        public void SetPosition(Vector3 position)
        {
            this.position = position;
            lineBox.SetPosition(this.position);
            UpddateBoundingBox();
        }

        public BoundingBox GetBoundingBox()
        {
            return bb;
        }

        public bool IsColliding(BoundingBox other)
        {
            return bb.Intersects(other);
        }

        public bool GetVisible()
        {
            return visible;
        }

        public void SetVisible(bool value)
        {
            visible = value;
        }

        public _LineBox GetLineBox()
        {
            return lineBox;
        }
    }
}
