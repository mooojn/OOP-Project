using AzureBankDLL.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzureBankDLL.DLInterfaces;

namespace AzureBankDLL.DL.FH
{
    public class UserFH  //: IUser           /// removee this commmecntt pzllzzz
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
        public bool UserNameExists(string name)
        {
            return false;
        }
        public int FindUser(User usr)
        {
            return 0;
        }
    }
}
