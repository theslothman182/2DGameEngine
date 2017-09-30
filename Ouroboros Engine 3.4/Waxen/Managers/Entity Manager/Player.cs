using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using OuroborosEngine.Managers.EntityManager;
using OuroborosEngine.Managers.Content_Manager;
using OuroborosEngine.Managers.InputManager;
using OuroborosEngine.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using WaxenV_1.Managers.BehaviourManager.WStateMachine;
using WaxenV_1.Managers.BehaviourManager.WStateMachine.States;

namespace WaxenV_1.Managers.Entity_Manager
{
    class Player : Entity
    {
        //MyContentManager content;

        // DECLARE: a state machine for the class
        PlayerStateMachine stateMachine;

        List<ICollidable> waxBalls;

        public Player()
        {
            // INSTANTIATE: the list of points
            points = new List<Vector2>();
            // INSTANTIATE: the list of edges
            edges = new List<Vector2>();


            mMass = 2f;
            damping = 0.125f;
            restitution = 1f;

            ConvertMass();
        }

        /// <summary>METHOD: a placeholder as the statemachine cannot be directly passed to the player because of content issues</summary>
        /// <param name="machine">a statemachine to set Players statemachine</param>
        public override void SetStateMachine(PlayerStateMachine machine)
        {
            // SET: players state machine to the statemachine requested
            stateMachine = machine;
        }

        /// <summary>METHOD: to declare the positions of points for all player entities</summary>
        public override void CreatePoints()
        {
            // DECLARE: a point for each corner of the player image
            Points.Add(new Vector2(Position.X, Position.Y));
            Points.Add(new Vector2(Position.X + (Image.Width), Position.Y));
            Points.Add(new Vector2(Position.X + (Image.Width), (Position.Y - Image.Height)));
            Points.Add(new Vector2(Position.X, (Position.Y - Image.Height)));

            //centrePoint = new Vector2(position.X + 15, position.Y - 24); problems with setting because of content issues, Image isn't actually being set to the current animation
        }

        /// <summary>METHOD: to update the positions of points for all player entities</summary>
        public override void UpdatePoints()
        {
            // DECLARE: the new position for each corner of the player image
            Vector2 _pos;// = position;
            _pos.X = position.X;
            _pos.Y = position.Y + 20;
            Points[0] = _pos;
            _pos.X = position.X + (image.Width);
            _pos.Y = position.Y + 20;
            Points[1] = _pos;
            _pos.X = position.X + (Image.Width);
            _pos.Y = position.Y - Image.Height + 20;
            Points[2] = _pos;
            _pos.X = position.X;
            _pos.Y = position.Y - Image.Height + 20;
            Points[3] = _pos;
        }

        /// <summary>METHOD: handles the event getting input</summary>
        /// <param name="source">the object that is listening</param>
        /// <param name="args">sets the keys being pressed</param>
        public override void GetInput(Object source, myEventArgs args)
        {
            // IF: a key is being pressed
            if (args.newKeys.Length != 0)
            {
                // FOR: each key that is being pressed
                foreach (Keys key in args.newKeys)
                {
                    //Declare the different keys that will to call the GetKeyboardInputDirection event
                    if (key == Keys.W)
                    {
                        // THEN: get the input direction to move up
                        ApplyForce(Input.GetKeyboardInputDirection(0.25f));
                        // CHANGE: the state machine to show the behaviour of walking up
                        stateMachine.Change("Up");
                    }
                    // CHECK: if the key is the left arrow or A, if it is:
                    else if (key == Keys.A)
                    {
                        // THEN: get the input direction to move left
                        ApplyForce(Input.GetKeyboardInputDirection(0.25f));
                        // CHANGE: the state machine to show the behaviour of walking left
                        stateMachine.Change("Left");
                    }
                    else if (key == Keys.S)
                    {
                        // THEN: get the input direction to move down
                        ApplyForce(Input.GetKeyboardInputDirection(0.25f));
                        // CHANGE: the state machine to show the behaviour of walking down
                        stateMachine.Change("Down");
                    }
                    // CHECK: if the key is the right arrow or D, if it is:
                    else if (key == Keys.D)
                    {
                        // THEN: get the input direction to move right
                        ApplyForce(Input.GetKeyboardInputDirection(0.25f));
                        // CHANGE: the state machine to show the behaviour of walking right
                        stateMachine.Change("Right");
                    }
                    else
                    {
                        // RESET: the velocity for now
                        Decelerator();
                    }  
                    
                }
            }
        }

        /// <summary>METHOD: handles the event when no keys are being pressed</summary>
        /// <param name="source">the object that is listening</param>
        /// <param name="args">sets the keys being pressed</param>
        public override void GetKeyUp(Object source, myEventArgs args)
        {
            // IF: there are no keys being pressed
            if (args.newKeys.Length == 0)
            {
                // RESET: the velocity for now
                Decelerator();
            }
        }

        /// <summary>METHOD: updating the player position and points, as well as running the new behaviour from the current state in the state machine</summary>
        /// <param name="dt">the current game loop time</param>
        /// <param name="content">grabs the content manager from the currect scene</param>
        public override void Update(GameTime dt, ContentManager content)
        {
            // RUN: the method that updates the poistion of the points for SAT
            UpdatePoints();
            // RUN: the behaviour from the current state in the state machine
            stateMachine.Update(dt, content, position);
            UpdatePhysics();
        }

        /// <summary>METHOD: override Entity draw method, so we can draw the animation instead</summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            // RUN: the draw method from the current state through the state machine
            stateMachine.Draw(spriteBatch);
        }

    }
}
