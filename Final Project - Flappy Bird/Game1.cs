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

        
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            batmanRect = new Rectangle(50, 50, 100, 100);
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

            backgroundTexture = Content.Load<Texture2D>("Background (2)");
            batmanTexture = Content.Load<Texture2D>("Batman");
            pipeTexture = Content.Load<Texture2D>("Pipe");
            introBackgroundTexture = Content.Load<Texture2D>("Background (2)");
            textFont = Content.Load<SpriteFont>("File");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            batmanRect.X += (int)batmanSpeed.X;
            if (batmanRect.Right > window.Width || batmanRect.Left < 0)
            {
                batmanSpeed.X *= 1;
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
                _spriteBatch.DrawString(textFont, "Click space to Continue to the Game!", new Vector2(165, 25), Color.White);

            }

            else if (screen == Screen.background)
            {
                _spriteBatch.Draw(backgroundTexture, window, Color.White);

                _spriteBatch.Draw(batmanTexture, batmanRect, Color.White);
               

            }

            _spriteBatch.Draw(backgroundTexture, Vector2.Zero, Color.White);

            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
