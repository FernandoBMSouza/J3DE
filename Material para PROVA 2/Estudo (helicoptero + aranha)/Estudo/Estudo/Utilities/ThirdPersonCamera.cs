using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Estudo.GameObjects.Mine;

namespace Estudo.Utilities
{
    public class ThirdPersonCamera
    {
        private Vector3 positionOffset = new Vector3(0, 3, -10); // Offset da câmera em relação ao jogador
        private Vector3 targetOffset = new Vector3(0, 1, 0);   // Offset do alvo da câmera em relação ao jogador

        private Vector3 position;
        private Vector3 target;
        private Vector3 up;

        public Matrix View { get; private set; }
        public Matrix Projection { get; private set; }

        public ThirdPersonCamera(Game game, Player player)
        {
            this.up = Vector3.Up;

            // Configura a projeção
            Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4,
                                                             Screen.GetInstance().Width / (float)Screen.GetInstance().Height,
                                                             0.001f, 1000);

            // Atualiza a câmera inicialmente
            UpdateCamera(player);
        }

        public void Update(GameTime gameTime, Player player)
        {
            UpdateCamera(player);
        }

        private void UpdateCamera(Player player)
        {
            // Atualiza a posição da câmera para estar atrás e acima do jogador
            position = player.GetPosition() + positionOffset;

            // Atualiza o alvo da câmera para o jogador
            target = player.GetPosition() + targetOffset;

            // Atualiza a matriz de visualização
            View = Matrix.CreateLookAt(position, target, up);
        }
    }
}
