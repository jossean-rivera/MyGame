using System;
using System.Drawing;
using System.IO;

namespace MyGame
{
    public abstract class HeroState
    {
        #region Properties
        public string Name { get; set; }
        protected int ImgNum { get; set; }
        protected const int ImgsCount = 10; //How many images for each state are in the hero art set folder.
        public Image CurrentImage { get; set; }
        public int ImgWidth { get; set; }
        public int ImgHeigh { get; set; }
        protected int _delaycounter;
        protected int _framecount;
        protected int _frametotal = ImgDelay * ImgsCount;
        public HeroDirection Direction { get; set; }
        private Image[] _images = new Image[ImgsCount];

        //How many frames until we move to the next img.
        public const int ImgDelay = 2;
        #endregion

        #region Methods
        /// <summary>
        /// Method that will draw the image at CurrentImage.
        /// </summary>
        /// <param name="g">Bitmap to draw the image.</param>
        /// <param name="x">Starting position in the x axis.</param>
        /// <param name="y">Starting position in the y axis.</param>
        public virtual void Draw(Graphics g, int x, int y)
        {
            g.DrawImage(CurrentImage, x, y, ImgWidth, ImgHeigh);
            //For test purposes, uncomment the line below to display a red rectangle over the image
            //g.DrawRectangle(Pens.Red, x, y, ImgWidth, ImgHeigh);
        }

        /// <summary>
        /// Logic that the hero will be doing in the state. The function process the CurrentImage assigning it to the corresponding image.
        /// </summary>
        /// <param name="hero">The hero instance.</param>
        public virtual void Update(Hero hero, double elapsed)
        {
            //Every state should have a total of (ImgDelay + 1) * 10 frames
            _framecount++;
            if (_delaycounter >= ImgDelay)
            {
                //Move to the next image of the state
                if (ImgNum >= 9)
                    ImgNum = 0;
                else
                    ImgNum++;

                //Select the Img at the index of ImgNum
                CurrentImage = _images[ImgNum];

                //reset the counter
                _delaycounter = 0;
            }
            else
            {
                //else, increment the delaycounter
                _delaycounter++;
            }
        }

        /// <summary>
        /// Constructor. Initialize all the necessary properties
        /// </summary>
        /// <param name="name">Name of the state. It should match the beggining of the file name in the hero art set.</param>
        /// <param name="heroWidth">Width limit when drawing the hero.</param>
        /// <param name="heroHeight">Height limit when drawing the hero.</param>
        /// <param name="direction">Direction that the hero is facing.</param>
        public HeroState(string name, int heroWidth, int heroHeight, HeroDirection direction)
        {
            Name = name;
            ImgWidth = heroWidth;
            ImgHeigh = heroHeight;
            Direction = direction;

            string ProjectDir;
            ProjectDir = Environment.CurrentDirectory;
            if (ProjectDir.Contains("\\bin\\Debug"))
                ProjectDir = ProjectDir.Replace("\\bin\\Debug", string.Empty);

            
            //Set up the images
            string FileName;
            for (int i = 0; i < ImgsCount; i++)
            {
                FileName = Name + "__" + "00" + i.ToString() + ".png";
                _images[i] = Image.FromFile(Path.Combine(ProjectDir, "heroartset (girl)", direction.ToString(), FileName));
            }

            //Assign the first one to the current img
            CurrentImage = _images[0];
        }

        /// <summary>
        /// This method will be called everytime the hero changes its state to this instance.
        /// </summary>
        /// <param name="hero">The hero instance.</param>
        public virtual void Enter(Hero hero)
        {
            //Since in the update method you increment ImgNum and then select the CurrentImg, start the ImgNum at 9
            //That way, we will set it to 0 first, and then we will set the CurrentImg at index 0
            ImgNum = 9;
            //Set the counter equal to the delay so that we can update the currentImg in the very first frame
            //After we update the currentImg, then the _delaycounter will be set to 0
            _delaycounter = ImgDelay;
            //Set the framecount to 0, this will be the first element that will be incremented in the update method.
            _framecount = 0;
        }

        /// <summary>
        /// Every state will handle input differently. This method gets called at the beggining of every frame of the GameLoop.
        /// </summary>
        /// <param name="h">The hero instance.</param>
        /// <returns></returns>
        public abstract HeroState HandleInput(Hero h);
        #endregion
    }
}
