using System;
using Microsoft.Xna.Framework.Input;
using OuroborosEngine.Managers.InputManager;

namespace OuroborosEngine.Interfaces
{
    public interface IInputManager
    {
        ///////////////////////////////////////  EVENTS  /////////////////////////////////////
        void GetInput(Keys[] getKeys);
        void GetKeyUp(Keys[] getKeys);
        void GetSpacebar(Keys[] getKeys);
        void GetMouseClick(MouseState getMouseState);

        ///////////////////////////////////////  UPDATE  /////////////////////////////////////
        void Update();

        ///////////////////////////////////////  ADD AND REMOVE LISTENER  /////////////////////////////////////
        void AddKeyboardListener(EventHandler<myEventArgs> handler);
        void AddMouseListener(EventHandler<myEventArgs> handler);
        void RemoveKeyboardListener(EventHandler<myEventArgs> handler);
        void RemoveMouseListener(EventHandler<myEventArgs> handler);
    }
}
