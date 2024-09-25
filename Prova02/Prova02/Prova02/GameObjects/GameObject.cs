using Microsoft.Xna.Framework;
using Prova02.Utilities;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Prova02.Utilities.Collision;

namespace Prova02.GameObjects
{
    public abstract class GameObject
    {
        private Game1 game;
        private Matrix world;
        private Vector3 size;
        private bool colliderVisible;
        private Vector3 position, rotation, scale, pivot;
        private Collider collider;

        protected List<GameObject> children;

        public GameObject(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, bool colliderVisible = true)
        {
            this.game = game;
            this.position = position;
            this.rotation = rotation;
            this.scale = scale;
            this.colliderVisible = colliderVisible;
            pivot = Vector3.Zero;
            SetSize(Vector3.One);
            SetupMatrix();
            children = new List<GameObject>();
        }

        public virtual void Update(GameTime gameTime)
        {
            foreach (GameObject child in children)
            {
                child.Update(gameTime);
                child.world *= world;
            }

            SetupMatrix();
        }

        public virtual void Draw(Camera camera)
        {
            foreach (GameObject child in children)
                child.Draw(camera);

            collider.Draw(camera);
        }

        protected virtual void SetupMatrix()
        {
            world = Matrix.Identity;
            world *= Matrix.CreateScale(scale);
            world *= Matrix.CreateTranslation(-pivot);
            world *= Matrix.CreateFromYawPitchRoll(MathHelper.ToRadians(rotation.Y), MathHelper.ToRadians(rotation.X), MathHelper.ToRadians(rotation.Z));
            world *= Matrix.CreateTranslation(position + pivot);
        }

        public bool IsColliding(BoundingBox other)
        {
            return collider.GetBoundingBox().Intersects(other);
        }

        protected Matrix GetWorld()         { return world; }
        protected Game1 GetGame1()          { return game; }
        public Vector3 GetDimension()    { return size * scale; }
        protected Vector3 GetSize()         { return size; }
        public Vector3 GetPosition()     { return position; }
        public Vector3 GetRotation()     { return rotation; }
        protected Vector3 GetScale()        { return scale; }
        protected Vector3 GetPivot()        { return pivot; }
        public BoundingBox GetCollider() { return collider.GetBoundingBox(); }

        protected void SetSize(Vector3 size)
        {
            this.size = size;
            collider = new Collider(game, position, scale, this.size, Color.Green, colliderVisible);
        }
        public void SetPosition(Vector3 position)
        {
            this.position = position;
            collider.SetPosition(Vector3.Transform(Vector3.Zero, world));
        }
        protected void SetScale(Vector3 scale)
        {
            this.scale = scale;
            collider.SetScale(this.scale);
        }
        public void SetRotation(Vector3 rotation)
        {
            this.rotation = rotation;
        }
        public void SetPivot(Vector3 pivot)
        {
            this.pivot = pivot;
        }
        public void AddPosition(Vector3 position)
        {
            this.position += position;
            collider.SetPosition(Vector3.Transform(Vector3.Zero, world));
        }
        protected void AddScale(Vector3 scale)
        {
            this.scale += scale;
            collider.SetScale(this.scale);
        }
        public void AddRotation(Vector3 rotation)
        {
            this.rotation += rotation;
        }
        protected void AddPivot(Vector3 pivot)
        {
            this.pivot += pivot;
        }
        public void SetColliderColor(Color color)
        {
            collider.SetColor(color);
        }
    }
}
