using System;
using Microsoft.Xna.Framework;
using OuroborosEngine.Interfaces;

namespace OuroborosEngine.Managers.CollisionManager
{
    class CircleCollision
    {
        public Vector2 overlap;

        public CircleCollision()
        {

        }

        /// <summary>METHOD: to detect an instance of circle collision</summary>
        /// <param name="item1">the first item colliding</param>
        /// <param name="item2">the second item colliding</param>
        /// <returns>a bool that tells us whether a collision is occuring</returns>
        public bool Detect(ICollidable item1, ICollidable item2)
        {
            // CREATE: a vector to store the centre points of each shape
            Vector2 firstCentre = item1.CentrePoint; 
            Vector2 secondCentre = item2.CentrePoint; 

            // FIND: the distance of the two by comparing their centre points
            Vector2 distance = firstCentre - secondCentre; 
            // FIND the length of the hypotenuse, using pythagorus 
            double hypotenuseLength = Math.Sqrt((distance.X * distance.X) + (distance.Y * distance.Y));

            
            // FIND: the applied radius by adding the radius to the centre point for each circle
            Vector2 firstRadiusApplied = new Vector2(item1.CentrePoint.X + item1.Radius, item1.CentrePoint.Y + item1.Radius);
            Vector2 secondRadiusApplied = new Vector2(item2.CentrePoint.X + item2.Radius, item2.CentrePoint.Y + item2.Radius);

            // IF: the position of second radius applied is bigger than the position of the first radius applied, on the x or y axis
            if (secondRadiusApplied.X > firstRadiusApplied.X || secondRadiusApplied.Y > firstRadiusApplied.Y)
                // THEN: the overlap is the distance minus ( the second radius applied minus the first radius applied)
                overlap = distance - (secondRadiusApplied - firstRadiusApplied);
            // IF: the position of first radius applied is bigger than the position of the second radius applied, on the x or y axis
            if (secondRadiusApplied.X < firstRadiusApplied.X || secondRadiusApplied.Y < firstRadiusApplied.Y)
                // THEN: the overlap is the distance minus ( the first radius applied minus the second radius applied)
                overlap = distance - (firstRadiusApplied - secondRadiusApplied);


            // IF: the length of the hypotenuse is less than the two radius combined
            if (hypotenuseLength <= item1.Radius + item2.Radius)
            {
                // THEN: a collision occurs, return true
                return true;
            }

            // RETURN: false to break the method
            return false;
        }
    }
}
