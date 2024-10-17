using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoFinalBilleterie.Exceptions
{
    internal class ReservationException : Exception
    {
        public ReservationException(string message) :base(message) { }
    }
}
