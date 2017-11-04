using System;
using System.Drawing;
using System.IO;

namespace MyGame
{
    public abstract class HeroState
    {
        public string Name { get; set; }
        protected int ImgNum { get; set; }
        public Image CurrentImage { get; set; }
        public int ImgWidth { get; set; }
        public int ImgHeigh { get; set; }
        protected int _delaycounter = 0;
        public HeroDirection Direction { get; set; }

        //How many frames until we move to the next img.
        public int ImgDelay { get; set; }

        private Image[] _images = new Image[10];

        public virtual void Draw(Graphics g, int x, int y)
        {
            g.DrawImage(CurrentImage, x, y, ImgWidth, ImgHeigh);
            //For test purposes, uncomment the line below to display a red rectangle over the image
            g.DrawRectangle(Pens.Red, x, y, ImgWidth, ImgHeigh);
        }

        public virtual void Update(Hero hero)
        {
            if (_delaycounter >= ImgDelay)
            {
                //Move to the next image of the state
                if (ImgNum >= 9)
                    ImgNum = 0;
                else
                    ImgNum++;

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

        public HeroState(string name, int heroWidth, int heroHeight, HeroDirection direction)
        {
            Name = name;
            ImgNum = 9;
            ImgDelay = 1;
            ImgWidth = heroWidth;
            ImgHeigh = heroHeight;
            Direction = direction;

            string ProjectDir;
            ProjectDir = Environment.CurrentDirectory;
            if (ProjectDir.Contains("\\bin\\Debug"))
                ProjectDir = ProjectDir.Replace("\\bin\\Debug", string.Empty);

            
            //Set up the images
            string FileName;
            for (int i = 0; i < 10; i++)
            {
                FileName = Name + "__" + "00" + i.ToString() + ".png";
                _images[i] = Image.FromFile(Path.Combine(ProjectDir, "heroartset", direction.ToString(), FileName));
            }

            //Assign the first one to the current img
            CurrentImage = _images[0];
        }

        public virtual void Enter(Hero hero)
        {
            ImgNum = 9;
        }

        public abstract HeroState HandleInput(Hero h);
    }
}
