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
        private Game1 game;
        private Matrix world;
        private Vector3 size;
        private bool colliderVisible;
        protected Vector3 position, rotation, scale, pivot;

        protected Collider collider;
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

            collider.SetPosition(Vector3.Transform(Vector3.Zero, world));
            collider.SetScale(scale);

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

        protected Matrix GetWorld() 
        { 
            return world; 
        }

        protected Game1 GetGame1()
        {
            return game;
        }
        
        protected void SetSize(Vector3 size) 
        { 
            this.size = size;
            collider = new Collider(game, position, scale, this.size, Color.Green, colliderVisible);
        }
    }
}
