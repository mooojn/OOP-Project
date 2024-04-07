using AzureBankDLL.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzureBankDLL.DLInterfaces;

namespace AzureBankDLL.DL.FH
{
    internal class StudentFH // : IUser           /// removee this commmecntt pzllzzz
    {
        public bool Create(User user)
        {
            return false;
        }
        public User Read(string userName)
        {
            return null;
        }
        public bool Update(User user)
        {
            return false;
        }
        public bool Delete(string userName)
        {
            return false;
        }
    }
}
