using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using OuroborosEngine.Interfaces;

namespace OuroborosEngine.Managers.Content_Manager
{
    public class MyContentManager : IMyContentManager
    {
        ///////////////////////////////////////  VARIABLES  /////////////////////////////////////


        // CREATE: a content manager
        private ContentManager Content;

        // CREATE: a dictionary to store images by name
        private IDictionary<String, Texture2D> textures;
        // CREATE: a dictionary to store sounds by name
        private IDictionary<String, SoundEffect> sounds;
        // CREATE: a dictionary to store fonts by name
        private IDictionary<string, SpriteFont> fonts;


        ///////////////////////////////////////  CONSTRUCTOR  /////////////////////////////////////


        public MyContentManager(ContentManager content)
        {
            // SET: the content manager to use the content from the scene manager
            Content = content;

            // INSTANTIATE: the dictionaries 
            textures = new Dictionary<String, Texture2D>();
            sounds = new Dictionary<String, SoundEffect>();
            fonts = new Dictionary<String, SpriteFont>();
        }


        ///////////////////////////////////////  CONTENT TYPES  /////////////////////////////////////


        /// <summary>METHOD: to get the image by its filename and return it</summary>
        /// <param name="pathName">the name of the image using its filename</param>
        /// <returns>the Texture2D now holding that image</returns>
        public Texture2D GetTexture(string pathName)
        {
            // CREATE: a blank object of type Texture2D
            Texture2D texture = null;

            // IF: the dictionary already contains an item with that filename 
            if (textures.ContainsKey(pathName))
            {
                // SET: the image that corresponds with that filename
                texture = textures[pathName];
            }
            else
            {
                
                // SET: the image using that filename
                texture = Content.Load<Texture2D>(pathName);
                // ADD: that image to the dictionary
                textures.Add(pathName, texture);
            }

            // RETURN: the image
            return texture;
        }

        /// <summary>METHOD: to get the sound by its filename and return it</summary>
        /// <param name="pathName">the name of the sound using its filename</param>
        /// <returns>the SoundEffect now holding that sound</returns>
        public SoundEffect GetSound(string pathName)
        {
            // CREATE: a blank object of type SoundEffect
            SoundEffect sound = null;

            // IF: the dictionary already contains an item with that filename
            if (sounds.ContainsKey(pathName))
            {
                // SET: the sound that corresponds with that filename
                sound = sounds[pathName];
            }
            // IF NOT:
            else
            {
                // SET: the sound using that filename
                sound = Content.Load<SoundEffect>(pathName);
                // ADD: that sound to the dictionary
                sounds.Add(pathName, sound);
            }

            // RETURN: the sound
            return sound;
        }

        /// <summary>METHOD: to get the font by its filename and return it</summary>
        /// <param name="pathName">the name of the font using its filename</param>
        /// <returns>the SpriteFont now holding that font</returns>
        public SpriteFont GetFont(string pathName)
        {
            // CREATE: a blank object of type SpriteFont
            SpriteFont font = null;

            // IF: the dictionary already contains an item with that filename
            if (fonts.ContainsKey(pathName))
            {
                // SET: the font that corresponds with that filename
                font = fonts[pathName];
            }
            // IF NOT:
            else
            {
                // SET: the font using that filename
                font = Content.Load<SpriteFont>(pathName);
                // ADD: that font to the dictionary
                fonts.Add(pathName, font);
            }

            // RETURN: the font
            return font;
        }
    }
}
