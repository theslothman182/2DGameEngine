using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using OuroborosEngine.Interfaces;
using OuroborosEngine.Managers.BehaviourManager.EStateMachine.States;
using WaxenV_1.Managers.BehaviourManager.WStateMachine.States;

namespace OuroborosEngine.Managers.BehaviourManager.EStateMachine
{
    public abstract class StateMachine : IStateMachine
    {
        ///////////////////////////////////////  VARIABLES  /////////////////////////////////////


        // CREATE: a dictionary to store states by their name
        protected Dictionary<string, IState> _stateDict = new Dictionary<string, IState>();

        // CREATE: a state that will hold the current state
        protected IState _current;


        ///////////////////////////////////////  GETTER  /////////////////////////////////////

        /// <summary>ACCESSOR: for other classes to get the current state</summary>
        public IState Current{ get { return _current; } }


        ///////////////////////////////////////  CONSTRUCTOR  /////////////////////////////////////


        public StateMachine()  //, GraphicsDevice gd)
        {
            // SET: the current state to be an empty state
            _current = new EmptyState();  //, gd);
        }


        ///////////////////////////////////////  HANDLE STATES  /////////////////////////////////////

        /// <summary>METHOD: to add states to the dictionary</summary>
        /// <param name="id">a unique ID name for the state</param>
        /// <param name="state">the state you want to match this id</param>
        public void Add(string id, IState state)
        {
            // ADD: the state to the dictionary, pairing it with an id
            _stateDict.Add(id, state);
        }

        /// <summary>METHOD: to remove states from the dictionary</summary>
        /// <param name="id">the unique ID name for the state you want to remove</param>
        public void Remove(string id)
        {
            // REMOVE: the state from the dictionary using its id
            _stateDict.Remove(id);
        }

        /// <summary>METHOD: to clear the dictionary of states and id's</summary>
        public void Clear()
        {
            // CLEAR: the dictionary
            _stateDict.Clear();
        }

        /// <summary>METHOD: to change the current states being used</summary>
        /// <param name="id">the unique ID name of the state you want to change to</param>
        public void Change(string id)
        {
            // CREATE: a new state, setting it to the state you want to change to
            IState next = _stateDict[id];
            // SET: the current state to the new state
            _current = next;
        }


        ///////////////////////////////////////  UPDATE AND DRAW  /////////////////////////////////////

        /// <summary>METHOD: that runs the update method of the current state being called</summary>
        public void Update()
        {

        }

        /// <summary>METHOD: draw the animation being played through current state</summary>
        /// <param name="spriteBatch">uses the Spritebatch.Draw() method</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            _current.Draw(spriteBatch);
        }
    }
}
