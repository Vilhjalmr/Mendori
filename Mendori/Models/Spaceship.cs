using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mendori.Models
{
    public class Spaceship : UserControlledSprite
    {
        #region Fields
        List<Weapon> Shots = new List<Weapon>();

        #endregion

        #region Properties
        Texture2D LaserTexture { get; set; }
        Polarity Polarity { get; set; }
        #endregion


        #region Constructors
        public Spaceship(Texture2D textureImage, Vector2 position,
            Point frameSize, int collisionOffset, Point currentFrame,
            Point sheetSize, Vector2 speed, Polarity polarity, Texture2D laserTexture)
            : base(textureImage, position, frameSize, collisionOffset,
                  currentFrame, sheetSize, speed)
        {
            // TODO: add polarity and lasertexture
            Polarity = polarity;
            LaserTexture = laserTexture;
        }

        #endregion

        #region Methods

        public override void Update(GameTime gameTime, Rectangle clientBounds)
        {
            position += direction;

            if (position.X < 0)
                position.X = 0;
            if (position.Y < 0)
                position.Y = 0;
            if (position.X > clientBounds.Width - frameSize.X)
                position.X = clientBounds.Width - frameSize.X;
            if (position.Y > clientBounds.Height - frameSize.Y)
                position.Y = clientBounds.Height - frameSize.Y;


            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                this.ShootLaser();

            foreach (LaserShot LS in Shots)
            {
                LS.Update(gameTime, clientBounds);
            }

            base.Update(gameTime, clientBounds);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (LaserShot LS in Shots)
            {
                LS.Draw(gameTime, spriteBatch);
            }

            base.Draw(gameTime, spriteBatch);
        }

        public void ShootLaser()
        {
            Vector2 posLeftLS = new Vector2(
                (this.position.X + (this.textureImage.Bounds.Width / 2) - (this.textureImage.Bounds.Width / 3) - (this.LaserTexture.Bounds.Width / 2)),
                (this.position.Y - (this.textureImage.Bounds.Height / 3))
                );
            Vector2 posRightLS = new Vector2(
                (this.position.X +  (this.textureImage.Bounds.Width / 2) + (this.textureImage.Bounds.Width / 3) - (this.LaserTexture.Bounds.Width / 2)),
                (this.position.Y - (this.textureImage.Bounds.Height / 3))
                );

            LaserShot LeftLS = new LaserShot(this.LaserTexture, posLeftLS, new Point(64, 64), 10, new Point(0, 0), new Point(1, 1), new Vector2(0, 12));
            LaserShot RightLS = new LaserShot(this.LaserTexture, posRightLS, new Point(64, 64), 10, new Point(0, 0), new Point(1, 1), new Vector2(0, 12));
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
