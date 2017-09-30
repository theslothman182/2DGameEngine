using System;
using Microsoft.Xna.Framework;
using OuroborosEngine.Interfaces;

namespace OuroborosEngine.Managers.CollisionManager
{
    class AABBCollision
    {
        public Vector2 overlap;

        public AABBCollision()
        {

        }

        /// <summary>METHOD: to detect an instance of AABB collision</summary>
        /// <param name="item1">the first item colliding</param>
        /// <param name="item2">the second item colliding</param>
        /// <returns>a bool that tells us whether a collision is occuring</returns>
        public bool Detect(ICollidable item1, ICollidable item2)
        {
            // CREATE: a float to store the distance between the two objects by their centre points on the x axis
            float distanceX = item2.CentrePoint.X - item1.CentrePoint.X;
            // CREATE: a float for each object to store the value of half their width
            float halfWidth1 = item1.Image.Width / 2; 
            float halfWidth2 = item2.Image.Width / 2;

            // CREATE: a float to store the distance between the two objects by their centre points on the y axis
            float distanceY = item2.CentrePoint.Y - item1.CentrePoint.Y;
            // CREATE: a float for each object to store the value of half their height
            float halfHeight1 = item1.Image.Height / 2; 
            float halfHeight2 = item2.Image.Height / 2;

            // CREATE: vectors to define the furthest most parts of the shapes, using thier half sizes
            Vector2 halfLength1 = new Vector2(halfWidth1, halfHeight1); 
            Vector2 halfLength2 = new Vector2(halfWidth2, halfHeight2);
            // CREATE: a vector that stores a new absolute vector for the distance between the 2 objects
            Vector2 locationComparison = new Vector2(Math.Abs(distanceX), Math.Abs(distanceY));
            // COMBINE: the two half lengths to define the closest length of the objects
            Vector2 halfLegthsTotal = halfLength1 + halfLength2;

            // IF: the distane between the 2 objects if shorter than their closest length, on either the x or y axis
            if ((locationComparison.X < halfLegthsTotal.X) && (locationComparison.Y < halfLegthsTotal.Y))
                // THEN: a collision occurs, return true
                return true;

            // IF: the location distance on the x axis is less than the half widths combined
            if (locationComparison.X < halfLegthsTotal.X)
                // THEN: set how much they are overlapping on the x axis
                overlap.X = halfLegthsTotal.X - locationComparison.X;
            // IF: the location distance on the y axis is less than the half heights combined
            if (locationComparison.Y < halfLegthsTotal.Y)
                // THEN: set how much they are overlapping on the y axis
                overlap.Y = halfLegthsTotal.Y - locationComparison.Y;

            // RETURN: false to break the method
            return false;
        }
    }
}
