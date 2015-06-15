using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConfederateWar
{
    public partial class ConfederateWar : Form, IControlCenter
    {
        private string allyName;
        private Label[] arrLevelLabel = new Label[6];
        private Label[] arrLifeLabel = new Label[6];
        private Label[] arrMagicLabel = new Label[6];
        private Label[] arrNameLabel = new Label[6];
        private PictureBox[] arrPictureBox = new PictureBox[6];
        private int headerPictureSelectIndex = 0;
        private Player[] player;
        private List<IPlayer> Players;
        private Random random = new Random();
        private ResourceManager rm = new ResourceManager("ConfederateWar.Properties.Resources", typeof(ConfederateWar).Assembly);
        private int teamPeopleNumber = 0;

        public ConfederateWar(string Name)
        {
            this.allyName = Name;

            Players = new List<IPlayer>();

            InitializeComponent();

            AllyGroupBox.Text = this.allyName;

            UpdateMsgTextBox("[系統訊息]");
            player = new Player[6];

            CreatePlayerData();

            arrPictureBox[0] = PlayerOnePictureBox;
            arrPictureBox[1] = PlayerTwoPictureBox;
            arrPictureBox[2] = PlayerThreePictureBox;
            arrPictureBox[3] = PlayerFourPictureBox;
            arrPictureBox[4] = PlayerFivePictureBox;
            arrPictureBox[5] = PlayerSixPictureBox;

            arrNameLabel[0] = PlayerOneNameLabel;
            arrNameLabel[1] = PlayerTwoNameLabel;
            arrNameLabel[2] = PlayerThreeNameLabel;
            arrNameLabel[3] = PlayerFourNameLabel;
            arrNameLabel[4] = PlayerFiveNameLabel;
            arrNameLabel[5] = PlayerSixNameLabel;

            arrLevelLabel[0] = PlayerOneLevelLabel;
            arrLevelLabel[1] = PlayerTwoLevelLabel;
            arrLevelLabel[2] = PlayerThreeLevelLabel;
            arrLevelLabel[3] = PlayerFourLevelLabel;
            arrLevelLabel[4] = PlayerFiveLevelLabel;
            arrLevelLabel[5] = PlayerSixLevelLabel;

            arrLifeLabel[0] = PlayerOneLifeLabel;
            arrLifeLabel[1] = PlayerTwoLifeLabel;
            arrLifeLabel[2] = PlayerThreeLifeLabel;
            arrLifeLabel[3] = PlayerFourLifeLabel;
            arrLifeLabel[4] = PlayerFiveLifeLabel;
            arrLifeLabel[5] = PlayerSixLifeLabel;

            arrMagicLabel[0] = PlayerOneMagicLabel;
            arrMagicLabel[1] = PlayerTwoMagicLabel;
            arrMagicLabel[2] = PlayerThreeMagicLabel;
            arrMagicLabel[3] = PlayerFourMagicLabel;
            arrMagicLabel[4] = PlayerFiveMagicLabel;
            arrMagicLabel[5] = PlayerSixMagicLabel;
        }

        public string AllyName
        {
            get
            {
                return allyName;
            }
            set
            {
                allyName = value;
            }
        }

        public int TeamPeopleNumber
        {
            get { return teamPeopleNumber; }
            set
            {
                if ((value > -1) && (value < 7))
                {
                    teamPeopleNumber = value;
                }
            }
        }

        private int HeaderPictureSelectIndex
        {
            get
            {
                return headerPictureSelectIndex;
            }
            set
            {
                if ((value > -1) && (value < 138))
                {
                    headerPictureSelectIndex = value;
                }
            }
        }

        public void join(IPlayer p)
        {
            Players.Add(p);
            UpdateMsgTextBox("[" + p.Name + "]" + " 加入隊伍了.");
        }

        public void Notify()
        {
            foreach (IPlayer player in Players)
            {
                this.UpdateMsgTextBox(player.Say());
            }
        }

        public void Quit(IPlayer p)
        {
            UpdateMsgTextBox("[" + p.Name + "]" + " 蒙祖寵召了.");
            Players.Remove(p);
        }

        public void UpdateMsgTextBox(string NewMsg)
        {
            this.MsgTextBox.Text += NewMsg + Environment.NewLine;
            this.MsgTextBox.SelectionStart = this.MsgTextBox.Text.Length - 1;
            this.MsgTextBox.ScrollToCaret();
        }

        private void AddPlayer()
        {
            TeamPeopleNumber = 0;

            do
            {
                if (arrNameLabel[TeamPeopleNumber].Text == "")
                {
                    player[TeamPeopleNumber] = new Player(this.NameTextBox.Text, this.HeaderPictureSelectIndex.ToString(), int.Parse(this.LevelTextBox.Text), double.Parse(this.LifeTextBox.Text), double.Parse(this.MagicTextBox.Text));

                    this.arrPictureBox[TeamPeopleNumber].Image = rm.GetObject("_" + player[TeamPeopleNumber].HeaderPictureIndex.ToString()) as Image;
                    this.arrNameLabel[TeamPeopleNumber].Text = player[TeamPeopleNumber].Name;
                    this.arrLevelLabel[TeamPeopleNumber].Text = player[TeamPeopleNumber].Level.ToString();
                    this.arrLifeLabel[TeamPeopleNumber].Text = player[TeamPeopleNumber].Life.ToString();
                    this.arrMagicLabel[TeamPeopleNumber].Text = player[TeamPeopleNumber].Magic.ToString();

                    this.join(player[TeamPeopleNumber]);

                    CreatePlayerData();
                    break;
                }

                TeamPeopleNumber++;
            } while (TeamPeopleNumber < 6);

            if (TeamPeopleNumber > 5)
            {
                UpdateMsgTextBox("隊伍人數已滿.");
                MessageBox.Show("隊伍人數已滿.");
            }
        }

        private void AttackButton_Click(object sender, EventArgs e)
        {
            if (Players.Count() != 0)
            {
                int Index = random.Next(0, Players.Count() - 1);
                UpdateMsgTextBox(Players[Index].BeAttacked(random.Next(0, 9999), Players));
                ReFlash(Players[Index]);

                if (Players[Index].Life < 0)
                {
                    this.RemovePlayer(Players[Index]);
                }
            }
            else
            {
                MessageBox.Show("目前隊伍沒有成員了!~先加入成員吧!~");
            }
        }

        private void CreatePlayerData()
        {
            int tempLevel = random.Next(1, 99);

            this.PlayerSelectPictureBox.Image = rm.GetObject("_" + HeaderPictureSelectIndex.ToString()) as Image;
            this.NameTextBox.Text = "勇者" + HeaderPictureSelectIndex.ToString();
            this.LevelTextBox.Text = tempLevel.ToString();
            this.LifeTextBox.Text = Convert.ToString(tempLevel * random.Next(1, 99));
            this.MagicTextBox.Text = Convert.ToString(tempLevel * random.Next(1, 99));
        }

        private void HelloWorldButton_Click(object sender, EventArgs e)
        {
            this.Notify();
        }

        private void JoinButton_Click(object sender, EventArgs e)
        {
            this.AddPlayer();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            HeaderPictureSelectIndex++;
            this.CreatePlayerData();
        }

        private void PreviousButton_Click(object sender, EventArgs e)
        {
            HeaderPictureSelectIndex--;
            this.CreatePlayerData();
        }

        private void ReFlash(IPlayer p)
        {
            for (int i = 0; i < arrNameLabel.Length; i++)
            {
                if (arrNameLabel[i].Text == p.Name)
                {
                    this.arrPictureBox[i].Image = rm.GetObject("_" + player[i].HeaderPictureIndex.ToString()) as Image;
                    this.arrNameLabel[i].Text = player[i].Name;
                    this.arrLevelLabel[i].Text = player[i].Level.ToString();
                    this.arrLifeLabel[i].Text = player[i].Life.ToString();
                    this.arrMagicLabel[i].Text = player[i].Magic.ToString();
                }
            }
        }

        private void RemovePlayer(IPlayer p)
        {
            for (int i = 0; i < arrNameLabel.Length; i++)
            {
                if (arrNameLabel[i].Text == p.Name)
                {
                    this.arrPictureBox[i].Image = rm.GetObject("NoName") as Image;
                    this.arrNameLabel[i].Text = "";
                    this.arrLevelLabel[i].Text = "";
                    this.arrLifeLabel[i].Text = "";
                    this.arrMagicLabel[i].Text = "";
                }
            }

            this.Quit(p);
        }
    }
}