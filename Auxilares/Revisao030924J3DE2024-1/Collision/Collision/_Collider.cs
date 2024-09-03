using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Collision
{
    public class _Collider
    {
        protected Vector3 position, dimension;
        BoundingBox bb;
        _LineBox lineBox;
        bool visible;

        public _Collider(Game game, Vector3 position, Vector3 dimension, Color color, bool visible = true)
        {
            this.position = position;
            this.dimension = dimension;

            this.UpdateBoundingBox();

            this.visible = visible;
            this.lineBox = new _LineBox(game, position, dimension, color);
        }

        private void UpdateBoundingBox()
        {
            this.bb = new BoundingBox(this.position - this.dimension / 2f,
                                      this.position + this.dimension / 2f);
        }

        public virtual void Draw(BasicEffect e)
        {
            if (this.visible)
                this.lineBox.Draw(e);
        }

        public void SetPosition(Vector3 position)
        {
            this.position = position;
            this.lineBox.SetPosition(this.position);
            this.UpdateBoundingBox();
        }

        public BoundingBox GetBoundingBox()
        {
            return this.bb;
        }

        public bool IsColliding(BoundingBox box)
        {
            return this.bb.Intersects(box);
        }

        public bool GetVisible()
        {
            return this.visible;
        }

        public void SetVisible(bool value)
        {
            this.visible = value;
        }

        public _LineBox GetLineBox()
        {
            return this.lineBox;
        }
    }
}
