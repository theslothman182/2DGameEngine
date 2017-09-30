using Microsoft.Xna.Framework.Content;

namespace OuroborosEngine.Interfaces
{
    interface ISoundManager
    {
        ///////////////////////////////////////  SOUND CONTROLS  /////////////////////////////////////
        void Play(string filename, ContentManager content);
        void BackgroundMusic(string fileName, ContentManager content);
        void Stop();
    }
}