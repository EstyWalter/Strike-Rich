
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Strike_Rich
{
    public partial class frmStrikeRich : Form
    {
        string path = Application.StartupPath + @"\Images\";

        List<PictureBox> Island;

        int i = 0;
        int diamond = 0;
        int water = 0;
        int water1 = 0;
        int water2 = 0;
        int water3 = 0;
        int chance = 3;
        int diceRoll = 0;

        readonly Random dice = new();

        readonly string[] diceFaces =
        {
            "⚀",
            "⚁",
            "⚂",
            "⚃",
            "⚄",
            "⚅"
        };


        // Professional boat drawing system
        Point boatPosition;
        Bitmap? boatImage;
        bool drawBoat = false;


        public frmStrikeRich()
        {
            InitializeComponent();

            pbMain.Paint += PbMain_Paint;

            Island = new()
            {
                pbIsland1,
                pbIsland2,
                pbIsland3,
                pbIsland4,
                pbIsland5,
                pbIsland6,
                pbIsland7,
                pbIsland8,
                pbIsland9,
                pbIsland10,
                pbIsland11,
                pbIsland12
            };


            HideDiamondAndWater();


            Image("StartScreen.png");

            pbIslandStart.Enabled = false;

            VisibleControl(false);


            Island.ForEach(island =>
            {
                island.Click += I_Click;
            });


            btnStartGo.Click += BtnStartGo_Click;

            btnDoor.Click += BtnDoor_Click;
        }


        private void PbMain_Paint(object? sender, PaintEventArgs e)
        {
            if (drawBoat && boatImage != null)
            {
                e.Graphics.DrawImage(
                    boatImage,
                    new Rectangle(
                        boatPosition.X,
                        boatPosition.Y,
                        150,
                        120));
            }
        }

        private void Image(PictureBox pb, string image)
        {
            pb.ImageLocation = path + image;
        }


        private void Image(string picture)
        {
            Image(pbMain, picture);

            if (picture == "win.png" || picture == "Sinking.png")
            {
                Island.ForEach(island => VisibleControl(island, false));
                VisibleControl(pbIslandStart, false);
            }
        }


        private void VisibleControl(Control control, bool status = false)
        {
            control.Visible = status;
        }


        private void VisibleControl(bool status = false)
        {
            btnStartGo.Visible = status;
            pbIslandStart.Visible = status;

            Island.ForEach(island =>
            {
                island.Visible = status;
            });
        }


        private void Settings(Control control)
        {
            control.Parent = pbMain;
            control.BackColor = Color.Transparent;
            control.Enabled = false;
        }


        private void StartGame()
        {
            txtInstructions.BackColor = Color.AliceBlue;
            txtInstructions.ForeColor = Color.Black;

            txtInstructions.Text =
                "A poor farmer is digging to find a treasure and save his family home. " +
                "Roll the dice before pressing GO. The farmer moves by the number you roll, " +
                "then click the island to dig for a hidden diamond. Watch out for floods!";


            Image("Ocean.png");

            Image(pbIslandStart, "House2Boats.png");


            Island.ForEach(island =>
            {
                Image(island, "Island.png");
                Settings(island);
                island.Visible = true;
            });


            Settings(pbIslandStart);

            pbIslandStart.Visible = true;

            btnDoor.Visible = false;

            VisibleControl(true);

            btnStartGo.Enabled = true;

            SetStartGoButtonText("START");
        }


        private void SetStartGoButtonText(string text)
        {
            btnStartGo.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Regular,
                    GraphicsUnit.Point);

            btnStartGo.Text = text;
        }


        private void ResetDiceButton()
        {
            btnStartGo.Font =
                new Font(
                    "Segoe UI Emoji",
                    32F,
                    FontStyle.Bold,
                    GraphicsUnit.Point);

            btnStartGo.Text = "🎲";
        }


        private void IslandImage(string picture)
        {
            Island[i].Enabled = true;

            Image(Island[i], picture);
        }


        private int RandomIsland()
        {
            Random rnd = new();

            return rnd.Next(0, 12);
        }


        private void HideDiamondAndWater()
        {
            water = RandomIsland();
            water1 = RandomIsland();
            water2 = RandomIsland();
            water3 = RandomIsland();
            diamond = RandomIsland();


            // Prevent the diamond from being on water
            while (diamond == water ||
                   diamond == water1 ||
                   diamond == water2 ||
                   diamond == water3)
            {
                diamond = RandomIsland();
            }
        }


        private void startgo()
        {
            if (btnStartGo.Text == "START")
            {
                txtInstructions.Text =
                    "Roll the dice, then press GO to move the farmer.";

                IslandImage("IslandFarmer.png");

                ResetDiceButton();

                LoseLifeboat();

                return;
            }


            if (diceRoll == 0)
            {
                txtInstructions.Text =
                    "Roll the dice before pressing GO.";

                return;
            }


            txtInstructions.Text =
                "The farmer moved. Click the island to dig.";


            IslandImage("Island.png");

            Island[i].Enabled = false;


            for (int move = 0; move < diceRoll; move++)
            {
                AdvanceToNextVisibleIsland();
            }


            diceRoll = 0;

            ResetDiceButton();


            IslandImage("IslandFarmer.png");

            LoseLifeboat();
        }


        private void AdvanceToNextVisibleIsland()
        {
            i = FindNextVisibleIslandIndex(i);
        }


        private int FindNextVisibleIslandIndex(int startIndex)
        {
            int next = startIndex;


            for (int count = 0; count < Island.Count; count++)
            {
                next = (next + 1) % Island.Count;


                if (Island[next].Visible)
                {
                    return next;
                }
            }


            return startIndex;
        }


        private void StartAgain()
        {
            HideDiamondAndWater();

            StartGame();


            i = 0;
            chance = 3;
            diceRoll = 0;


            SetStartGoButtonText("START");

            btnStartGo.Enabled = true;
        }
        private async Task AnimateBoat(int startIndex, int endIndex)
        {
            boatImage = new Bitmap(path + "LifeBoat.png");


            bool movingRight =
                Island[endIndex].Left > Island[startIndex].Left;


            if (movingRight)
            {
                boatImage.RotateFlip(
                    RotateFlipType.RotateNoneFlipX);
            }


            Point start = new Point(
                Island[startIndex].Left - 20,
                Island[startIndex].Top + 10);


            Point finish = new Point(
                Island[endIndex].Left - 20,
                Island[endIndex].Top + 10);


            boatPosition = start;
            drawBoat = true;


            int steps = 40;


            for (int s = 1; s <= steps; s++)
            {
                int x =
                    start.X +
                    (finish.X - start.X) * s / steps;


                double bob =
                    Math.Sin(s * 0.4) * 6;


                int y =
                    start.Y +
                    (finish.Y - start.Y) * s / steps +
                    (int)bob;


                boatPosition = new Point(x, y);


                pbMain.Invalidate();


                await Task.Delay(30);
            }


            drawBoat = false;


            pbMain.Invalidate();


            boatImage.Dispose();

            boatImage = null;
        }



        private void LoseLifeboat()
        {
            switch (chance)
            {
                case 3:
                    Image(pbIslandStart, "House2Boats.png");
                    break;


                case 2:
                    Image(pbIslandStart, "House1Boat.png");
                    break;


                case 1:
                    Image(pbIslandStart, "IslandHouseNoBoat.png");
                    break;


                case 0:
                    Image("Sinking.png");

                    txtInstructions.Text =
                        "GAME OVER. The farmer lost all his boats.";

                    SetStartGoButtonText("start new game");

                    btnStartGo.Enabled = true;

                    break;
            }


            pbIslandStart.Enabled = false;
        }



        private void Go()
        {
            if (btnStartGo.Text == "START" ||
                btnStartGo.Text.StartsWith("GO"))
            {
                startgo();
            }
            else if (btnStartGo.Text == "start new game")
            {
                StartAgain();
            }
        }



        private void BtnDoor_Click(object? sender, EventArgs e)
        {
            StartGame();
        }



        private async void BtnStartGo_Click(object? sender, EventArgs e)
        {
            if (btnStartGo.Text == "🎲")
            {
                await RollDice();

                return;
            }


            Go();
        }



        private async Task RollDice()
        {
            btnStartGo.Enabled = false;


            txtInstructions.Text =
                "The dice is rolling...";


            for (int roll = 0; roll < 12; roll++)
            {
                int number = dice.Next(1, 7);


                btnStartGo.Text =
                    diceFaces[number - 1];


                await Task.Delay(100);
            }


            diceRoll = dice.Next(1, 7);


            SetStartGoButtonText(
                $"GO {diceRoll}");


            btnStartGo.Enabled = true;


            txtInstructions.Text =
                $"The dice landed on {diceRoll}. Press GO to move.";
        }



        private async void IslandChange()
        {
            if (diamond == i)
            {
                IslandImage("IslandDiamond.png");


                txtInstructions.Text =
                    "THE FARMER STRUCK IT RICH";


                Image("win.png");


                SetStartGoButtonText(
                    "start new game");


                btnStartGo.Enabled = true;
            }


            else if (water == i ||
                     water1 == i ||
                     water2 == i ||
                     water3 == i)
            {
                Image(Island[i], "IslandWater.png");


                Island[i].Enabled = false;


                btnStartGo.Enabled = false;


                txtInstructions.Text =
                    "Flood! The farmer needs a lifeboat.";


                await Task.Delay(900);


                chance--;


                LoseLifeboat();



                if (chance > 0)
                {
                    int oldIsland = i;


                    int nextIsland =
                        FindNextVisibleIslandIndex(oldIsland);


                    txtInstructions.Text =
                        "The farmer escaped in his boat.";


                    await Task.Delay(500);


                    Island[oldIsland].Visible = false;


                    await AnimateBoat(
                        oldIsland,
                        nextIsland);



                    i = nextIsland;


                    IslandImage("IslandFarmer.png");


                    ResetDiceButton();


                    btnStartGo.Enabled = true;


                    txtInstructions.Text =
                        "The island sank! Roll again.";
                }
            }


            else
            {
                IslandImage("IslandHole.png");


                txtInstructions.Text =
                    "The hole is empty. Keep searching!";
            }
        }



        private void I_Click(object? sender, EventArgs e)
        {
            IslandChange();
        }

    }
}