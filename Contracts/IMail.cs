using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangar.Restaurant.Contracts
{
    public interface IMail
    {
        Task ReservationAsync(string email, string name, DateTime dateAndTime, int person);
        void Contact(string email, string message);
        void Subscribe(string email);
    }
}
