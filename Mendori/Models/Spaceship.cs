using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mendori.Models
{
    class Spaceship : UserControlledSprite
    {
        public List<Weapon> Shots = new List<Weapon>() { get; set; }

        #region Methods
        
        public void Update()
        {
            
        }
        
        public void ShootLaser()
        {
            LaserShot LeftLS= new LaserShot((this.posX + (this.width / 2) - (this.width / 3 ) - (LaserTexture.Bounds.Width/2)), this.posY-(this.height/3), LaserTexture);
            LaserShot RightLS = new LaserShot((this.posX + (this.width / 2) + (this.width / 3 ) - (LaserTexture.Bounds.Width/2)), this.posY - (this.height / 3), LaserTexture);
            Shots.Add(LeftLS);
            Shots.Add(RightLS);
        }
        
        public void ShootMissile()
        {
            
        }
        
        public void Switchpolarity()
        {
            
        }
        #endregion
    }
}
