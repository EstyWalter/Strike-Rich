using Microsoft.VisualBasic.ApplicationServices;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography.X509Certificates;

namespace Strike_Rich
{
    public partial class frmStrikeRich : Form
    {
        String path = Application.StartupPath + @"\Images\";
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
        readonly string[] diceFaces = { "⚀", "⚁", "⚂", "⚃", "⚄", "⚅" };

        public frmStrikeRich()
        {
            InitializeComponent();
            HideDiamondAndWater();
            Island = new() { pbIsland1, pbIsland2, pbIsland3, pbIsland4, pbIsland5, pbIsland6, pbIsland7, pbIsland8, pbIsland9, pbIsland10, pbIsland11, pbIsland12 };
            Image("StartScreen.png");
            pbIslandStart.Enabled = false;
            VisibleControl(false);
            Island.ForEach(i => i.Click += I_Click);
            btnStartGo.Click += BtnStartGo_Click;
            btnDoor.Click += BtnDoor_Click;
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
                Island.ForEach(i => VisibleControl(i));
                VisibleControl(pbIslandStart);
            }
        }

        private void VisibleControl(Control thecontrol, Boolean status = false)
        {
            thecontrol.Visible = status;
        }

        private void VisibleControl(Boolean status = false)
        {
            VisibleControl(btnStartGo, status);
            VisibleControl(pbIslandStart, status);
            Island.ForEach(i => VisibleControl(i, status));
        }

        private void Settings(Control thecontrol)
        {
            thecontrol.Parent = pbMain;
            thecontrol.BackColor = Color.Transparent;
            thecontrol.Enabled = false;
        }

        private void StartGame()
        {
            txtInstructions.BackColor = Color.AliceBlue;
            txtInstructions.ForeColor = Color.Black;
            txtInstructions.Text = "A poor farmer is digging to find a treasure and save his family home. Roll the dice before pressing GO. The farmer moves by the number you roll, then click the island to dig for a hidden diamond. (Watch out for floods - some islands are traps!)";
            Image("Ocean.png");
            Image(pbIslandStart, "House2Boats.png");
            Island.ForEach(i => Image(i, "Island.png"));
            Island.ForEach(i => Settings(i));
            Settings(pbIslandStart);
            VisibleControl(btnDoor);
            VisibleControl(true);
            btnStartGo.Enabled = true;
            SetStartGoButtonText("START");
        }

        private void SetStartGoButtonText(string text)
        {
            btnStartGo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnStartGo.Text = text;
        }

        private void ResetDiceButton()
        {
            btnStartGo.Font = new Font("Segoe UI Emoji", 32F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnStartGo.Text = "🎲";
        }

        private void IslandImage(string picture)
        {
            Island[i].Enabled = true;
            Image(Island[i], picture);
        }
        private int random(int number)
        {
            Random rnd = new();
            number  = rnd.Next(0, 12);
            return number;
        }
        private void HideDiamondAndWater()
        {
          water =  random(water);
          water1 =  random(water1);
          water2 =  random(water2);
          water3 = random(water3);
          diamond = random(diamond);
        }

        private void startgo()
        {
            if (btnStartGo.Text == "START")
            {
                txtInstructions.Text = "Roll the dice, then press GO to move the farmer by the number you rolled.";
                IslandImage("IslandFarmer.png");
                ResetDiceButton();
                btnStartGo.Enabled = true;
                LoseLifeboat();
                return;
            }

            if (diceRoll == 0)
            {
                txtInstructions.Text = "Roll the dice before pressing GO.";
                btnStartGo.Enabled = true;
                return;
            }

            txtInstructions.Text = "Click on the island to dig it up, or roll again before pressing GO to move to another island.";
            IslandImage("Island.png");
            Island[i].Enabled = false;
            for (int move = 0; move < diceRoll; move++)
            {
                AdvanceToNextVisibleIsland();
            }
            diceRoll = 0;
            ResetDiceButton();
            btnStartGo.Enabled = true;
            IslandImage("IslandFarmer.png");
            LoseLifeboat();
        }


        private void AdvanceToNextVisibleIsland()
        {
            i = FindNextVisibleIslandIndex(i);
        }

        private int FindNextVisibleIslandIndex(int startIndex)
        {
            int nextIndex = startIndex;
            for (int islandCount = 0; islandCount < Island.Count; islandCount++)
            {
                nextIndex = (nextIndex + 1) % Island.Count;
                if (Island[nextIndex].Visible)
                {
                    return nextIndex;
                }
            }

            return startIndex;
        }

        private async Task AnimateLifeboatToIsland(int startIndex, int endIndex)
        {
            PictureBox lifeboat = new()
            {
                Parent = pbMain,
                BackColor = Color.Transparent,
                ImageLocation = path + "LifeBoat.png",
                Location = Island[startIndex].Location,
                Size = Island[startIndex].Size,
                SizeMode = PictureBoxSizeMode.StretchImage
            };
            lifeboat.BringToFront();

            Point startLocation = Island[startIndex].Location;
            Point endLocation = Island[endIndex].Location;
            const int animationSteps = 24;

            for (int step = 1; step <= animationSteps; step++)
            {
                int left = startLocation.X + ((endLocation.X - startLocation.X) * step / animationSteps);
                int top = startLocation.Y + ((endLocation.Y - startLocation.Y) * step / animationSteps);
                lifeboat.Location = new Point(left, top);
                await Task.Delay(35);
            }

            lifeboat.Dispose();
        }

        private void StartAgain()
        {
            HideDiamondAndWater();
            StartGame();
            Island.ForEach(i => i.Visible = true);
            pbIslandStart.Visible = true;
            i = 0;
            SetStartGoButtonText("START");
            btnStartGo.Enabled = true;
            diceRoll = 0;
            chance = 3;
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
                    txtInstructions.Text = "GAME OVER. farmer died a tragic death!";
                    SetStartGoButtonText("start new game");
                    btnStartGo.Enabled = true;
                    break;
            }
            pbIslandStart.Enabled = false;
        }
        private void Go()
        {
            if (btnStartGo.Text == "START" || btnStartGo.Text.StartsWith("GO"))
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
            txtInstructions.Text = "The dice is rolling...";

            for (int roll = 0; roll < 12; roll++)
            {
                int rollingNumber = dice.Next(1, 7);
                btnStartGo.Text = diceFaces[rollingNumber - 1];
                await Task.Delay(100);
            }

            diceRoll = dice.Next(1, 7);
            SetStartGoButtonText($"GO {diceRoll}");
            btnStartGo.Enabled = true;
            txtInstructions.Text = $"The dice landed on {diceRoll}. Press GO {diceRoll} to move the farmer {diceRoll} space{(diceRoll == 1 ? "" : "s")}.";
        }

        private async void IslandChange()
        {
            if (diamond == i)
            {
                IslandImage("IslandDiamond.png");
                txtInstructions.Text = "THE FARMER STRUCK IT RICH";
                Image("win.png");
                SetStartGoButtonText("start new game");
                btnStartGo.Enabled = true;
            }
            else if (water == i || water1 == i || water2 == i || water3 == i)
            {
                Image(Island[i], "IslandWater.png");
                Island[i].Enabled = false;
                btnStartGo.Enabled = false;
                txtInstructions.Text = "Water is coming out of this island! The farmer needs a lifeboat.";
                await Task.Delay(900);

                chance--;
                LoseLifeboat();

                if (chance > 0)
                {
                    Image(Island[i], "LifeBoat.png");
                    txtInstructions.Text = "The farmer got into a lifeboat. Now the flooded island is sinking away.";
                    await Task.Delay(900);

                    int sunkIsland = i;
                    int nextIsland = FindNextVisibleIslandIndex(sunkIsland);
                    Island[sunkIsland].Visible = false;
                    await AnimateLifeboatToIsland(sunkIsland, nextIsland);
                    i = nextIsland;
                    IslandImage("IslandFarmer.png");
                    diceRoll = 0;
                    ResetDiceButton();
                    btnStartGo.Enabled = true;
                    txtInstructions.Text = "The island sunk! The farmer moved to the next island. Roll the dice before pressing GO again.";
                }
            }
            else
            {
                IslandImage("IslandHole.png");
                txtInstructions.Text = "The farmer wasted his energy and time. The hole is empty";
            }
        }
        private void I_Click(object? sender, EventArgs e)
        {
            IslandChange();
        }
    }
}
