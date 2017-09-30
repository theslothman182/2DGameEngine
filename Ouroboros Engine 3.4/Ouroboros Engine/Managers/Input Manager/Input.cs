using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using OuroborosEngine.Managers.SceneManager;


namespace OuroborosEngine.Managers.InputManager
{
    public class Input
    {
        ///////////////////////////////////////  CONSTRUCTOR  /////////////////////////////////////
        MouseState mouseState;
        MouseState lastMouseState;
        Vector2 location;

        public Input()
        {

        }


        ///////////////////////////////////////  INPUT MOVEMENT  /////////////////////////////////////


        /// <summary>METHOD: a defualt method without parameters, reading the state of the keyboard, giving a vector direction accordingly, with a magnitude of 15</summary>
        /// <returns>the vector which giving magnitude of 15 in a direction to the players direction</returns>
        public static Vector2 GetKeyboardInputDirection()
        {
            // CREATE: a vector to store the direction, giving it a magnitude of 15, and direction from WASD or Up,Down,Left,Right arrow input;
            Vector2 direction = GetKeyboardInputDirection(3);

            // RETURN: the vector holding the default magnitude and input direction
            return direction;
        }

        /// <summary>METHOD: reads the state of the keyboard, giving a vector direction accordingly</summary>
        /// <param name="size">the magnitude for the vector to be increase by</param>
        /// <returns>the vector which giving magnitude and direction to the players direction</returns>
        public static Vector2 GetKeyboardInputDirection(float size)
        {
            // CREATE: a vector to store the direction, and initialise it
            Vector2 direction = Vector2.Zero;

            // CREATE: an object to get the keyboards state
            KeyboardState keyboardState = Keyboard.GetState();

            // IF: the W or UP keys are pressed
            if ((keyboardState.IsKeyDown(Keys.W)) || (keyboardState.IsKeyDown(Keys.Up)))
            {
                // THEN: then increase the vectors magnitude going UP
                direction.Y -= size; // move up
            }

            // IF: the S or DOWN keys are pressed
            if ((keyboardState.IsKeyDown(Keys.S)) || (keyboardState.IsKeyDown(Keys.Down)))
            {
                // THEN: then increase the vectors magnitude going DOWN
                direction.Y += size; // move down
            }

            // IF: the A or LEFT keys are pressed
            if ((keyboardState.IsKeyDown(Keys.A)) || (keyboardState.IsKeyDown(Keys.Left)))
            {
                // THEN: then increase the vectors magnitude going LEFT
                direction.X -= size; // move left
            }

            // IF: the D or RIGHT keys are pressed
            if ((keyboardState.IsKeyDown(Keys.D)) || (keyboardState.IsKeyDown(Keys.Right)))
            {
                // THEN: then increase the vectors magnitude going RIGHT
                direction.X += size; // move right
            }

            // RETURN: the vector holding the magnitude and direction
            return direction;
        }

        // ATTEMPT at getting mouse input to work
        public static Vector2 GetMouseClickLocation()
        {
            Vector2 location = Vector2.Zero; ;// = new Vector2(mouseState.X, mouseState.Y);
            MouseState currentmouseState = Mouse.GetState();
            
            if (currentmouseState.LeftButton == ButtonState.Pressed)
            {
                location.X = currentmouseState.Position.X;
                location.Y = currentmouseState.Position.Y;
                Console.WriteLine("Pressed");
            }

            return location;
        }

    }
}
