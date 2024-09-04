using Microsoft.Xna.Framework;
using Mundo01.Utilities;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Mundo01.Utilities.Collision;

namespace Mundo01.GameObjects
{
    public abstract class GameObject
    {
        Game1 game;
        protected Matrix world;
        Vector3 position, rotation, scale, size;
        Collider collider;
        protected BasicEffect effect;
        protected List<GameObject> children;

        public GameObject(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Vector3 size, bool colliderVisible = true)
        {
            this.game = game;

            this.position = position;
            this.rotation = rotation;
            this.scale = scale;
            this.size = size;

            CreateMatrix();

            children = new List<GameObject>();

            collider = new Collider(this.game, this.position, this.scale, this.size, Color.Green, colliderVisible);
            effect = new BasicEffect(game.GraphicsDevice);
        }

        public void Update()
        {
            foreach (GameObject child in children) child.Update();
            CreateMatrix();
        }

        public virtual void Draw(Camera camera)
        {
            foreach (GameObject child in children) child.Draw(camera);
            collider.Draw(effect, camera);
        }

        private void CreateMatrix()
        {
            world = Matrix.Identity;
            world *= Matrix.CreateScale(scale);
            world *= Matrix.CreateFromYawPitchRoll(MathHelper.ToRadians(rotation.Y), MathHelper.ToRadians(rotation.X), MathHelper.ToRadians(rotation.Z));
            world *= Matrix.CreateTranslation(position);
        }
    }
}
