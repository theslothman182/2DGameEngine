using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using OuroborosEngine.Interfaces;
using OuroborosEngine.Managers.InputManager;
using WaxenV_1.Managers.BehaviourManager.WStateMachine;
using WaxenV_1.Managers.Entity_Manager;

namespace OuroborosEngine.Managers.EntityManager
{
    public abstract class Entity : IEntity, ICollidable
    {
        ///////////////////////////////////////  VARIABLES  /////////////////////////////////////

        // IEntity
        // CREATE: a string to hold the unique ID name
        protected string idName;
        // CREATE: an int to hold the unique ID number
        protected int idNumber;

        // CREATE: a Texture2D to hold the image texture
        protected Texture2D image;
        // CREATE: a Vector2 to hold the position of the entity
        protected Vector2 position;
        // CREATE: a Vector2 to hold the velocity for the entity
        protected Vector2 velocity;


        // ICollidable
        // CREATE: a float to hold the radius of the entity
        protected float radius;
        // CREATE: a Vector2 to hold the centre point of the entity
        protected Vector2 centrePoint;

        // CREATE: a list to hold points that will represent the corners of shapes
        protected List<Vector2> points;
        // CREATE: a list to hold edges that will represent the sides of shapes
        protected List<Vector2> edges;

        // CREATE: a vector to apply acceleration
        protected Vector2 acceleration;
        // CREATE: a float to represent the mass of an object
        protected float mMass;
        protected float inverseMass;

        // CREATE: a float to define the restitution of an object
        protected float restitution;
        // CREATE: a float to apply damping effect on an object
        protected float damping;

        // DEFINE: gravity in the scene
        protected Vector2 gravity = new Vector2(0, 0);// -3);
        // CREATE: an boolean to check if the object is touching the ground
        protected Boolean isGround = false;


        ///////////////////////////////////////  GETTERS AND SETTERS  /////////////////////////////////////


        // IEntity
        /// <summary>ACCESSOR: for other classes to get the unique ID name</summary>
        public string IdName { get { return idName; } }

        /// <summary>ACCESSOR: for other classes to get the unique ID number</summary>
        public int IdNumber { get { return idNumber; } }

        /// <summary>ACCESSOR: for other classes to get and/or set the value of Image</summary>
        public Texture2D Image { get { return image; } set { image = value; } }

        /// <summary>ACCESSOR: for other classes to get and/or set the value of position</summary>
        public Vector2 Position { get { return position; } set { position = value; } }

        /// <summary>ACCESSOR: for other classes to get and/or set the value of Velocity</summary>
        public Vector2 Velocity { get { return velocity; } set { velocity = value; } }


        //ICollidable
        /// <summary>ACCESSOR: for other classes to get and/or the centre point</summary>
        public Vector2 CentrePoint { get { return centrePoint; } set { centrePoint = value; } }

        /// <summary>ACCESSOR: for other classes to get and/or the radius of a circle</summary>
        public float Radius { get { return radius; } set { radius = value; } }


        /// <summary>ACCESSOR: for other classes to get and/or the list of points for the shape</summary>
        public List<Vector2> Points { get { return points; } set { points = value; } }

        /// <summary>ACCESSOR: for other classes to get and/or the list of edges for the shape</summary>
        public List<Vector2> Edges { get { return edges; } set { edges = value; } }




        /// <summary>ACCESSOR: for other classes to get and/or the value of acceleration</summary>
        public Vector2 Acceleration { get { return acceleration; } set { acceleration = value; } }

        /// <summary>ACCESSOR: for other classes to get and/or the mass of an object</summary>
        public float MMass { get { return mMass; } set { mMass = value; } }

        /// <summary>ACCESSOR: for other classes to get and/or the restitution of an object</summary>
        public float Restitution { get { return restitution; } set { restitution = value; } }

        /// <summary>ACCESSOR: for other classes to get and/or the damping effect that is applied to an object</summary>
        public float Damping { get { return damping; } set { damping = value; } }


        /// <summary>ACCESSOR: for other classes to get and/or the gravity of a scene</summary>
        public Vector2 Gravity { get { return gravity; } set { gravity = value; } }

        /// <summary>ACCESSOR: for other classes to get and/or the check to see if the object is touching the ground</summary>
        public Boolean IsGround { get { return isGround; } set { isGround = value; } }


        ///////////////////////////////////////  SET ID  /////////////////////////////////////


        /// <summary>METHOD: to set the unique ID name and unique ID number so that they can be requested by them</summary>
        /// <param name="idNa">to give the unique name</param>
        /// <param name="idNu">to give the unique number</param>
        public void setID(string idNa, int idNu)
        {
            // SET: the ID name
            idName = idNa;
            // SET: the ID number
            idNumber = idNu;
        }


        ///////////////////////////////////////  CIRCLE COLLISION  /////////////////////////////////////


        /// <summary>MeTHOD: for setting and returning the radius of a circle</summary>
        /// <returns>the radius of that shape</returns>
        public float GetRadius()
        {
            // SET: the radius of the circle, by halfing it's height
            radius = image.Height / 2;
            // RETURN: the raidus of the object
            return radius;
        }

        /// <summary>METHOD: for finding the centre point of a circle</summary>
        /// <returns>the centre point of that shape</returns>
        public Vector2 GetCentrePoint()
        {
            // FIND: the centre point on the x axis
            float midX = Position.X + Image.Width / 2;
            // FIND: the centre point on the y axis
            float midY = Position.Y + Image.Height / 2;

            // SET: the centre point using centres from the x and y axes
            centrePoint = new Vector2(midX, midY);

            // RETURN: the centre point of that object
            return centrePoint;
        }


        ///////////////////////////////////////  SAT COLLISION  /////////////////////////////////////


        /// <summary>METHOD: for creating edges, using the points that have been given</summary>
        public void CreateEdges()
        {
            // CREATE: a vector to hold the first point
            Vector2 point1;
            // CREATE: a vector to hold the second point
            Vector2 point2;
            // CLEAR: the edges list, making sure it start from [0]
            edges.Clear();

            // FOR: the amount of point in the list
            for (int i = 0; i < points.Count; i++)
            {
                // SET: the first point to equal the count of the loop
                point1 = points[i];
                // IF: there are no other points in the list after this one
                if (i + 1 >= points.Count)
                {
                    // SET: the second point to the first member of the list, to complete the shape
                    point2 = points[0];
                }
                else
                {
                    // SET: the second point to be the next member in the list
                    point2 = points[i + 1];
                }
                // ADD: the edge in the list, by taking the first point, from the sceond point
                edges.Add(point2 - point1);
            }
        }

        /// <summary>METHOD: defualt method, for creating the points of a shape</summary>
        public virtual void CreatePoints()
        {

        }

        /// <summary>METHOD: defualt method, for updating the position of points in the list</summary>
        public virtual void UpdatePoints()
        {

        }



        ///////////////////////////////////////  UPDATE AND DRAW  /////////////////////////////////////

        /// <summary>METHOD: to update the entity</summary>
        public virtual void Update()
        {

        }

        /// <summary>METHOD: to update the entity, using the state machines update</summary>
        /// <param name="dt">the current game loop time</param>
        /// <param name="content">grabs the content manager from the currect scene</param>
        public virtual void Update(GameTime dt, ContentManager content)
        {

        }

        public virtual void Update(Vector2 playerPos)
        {

        }

        /// <summary>METHOD: objects of IEntity must be drawn so that they can appear in the scene</summary>
        /// <param name="spriteBatch">uses the Spritebatch.Draw() method</param>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Image, Position, Color.AntiqueWhite);
        }

        ///////////////////////////////////////  UPDATE AND DRAW  /////////////////////////////////////



        /// <summary>METHOD: handles the event getting input</summary>
        /// <param name="source">the object that is listening</param>
        /// <param name="args">sets the keys being pressed</param>
        public virtual void GetInput(Object source, myEventArgs args)
        {

        }

        /// <summary>METHOD: handles the event when no keys are being pressed</summary>
        /// <param name="source">the object that is listening</param>
        /// <param name="args">sets the keys being pressed</param>
        public virtual void GetKeyUp(Object source, myEventArgs args)
        {

        }


        ///////////////////////////////////////  STATE MACHINE  /////////////////////////////////////


        /// <summary>METHOD: handles the event getting input</summary>
        /// <param name="source">the object that is listening</param>
        /// <param name="args">sets the keys being pressed</param>
        public virtual void SetStateMachine(PlayerStateMachine machine)
        {

        }


        ///////////////////////////////////////  PHYSICS  /////////////////////////////////////

        public void ConvertMass()
        {
            if (MMass != 0)
            {
                inverseMass = 1 / mMass;
            }
            else
            {
                inverseMass = 0;
            }
        }

        /// <summary>METHOD: declares the equation to apply accelertion</summary>
        /// <param name="force">the force to be applied to the acceleration</param>
        public void ApplyForce(Vector2 force)
        {
            // EQUATION: 
            acceleration += force * inverseMass;
        }

        /// <summary>METHOD: applies the acceleration to move the entity</summary>
        public void UpdatePhysics()
        {
            // MULTIPLY: the current velocity by the damping effect
            velocity *= damping;
            // INCREASE: the velocity by the acceleration, and apply gravity
            velocity += acceleration + gravity;
            // CAP: the velocity
            capPhysics();
            // APPLY: the new velocity to the position
            position += velocity;
        }

        /// <summary>METHOD: to apply the impulse of a collision</summary>
        /// <param name="input">the input velocity</param>
        public void ApplyImpulse(Vector2 input)
        {
            // APPLY: the impulse to the acceleration
            ApplyForce(restitution * input);
        }

        /// <summary>METHOD: defines deceleration to give a physical feeling decrease in speed</summary>
        public void Decelerator()
        {
            // IF: the length of the acceleration vector more than 0
            if (acceleration.Length() != 0)
            {
                // DECREASE: the acceleration gradually
                acceleration -= (acceleration / 10);

                // IF: the acceleration is small enough
                if (acceleration.Length() > 0.24 && acceleration.Length() < -0.24)
                {
                    // SET: it to zero
                    acceleration = Vector2.Zero;
                }
            }

            // IF: the entity is not on the ground
            if (position.Y < 1024)
            {
                // AND IF: the acceleration on the Y value is not eqaul to gravity
                if (acceleration.Y != gravity.Y)
                {
                    // THEN: decrease the acceleration gradually
                    acceleration.Y -= (acceleration.Y / 10) + gravity.Y;

                    // IF: the acceleration is close enough to gravity
                    if (acceleration.Y > gravity.Y + 0.24 && acceleration.Y < gravity.Y - 0.24)
                    {
                        // THENL set it to gravity
                        acceleration.Y = gravity.Y;
                    }
                }
            }
            // OTHERWISE: the acceleration is zero
            else { acceleration.Y = 0; }
        }

        /// <summary>METHOD: caps the speed of the object</summary>
        public void capPhysics()
        {
            // IF: the velocity vector longer than 10
            if (velocity.Length() > 10)
            {
                // AND IF: the x value is more than 10
                if (velocity.X > 10)
                {
                    // SET: the x value to 10
                    velocity.X = 10;
                }
                // OR: less than -10
                else if (velocity.X < -10)
                {
                    // SET: the x value to -10
                    velocity.X = -10;
                }

                // AND IF: the y value is more than 10
                if (velocity.Y > 10)
                {
                    // SET: the y value to 10
                    velocity.Y = 10;
                }
                // OR: less than -10
                else if (velocity.Y < -10)
                {
                    // SET: the y value to -10
                    velocity.Y = -10;
                }
            }


            // IF: the acceleration vector longer than 10
            if (acceleration.Length() > 20)
            {
                // AND IF: the x value is more than 10
                if (acceleration.X > 20)
                {
                    // SET: the x value to 10
                    acceleration.X = 20;
                }
                // OR: less than -10
                else if (acceleration.X < -20)
                {
                    // SET: the x value to -10
                    acceleration.X = -20;
                }

                // AND IF: the y value is more than 10
                if (acceleration.Y > 20)
                {
                    // SET: the y value to 10
                    acceleration.Y = 20;
                }
                // OR: less than -10
                else if (acceleration.Y < -20)
                {
                    // SET: the y value to -10
                    acceleration.Y = -20;
                }

            }
        }
    }
}


