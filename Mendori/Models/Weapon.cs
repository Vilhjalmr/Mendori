using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mendori.Models
{
    public class Weapon : AutomatedSprite
    {
        public int Damage { get; set; }

        #region Constructors
        public Weapon(Texture2D textureImage, Vector2 position,
            Point frameSize, int collisionOffset, Point currentFrame,
            Point sheetSize, Vector2 speed)
            : base(textureImage, position, frameSize, collisionOffset,
                  currentFrame, sheetSize, speed)
        { }

        public Weapon(Texture2D textureImage, Vector2 position,
            Point frameSize, int collisionOffset, Point currentFrame,
            Point sheetSize, Vector2 speed, int millisecondsPerFrame)
            : base(textureImage, position, frameSize, collisionOffset,
                  currentFrame, sheetSize, speed, millisecondsPerFrame)
        { }
        #endregion

    }
}
