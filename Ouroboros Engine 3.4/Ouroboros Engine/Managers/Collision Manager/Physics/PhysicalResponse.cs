using Microsoft.Xna.Framework;
using OuroborosEngine.Interfaces;

namespace OuroborosEngine.Managers.CollisionManager.Physics
{
    class PhysicalResponse
    {
        // CREATE: a vector to store the combined velocity
        private Vector2 combVelocity;
        // CREATE: 2 floats to store the closing velocity of objects
        private float closingVelocityA;
        private float closingVelocityB;
        // CREATE: 2 vectors to store the velocities so they can get applied to the entities
        private Vector2 newVelocityA;
        private Vector2 newVelocityB;
        // CREATE: a vector for the collision normal
        private Vector2 collisionNormal;

        public PhysicalResponse()
        {

        }

        /// <summary>METHOD: defining the response of physical object colliding</summary>
        /// <param name="item1">the first entity in the collision, usually the player</param>
        /// <param name="item2">the second entity in the collision</param>
        /// <param name="overlap">the amount the 2 shapes are overlapping</param>
        public void Response(ICollidable item1, ICollidable item2, Vector2 overlap)
        {
            // COMBINE: the velocity of the 2 objects
            combVelocity = new Vector2(item1.Velocity.X - item2.Velocity.X, item1.Velocity.Y - item2.Velocity.Y);
            // SET: the collision normal
            collisionNormal = Vector2.Normalize(combVelocity);

            // REMOVE: the interpenetration of both objects by applying it through forces
            item1.ApplyForce(0.0125f * overlap * collisionNormal);
            item2.ApplyForce(0.0125f * overlap * collisionNormal);

            // SET: the closing velocity of the 2 objects
            closingVelocityA = Vector2.Dot(item1.Velocity, collisionNormal);
            closingVelocityB = -(Vector2.Dot(item2.Velocity, collisionNormal));

            // STORE: the new velocity to be applied
            newVelocityA = (collisionNormal * closingVelocityB) - (collisionNormal * closingVelocityA);
            newVelocityB = (collisionNormal * closingVelocityA) - (collisionNormal * closingVelocityB);

            // APPLY: the impulse of the collision to both objects
            item1.ApplyImpulse(newVelocityA);
            item2.ApplyImpulse(newVelocityB);
        }


        /// <summary>METHOD: defines how entities collide with walls</summary>
        /// <param name="item">the entity colliding</param>
        /// <param name="wall">true is for left wall, false is for right</param>
        /// <param name="wallPosition">states the position of the wall on the x axis</param>
        public void WallImpulse(ICollidable item, bool wall, float wallPosition)
        {
            // IF: its the left wall
            if (wall == true)
            {
                wallPosition += item.Image.Width / 2;

                // SET: where the left wall is
                if (item.CentrePoint.X < wallPosition)
                {
                    // STOP: the entity from going through it
                    item.Position = new Vector2(wallPosition - item.Image.Width / 2, item.Position.Y);
                    // SET: the collision normal
                    collisionNormal = Vector2.Normalize(item.Velocity);

                    // SET: the closing velocity
                    closingVelocityA = Vector2.Dot(item.Velocity, collisionNormal);
                    // STORE: the new velocity to be applied
                    newVelocityA = -2 * (collisionNormal * closingVelocityA);
                    // INVERT: the velocity on the y axis
                    newVelocityA.Y = -newVelocityA.Y / 2;
                    // APPLY: the impulse of the collision to the entity
                    item.ApplyImpulse(newVelocityA);
                }
            }
            // ELSE: its the right wall
            else
            {
                // SET: where the right wall is
                if (item.CentrePoint.X > wallPosition)
                {
                    // STOP: the entity from going through it
                    item.Position = new Vector2(wallPosition - item.Image.Width / 2, item.Position.Y);
                    // SET: the collision normal
                    collisionNormal = Vector2.Normalize(item.Velocity);

                    // SET: the closing velocity
                    closingVelocityA = Vector2.Dot(item.Velocity, collisionNormal);
                    // STORE: the new velocity to be applied
                    newVelocityA = -2 * (collisionNormal * closingVelocityA);
                    // INVERT: the velocity on the y axis
                    newVelocityA.Y = -newVelocityA.Y / 2;
                    // APPLY: the impulse of the collision to the entity
                    item.ApplyImpulse(newVelocityA);
                }
            }
        }
    }
}
