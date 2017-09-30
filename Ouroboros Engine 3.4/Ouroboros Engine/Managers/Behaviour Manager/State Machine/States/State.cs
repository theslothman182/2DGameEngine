using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using OuroborosEngine.Interfaces;
using OuroborosEngine.Managers.AnimationManager;
using OuroborosEngine.Managers.Sound_Manager;

namespace OuroborosEngine.Managers.BehaviourManager.EStateMachine.States
{
    abstract class State : IState
    {

        ///////////////////////////////////////  CONSTRUCTOR  /////////////////////////////////////

        public State()
        {

        }


        ///////////////////////////////////////  UPDATE AND DRAW  /////////////////////////////////////


        /// <summary>METHOD: top level update method, to be inherited by all states</summary>
        /// <param name="dt">the game loops time</param>
        /// <param name="content">grabs the content manager from the game scene</param>
        /// <param name="position">the positionof the the animation in the scene</param>
        public virtual void Update()
        {

        }

        /// <summary>METHOD: overloaded update for the use of the palyer states</summary>
        /// <param name="dt">the game loops time</param>
        /// <param name="content">grabs the content manager from the game scene</param>
        /// <param name="position">the positionof the the animation in the scene</param>
        public virtual void Update(GameTime dT, ContentManager content, Vector2 position)
        {

        }

        /// <summary>METHOD: top level draw method, to be inherited by all states</summary>
        /// <param name="spriteBatch">uses the Spritebatch.Draw() method</param>
        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }

        protected Boolean isMelted;

        public Boolean IsMelted { get { return isMelted; } set { isMelted = value; } }
    }
}
