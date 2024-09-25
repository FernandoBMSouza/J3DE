using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Prova02.GameObjects.Models
{
    public class WindmillModel : Model3D
    {
        public WindmillModel(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, bool colliderVisible = true)
            : base(game, position, rotation, scale, colliderVisible)
        {
            SetSize(new Vector3(2, 5, 3));
            children.Add(new PropellerModel(game, new Vector3(0, 1, 1.2f), new Vector3(0, 0, 0), new Vector3(1, 1, 1), true, false));
            children.Add(new BuildingModel(game, new Vector3(0,0,0), new Vector3(0,0,0), new Vector3(1,1,1), false));
        }
    }
}
