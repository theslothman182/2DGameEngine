using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using OuroborosEngine.Interfaces;
using OuroborosEngine.Managers.AnimationManager;
using OuroborosEngine.Managers.Sound_Manager;
using OuroborosEngine.Managers.BehaviourManager.EStateMachine.States;

namespace WaxenV_1.Managers.BehaviourManager.WStateMachine.States
{
    abstract class PlayerState : State
    {
        ///////////////////////////////////////  VARIABLES  /////////////////////////////////////

        // CREATE: an animation manager
        protected Anim animMgr;
        // CREATE: a sound manager
        protected SoundManager soundmanager;


        ///////////////////////////////////////  CONSTRUCTOR  /////////////////////////////////////

        public PlayerState()
        {

        }

        public PlayerState(ContentManager content)//, GraphicsDevice gd)
        {
            // INSTANTIATE: the managers
            animMgr = new Anim();//  content);//, gd);
            soundmanager = new SoundManager(content);
        }


        ///////////////////////////////////////  UPDATE AND DRAW  /////////////////////////////////////


        /// <summary>METHOD: top level update method, to be inherited by all states</summary>
        /// <param name="dt">the game loops time</param>
        /// <param name="content">grabs the content manager from the game scene</param>
        /// <param name="position">the positionof the the animation in the scene</param>
        public override void Update(GameTime dt, ContentManager content, Vector2 position)
        {

        }

        /// <summary>METHOD: top level draw method, to be inherited by all states</summary>
        /// <param name="spriteBatch">uses the Spritebatch.Draw() method</param>
        public override void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
