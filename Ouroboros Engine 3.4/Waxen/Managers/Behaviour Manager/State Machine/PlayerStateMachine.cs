using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using OuroborosEngine.Interfaces;
using OuroborosEngine.Managers.BehaviourManager.EStateMachine.States;
using WaxenV_1.Managers.BehaviourManager.WStateMachine.States;
using OuroborosEngine.Managers.BehaviourManager.EStateMachine;

namespace WaxenV_1.Managers.BehaviourManager.WStateMachine
{
    public class PlayerStateMachine : StateMachine
    {

        public PlayerStateMachine(ContentManager content)
        {
            _current = new EmptyState();

            Add("Right", new WalkRight(content));
            Add("Left", new WalkLeft(content));
            Add("Down", new WalkDown(content));
            Add("Up", new WalkUp(content));
        }

        /// <summary>METHOD: that runs the update method of the current state being called</summary>
        /// <param name="dt">the game loops time</param>
        /// <param name="content">grabs the content manager from the game scene</param>
        /// <param name="position">a position to be handed to the the animation of that state</param>
        public void Update(GameTime dt, ContentManager content, Vector2 position)
        {
            // RUN: the current states update method
                _current.Update(dt, content, position);
        }
    }
}
