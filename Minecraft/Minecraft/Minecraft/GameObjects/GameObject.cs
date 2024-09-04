using Microsoft.Xna.Framework;
using Minecraft.Utilities;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Minecraft.Utilities.Collision;

namespace Minecraft.GameObjects
{
    public abstract class GameObject
    {
        Game1 game;
        Matrix world;
        protected Vector3 position, rotation, scale, size;
        Collider collider;
        protected BasicEffect effect;
        protected List<GameObject> children;

        public Vector3 pivot;

        public GameObject(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, Vector3 size, bool colliderVisible = true)
        {
            this.game = game;

            this.position = position;
            this.rotation = rotation;
            this.scale = scale;
            this.size = size;

            //this.pivot = Vector3.Zero;

            CreateMatrix();

            children = new List<GameObject>();

            collider = new Collider(this.game, this.position, this.scale, this.size, Color.Green, colliderVisible);
            effect = new BasicEffect(game.GraphicsDevice);
        }

        public virtual void Update(GameTime gameTime)
        {
            foreach (GameObject child in children)
            {
                child.Update(gameTime);
                child.world *= world;
            }

            collider.SetPosition(Vector3.Transform(Vector3.Zero, world));
            collider.SetScale(scale);

            CreateMatrix();
        }

        public virtual void Draw(Camera camera)
        {
            foreach (GameObject child in children)
                child.Draw(camera);

            collider.Draw(effect, camera);
        }

        protected virtual void CreateMatrix()
        {
            world = Matrix.Identity;
            world *= Matrix.CreateScale(scale);
            world *= Matrix.CreateTranslation(-pivot);
            world *= Matrix.CreateFromYawPitchRoll(MathHelper.ToRadians(rotation.Y), MathHelper.ToRadians(rotation.X), MathHelper.ToRadians(rotation.Z));
            world *= Matrix.CreateTranslation(position + pivot);
        }

        public BoundingBox GetCollider() { return collider.GetBoundingBox(); }
        public Matrix GetWorld() { return world; }
        public Vector3 GetDimension()    { return size * scale; }
        public Vector3 GetPosition()     { return position; }
        public void SetRotationY(float value) { rotation.Y = value; }
        public void SetRotationX(float value) { rotation.X = value; }
    }
}
