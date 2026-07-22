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
        float relativeX = 0.47f;
        float relativeY = 0.41f;

        public frmStrikeRich()
        {
            InitializeComponent();
            HideDiamondAndWater();
            Island = new() { pbIsland1, pbIsland2, pbIsland3, pbIsland4, pbIsland5, pbIsland6, pbIsland7, pbIsland8, pbIsland9, pbIsland10, pbIsland11, pbIsland12 };
            Image("StartScreen.png");
            btnDoor.Parent = pbMain;
            Parent(btnStartGo);
            Island.ForEach(i => i.Click += I_Click);
            pbIslandStart.Enabled = false;
            pbMain.BringToFront();
            // tblMain.SendToBack();
            btnStartGo.Click += BtnStartGo_Click;
            btnDoor.Click += BtnDoor_Click;
            pbMain.Resize += PbMain_Resize;
        }

        private void Image(PictureBox pb, string image)
        {
            pb.ImageLocation = path + image;
        }

        private void Image(string picture)
        {
            Image(pbMain, picture);
            pbMain.Dock = DockStyle.Fill;
            if (picture == "win.png" || picture == "Sinking.png")
            {
                Island.ForEach(i => Visible(i));
                Visible(pbIslandStart);
            }
        }

        private void Visible(Control thecontrol, bool status = false)
        {
            thecontrol.Visible = status;
        }

        private void Parent(Control thecontrol)
        {
            thecontrol.Parent = tblMain;
        }
        private void Settings(Control thecontrol)
        {
            thecontrol.Parent = tblMain;
            thecontrol.BackColor = Color.Transparent;
            thecontrol.BringToFront();
            thecontrol.Enabled = false;
        }

        private void StartGame()
        {
            Visible(btnDoor);
            txtInstructions.BackColor = Color.AliceBlue;
            txtInstructions.ForeColor = Color.Black;
            txtInstructions.Text = "A poor farmer is digging to find a treasure and save his family home. Click the island to dig for hidden diamond. (Watch out for floods - some islands are traps!) Click go to skip to the next island.";
            Image("Ocean.png");
            Image(pbIslandStart, "House2Boats.png");
            Island.ForEach(i => Image(i, "Island.png"));
            Island.ForEach(i => Settings(i));
            pbIslandStart.Parent = pbMain;
            Settings(pbIslandStart);
            tblMain.Parent = pbMain;
            tblMain.BackColor = Color.Transparent;
            tblMain.Dock = DockStyle.Fill;
            tblMain.BringToFront();


        }

        private void IslandImage(string picture)
        {
            Island[i].Enabled = true;
            Image(Island[i], picture);
        }
        //private void Random(int number)
        //{
        //    Random rnd = new();
        //    number =
        //}

        private void HideDiamondAndWater()
        {

            Random rnd = new();
            water = rnd.Next(0, 12);
            water1 = rnd.Next(0, 12);
            water2 = rnd.Next(0, 12);
            water3 = rnd.Next(0, 12);
            diamond = rnd.Next(0, 12);
            // if (diamond == water)
            // {
            //     Random(diamond);
            // }
        }
        private void PbMain_Resize(object? sender, EventArgs e)
        {
            int newX = (int)(pbMain.Width * relativeX) - (btnDoor.Width / 2);
            int newY = (int)(pbMain.Height * relativeY) - (btnDoor.Height / 2);
            btnDoor.Location = new Point(newX, newY);
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
            Island.ForEach(i => Visible(i, true));
            Visible(pbIslandStart, true);
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

        private void pbIsland1_Click(object sender, EventArgs e)
        {

        }

        private void pbIsland10_Click(object sender, EventArgs e)
        {

        }

        private void pbIsland7_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pbIsland11_Click(object sender, EventArgs e)
        {

        }

        private void txtInstructions_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmStrikeRich_Load(object sender, EventArgs e)
        {

        }

        private void tblMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
