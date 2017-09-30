using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using OuroborosEngine.Interfaces;
using OuroborosEngine.Managers.Content_Manager;

namespace OuroborosEngine.Managers.AnimationManager
{
    class Anim : IAnimationManager
    {
        ///////////////////////////////////////  VARIABLES  /////////////////////////////////////


        // CREATE: a content manager
        MyContentManager myContent;

        // CREATE: a rectangle to hold the screen position of the image
        public Rectangle animPos;
        // CREATE: a rectangle to hold the position on the sprite sheet of the image
        public Rectangle currentAnim;

        // CREATE: a float to hold the time that has passed
        float counter;
        // CREATE: a float to set how long a frame will show for
        float frameTime = 175f;
        // CREATE: an int to store the amount of frames on a sprite sheet
        int frames = 0;
        // CREATE: an int to record the last frame that was shown
        int lastframe;

        // CREATE: a Texture2D to hold the current sprite sheet for the animation playing
        public Texture2D currentSprite;


        ///////////////////////////////////////  CONSTRUCTOR  /////////////////////////////////////


        public Anim()             //ContentManager content, GraphicsDevice graphics)
        {
            // INSTANTIATE: the content manager
            //myContent = new MyContentManager(content);
            // INSTANTIATE: currentSprite so it is not null
            //currentSprite = new Texture2D(graphics, 5, 5);
            // SET: the last frame to be the same as the current frame
            lastframe = frames;
        }


        ///////////////////////////////////////  ANIMATION  /////////////////////////////////////


        /// <summary>METHOD: that will animate sprites, using a fixed framerate</summary>
        /// <param name="gameTime">the current time of the game loop</param>
        /// <param name="content">grabs the content manager from the game scene</param>
        /// <param name="filename">the name of the sprite sheet</param>
        /// <param name="frameMax">the number of frames on the sprite sheet</param>
        /// <param name="spriteLength">the distance between sprites on the sheet</param>
        /// <param name="spriteWidth">the widths of the sprites on the sheet</param>
        /// <param name="spriteHeight">the height of the sprites on the sheet</param>
        public void Animate(GameTime gameTime, ContentManager content, string filename, int frameMax, int spriteLength, int spriteWidth, int spriteHeight)
        {
            // SET: the number of frames on the sprite sheet, taking 1 away, as it works like a list of frames, starting from 0
            frameMax--;

           // currentSprite = myContent.GetTexture("walkright");

            // IF: the filename has been set
            if (filename != null)
            {
                // THEN: then the sprite sheet will be set using this filename
                currentSprite = content.Load<Texture2D>(filename);       //myContent.GetTexture(filename);
            }

            // INCREASE: the counter, using the time of the gameloop
            counter += (float)gameTime.ElapsedGameTime.Milliseconds;
            // IF: the counter is higher than or equal to the time to change the frame
            if (counter >= frameTime)
            {
                // IF: the current frame is equal to or higher than the number of frames on the sprite sheet
                if (frames >= frameMax)
                {
                    // THEN: frames will be reset, to the first frame on the sheet
                    frames = 0;
                    // AND: the last frame will also be reset, making it the same as the current frame
                    lastframe = frames;
                }
                else
                {
                    // INCREMENT: the frames, moving it to the next frame
                    frames++;
                    // SET: the last frame to to be the newest frame
                    lastframe = frames;
                }
                // RESET: the counter, for the next frame
                counter = 0;
            }
            // IF: the counter is lower than the time to change the frame
            else if (counter < frameTime)
            {
                // THEN: the current frame will remain to be the last frame shown
                frames = lastframe;
            }

            // SET: the current animation sprite of the spritesheet, setting its x position using the distance between the sprites on the sheet and the frame it should be on
            currentAnim = new Rectangle(spriteLength * frames, 0, spriteWidth, spriteHeight);
        }
    }
}

