using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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

        /// <summary>
        /// Adds Polarity and LaserTexture to base constructor.
        /// Polarity is White by default.
        /// </summary>
        /// <param name="textureImage"></param>
        /// <param name="position"></param>
        /// <param name="frameSize"></param>
        /// <param name="collisionOffset"></param>
        /// <param name="currentFrame"></param>
        /// <param name="sheetSize"></param>
        /// <param name="speed"></param>
        /// <param name="laserTexture"></param>
        public Spaceship(Texture2D textureImage, Vector2 position,
           Point frameSize, int collisionOffset, Point currentFrame,
           Point sheetSize, Vector2 speed, Texture2D laserTexture)
           : base(textureImage, position, frameSize, collisionOffset,
                 currentFrame, sheetSize, speed)
        {
            Polarity = Polarity.White;
            LaserTexture = LaserTexture;
        }

        /// <summary>
        /// Adds Polarity and LaserTexture to base constructor.
        /// </summary>
        /// <param name="textureImage"></param>
        /// <param name="position"></param>
        /// <param name="frameSize"></param>
        /// <param name="collisionOffset"></param>
        /// <param name="currentFrame"></param>
        /// <param name="sheetSize"></param>
        /// <param name="speed"></param>
        /// <param name="polarity"></param>
        /// <param name="laserTexture"></param>
        public Spaceship(Texture2D textureImage, Vector2 position,
            Point frameSize, int collisionOffset, Point currentFrame,
            Point sheetSize, Vector2 speed, Polarity polarity, Texture2D laserTexture)
            : base(textureImage, position, frameSize, collisionOffset,
                  currentFrame, sheetSize, speed)
        {
            Polarity = polarity;
            LaserTexture = laserTexture;
        }



        #endregion

        // TODO : implement ShootMissile & SwitchPolarity
        #region Methods

       
        public override void LoadContent(ContentManager content)
        {
            this.textureImage = content.Load<Texture2D>("Img/player1_");
        }

        /// <summary>
        /// Overrides parent Update. Responds to Keyboard.GetState, 
        /// and calls update of each LaserShot.
        /// Might need to change.
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="clientBounds"></param>
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

        /// <summary>
        /// Calls draw for every laser shot, 
        /// then calls its own base draw (from UserControlledSprite)
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="spriteBatch"></param>
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (LaserShot LS in Shots)
            {
                LS.Draw(gameTime, spriteBatch);
            }

            base.Draw(gameTime, spriteBatch);
        }

        

        /// <summary>
        /// Creates two instances of LaserShot. One at each side of the Spaceship.
        /// Currently no animation
        /// </summary>
        public void ShootLaser()
        {
            // TODO: limit number of shots
            Vector2 posLeftLS = new Vector2(
                (this.position.X + (this.textureImage.Bounds.Width / 2) - (this.textureImage.Bounds.Width / 3) - (this.LaserTexture.Bounds.Width / 2)),
                (this.position.Y - (this.textureImage.Bounds.Height / 3))
                );
            Vector2 posRightLS = new Vector2(
                (this.position.X +  (this.textureImage.Bounds.Width / 2) + (this.textureImage.Bounds.Width / 3) - (this.LaserTexture.Bounds.Width / 2)),
                (this.position.Y - (this.textureImage.Bounds.Height / 3))
                );

            LaserShot LeftLS = new LaserShot(this.LaserTexture, posLeftLS, new Point(64, 64), 10, new Point(0, 0), new Point(1, 1), new Vector2(0, 15));
            LaserShot RightLS = new LaserShot(this.LaserTexture, posRightLS, new Point(64, 64), 10, new Point(0, 0), new Point(1, 1), new Vector2(0, 15));
            Shots.Add(LeftLS);
            Shots.Add(RightLS);
        }
        
        /// <summary>
        /// Not yet implemented
        /// </summary>
        public void ShootMissile()
        {
            // TODO: pour jerem.
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// Not yet implemented
        /// </summary>
        public void Switchpolarity()
        {
            throw new NotImplementedException();
        }


            

        #endregion
    }
}
