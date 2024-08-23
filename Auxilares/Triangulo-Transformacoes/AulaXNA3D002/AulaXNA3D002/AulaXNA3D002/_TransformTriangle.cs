using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AulaXNA3D002
{
    public class _TransformTriangle : _Triangle
    {
        private float angle;
        private float speed;

        public _TransformTriangle(GraphicsDevice device) :
            base(device)
        {
            this.angle = 0;
            this.speed = 100;
        }

        public void Update(GameTime gameTime)
        {
            this.angle += this.speed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;

            float auxScale = Math.Abs((float)Math.Sin(MathHelper.ToRadians(this.angle)));

            world = Matrix.Identity;
            world *= Matrix.CreateTranslation(0f, -1f, 0f);
            world *= Matrix.CreateRotationZ((float)Math.Sin(MathHelper.ToRadians(this.angle)));

            //this.world = Matrix.Identity;
            //this.world *= Matrix.CreateScale(1,auxScale,1);
            //this.world *= Matrix.CreateRotationY(MathHelper.ToRadians(this.angle));
            //this.world *= Matrix.CreateTranslation((float)Math.Sin(MathHelper.ToRadians(this.angle)), 0, 0);
        }

        public override void Draw(_Camera camera)
        {
            RasterizerState rs = new RasterizerState();
            rs.CullMode = CullMode.None;
            this.device.RasterizerState = rs;

            base.Draw(camera);
        }
    }
}
