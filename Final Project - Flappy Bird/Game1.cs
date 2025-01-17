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

        Texture2D backgroundTexture,  batmanTexture, pipeTexture, introBackgroundTexture, backwardsPipeTexture;

        Rectangle batmanRect, backgroundRect, background2Rect, pipeRect, pipe2Rect, pipe3Rect, backwardsPipeRect, backwardsPipe2Rect, backwardsPipe3Rect;

        Vector2 batmanSpeed, backgroundSpeed, background2Speed, pipeSpeed, backwardsPipeSpeed;

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
            backgroundRect = new Rectangle(800,0,800,600);
            background2Rect = new Rectangle(0, 0, 800, 600);
            backgroundSpeed = new Vector2(-2,0); 
            
            pipeRect = new Rectangle(790, 500, 200, 350);
            pipe2Rect = new Rectangle(1140, 300, 200, 600);
            pipe3Rect = new Rectangle(1490, 375, 200, 600);
            pipeSpeed = new Vector2(-2,0);

            backwardsPipeRect = new Rectangle(790, 0, 200, 350);
            backwardsPipe2Rect = new Rectangle(300, 1140, 200, 600);
            backwardsPipe3Rect = new Rectangle(375, 1490, 200, 600);
            backwardsPipeSpeed = new Vector2(-2, 0);

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
            //background2Texture = Content.Load<Texture2D>("Background");
            batmanTexture = Content.Load<Texture2D>("Batman1");
            pipeTexture = Content.Load<Texture2D>("Pipe2");
            introBackgroundTexture = Content.Load<Texture2D>("Background");
            textFont = Content.Load<SpriteFont>("File");
            backwardsPipeTexture = Content.Load<Texture2D>("UpsideDownPipe");
        }

        protected override void Update(GameTime gameTime)

        {

            mouseState = Mouse.GetState();


            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            if (screen == Screen.background)
            {
                //atmanRect.X += (int)batmanSpeed.X;
                //if (batmanRect.Right > window.Width || batmanRect.Left < 0)
                //{
                //    batmanSpeed.X *= 1;
                //}
                backgroundRect.Offset(backgroundSpeed);
                background2Rect.Offset(backgroundSpeed);
                if (backgroundRect.Right <= 0)
                {
                    backgroundRect.X = window.Width;
                }
                if (background2Rect.Right <= 0) 
                {
                    background2Rect.X = window.Width;
                }
                 
                
            }
            backwardsPipeRect.Offset(backwardsPipeSpeed);
            backwardsPipe2Rect.Offset(backwardsPipeSpeed); 
            backwardsPipe3Rect.Offset(backwardsPipeSpeed);
            if (backwardsPipeRect.Right <= 0)
            {
                backwardsPipeRect.X = window.Width;
            }
            if (backwardsPipe2Rect.Right <= 0)
            {
                backwardsPipe2Rect.X = window.Width;
            }
            if (backwardsPipe3Rect.Right <= 0)
            {
                backwardsPipe3Rect.X = window.Width;
            }
            pipeRect.Offset(pipeSpeed);
            pipe2Rect.Offset(pipeSpeed);
            pipe3Rect.Offset(pipeSpeed);
            if (pipeRect.Right <= 0)
            {
                pipeRect.X = window.Width;
            }
            if (pipe2Rect.Right <= 0)
            {
                pipe2Rect.X = window.Width;
            }
            if (pipe3Rect.Right <= 0)
            {
                pipe3Rect.X = window.Width;
            }
            else if (screen == Screen.introBackground)
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
                _spriteBatch.Draw(backgroundTexture, backgroundRect, Color.White);
                _spriteBatch.Draw(backgroundTexture, background2Rect, Color.White);

                _spriteBatch.Draw(batmanTexture, batmanRect, Color.White);

                _spriteBatch.Draw(pipeTexture, pipeRect, Color.White);
                _spriteBatch.Draw(pipeTexture, pipe2Rect, Color.White);
                _spriteBatch.Draw(pipeTexture, pipe3Rect, Color.White);
            }

            

            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
