using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using OuroborosEngine.Managers.SceneManager;

namespace OuroborosEngine.Managers.BehaviourManager.EStateMachine.States
{
    class EmptyState : State
    {
        ///////////////////////////////////////  CONSTRUCTOR  /////////////////////////////////////

        public EmptyState()
        {
            
        }


        ///////////////////////////////////////  UPDATE AND DRAW  /////////////////////////////////////


        /// <summary>METHOD: empty update</summary>
        public override void Update()
        {
        }

        /// <summary>METHOD: overloaded update for the use of the player states</summary>
        /// <param name="dt">the game loops time</param>
        /// <param name="content">grabs the content manager from the game scene</param>
        /// <param name="position">the positionof the the animation in the scene</param>
        public override void Update(GameTime dT, ContentManager content, Vector2 position)
        {

        }

        /// <summary>METHOD: empty draw</summary>
        /// <param name="spriteBatch">uses the Spritebatch.Draw() method</param>
        public override void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
