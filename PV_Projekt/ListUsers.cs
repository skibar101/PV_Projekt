using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV_Projekt
{
    internal class ListUsers : ICommand
    {
        void ICommand.Execute()
        {
            ZakaznikDao dao = new ZakaznikDao();

            var all = dao.GetAll().ToList();

            Console.WriteLine(all);
        }

        string ICommand.GetInfo()
        {
            return "Neco o prikazu, pripadne popsat argumenty";
        }

        string ICommand.GetName()
        {
            return "ListUsers";
        }

        bool ICommand.ValidateInput(string input)
        {
           
            return false;
        }

    }
}
