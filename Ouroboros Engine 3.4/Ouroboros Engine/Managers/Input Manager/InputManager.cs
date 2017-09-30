using System;
using Microsoft.Xna.Framework.Input;
using OuroborosEngine.Interfaces;

namespace OuroborosEngine.Managers.InputManager
{
    public class InputManager : IInputManager
    {
        ///////////////////////////////////////  DECLARATIONS  /////////////////////////////////////


        // DECLARE: an event using GetKeyboardInputDirection
        public event EventHandler<myEventArgs> GetKeyboardInputDirection;
        public event EventHandler<myEventArgs> GetMouseClickLocation;

        // DECLARE: the input devices
        public enum InputDevice
        {
            Keyboard,
            Mouse
        }


        ///////////////////////////////////////  EVENTS  /////////////////////////////////////


        /// <summary>METHOD: an event to be called when a key is pressed</summary>
        /// <param name="getKeys">contains the number of keys that are pressed at one time</param>
        public virtual void GetInput(Keys[] getKeys)
        {
            // CREATE: a new argument
            myEventArgs args = new myEventArgs(getKeys);
            // GIVE: the event handler this argument
            GetKeyboardInputDirection(this, args);
        }

        /// <summary>METHOD: an event to be called when all keys are up</summary>
        /// <param name="getKeys">contains the number of keys that are pressed at one time</param>
        public virtual void GetKeyUp(Keys[] getKeys)
        {
            // CREATE: a new argument
            myEventArgs args = new myEventArgs(getKeys);
            // GIVE: the event handler this argument
            GetKeyboardInputDirection(this, args);
        }

        /// <summary>METHOD: an event to be called whenever the space bar is pressed</summary>
        /// <param name="getKeys">contains the number of keys that are pressed at one time</param>
        public virtual void GetSpacebar(Keys[] getKeys)
        {
            // CREATE: a new argument
            myEventArgs args = new myEventArgs(getKeys);
            // GIVE: the event handler this argument
            GetKeyboardInputDirection(this, args);
        }

        // ADDED for if mouse input would have worked
        public virtual void GetMouseClick(MouseState getMouseState)
        {
            myEventArgs args = new myEventArgs(getMouseState);
            GetMouseClickLocation(this, args);
        }


        ///////////////////////////////////////  UPDATE  /////////////////////////////////////


        /// <summary>METHOD: updates the events based on the input </summary>
        public void Update()
        {
            // CREATE: an object to get the keyboards state
            KeyboardState keyboardState = Keyboard.GetState();
            // CREATE: an array of keys, setting it to all the keys pressed at one time
            Keys[] getKeys = keyboardState.GetPressedKeys();

            MouseState mouseState = Mouse.GetState();

            //  IF: there is a key being pressed
            if (getKeys.Length > 0)
            {
                // THEN: call this event
                GetInput(getKeys);
            }
            // IF: there is at least on key being pressed
            if (getKeys.Length != 0)
            {
                // IF: this key is the space bar
                if (getKeys[0] == Keys.Space)
                {
                    // THEN: call this event
                    GetSpacebar(getKeys);
                }
            }
            // IF: there are not any keys being pressed
            if (getKeys.Length == 0)
            {
                // THEN: call this event
                GetKeyUp(getKeys);
            }

            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                GetMouseClick(mouseState);
            }
        }


        ///////////////////////////////////////  ADD AND REMOVE LISTENER  /////////////////////////////////////


        /// <summary>METHOD: add a listener to the event handler</summary>
        /// <param name="handler">the listener you want to add</param>
        public void AddKeyboardListener(EventHandler<myEventArgs> handler)
        {
            // ADD: a listener to the GetKeyboardInputDirection event
            GetKeyboardInputDirection += handler;
        }

        public void AddMouseListener(EventHandler<myEventArgs> handler)
        {
            GetMouseClickLocation += handler;
        }

        /// <summary>METHOD: remove a listener from the event handler</summary>
        /// <param name="handler">the listener you want to remove</param>
        public void RemoveKeyboardListener(EventHandler<myEventArgs> handler)
        {
            // REMOVE: a listener to the GetKeyboardInputDirection event
            GetKeyboardInputDirection -= handler;
        }

        public void RemoveMouseListener(EventHandler<myEventArgs> handler)
        {
            GetMouseClickLocation -= handler;
        }
    }
}
