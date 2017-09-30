using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using OuroborosEngine.Managers.SceneManager.Camera;

namespace WaxenV_1.Managers.SceneManager.Screens.WCamera
{
    class WaxenCamera : Camera
    {
        public WaxenCamera(Viewport lens) : base(lens)
        {

        }

        public override void Update(Vector2 controller)
        {
            position = -controller;

            zoom = MathHelper.Clamp(zoom, 0, 10);
            transform = Matrix.CreateRotationZ(rotation) *
                            Matrix.CreateScale(new Vector3(zoom, zoom, 1)) *
                                Matrix.CreateTranslation(position.X + 650, 0, 0);
        }
    }
}
