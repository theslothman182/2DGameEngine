using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace OuroborosEngine.Interfaces
{
    public interface ICollidable
    {
        ///////////////////////////////////////  GETTERS AND SETTERS  /////////////////////////////////////
        float Radius { get; set; }
        Vector2 CentrePoint { get; set; }
        List<Vector2> Points { get; set; }
        List<Vector2> Edges { get; set; }
        Vector2 Acceleration { get; set; }
        float MMass { get; set; }
        float Restitution { get; set; }
        float Damping { get; set; }
        Vector2 Gravity { get; set; }
        Boolean IsGround { get; set; }

        ///////////////////////////////////////  NEEDED FOR REFERENCE  /////////////////////////////////////
        Texture2D Image { get; set; }
        Vector2 Position { get; set; }
        Vector2 Velocity { get; set; }

        ///////////////////////////////////////  CIRCLE COLLISION  /////////////////////////////////////
        float GetRadius();
        Vector2 GetCentrePoint();

        ///////////////////////////////////////  SAT COLLISION  /////////////////////////////////////
        void CreatePoints();
        void UpdatePoints();
        void CreateEdges();

        ///////////////////////////////////////  PHYSICS  /////////////////////////////////////
        void ConvertMass();
        void ApplyForce(Vector2 force);
        void UpdatePhysics();
        void ApplyImpulse(Vector2 input);
        void Decelerator();
    }
}
