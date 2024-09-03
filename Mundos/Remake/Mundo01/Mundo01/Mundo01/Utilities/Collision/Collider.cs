using System;
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

        Vector3 position;
        Vector3 scale;

        public Collider(Game1 game, Vector3 position, Vector3 scale, Color color, bool visible = true)
        {
            this.position = position;
            this.scale = scale;
            this.visible = visible;

            Update();
            lineBox = new LineBox(game, position, scale, color);
        }

        public void Update()
        {
            this.boundingBox = new BoundingBox(position - scale / 2f,
                                               position + scale / 2f);
        }

        public void Draw(BasicEffect effect)
        {
            if (visible) lineBox.Draw(effect);
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

        public bool IsColliding(BoundingBox other)
        {
            return boundingBox.Intersects(other);
        }
        
    }
}
