using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Final_Project___Flappy_Bird
{
    enum Screen
    {
        introBackground,
        background,
        end, 
        win
    }
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Rectangle window;

        Texture2D backgroundTexture,  batmanTexture, pipeTexture, introBackgroundTexture, backwardsPipeTexture, endTexture, winTexture;

        Rectangle batmanRect, backgroundRect, background2Rect, pipeRect, pipe2Rect, pipe3Rect, backwardsPipeRect, backwardsPipe2Rect, backwardsPipe3Rect;

        Vector2 batmanSpeed, backgroundSpeed, background2Speed, pipeSpeed, backwardsPipeSpeed;

        SpriteBatch spriteBatch;

        SpriteFont textFont;

        Screen screen;

        MouseState mouseState, previousMouseState;

        KeyboardState keyboardState, previousKeyboardState;

        int flapCount;

        int points;

        bool isJumping;

        SoundEffect backgroundMusic;

        int soundCount;

        bool backgroundSound;

        SpriteFont font;

        


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            InitializeGameObjects();

            points = 0;
           


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
            batmanTexture = Content.Load<Texture2D>("BatmanGame");
            pipeTexture = Content.Load<Texture2D>("PipeBottom");
            introBackgroundTexture = Content.Load<Texture2D>("Background");
            textFont = Content.Load<SpriteFont>("File");
            backwardsPipeTexture = Content.Load<Texture2D>("PipeTop");
            backgroundMusic = Content.Load<SoundEffect>("BackgroundChill");
            endTexture = Content.Load<Texture2D>("Background");
            winTexture = Content.Load<Texture2D>("Background");

        }

        protected override void Update(GameTime gameTime)

        {
            previousMouseState = mouseState;
            mouseState = Mouse.GetState();
            keyboardState = Keyboard.GetState();
            previousKeyboardState = keyboardState;

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            if (screen == Screen.background)
            {
               
                    
                
               
                
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

                backwardsPipeRect.Offset(backwardsPipeSpeed);
                backwardsPipe2Rect.Offset(backwardsPipeSpeed);
                backwardsPipe3Rect.Offset(backwardsPipeSpeed);
                if (backwardsPipeRect.Right <= 0)
                {
                    backwardsPipeRect.X = window.Width + 225;    
                }
                if (backwardsPipe2Rect.Right <= 0)
                {
                    backwardsPipe2Rect.X = window.Width + 220;
                }
                if (backwardsPipe3Rect.Right <= 0)
                {
                    backwardsPipe3Rect.X = window.Width + 220;
                }
                pipeRect.Offset(pipeSpeed);
                pipe2Rect.Offset(pipeSpeed);
                pipe3Rect.Offset(pipeSpeed);
                if (pipeRect.Right <= 0)
                {
                    pipeRect.X = window.Width + 225;
                    points += 1;
                }
                if (pipe2Rect.Right <= 0)
                {
                    pipe2Rect.X = window.Width + 220;
                    points += 1;
                }
                if (pipe3Rect.Right <= 0)
                {
                    pipe3Rect.X = window.Width + 220;
                    points += 1;
                }


                if (keyboardState.IsKeyDown(Keys.Space) && !isJumping)
                {
                    batmanSpeed.Y = -2;     
                    isJumping = true;
                }
                if (isJumping)
                {
                    flapCount += 1;
                }

                if (flapCount > 15)
                {
                    batmanSpeed.Y = 2;
                    isJumping = false;
                    flapCount = 0;
                }
                else if (batmanRect.Intersects(pipeRect))
                {
                    screen = Screen.end;
                }
                else if (batmanRect.Intersects(pipe2Rect))
                {
                    screen = Screen.end;
                }
                else if (batmanRect.Intersects(pipe3Rect))
                {
                    screen = Screen.end;
                }
                else if (batmanRect.Intersects(backwardsPipeRect))
                {
                    screen = Screen.end;
                }
                else if (batmanRect.Intersects(backwardsPipe2Rect))
                {
                    screen = Screen.end;
                }
                else if (batmanRect.Intersects(backwardsPipe3Rect))
                {
                    screen = Screen.end;
                }
                else if (points == 25)
                {
                    screen = Screen.win;
                }

                

                batmanRect.Offset(batmanSpeed);

            }
            else if (screen == Screen.introBackground)
            {
                if (mouseState.LeftButton == ButtonState.Pressed & previousMouseState.LeftButton == ButtonState.Released)
                {
                    screen = Screen.background;
                    backgroundMusic.Play();
                }

            }

            else if (screen == Screen.end)
            {
                if (mouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released)
                {
                    screen = Screen.introBackground;
                    InitializeGameObjects();
                }

            }
            
            else if (screen == Screen.win)
            {
                if (mouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released)
                {
                    screen = Screen.introBackground;
                    InitializeGameObjects();
                }
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

                _spriteBatch.Draw(backwardsPipeTexture, backwardsPipeRect, Color.White);
                _spriteBatch.Draw(backwardsPipeTexture, backwardsPipe2Rect, Color.White);
                _spriteBatch.Draw(backwardsPipeTexture, backwardsPipe3Rect, Color.White);

                _spriteBatch.DrawString(textFont, "Points:" + points , new Vector2(20, 20), Color.White);
                
                
            }

            else if (screen == Screen.end)
            {
                _spriteBatch.Draw(endTexture, window, Color.White);
                _spriteBatch.DrawString(textFont, "You Died!", new Vector2(335,200), Color.White);
                _spriteBatch.DrawString(textFont, "Left Click To Restart!", new Vector2(260, 300), Color.White);
            }

            else if (screen == Screen.win)
            {
                _spriteBatch.Draw(endTexture, window, Color.White);
                _spriteBatch.DrawString(textFont, "CONGRATULATIONS, YOU WON!", new Vector2(150, 125), Color.White);
                _spriteBatch.DrawString(textFont, "Left Click If You Want To Play Agian!", new Vector2(135, 240), Color.White);
            }

            _spriteBatch.End();


            base.Draw(gameTime);
        }

        public void InitializeGameObjects()
        {
            flapCount = 0;

            isJumping = false;




            batmanRect = new Rectangle(0, 200, 80, 80);
            batmanSpeed = new Vector2(0, 2);
            backgroundRect = new Rectangle(800, 0, 800, 600);
            background2Rect = new Rectangle(0, 0, 800, 600);
            backgroundSpeed = new Vector2(-2, 0);

            pipeRect = new Rectangle(500, 475, 50, 350);
            pipe2Rect = new Rectangle(900, 275, 50, 575);
            pipe3Rect = new Rectangle(1300, 350, 50, 600);
            pipeSpeed = new Vector2(-2, 0);

            backwardsPipeRect = new Rectangle(500, 0, 50, 305);
            backwardsPipe2Rect = new Rectangle(900, 0, 50, 120);
            backwardsPipe3Rect = new Rectangle(1300, 0, 50, 200);
            backwardsPipeSpeed = new Vector2(-2, 0);

            points = 0;
        }
    }
}
