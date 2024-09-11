using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Dorgas.GameObjects.Models
{
    class PropellerModel : Model3D
    {
        float rotationSpeed;
        bool working;
        static Random random = new Random();

        public PropellerModel(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, bool working = true, bool colliderVisible = true)
            : base(game, position, rotation, scale, colliderVisible)
        {
            SetSize(new Vector3(4, 4, .25f));

            children.Add(new BladeModel(game, new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(.4f, .4f, 1), false));
            children.Add(new BladeModel(game, new Vector3(0, 0, 0), new Vector3(0, 0, 90), new Vector3(.4f, .4f, 1), false));
            children.Add(new BladeModel(game, new Vector3(0, 0, 0), new Vector3(0, 0, 180), new Vector3(.4f, .4f, 1), false));
            children.Add(new BladeModel(game, new Vector3(0, 0, 0), new Vector3(0, 0, 270), new Vector3(.4f, .4f, 1), false));

            this.working = working;
            rotationSpeed = random.Next(50, 500);
        }

        public override void Update(GameTime gameTime)
        {
            if (working) //rotation.Z += rotationSpeed * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
                AddRotation(new Vector3(0, 0, rotationSpeed * gameTime.ElapsedGameTime.Milliseconds * 0.001f));
            base.Update(gameTime);
        }
    }
}
