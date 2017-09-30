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
    class Ground : Entity
    {
        public Ground()
        {
            // INSTANTIATE: the list of points
            points = new List<Vector2>();
            // INSTANTIATE: the list of edges
            edges = new List<Vector2>();
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
            _pos.Y = position.Y;
            Points[0] = _pos;
            _pos.X = position.X + (image.Width);
            _pos.Y = position.Y;
            Points[1] = _pos;
            _pos.X = position.X + (Image.Width);
            _pos.Y = position.Y - Image.Height - 10;
            Points[2] = _pos;
            _pos.X = position.X;
            _pos.Y = position.Y - Image.Height - 10;
            Points[3] = _pos;
        }

        /// <summary>METHOD: updating the player position and points, as well as running the new behaviour from the current state in the state mahcine</summary>
        public override void Update()
        {
            // RUN: the method that updates the poistion of the points for SAT
            UpdatePoints();
        }
    }
}
