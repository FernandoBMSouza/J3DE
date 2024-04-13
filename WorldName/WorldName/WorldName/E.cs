using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace WorldName
{
    class E : Letter
    {
        public E(GraphicsDevice device)
        {
            Shapes = new Cube[14];

            for (int i = 0; i < 14; i++)
                Shapes[i] = new Cube(device);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            Shapes[0].Translation(new Vector3(0, 4, 0));
            Shapes[1].Translation(new Vector3(0, 2, 0));
            Shapes[2].Translation(new Vector3(0, 0, 0));
            Shapes[3].Translation(new Vector3(0,-2, 0));
            Shapes[4].Translation(new Vector3(0,-4, 0));

            Shapes[5].Translation(new Vector3(2, 4, 0));
            Shapes[6].Translation(new Vector3(4, 4, 0));
            Shapes[7].Translation(new Vector3(6, 4, 0));

            Shapes[8].Translation(new Vector3(2, 0, 0));
            Shapes[9].Translation(new Vector3(4, 0, 0));

            Shapes[10].Translation(new Vector3(2,-4, 0));
            Shapes[11].Translation(new Vector3(4,-4, 0));
            Shapes[12].Translation(new Vector3(6,-4, 0));

            foreach (Shape s in Shapes)
                s.RotationY(rotationAngle);
        }
    }
}
