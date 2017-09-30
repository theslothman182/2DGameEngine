//-----------------------------------------------------------------------------
// GameplayScreen.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------

#region Using Statements
using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using OuroborosEngine.Interfaces;
using OuroborosEngine.Managers.InputManager;
using OuroborosEngine.Managers.Sound_Manager;
using OuroborosEngine.Managers.Content_Manager;
using OuroborosEngine.Managers.SceneManager;
using OuroborosEngine.Managers.CollisionManager;
using WaxenV_1.Managers.BehaviourManager.WStateMachine;
using OuroborosEngine.Managers.EntityManager;
using WaxenV_1.Game_Class;
using WaxenV_1.Managers.Entity_Manager;
using WaxenV_1.Managers.SceneManager.Screens.WCamera;
#endregion

namespace WaxenV_1.Managers.SceneManager.Screens
{
    /// <summary>
    /// This screen implements the actual game logic. It is just a
    /// placeholder to get the idea across: you'll probably want to
    /// put some more interesting gameplay in here!
    /// </summary>
    class GameplayScreen : GameScreen
    {
        ContentManager content;
        SpriteFont gameFont;
        MyContentManager myContent;

        InputManager inputManager;
        SoundManager soundMngr;
        PlayerStateMachine stateMachine;
        CollisionManager collMgr;

        EntityManager entityMgr;

        float pauseAlpha;

        InputAction pauseAction;

        Waxen game;

        IEntity entity;

        private List<IEntity> entities;
        private List<ICollidable> collidables;

        public static int screenHeight = 0;
        public static int screenWidth = 0;

        public WaxenCamera camera;

        TimeSpan timeSpan;

        Boolean Hypoo = false;

        /// <summary>
        /// Constructor.
        /// </summary>
        public GameplayScreen()
        {
            TransitionOnTime = TimeSpan.FromSeconds(1.5);
            TransitionOffTime = TimeSpan.FromSeconds(0.5);

            game = new Waxen();

            entityMgr = new EntityManager();
            collMgr = new CollisionManager();
            inputManager = new InputManager();
            
            entities = new List<IEntity>();

            Mouse.WindowHandle = game.Window.Handle;

            timeSpan = new TimeSpan(0, 0, 0, 1);

            pauseAction = new InputAction(new Keys[] { Keys.Escape }, true);
        }

        public void Add()
        {
            entities.Add(game.playerRequest(entity,500,700, "player1"));
            entities.Add(game.testBoxRequest(entity,500,500, "Box"));
            entities.Add(game.groundRequest(entity,0,760, "ground"));

        }

        public void AddGraphics()
        {
            entities[0].Image = myContent.GetTexture("blank");
            entities[1].Image = content.Load<Texture2D>("Box");
            entities[2].Image = content.Load<Texture2D>("ground");
            

        }

        /// <summary>
        /// Load graphics content for the game.
        /// </summary>
        public override void Activate(bool instancePreserved)
        {
            if (!instancePreserved)
            {
                if (content == null)
                    content = new ContentManager(ScreenManager.Game.Services, "Content");

                myContent = new MyContentManager(content);

                stateMachine = new PlayerStateMachine(content);
                soundMngr = new SoundManager(content);

                gameFont = myContent.GetFont("gamefont");

                screenHeight = ScreenManager.GraphicsDevice.Viewport.Height;
                screenWidth = ScreenManager.GraphicsDevice.Viewport.Width;

                camera = new WaxenCamera(ScreenManager.GraphicsDevice.Viewport);
                
                Add();
                AddGraphics();

                soundMngr.BackgroundMusic("bgmusic", content);
                entities[0].SetStateMachine(stateMachine);

                inputManager.AddKeyboardListener(entities[0].GetInput);
                inputManager.AddKeyboardListener(entities[0].GetKeyUp);

                collidables = collMgr.GetCollidableList(entities);

                //IEntity testget = entityMgr.GetEntityByNumber(entities, 3);
                //Console.WriteLine(testget.Position);

                foreach (ICollidable item in collidables)
                {
                    item.CreatePoints();
                    item.CreateEdges();
                    item.GetRadius();
                    item.GetCentrePoint();
                }

                //camera = new Camera(game.GraphicsDevice.Viewport);
                //camera = game.cameraRequest(camera);

                // A real game would probably have more content than this sample, so
                // it would take longer to load. We simulate that by delaying for a
                // while, giving you a chance to admire the beautiful loading screen.
                Thread.Sleep(1000);

                // once the load has finished, we use ResetElapsedTime to tell the game's
                // timing mechanism that we have just finished a very long frame, and that
                // it should not try to catch up.
                ScreenManager.Game.ResetElapsedTime();
            }
        }


        public override void Deactivate()
        {
            base.Deactivate();
        }


        /// <summary>
        /// Unload graphics content used by the game.
        /// </summary>
        public override void Unload()
        {
            content.Unload();
        }

        /// <summary>
        /// Updates the state of the game. This method checks the GameScreen.IsActive
        /// property, so the game will stop updating when the pause menu is active,
        /// or if you tab away to a different application.
        /// </summary>
        public override void Update(GameTime gameTime, bool otherScreenHasFocus,
                                                       bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, false);

            // Gradually fade in or out depending on whether we are covered by the pause screen.
            if (coveredByOtherScreen)
                pauseAlpha = Math.Min(pauseAlpha + 1f / 32, 1);
            else
                pauseAlpha = Math.Max(pauseAlpha - 1f / 32, 0);

            if (IsActive)
            {
                inputManager.Update();

                /// UPDATE: each entity + makeshift crosshair
                entities[0].Update(gameTime, content);
                entities[1].Update();
                entities[2].Update();

                /// updating the camera and giving it the entities position
                camera.Update(entities[0].Position);

                foreach(ICollidable item in collidables)
                {
                    /// UPDATE: the centre point of the collidables
                    item.GetCentrePoint();
                }
                // Collision between collidables
                if(Hypoo == false)
                    CollisionManager.CollisionType(collidables[0], collidables[1], "AABB", true);
                else
                    CollisionManager.CollisionType(collidables[0], collidables[1], "SAT", false);
                    CollisionManager.CollisionType(collidables[0], collidables[2], "SAT", false);
                    CollisionManager.CollisionType(collidables[1], collidables[2], "SAT", false);
            
            }
        }


        /// <summary>
        /// Lets the game respond to player input. Unlike the Update method,
        /// this will only be called when the gameplay screen is active.
        /// </summary>
        public override void HandleInput(GameTime gameTime, InputState input)
        {
            if (input == null)
                throw new ArgumentNullException("input");

            // Look up inputs for the active player profile.
            int playerIndex = (int)ControllingPlayer.Value;

            KeyboardState keyboardState = input.CurrentKeyboardStates[playerIndex];
            PlayerIndex player;

            if (pauseAction.Evaluate(input, ControllingPlayer, out player))
            {
                ScreenManager.AddScreen(new PauseMenuScreen(), ControllingPlayer);
            }
        }


        /// <summary>
        /// Draws the gameplay screen.
        /// </summary>
        public override void Draw(GameTime gameTime)
        {
            // This game has a blue background. Why? Because!
            ScreenManager.GraphicsDevice.Clear(ClearOptions.Target,
                                               Color.DarkSlateBlue, 0, 0);

            // Our player and enemy are both actually just text strings.
            SpriteBatch spriteBatch = ScreenManager.SpriteBatch;

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend,
                null, null, null, null, camera.Transform);

            foreach (IEntity item in entities)
                item.Draw(spriteBatch);

            spriteBatch.End();

        }
    }
}
