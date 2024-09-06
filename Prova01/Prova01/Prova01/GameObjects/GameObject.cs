using Microsoft.Xna.Framework;
using Prova01.Utilities;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Prova01.Utilities.Collision;

namespace Prova01.GameObjects
{
    public class GameObject
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
                child.collider.SetScale(child.GetScale() * GetScale());
            }

            collider.SetPosition(Vector3.Transform(Vector3.Zero, world));
            collider.SetScale(this.scale);

            SetupMatrix();
        }

        public virtual void Draw(Camera camera, BasicEffect effect)
        {
            foreach (GameObject child in children)
                child.Draw(camera, effect);

            collider.Draw(effect, camera);
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

        private float NormalizeAngle(float angle)
        {
            angle = angle % 360; // Garante que esteja entre -360 e 360
            if (angle < 0)
            {
                angle += 360; // Ajusta para ficar entre 0 e 360
            }
            return angle;
        }

        protected Matrix GetWorld()         { return world; }
        protected Game1 GetGame1()          { return game; }
        protected Vector3 GetDimension()    { return size * scale; }
        protected Vector3 GetSize()         { return size; }
        public Vector3 GetPosition()     { return position; }
        public Vector3 GetRotation() { return rotation; }
        protected Vector3 GetScale()        { return scale; }
        protected Vector3 GetPivot()        { return pivot; }
        
        protected void SetSize(Vector3 size)
        {
            this.size = size;
            collider = new Collider(game, position, scale, this.size, Color.Green, colliderVisible);
        }
        protected void SetPosition(Vector3 position)
        {
            this.position = position;
            collider.SetPosition(Vector3.Transform(Vector3.Zero, world));
        }
        protected void SetScale(Vector3 scale)
        {
            this.scale = scale;
            collider.SetScale(this.scale);
        }
        protected void SetRotation(Vector3 rotation)
        {
            this.rotation = rotation;
            this.rotation.X = NormalizeAngle(this.rotation.X);
            this.rotation.Y = NormalizeAngle(this.rotation.Y);
            this.rotation.Z = NormalizeAngle(this.rotation.Z);
        }
        protected void SetPivot(Vector3 pivot)
        {
            this.pivot = pivot;
        }
        protected void AddPosition(Vector3 position)
        {
            this.position += position;
            collider.SetPosition(Vector3.Transform(Vector3.Zero, world));
        }
        protected void AddScale(Vector3 scale)
        {
            this.scale += scale;
            collider.SetScale(this.scale);
        }
        protected void AddRotation(Vector3 rotation)
        {
            this.rotation += rotation;
            this.rotation.X = NormalizeAngle(this.rotation.X);
            this.rotation.Y = NormalizeAngle(this.rotation.Y);
            this.rotation.Z = NormalizeAngle(this.rotation.Z);
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
