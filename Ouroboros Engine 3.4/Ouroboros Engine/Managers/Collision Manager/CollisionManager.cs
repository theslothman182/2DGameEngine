using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using OuroborosEngine.Interfaces;
using OuroborosEngine.Managers.CollisionManager.Physics;


namespace OuroborosEngine.Managers.CollisionManager
{
    public class CollisionManager : ICollisionManager
    {

        //PhysicalResponse physicsResponse = new PhysicalResponse();
        //public Boolean isColliding = false;

        public CollisionManager()
        {

        }


        ///////////////////////////////////////  COLLISION HANDLING  /////////////////////////////////////


        // NOW STATIC

        /// <summary>METHOD: to decide which type of collision will occur</summary>
        /// <param name="item1">the first entity in the collision, usually the player</param>
        /// <param name="item2">the second entity in the collision</param>
        /// <param name="collisionType">a string with the type of collision</param>
        /// <param name="physics">a bool, to decide whether the collision should include physics behaviours or not</param>
        public static bool CollisionType(ICollidable item1, ICollidable item2, string collisionType, bool physics)
        {
            PhysicalResponse physicsResponse = new PhysicalResponse();
            Boolean isColliding = false;

            // IF: the collision type is set to AABB
            if (collisionType == "AABB")
            {
                // CREATE: an AABB collision object
                AABBCollision aabb = new AABBCollision();

                // IF: the collision will have physics behaviours
                if (physics == true)
                {
                    // AND IF: an AABB collsion is detected
                    if (aabb.Detect(item1, item2))
                    {
                        // RUN: the physics response for the objects
                        physicsResponse.Response(item1, item2, aabb.overlap);
                        isColliding = true;
                        return isColliding;
                    }
                    }
                else
                {
                    // OTHERWISE IF: an AABB collsion is detected
                    if (aabb.Detect(item1, item2))
                    {
                        // STOP: the entity from interpenetrating
                        item1.Position -= item1.Velocity;
                        isColliding = true;
                        return isColliding;
                    }
                    }
            }

            // IF: the collision type is set to circle collision
            if (collisionType == "Circle")
            {
                // CREATE: an Circle collision object
                CircleCollision circle = new CircleCollision();

                // IF: the collision will have physics behaviours:
                if (physics == true)
                {
                    // AND IF: an circle collsion is detected
                    if (circle.Detect(item1, item2))
                    {
                        // RUN: the physics response for the objects
                        physicsResponse.Response(item1, item2, circle.overlap);
                        isColliding = true;
                        return isColliding;
                    }
                }
                else
                {
                    // OTHERWISE IF:  an circle collsion is detected
                    if (circle.Detect(item1, item2))
                    {
                        // STOP: the entity from interpenetrating
                        item1.Position -= item1.Velocity;
                        isColliding = true;
                        return isColliding;
                    }
                }
            }
            

            // IF: the collision type is set to SAT
            if (collisionType == "SAT")
            {
                // IF: the collision will have physics behaviours:
                SATCollision satCollision = new SATCollision();
                // CHECK: for an SAT collision, if it occurs:
                if (physics == true)
                {
                    // CHECK: for an SAT collision, if it occurs:
                    if (satCollision.Detect(item1, item2, item1.Velocity))
                    {
                        // ADD: the MTV minus the velocity, to the current position
                        item1.Position += SATCollision.MinimumTranslationVector - item1.Velocity;
                        // RUN: the physics response for the objects
                        physicsResponse.Response(item1, item2, satCollision.overlap);
                        isColliding = true;
                        return isColliding;
                    }
                }
                else
                {
                    // OTHERWISE IF:  an SAT collsion is detected
                    if (satCollision.Detect(item1, item2, item1.Velocity))
                    {
                        // ADD: the MTV minus the velocity, to the current position
                        item1.Position += SATCollision.MinimumTranslationVector - item1.Velocity;
                        isColliding = true;
                        return isColliding;
                    }
                }
            }

            // IF: a wall collision occurs
            if (collisionType == "Wall")
            {
                // RUN: wall impusle behaviour
                physicsResponse.WallImpulse(item1, true, 0);
                physicsResponse.WallImpulse(item1, false, 1400);
                physicsResponse.WallImpulse(item2, true, 0);
                physicsResponse.WallImpulse(item2, false, 1400);
                isColliding = true;
                return isColliding;
            }

            if (item2 != null)
            {
                // DECELERATE: the second object
                item2.Decelerator();
            }
            isColliding = false;
            return isColliding;
        }


        ///////////////////////////////////////  COLLISION LIST  /////////////////////////////////////


        /// <summary>METHOD: takes in an entity list an converts its's members into collidables</summary>
        /// <param name="entities">the list of entities you wish to convert</param>
        /// <returns>the list of collidable requested</returns>
        public List<ICollidable> GetCollidableList(List<IEntity> entities)
        {
            // CREATE: a new list to hold the list of entities
            List<IEntity> entList = entities;
            // CREATE: a blank list of collidable objects
            List<ICollidable> collidables = new List<ICollidable>();

            // FOR: each entity in the list of entities
            foreach (IEntity item in entList)
            {
                // IF: that entity is also a collidable object
                if (item is ICollidable)
                    // ADD: it to the list of collidables
                    collidables.Add(item as ICollidable);
            }

            // RETURN: the list of collidable objects
            return collidables;
        }
    }
}
