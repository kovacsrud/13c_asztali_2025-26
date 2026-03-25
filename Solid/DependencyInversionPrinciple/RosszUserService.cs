using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversionPrinciple
{
    public class RosszUserService
    {
        //függőség
        private MysqlDB mysql=new MysqlDB();

        public void UserMentes(string user)
        {
            mysql.DbMentes(user);
        }

    }
}
