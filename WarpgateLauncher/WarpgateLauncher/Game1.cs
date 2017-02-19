using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WarpgateLauncher
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        private int windowHeight = 600;
        private int windowWidth = 800;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            graphics.PreferredBackBufferHeight = windowHeight;
            graphics.PreferredBackBufferWidth = windowWidth;
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            SpriteContainer.PanelBorders = new Dictionary<BorderSegment, Texture2D>();
            SpriteContainer.PanelBorders.Add(BorderSegment.TopLeft, Content.Load<Texture2D>("./images/windowborder/topleft"));
            SpriteContainer.PanelBorders.Add(BorderSegment.TopRight, Content.Load<Texture2D>("./images/windowborder/topright"));
            SpriteContainer.PanelBorders.Add(BorderSegment.BottomLeft, Content.Load<Texture2D>("./images/windowborder/bottomleft"));
            SpriteContainer.PanelBorders.Add(BorderSegment.BottomRight, Content.Load<Texture2D>("./images/windowborder/bottomright"));
            SpriteContainer.PanelBorders.Add(BorderSegment.Left, Content.Load<Texture2D>("./images/windowborder/sideleft"));
            SpriteContainer.PanelBorders.Add(BorderSegment.Right, Content.Load<Texture2D>("./images/windowborder/sideright"));
            SpriteContainer.PanelBorders.Add(BorderSegment.Top, Content.Load<Texture2D>("./images/windowborder/sidetop"));
            SpriteContainer.PanelBorders.Add(BorderSegment.Bottom, Content.Load<Texture2D>("./images/windowborder/sidebottom"));

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            var panelRectangle = new Rectangle(graphics.GraphicsDevice.Viewport.X, graphics.GraphicsDevice.Viewport.Height / 2,
                                        graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height / 2);

            spriteBatch.Draw(SpriteContainer.PanelBorders[BorderSegment.TopLeft], new Vector2(panelRectangle.Left, panelRectangle.Top), Color.White);
            spriteBatch.Draw(SpriteContainer.PanelBorders[BorderSegment.BottomRight], new Vector2(panelRectangle.Right - 32, panelRectangle.Bottom - 32), Color.White);
            spriteBatch.Draw(SpriteContainer.PanelBorders[BorderSegment.TopRight], new Vector2(panelRectangle.Right - 32, panelRectangle.Top), Color.White);
            spriteBatch.Draw(SpriteContainer.PanelBorders[BorderSegment.BottomLeft], new Vector2(panelRectangle.Left, panelRectangle.Bottom - 32), Color.White);
            spriteBatch.Draw(SpriteContainer.PanelBorders[BorderSegment.Top], new Rectangle(panelRectangle.Left + 32, panelRectangle.Top, panelRectangle.Right - 64, 32), Color.White);
            spriteBatch.Draw(SpriteContainer.PanelBorders[BorderSegment.Bottom], new Rectangle(panelRectangle.Left + 32, panelRectangle.Bottom - 32, panelRectangle.Right - 64, 32), Color.White);
            spriteBatch.Draw(SpriteContainer.PanelBorders[BorderSegment.Right], new Rectangle(panelRectangle.Right - 32, panelRectangle.Top + 32, 32, graphics.GraphicsDevice.Viewport.Height / 2 - 64), Color.White);
            spriteBatch.Draw(SpriteContainer.PanelBorders[BorderSegment.Left], new Rectangle(panelRectangle.Left, panelRectangle.Top + 32, 32, graphics.GraphicsDevice.Viewport.Height / 2 - 64), Color.White);
            var rectangleTexture = new Texture2D(GraphicsDevice, 1, 1);
            rectangleTexture.SetData(new []{new Color(255, 255, 255)});
            spriteBatch.Draw(rectangleTexture, new Rectangle(32, graphics.GraphicsDevice.Viewport.Height / 2 + 32, panelRectangle.Right - 64, graphics.GraphicsDevice.Viewport.Height / 2 - 64), Color.White);

            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
