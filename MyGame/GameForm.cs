using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace MyGame
{
    public partial class GameForm : Form
    {
        private bool GameOver;
        private Bitmap Map;
        private const double MS_PER_FRAME = 1000 / 30;

        public GameForm()
        {
            InitializeComponent();

            #region Custom Initialization
            //Initialize the Bitmap
            Map = new Bitmap(ContainerBox.Width, ContainerBox.Height);
            //Attach the Bitmap to the main Picture Box
            ContainerBox.Image = Map;

            //Clear the screen
            using (Graphics g = Graphics.FromImage(Map))
            {
                g.Clear(Color.White);
            }
            #endregion
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if(btnStartStop.Text == "Start")
            {
                btnStartStop.Text = "Stop";
                GameOver = false;

                Task TaskGameLoop = Task.Factory.StartNew(GameLoop);
            }
            else
            {
                btnStartStop.Text = "Stopped";
                btnStartStop.Enabled = false;
                GameOver = true;
            }
        }

        private void GameLoop()
        {
            while (!GameOver)
            {
                double start = GetCurrentTime();
                //processInput();
                //update();
                //render();
                
                Thread.Sleep((int)(start + MS_PER_FRAME - GetCurrentTime()));
                Console.WriteLine("FPS: [{0}]", Math.Round(1000 / (GetCurrentTime() - start), 1));
            }
            Console.WriteLine("Game Over");
        }

        private long GetCurrentTime()
        {
            return DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        }
    }
}
