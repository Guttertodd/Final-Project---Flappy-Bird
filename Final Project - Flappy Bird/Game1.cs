using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Final_Project___Flappy_Bird
{
    enum Screen
    {
        introBackground,
        background
    }
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Rectangle window;

        Texture2D backgroundTexture, batmanTexture, pipeTexture, introBackgroundTexture;
       
        Rectangle batmanRect;

        Vector2 batmanSpeed;

        SpriteBatch spriteBatch;

        SpriteFont textFont;

        Screen screen;

        MouseState mouseState;
        
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            batmanRect = new Rectangle(0, 200, 120, 120);
            batmanSpeed = new Vector2(2, 2);

            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();
            base.Initialize();

            screen = Screen.introBackground;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);


            // TODO: use this.Content to load your game content here

            backgroundTexture = Content.Load<Texture2D>("Background");
            batmanTexture = Content.Load<Texture2D>("Batman");
            pipeTexture = Content.Load<Texture2D>("Pipe");
            introBackgroundTexture = Content.Load<Texture2D>("Background");
            textFont = Content.Load<SpriteFont>("File");
        }

        protected override void Update(GameTime gameTime)

        {

            mouseState = Mouse.GetState();


            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            if (screen == Screen.background)
            {
                batmanRect.X += (int)batmanSpeed.X;
                if (batmanRect.Right > window.Width || batmanRect.Left < 0)
                {
                    batmanSpeed.X *= 1;
                }
            }
            //    batmanRect.X += (int)batmanSpeed.X;
            //if (batmanRect.Right > window.Width || batmanRect.Left < 0)
            //{
            //    batmanSpeed.X *= 1;
            //}

            if (screen == Screen.introBackground)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)

                    screen = Screen.background;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

          

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            if (screen == Screen.introBackground)
            {
                _spriteBatch.Draw(introBackgroundTexture, window, Color.White);
                _spriteBatch.DrawString(textFont, "How To Play:", new Vector2(320, 75), Color.White);
                _spriteBatch.DrawString(textFont, "Space Bar = Jump, Don't Hit the Pipe, 25 Score = Win!", new Vector2(15, 180), Color.White);
                _spriteBatch.DrawString(textFont, "Left Click to Continue to the Game!", new Vector2(165, 300), Color.White);

            }

            else if (screen == Screen.background)
            {
                _spriteBatch.Draw(backgroundTexture, window, Color.White);

                _spriteBatch.Draw(batmanTexture, batmanRect, Color.White);
               

            }

            

            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
