using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mendori.Models
{
    public class LaserShot : Weapon
    {
        // TODO: add polarity logic to laser

        public LaserShot(Texture2D textureImage, Vector2 position,
            Point frameSize, int collisionOffset, Point currentFrame,
            Point sheetSize, Vector2 speed)
            : base(textureImage, position, frameSize, collisionOffset,
                  currentFrame, sheetSize, speed)
        { }
      

       

        public override void Update(GameTime gameTime, Rectangle clientBounds)
        {
            if (this.position.Y > 0 - textureImage.Bounds.Height)
            {
                this.position -= speed;
            }
            else
            {

            }
        }

        
    }
}
