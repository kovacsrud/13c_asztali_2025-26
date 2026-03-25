using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversionPrinciple
{
    public class JoUserService
    {
        //Absztrakció
        private IDatabase database;

        public JoUserService(IDatabase database)
        {
            this.database = database;
        }

        public void UserMentes(string user)
        {
            database.Mentes(user);
        }

    }
}
