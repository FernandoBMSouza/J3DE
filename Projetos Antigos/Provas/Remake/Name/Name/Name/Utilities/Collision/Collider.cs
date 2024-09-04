using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Name.GameObjects;

namespace Name.Utilities.Collision
{
    class Collider
    {
        Game1 game;
        GameObject gameObject;

        Vector3 oldPosition;
        Vector3 oldScale;
        Vector3 oldSize;

        bool isActive;

        public BoundingBox BoundingBox { get; private set; }
        public LineBox Lines { get; private set; }
        public bool IsVisible { get; set; }

        public bool IsActive 
        {
            get { return isActive; }
            set
            {
                if (value == true) isActive = true;
                else
                {
                    isActive = false;
                    BoundingBox = new BoundingBox(Vector3.Zero, Vector3.Zero);
                }
            }
        }

        public Collider(Game1 game, GameObject gameObject, bool visible = true)
        {
            this.game = game;
            this.IsVisible = visible;
            isActive = true;

            this.gameObject = gameObject;
            oldPosition = gameObject.GetPosition();
            oldScale = gameObject.GetScale();
            oldSize = gameObject.Size;

            Lines = new LineBox(game, oldPosition, oldScale, oldSize, Color.Green);
            BoundingBox = new BoundingBox(oldPosition - (oldScale * oldSize / 2f),
                                          oldPosition + (oldScale * oldSize / 2f));
        }

        public void Update()
        {
            if (isActive)
            {
                Vector3 position = gameObject.GetPosition();
                Vector3 scale = gameObject.GetScale();
                Vector3 size = gameObject.Size;

                if (position != oldPosition || scale != oldScale || size != oldSize)
                {
                    Vector3 dimension = scale * size;

                    Lines = new LineBox(game, position, scale, gameObject.Size, Color.Green);
                    BoundingBox = new BoundingBox(position - (dimension / 2f),
                                                  position + (dimension / 2f));

                    oldPosition = position;
                    oldScale = scale;
                    oldSize = size;
                }
            }
        }

        public void Draw(BasicEffect effect, Camera camera)
        {
            if(IsVisible) Lines.Draw(effect, camera);
        }

        public void SetColor(Color color)
        {
            Lines.SetColor(color);
        }
    }
}
