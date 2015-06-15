using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfederateWar
{
    public interface IControlCenter
    {
        string AllyName { get; set; }

        void join(IPlayer p);

        void Notify();

        void Quit(IPlayer p);
    }
}