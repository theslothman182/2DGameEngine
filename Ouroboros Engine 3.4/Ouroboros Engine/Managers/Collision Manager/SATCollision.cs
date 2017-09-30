using System;
using Microsoft.Xna.Framework;
using OuroborosEngine.Interfaces;

namespace OuroborosEngine.Managers.CollisionManager
{
    class SATCollision
    {
        // DECLARE: a vector to to store the MTV
        public static Vector2 MinimumTranslationVector = new Vector2(0, 0);

        public Vector2 overlap;

        public SATCollision()
        {

        }

        /// <summary>METHOD: to detect an instance of AABB collision</summary>
        /// <param name="item1">the first item colliding</param>
        /// <param name="item2">the second item colliding</param>
        /// <param name="velocity">the velocity of the player colliding</param>
        /// <returns>a bool that tells us whether a collision is occuring</returns>
        public bool Detect(ICollidable entity1, ICollidable entity2, Vector2 velocity)
        {
            // CREATE: a bool to check if the entities will ever collide
            bool WillIntersect = true;
            // CREATE: a bool to check if the entities are colliding
            bool Intersect = true; 

            // STORE: the number of edges for each shape
            int edgeCount1 = entity1.Edges.Count;
            int edgeCount2 = entity2.Edges.Count;

            // CREATE: a vector to store the current edge
            Vector2 thisEdge;

            // SET: a minimum interval distance to be infinity
            float minIntervalDistance = float.PositiveInfinity;
            // CREATE: a translation axis
            Vector2 translationAxis = Vector2.Zero;

            // FOR: every edge of both shapes
            for (int edgeIndex = 0; edgeIndex < edgeCount1 + edgeCount2; edgeIndex++)
            {
                // IF: the edge index is less than the number of edges for the first shape
                if (edgeIndex < edgeCount1)
                {
                    // SET: the current edge to be this edge
                    thisEdge = entity1.Edges[edgeIndex];
                }
                else
                {
                    // OTHERWISE: set the current edge to be an edge on the second shape
                    thisEdge = entity2.Edges[edgeIndex - edgeCount1];
                }

                // CREATE: an axes the shapes will be drawn on, normalize it
                Vector2 axis = new Vector2(-thisEdge.Y, thisEdge.X);
                axis.Normalize();

                // DEFINE, some minimum and maximum points for the projection
                float min1 = 0;
                float min2 = 0;
                float max1 = 0;
                float max2 = 0;

                // PROJECT: the first shape onto the axis
                Projection(axis, entity1, ref min1, ref max1);
                // PROJECT: the second shape onto the axis
                Projection(axis, entity2, ref min2, ref max2);

                // IF: the interval distance is bigger than zero
                if (IntervalDistance(min1, max1, min2, max2) > 0)
                {
                    // THEN: they are not intersecting
                    Intersect = false;
                }

                //int speedOffset = 3;
                // CREATE: a velocity projection using the dot product of the axis and the current velocity
                float velocityProjection = Vector2.Dot(axis, velocity);    // + speedOffset;

                // IF: the velocity project is less than zero
                if (velocityProjection < 0)
                {
                    // THEN: the minimum will be set
                    min1 += velocityProjection;
                }
                else
                {
                    // ELSE: the maximum will be set
                    max1 += velocityProjection;
                }

                // CREATE a new interval distance, setting it with the new min/max
                float intervalDistance = IntervalDistance(min1, max1, min2, max2);

                // IF: the new interval distance is more than zero
                if (intervalDistance > 0)
                {
                    // THEN: they will not collide
                    WillIntersect = false;
                }

                // RESET: the new interval distance to an absolute float, so it can occur on all sides
                intervalDistance = Math.Abs(intervalDistance);
                // IF: the new interval distance is less than the minimum interval distance
                if (intervalDistance < minIntervalDistance)
                {
                    // SET: the minimum to eqaul the new interval distance
                    minIntervalDistance = intervalDistance;
                    // AND: set the translation axis to be the normal axis
                    translationAxis = axis;

                    // CREATE: a vector to store the distance of the two shapes, comparing their centre points
                    Vector2 distance = entity1.CentrePoint - entity2.CentrePoint;

                    // IF: the distance on the x axis, or y axis is shorted than zero
                    if (distance.X < 0 || distance.Y < 0)
                    {
                        // THEN: the overlap is equal to the inverted distance
                        overlap = -distance;
                    }

                    // IF: the dot product of the distance and the translation axis is less than 0
                    if (Vector2.Dot(distance, translationAxis) < 0)
                    {
                        // INVERT: the translation axis
                        translationAxis = -translationAxis;
                    }
                }
            }

            // IF: the shapes are going to intersect
            if (WillIntersect)
            {
                // THEN: set the MTV to equal the translation axis multiplied by the minimum interval distance
                MinimumTranslationVector = translationAxis * minIntervalDistance;
                // ADD: the current velocity to the MTV, so it can still move along the shape
                MinimumTranslationVector += velocity;
            }
            // IF: the shapes will intersect or are intersecting
            if (WillIntersect || Intersect)
            {
                
                // THEN: a collision is going to happen
                return true;
            }

            // RESET: the MTV
            MinimumTranslationVector.X = 0;
            MinimumTranslationVector.Y = 0;

            // RETURN: false to break the method
            return false; 
        }

        /// <summary>
        /// METHOD: to handle the projection of the entities onto an axis
        /// </summary>
        /// <param name="axis">the axis they are to be projected onto</param>
        /// <param name="myEnt">the entity projected</param>
        /// <param name="min">the minimum distance</param>
        /// <param name="max">the maximum distance</param>
        public void Projection(Vector2 axis, ICollidable myEnt, ref float min, ref float max)
        {
            // To project a point on an axis use the dot product
            // CREATE: a float to create a distance using the dot product of the axis and the first point
            float distance = Vector2.Dot(axis, myEnt.Points[0]);
            // SET: both min and max to be equal to this point
            min = distance;
            max = distance;

            // FOR: every point of the shape
            for (int i = 0; i < myEnt.Points.Count; i++)
            {
                // RESET: the distance using the new point
                distance = Vector2.Dot(myEnt.Points[i], axis);
                // IF: the distance is less than the min
                if (distance < min)
                {
                    // RESET: the minimum to be the new distance
                    min = distance;
                }
                else
                {
                    // IF: the distance is more than the max
                    if (distance > max)
                    {
                        // RESET: the maximum to be the new distance
                        max = distance;
                    }
                }
            }
        }


        /// <summary>METHOD: to measure the interval distance of the two shapes</summary>
        /// <param name="minA">the minimum of the first shape</param>
        /// <param name="maxA">the maximum of the first shape</param>
        /// <param name="minB">the minimum of the second shape</param>
        /// <param name="maxB">the maximum of the first shape</param>
        /// <returns></returns>
        public float IntervalDistance(float minA, float maxA, float minB, float maxB)
        {
            // IF: the first shapes minimum is less than the second shapes minimum
            if (minA < minB)
            {
                // THEN: subtract the first shapes maximum from the second shapes minimum
                return minB - maxA;
            }
            else
            {
                // OTHERWISE: subtract the second shapes maximum from the first shapes minimum
                return minA - maxB;
            }

        }
    }
}
