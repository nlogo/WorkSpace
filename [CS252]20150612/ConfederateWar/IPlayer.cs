using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConfederateWar
{
    public interface IPlayer
    {
        string HeaderPictureIndex { get; set; }

        int Level { get; set; }

        double Life { get; set; }

        double Magic { get; set; }

        string Name { get; set; }

        string BeAttacked(double SubLife, List<IPlayer> Players);

        string CurrentlyFighting(string FightingMsg, List<IPlayer> Players);

        string Say();
    }
}