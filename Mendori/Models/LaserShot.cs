using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mendori.Models
{
    internal class LaserShot : Weapon
    {
        public LaserShot() : base()
        {

        }

        public override void Move()
        {
            if (this.posY > 0 - Texture.Bounds.Height)
            {
                this.posY -= 15;
            }
            else
            {

            }
        }

        public override void Update()
        {
            Move();
        }
    }
}
