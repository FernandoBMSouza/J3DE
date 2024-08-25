using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Effects
{
    class Helicopter : GameObject
    {
        Game1 game;
        public Helicopter(Game1 game)
            : base(game)
        {
            this.game = game;
            Size = new Vector3(2, 5, 3);
            Model = game.Content.Load<Model>(@"Models\Helicopter");
            effect = game.Content.Load<Effect>(@"Effects\Diffuse");
        }

        public void DrawAmbient(Camera camera)
        {
            if (Vertices != null)
                game.GraphicsDevice.SetVertexBuffer(buffer);

            Matrix world = Matrix.CreateScale(Scale)
                                 * Matrix.CreateFromYawPitchRoll(Rotation.Y, Rotation.X, Rotation.Z)
                                 * Matrix.CreateTranslation(Position);
            if (Model != null)
            {
                foreach (ModelMesh mesh in Model.Meshes)
                {
                    foreach (ModelMeshPart part in mesh.MeshParts)
                    {
                        part.Effect = effect;
                        effect.Parameters["World"].SetValue(world);
                        effect.Parameters["View"].SetValue(camera.View);
                        effect.Parameters["Projection"].SetValue(camera.Projection);
                        //effect.Parameters["AmbientColor"].SetValue(Color.Green.ToVector4());
                        //effect.Parameters["AmbientIntensity"].SetValue(0.5f);
                    }
                    mesh.Draw();
                }
            }
        }
        public void DrawDiffuse(Camera camera)
        {
            if (Vertices != null)
                game.GraphicsDevice.SetVertexBuffer(buffer);

            Matrix world = Matrix.CreateScale(Scale)
                           * Matrix.CreateFromYawPitchRoll(Rotation.Y, Rotation.X, Rotation.Z)
                           * Matrix.CreateTranslation(Position);

            if (Model != null)
            {
                foreach (ModelMesh mesh in Model.Meshes)
                {
                    foreach (ModelMeshPart part in mesh.MeshParts)
                    {
                        part.Effect = effect;
                        effect.Parameters["World"].SetValue(world);
                        effect.Parameters["View"].SetValue(camera.View);
                        effect.Parameters["Projection"].SetValue(camera.Projection);
                        //effect.Parameters["AmbientColor"].SetValue(Color.Green.ToVector4());
                        //effect.Parameters["AmbientIntensity"].SetValue(0.5f);

                        Matrix worldInverseTransposeMatrix = Matrix.Transpose(Matrix.Invert(world));
                        effect.Parameters["WorldInverseTranspose"].SetValue(worldInverseTransposeMatrix);
                    }
                    mesh.Draw();
                }
            }
        }
    
    }
}
