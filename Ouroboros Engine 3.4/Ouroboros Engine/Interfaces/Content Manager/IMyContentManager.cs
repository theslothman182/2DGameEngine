using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace OuroborosEngine.Interfaces
{
    public interface IMyContentManager
    {
        ///////////////////////////////////////  CONTENT TYPES  /////////////////////////////////////
        Texture2D GetTexture(string pathName);
        SoundEffect GetSound(string pathName);
        SpriteFont GetFont(string pathName);
    }
}
