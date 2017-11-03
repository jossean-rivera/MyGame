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
using System.IO;

namespace MyGame
{
    public partial class GameForm : Form
    {
        private bool GameOver;
        private Bitmap Map;
        private const double MS_PER_FRAME = 1000 / 30;
        private string BGDirectory;

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

                Task.Factory.StartNew(GameLoop);
            }
            else
            {
                btnStartStop.Text = "Stopped";
                btnStartStop.Enabled = false;
                GameOver = true;
                this.Close();
            }
        }

        private void GameLoop()
        {
            InitializeGame();
            while (!GameOver)
            {
                double start = GetCurrentTime();
                //processInput();
                GameWorld.Instance.Update();
                GameRender();

                int wait = (int)(start + MS_PER_FRAME - GetCurrentTime());
                if(wait > 0)
                    Thread.Sleep(wait);

                //Display the rate of frames per seconds to the console
                Console.WriteLine("FPS: [{0}]", Math.Round(1000 / (GetCurrentTime() - start), 1));
            }
            Console.WriteLine("Game Over");
        }

        private long GetCurrentTime()
        {
            return DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        }

        private void InitializeGame()
        {
            Random rnd = new Random();
            Ball ball;
            for (int i = 0; i < 100; i++)
            {
                ball = new Ball(rnd.Next(Map.Width), rnd.Next(Map.Height), rnd.Next(20) + 5);
                GameWorld.Instance.AddObject(ball);
            }

            GroundTile tile_Under_BottomLeftEnd = new GroundTile(GameWorld.CONTAINER_WIDTH / 10, GameWorld.CONTAINER_HEIGHT / 10, TileType.Under_Ground, GroundTileType.Under_BottomLeftEnd);
            GameWorld.Instance.AddTile(tile_Under_BottomLeftEnd, 0, 9);

            GroundTile tile_Under_BottomEnd = new GroundTile(GameWorld.CONTAINER_WIDTH / 10, GameWorld.CONTAINER_HEIGHT / 10, TileType.Under_Ground, GroundTileType.Under_BottomEnd);
            for(int i = 1; i <= 8; i++)
                GameWorld.Instance.AddTile(tile_Under_BottomEnd, i, 9);

            GroundTile tile_Under_BottonRightEnd = new GroundTile(GameWorld.CONTAINER_WIDTH / 10, GameWorld.CONTAINER_HEIGHT / 10, TileType.Under_Ground, GroundTileType.Under_RightBottomEnd);
            GameWorld.Instance.AddTile(tile_Under_BottonRightEnd, 9, 9);
        }

        private void GameRender()
        {
            using(Graphics g = Graphics.FromImage(Map))
            {
                #region Draw Background
                BGDirectory = Path.Combine(Environment.CurrentDirectory, @"tileset\bg\BG.png");

                if (BGDirectory.Contains("bin\\Debug\\"))
                    BGDirectory = BGDirectory.Replace("bin\\Debug\\", string.Empty);

                g.DrawImage(Image.FromFile(BGDirectory), 0, 0, GameWorld.CONTAINER_WIDTH, GameWorld.CONTAINER_HEIGHT);
                #endregion

                #region Draw Tiles
                for (int row = 0; row < 10; row++)
                    for (int col = 0; col < 10; col++)
                        if(GameWorld.Instance.Tiles[row, col] != null)
                            GameWorld.Instance.Tiles[row, col].Draw(g, row, col);
                #endregion

                #region Draw Objects
                foreach (GameObject obj in GameWorld.Instance.Objects)
                    obj.Draw(g);
                #endregion

                #region Refresh Container
                try
                {
                    this.Invoke(new MethodInvoker(() =>
                    {
                        ContainerBox.Refresh();

                    }));
                }
                catch (ObjectDisposedException ex)
                {
                    Console.WriteLine("Exception: " + ex.Message);
                }
                #endregion
            }
        }
    }
}
