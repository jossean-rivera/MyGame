using System;
using System.Drawing;
using System.IO;

namespace MyGame
{
    public abstract class HeroState
    {
        public string Name { get; set; }
        protected int FrameNum { get; set; }
        public Image CurrentImage { get; set; }
        public int ImgWidth { get; set; }
        public int ImgHeigh { get; set; }

        private Image[] _images = new Image[10];

        public virtual void Draw(Graphics g, int x, int y)
        {
            g.DrawImage(CurrentImage, x, y, ImgWidth, ImgHeigh);
        }

        public virtual void Update(Hero hero)
        {
            if (FrameNum >= 9)
                FrameNum = 0;
            else
                FrameNum++;

            CurrentImage = _images[FrameNum];
        }

        public HeroState(string name, int heroWidth, int heroHeight, HeroDirection direction)
        {
            Name = name;
            FrameNum = 9;
            ImgWidth = heroWidth;
            ImgHeigh = heroHeight;

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
        }

        public virtual void Enter(Hero hero)
        {
            FrameNum = 9;
        }

        public abstract HeroState HandleInput(Hero h);
    }
}
