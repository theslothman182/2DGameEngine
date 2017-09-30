using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using OuroborosEngine.Managers.EntityManager;
using OuroborosEngine.Managers.Content_Manager;
using OuroborosEngine.Managers.InputManager;
using Microsoft.Xna.Framework.Graphics;

namespace WaxenV_1.Managers.Entity_Manager
{
    class TestBox : Entity
    {
        //MyContentManager content;

        public TestBox()
        {
            // INSTANTIATE: the list of points
            points = new List<Vector2>();
            // INSTANTIATE: the list of edges
            edges = new List<Vector2>();

            mMass = 1.5f;
            damping = 0.125f;
            restitution = 1.5f;
            gravity = Vector2.Zero;
            ConvertMass();
        }
        
        /// <summary>METHOD: to declare the positions of points for all test box entities</summary>
        public override void CreatePoints()
        {
            // DECLARE: a point for each corner of the player image
            Points.Add(new Vector2(Position.X, Position.Y));
            Points.Add(new Vector2(Position.X + (Image.Width), Position.Y));
            Points.Add(new Vector2(Position.X + (Image.Width), (Position.Y - Image.Height)));
            Points.Add(new Vector2(Position.X, (Position.Y - Image.Height)));
        }

        /// <summary>METHOD: to update the positions of points for all player entities</summary>
        public override void UpdatePoints()
        {
            // DECLARE: the new position for each corner of the player image
            Vector2 _pos;
            _pos.X = position.X;
            _pos.Y = position.Y - 9;
            Points[0] = _pos;
            _pos.X = position.X + (image.Width);
            _pos.Y = position.Y - 9;
            Points[1] = _pos;
            _pos.X = position.X + (Image.Width);
            _pos.Y = position.Y - Image.Height - 9;
            Points[2] = _pos;
            _pos.X = position.X;
            _pos.Y = position.Y - Image.Height - 9;
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
                    // CHECK: if the key is the up arrow or W, if it is:
                    if ((key == Keys.Up) || (key == Keys.W))
                    {
                        // THEN: get the input direction to move up
                        ApplyForce(Input.GetKeyboardInputDirection());
                    }
                    // CHECK: if the key is the left arrow or A, if it is:
                    else if ((key == Keys.Left) || (key == Keys.A))
                    {
                        // THEN: get the input direction to move left
                        ApplyForce(Input.GetKeyboardInputDirection());
                    }
                    // CHECK: if the key is the down arrow or S, if it is:
                    else if ((key == Keys.Down) || (key == Keys.S))
                    {
                        // THEN: get the input direction to move down
                        ApplyForce(Input.GetKeyboardInputDirection());
                    }
                    // CHECK: if the key is the right arrow or D, if it is:
                    else if ((key == Keys.Right) || (key == Keys.D))
                    {
                        // THEN: get the input direction to move right
                        ApplyForce(Input.GetKeyboardInputDirection());
                    }
                    else
                    {
                        // RESET: the velocity for now
                        velocity = Vector2.Zero;
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
            if (args.newKeys.Length == 0)//if none of the keys are pressed it slowly moves the player backwards
            {
                // RESET: the velocity for now
                Decelerator();
            }
        }

        /// <summary>METHOD: updating the player position and points, as well as running the new behaviour from the current state in the state mahcine</summary>
        public override void Update()
        {
            // RUN: the method that updates the poistion of the points for SAT
            UpdatePoints();
            // CHANGE: the position based on the velocity
            //position += velocity; 
            UpdatePhysics();
        }
    }
}