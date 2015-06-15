using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConfederateWar
{
    internal class Player : IPlayer
    {
        private string headerPictureIndex;
        private int level;
        private double life;
        private double magic;
        private string name;
        private string tempmsg;

        public Player(string Name, string HeaderPictureIndex, int Level, double Life, double Magic)
        {
            this.Name = Name;
            this.HeaderPictureIndex = HeaderPictureIndex;
            this.Level = Level;
            this.Life = Life;
            this.Magic = Magic;
        }

        public string HeaderPictureIndex
        {
            get
            {
                return headerPictureIndex;
            }
            set
            {
                headerPictureIndex = value;
            }
        }

        public int Level
        {
            get
            {
                return level;
            }
            set
            {
                level = value;
            }
        }

        public double Life
        {
            get
            {
                return life;
            }
            set
            {
                life = value;
            }
        }

        public double Magic
        {
            get
            {
                return magic;
            }
            set
            {
                magic = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string BeAttacked(double SubLife, List<IPlayer> Players)
        {
            tempmsg = "";

            if ((this.Life -= SubLife) > 0)
            {
                tempmsg = "我是" + Name + "我被打了!! 只剩" + Life + "生命值 ";
                foreach (IPlayer player in Players)
                {
                    if (player.Name != this.name)
                        tempmsg += player.Name + " ";
                }

                tempmsg += "快來救我";
            }
            else
            {
                tempmsg = Name + "遭受強力攻擊!~ 損失" + SubLife + "生命值";
            }

            return string.Format(tempmsg);
        }

        public string CurrentlyFighting(string FightingMsg, List<IPlayer> Players)
        {
            return "Test";
        }

        public string Say()
        {
            return string.Format("Hello 我是" + Name + "大家好");
        }
    }
}