using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using OuroborosEngine.Interfaces;

namespace OuroborosEngine.Managers.SceneManager.Camera
{
    public class Camera : ICamera
    {
        protected float zoom;
        protected Matrix transform;
        protected float rotation;
        protected Vector2 position;
        protected Viewport view;

        public float Zoom{ get { return zoom; } set { zoom = value; } }
        public Matrix Transform { get { return transform; } set { transform = value; } }
        public float Rotation { get { return rotation; } set { rotation = value; } }
        public Vector2 Position { get { return position; } set { position = value; } }
        public Viewport View { get { return view; } set { view = value; } }

        public Camera(Viewport lens)
        {
            zoom = 1.0f;
            rotation = 0;
            position = Vector2.Zero;
            view = lens;
        }

        public virtual void Update(Vector2 controller)
        {
            position = -controller;

            zoom = MathHelper.Clamp(zoom, 0, 10);
            transform = Matrix.CreateRotationZ(rotation) * 
                            Matrix.CreateScale(new Vector3(zoom, zoom, 1)) * 
                                Matrix.CreateTranslation(position.X, position.Y, 0);
        }
    }
}
