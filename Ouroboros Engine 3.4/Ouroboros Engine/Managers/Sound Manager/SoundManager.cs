using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using OuroborosEngine.Interfaces;
using OuroborosEngine.Managers.Content_Manager;

namespace OuroborosEngine.Managers.Sound_Manager
{
    class SoundManager : ISoundManager
    {
        ///////////////////////////////////////  VARIABLES  /////////////////////////////////////


        // CREATE: a content manager
        MyContentManager myContent;

        // CREATE: a list to hold the level sounds
        private List<SoundEffectInstance> soundEffects;
        // CREATE: an object to hold the sound
        SoundEffect effect;
        // CREATE: an object to control the instance of a sound
        SoundEffectInstance soundEffectInstance;


        ///////////////////////////////////////  CONSTRUCTOR  /////////////////////////////////////

        
        public SoundManager(ContentManager content)
        {
            // INSTANTIATE: the content manager
            myContent = new MyContentManager(content);
            // INSTANTIATE: the list of sounds, giving it a limit of 1
            soundEffects = new List<SoundEffectInstance>(1);
        }


        ///////////////////////////////////////  SOUND CONTROLS  /////////////////////////////////////


        /// <summary>METHOD: to play sounds that will occur throughout the level</summary>
        /// <param name="filename">the name of the music file</param>
        /// <param name="content">grabs the content manager from the game scene</param>
        public void Play(string filename, ContentManager content)
        {
            // SET: the sound effect to play
            effect = content.Load<SoundEffect>(filename);//myContent.GetSound(filename);
            // SET: that sound effect to a sound effect instance, to give more control
            soundEffectInstance = effect.CreateInstance();
            // DO NOT: loop this sound
            soundEffectInstance.IsLooped = false;

            //IF: there isn't a sound already in the list
            if (soundEffects.Count == 0)
            {
                // THEN: add the sound to that list
                soundEffects.Add(soundEffectInstance);
            }

            // FOR EACH: sound in the list of sounds
            foreach (SoundEffectInstance sound in soundEffects)
                // PLAY: that sound
                sound.Play();
        }

        /// <summary>METHOD: to play the background music for the level, and loop it</summary>
        /// <param name="filename">the name of the music file</param>
        /// <param name="content">grabs the content manager from the game scene</param>
        public void BackgroundMusic(string fileName, ContentManager content)
        {
            // SET: the background music
            effect = content.Load<SoundEffect>(fileName);//myContent.GetSound(fileName);
            // SET: that sound effect to a sound effect instance, to give more control
            soundEffectInstance = effect.CreateInstance();
            // LOOP: this sound
            soundEffectInstance.IsLooped = true;
            
            // PLAY: the background music
            soundEffectInstance.Play();
        }

        /// <summary>METHOD: to stop the sound that is currently playing</summary>
        public void Stop()
        {
            // IF: there is a sound in the list
            if (soundEffects.Count != 0)
            {
                // STOP: that sound
                soundEffects[0].Stop();
            }
        }
    }
}
