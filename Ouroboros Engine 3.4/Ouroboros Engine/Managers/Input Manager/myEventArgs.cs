using System;
using Microsoft.Xna.Framework.Input;

namespace OuroborosEngine.Managers.InputManager
{
    public class myEventArgs : EventArgs
    {
        ///////////////////////////////////////  VARIABLES  /////////////////////////////////////


        // CREATE: an array of keys, to store the amount of keys pressed
        public Keys[] newKeys;

        public MouseState newMouseState;
        ///////////////////////////////////////  CONSTRUCTOR  /////////////////////////////////////


        public myEventArgs(Keys[] getKeys)
        {
            // SET: new keys to to the amount of keys that are being pressed
            newKeys = getKeys;
        }

        // event argument overloaded method for if mouse input would have worked
        public myEventArgs(MouseState getMouseState)
        {
            newMouseState = getMouseState;
        }

    }
}
