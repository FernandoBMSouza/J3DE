using Microsoft.Xna.Framework;
using Mundo03.Utilities;
using Microsoft.Xna.Framework.Graphics;
using Mundo03.Utilities.Collision;
using Microsoft.Xna.Framework.Input;

namespace Mundo03.GameObjects
{
    abstract class GameObject
    {
        public Matrix World { get; set; }
        public Vector3 Size { get; protected set; }
        public Collider BoxCollider { get; private set; }
        public GameObject[] Children { get; protected set; }

        protected BasicEffect effect;
        Game1 game;

        public GameObject(Game1 game, bool showColliderLines = false)
        {
            this.game = game;
            effect = new BasicEffect(game.GraphicsDevice);
            BoxCollider = new Collider(game, this);
            BoxCollider.IsVisible = showColliderLines;
        }

        public virtual void Update(GameTime gameTime)
        {
            // Desativa o colisor dos filhos, se deixar ativo o jogo trava por causa das helices que ficam atualizando direto
            if (Children != null)
            {
                foreach (GameObject child in Children)
                {
                    child.BoxCollider.IsVisible = false;
                    child.BoxCollider.IsActive = false;
                }
            }

            BoxCollider.Update();
        }

        public virtual void Draw(Camera camera)
        {
            if (Children != null)
            {
                foreach (GameObject child in Children)
                    child.Draw(camera);
            }

            if (BoxCollider.IsVisible) BoxCollider.Lines.Draw(effect, camera);
        }

        public Vector3 GetPosition()
        {
            Vector3 scale, translation;
            Quaternion rotation;

            World.Decompose(out scale, out rotation, out translation);
            return translation;
        }

        public Vector3 GetRotation()
        {
            Vector3 scale, translation;
            Quaternion rotation;

            World.Decompose(out scale, out rotation, out translation);
            return new Vector3(rotation.ToEulerAngles().X, rotation.ToEulerAngles().Y, rotation.ToEulerAngles().Z);
        }

        public Vector3 GetScale()
        {
            Vector3 scale, translation;
            Quaternion rotation;

            World.Decompose(out scale, out rotation, out translation);
            return scale;
        }

        public bool IsColliding(GameObject other)
        {
            return BoxCollider.BoundingBox.Intersects(other.BoxCollider.BoundingBox);         
        }
    }
}
