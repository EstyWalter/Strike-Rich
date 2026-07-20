using Microsoft.VisualBasic.ApplicationServices;
using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography.X509Certificates;

namespace Strike_Rich
{
    //public enum EnumDugUpIslandStatus {Diamonds, Water, EmptyHole, EmptyHole2, EmptyHole3, EmptyHole4, EmptyHole5, emptyHole6 }
    // enum EnumIslandStatus { Island, IslandFarmer, IslandHole}

    public partial class frmStrikeRich : Form
    {
        String path = Application.StartupPath + @"\Images\";
        List<PictureBox> Island;
        int i = 0;
        int t = 0;
        int n = 0;

        public frmStrikeRich()
        {
            InitializeComponent();
            HideDiamondAndWater();
            Island = new() { pbIsland1, pbIsland2, pbIsland3, pbIsland4, pbIsland5, pbIsland6, pbIsland7, pbIsland8, pbIsland9, pbIsland10, pbIsland11, pbIsland12 };
            Island.ForEach(i => i.ImageLocation = path + "Island.png");
            btnStartGo.Click += BtnStartGo_Click;
            Island.ForEach(i => i.Click += I_Click);
            Island.ForEach(i => i.Enabled = false);
        }

        private void IslandImage(string picture)
        {
            Island[i].Enabled = true;
            Island[i].ImageLocation = path + picture;
        }

        private void HideDiamondAndWater()
        {
            Random rnd = new();
            t = rnd.Next(0, 12);
            n = rnd.Next(0, 12);
            if(t == n)
            {
                n = rnd.Next(0, 12);
            }
        }
        private void Go()
        {
            IslandImage("Island.png");
            txtInstructions.Text = "The poor farmer desperately wants to find the diamond that " +
                "is \r\nhidden deep under one of these islands. He will dig up the islands until he uncovers the " +
                "\r\ndiamond. Some of these islands can become flooded with water if dug up, watch out." +
                " \r\nClick on the island if you choose that the farmer should dig up the island. Click on the go " +
                "\r\nbutton if you want the farmer to continue to the next island. Good Luck! ";
            if (i < 11)
            {
                if (btnStartGo.Text == "GO")
                {
                    i++;
                }
                IslandImage("IslandFarmer.png");
            }
            else
            {
                i = 0;
                IslandImage("IslandFarmer.png");
            }
            btnStartGo.Text = "GO";
        }
 
        private void BtnStartGo_Click(object? sender, EventArgs e)
        {
            Go();
        }
        private void IslandChange()
        {
            if (t == i)
            {
                IslandImage("IslandDiamond.png");
                txtInstructions.Text = "THE FARMER STRUCK IT RICH";
            }
            else if (n == i)
            {
                IslandImage("IslandWater.png");
            }
            else
            {
                IslandImage("IslandHole.png");
            }
        }
        private void I_Click(object? sender, EventArgs e)
        {
            IslandChange();
        }
    }
}
