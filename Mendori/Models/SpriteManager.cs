using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mendori.Models
{
    public class SpriteManager : DrawableGameComponent
    {
        public bool gameOver { get; private set; }

        SpriteBatch spriteBatch;
        UserControlledSprite player;
        Spaceship pj;
        List<Sprite> spriteList = new List<Sprite>();

        public SpriteManager(Game game) : base(game)
        { }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(Game.GraphicsDevice);

            //player = new UserControlledSprite(
            //    Game.Content.Load<Texture2D>("Img/player1"),
            //    new Vector2(Game.GraphicsDevice.PresentationParameters.BackBufferWidth/2, Game.GraphicsDevice.PresentationParameters.BackBufferHeight/10*9),
            //    new Point(128, 128), 5,
            //    new Point(0, 0), new Point(1, 1), new Vector2(6, 6));

            pj = new Spaceship(
                Game.Content.Load<Texture2D>("Img/player1"),
                new Vector2(Game.GraphicsDevice.PresentationParameters.BackBufferWidth / 2, Game.GraphicsDevice.PresentationParameters.BackBufferHeight / 10 *9),
                new Point(128, 128), 5,
                new Point(0, 0), new Point(1, 1), new Vector2(6, 6),
                Polarity.White,
                Game.Content.Load<Texture2D>("Img/blueLaser")
                );

            spriteList.Add(new AutomatedSprite(
                Game.Content.Load<Texture2D>("Img/threerings"),
                new Vector2(150, 150), 
                new Point(75, 75), 10,
                new Point(0, 0), new Point(6, 8), Vector2.Zero));

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (!gameOver)
            {
                // Update player
                pj.Update(gameTime, Game.GraphicsDevice.PresentationParameters.Bounds);

                // Update sprite list
                foreach (Sprite s in spriteList)
                {
                    s.Update(gameTime, Game.GraphicsDevice.PresentationParameters.Bounds);

                    // Check for collisions. Exit if found
                    if (s.collisionRect.Intersects(pj.collisionRect))
                    {
                        gameOver = true;
                    }
                }
            }


            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

            // Draw Player
            pj.Draw(gameTime, spriteBatch);

            // Draw sprite list
            foreach (Sprite s in spriteList)
            {
                s.Draw(gameTime, spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
