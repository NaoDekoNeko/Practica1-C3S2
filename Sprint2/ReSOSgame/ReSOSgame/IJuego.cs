using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReSOSgame
{
    public interface IJuegoTerminado
    {
        bool JuegoTerminado();
    }
    public interface IJuegoGanado
    {
        bool JuegoGanado();
    }
}
