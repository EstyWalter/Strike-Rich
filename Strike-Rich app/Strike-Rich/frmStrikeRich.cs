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
            txtInstructions.Text = "A poor farmer is digging to find a treasure and save his family home. Click the island to dig for hidden diamond. (Watch out for floods - some islands are traps!) Click go to skip to the next island.";
            Image("Ocean.png");
            Image(pbIslandStart, "House2Boats.png");
            Island.ForEach(i => Image(i, "Island.png"));
            Island.ForEach(i => Settings(i));
            Settings(pbIslandStart);
            VisibleControl(btnDoor);
            VisibleControl(true);
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
            txtInstructions.Text = "Click on the island to dig it up or click on the go button to skip to the next island.";
            IslandImage("Island.png");
            Island[i].Enabled = false;
            if (i < 11)
            {
                if (btnStartGo.Text == "GO")
                {
                    i++;
                }
                IslandImage("IslandFarmer.png");
                LoseLifeboat();
            }
            else
            {
                i = 0;
                IslandImage("IslandFarmer.png");
            }
            btnStartGo.Text = "GO";
        }

        private void StartAgain()
        {
            HideDiamondAndWater();
            StartGame();
            Island.ForEach(i => i.Visible = true);
            pbIslandStart.Visible = true;
            i = 0;
            btnStartGo.Text = "START";
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
                    btnStartGo.Text = "start new game";
                    break;
            }
            pbIslandStart.Enabled = false;
        }
        private void Go()
        {
            if (btnStartGo.Text == "START" || btnStartGo.Text == "GO")
            {
                startgo();
            }
            else if (btnStartGo.Text == "start new game")
            {
                StartAgain();
            }
            else if (btnStartGo.Text == "get a lifeboat")
            {
                btnStartGo.Text = "GO";
                LoseLifeboat();
                Image(Island[i], "LifeBoat.png");
                Island[i].Enabled = false;
            }

        }
        private void BtnDoor_Click(object? sender, EventArgs e)
        {
            StartGame();
        }

        private void BtnStartGo_Click(object? sender, EventArgs e)
        {
            Go();
        }

        private void IslandChange()
        {
            if (diamond == i)
            {
                IslandImage("IslandDiamond.png");
                txtInstructions.Text = "THE FARMER STRUCK IT RICH";
                Image("win.png");
                btnStartGo.Text = "start new game";
            }
            else if (water == i || water1 == i || water2 == i || water3 == i)
            {
                IslandImage("IslandWater.png");
                txtInstructions.Text = "POOR FARMER! press get a lifeboat to be saved. You will use up a chance";
                btnStartGo.Text = "get a lifeboat";
                Island[i].Enabled = false;
                chance--;
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
