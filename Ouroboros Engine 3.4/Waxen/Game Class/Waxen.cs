using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using OuroborosEngine.Interfaces;
using OuroborosEngine.Managers.SceneManager;
using OuroborosEngine.Managers.EntityManager;
using OuroborosEngine.Managers.SceneManager.Camera;
using WaxenV_1.Managers.SceneManager.Screens;
using WaxenV_1.Managers.Entity_Manager;
//using OuroborosEngine.Managers.BehaviourManager.StateMachine;


namespace WaxenV_1.Game_Class
{
    public class Waxen : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;

        ScreenManager screenManager;
        ScreenFactory screenFactory;
        EntityManager entityManager;

        public static int screenHeight = 0;
        public static int screenWidth = 0;

        /// <summary>
        /// 
        /// </summary>
        public Waxen()
        {
            Content.RootDirectory = "Content";

            this.IsMouseVisible = true;

            graphics = new GraphicsDeviceManager(this);
            TargetElapsedTime = TimeSpan.FromTicks(333333);

            graphics.PreferredBackBufferHeight = 800;
            graphics.PreferredBackBufferWidth = 1300;

            //Create the screen factor and add it to the Services
            screenFactory = new ScreenFactory();
            Services.AddService(typeof(IScreenFactory), screenFactory);

            //Create the screen manager component.
            screenManager = new ScreenManager(this);
            Components.Add(screenManager);

            AddInitialScreens();

            entityManager = new EntityManager();
        }

        /// <summary>METHOD: requests an entity of type player from the entity manager</summary>
        /// <param name="entity">an empty object to take the entity request</param>
        /// <param name="posx">the position on the entity on the x axis</param>
        /// <param name="posy">the position on the entity on the y axis</param>
        /// <param name="nick">the unique ID name of the entity</param>
        /// <returns>the entity requested</returns>
        public IEntity playerRequest(IEntity entity, float posx, float posy ,string nick)
        {
            entity = entityManager.AddEntity<Player>(posx,posy, nick);
            return entity;
        }

        /// <summary>METHOD: requests an entity of type testBox from the entity manager</summary>
        /// <param name="entity">an empty object to take the entity request</param>
        /// <param name="posx">the position on the entity on the x axis</param>
        /// <param name="posy">the position on the entity on the y axis</param>
        /// <param name="nick">the unique ID name of the entity</param>
        /// <returns>the entity requested</returns>
        public IEntity testBoxRequest(IEntity entity, float posx, float posy, string nick)
        {
            entity = entityManager.AddEntity<TestBox>(posx, posy, nick);
            return entity;
        }

        /// <summary>METHOD: requests an entity of type testBox from the entity manager</summary>
        /// <param name="entity">an empty object to take the entity request</param>
        /// <param name="posx">the position on the entity on the x axis</param>
        /// <param name="posy">the position on the entity on the y axis</param>
        /// <param name="nick">the unique ID name of the entity</param>
        /// <returns>the entity requested</returns>
        public IEntity groundRequest(IEntity entity, float posx, float posy, string nick)
        {
            entity = entityManager.AddEntity<Ground>(posx, posy, nick);
            return entity;
        }

        private void AddInitialScreens()
        {
            //Activate the first screens.
            screenManager.AddScreen(new BackgroundScreen(), null);

            screenManager.AddScreen(new MainMenuScreen(), null);
        }

        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.Black);
            
            // The real drawing happens inside the screen manager component
            base.Draw(gameTime);
        }
    }
}
