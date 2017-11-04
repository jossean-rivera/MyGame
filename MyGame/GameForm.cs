using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace MyGame
{
    public partial class GameForm : Form
    {
        private Bitmap Map;
        private Thread GameThread;

        public GameForm()
        {
            InitializeComponent();
            this.ShowIcon = false;

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
            if (btnStartStop.Text == "Start")
            {
                btnStartStop.Text = "Stop";
                GameWorld.Instance.GameOver = false;

                //Task.Factory.StartNew(GameLoop);
                GameThread = new Thread(GameWorld.Instance.GameLoop);
                GameWorld.Instance.GameRender = Render;
                GameThread.Name = "Game Thread";
                GameThread.SetApartmentState(ApartmentState.STA);
                GameThread.Start();
            }
            else
            {
                btnStartStop.Text = "Stopped";
                btnStartStop.Enabled = false;
                GameWorld.Instance.GameOver = true;
                this.Close();
            }
        }
        
        public void Render()
        {
            using(Graphics g = Graphics.FromImage(Map))
            {
                GameWorld.Instance.RenderAllElements(g);

                try
                {
                    this.Invoke(new MethodInvoker(() =>
                    {
                        try
                        {
                            ContainerBox.Refresh();
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            GameWorld.Instance.GameOver = true;
            if (GameThread != null) GameThread.Join();
        }
    }
}
