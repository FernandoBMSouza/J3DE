using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Prova01.GameObjects.Prova01
{
    class NPC : Snail
    {
        public NPC(Game1 game, Vector3 position, Vector3 rotation, Vector3 scale, float offset, Color color, Track track, bool colliderVisible = true)
            : base(game, position + new Vector3(0, 0, offset), rotation, scale, offset, color, track, colliderVisible)
        { 
        
        }
    }
}
