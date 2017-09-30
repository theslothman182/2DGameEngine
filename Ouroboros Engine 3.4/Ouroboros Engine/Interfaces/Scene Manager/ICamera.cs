using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace OuroborosEngine.Interfaces
{
    public interface ICamera
    {
        float Zoom { get; set; }
        Matrix Transform { get; set; }
        float Rotation { get; set; }
        Vector2 Position { get; set; }
        Viewport View { get; set; }
    }
}
