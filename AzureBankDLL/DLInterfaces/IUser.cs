using AzureBankDLL.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureBankDLL.DLInterfaces
{
    public interface IUser
    {
        bool Create(User user);
        User Read(string userName);
        bool Update(User user);
        bool Delete(string userName);
        bool UserNameExists(string name);
        int FindUser(User usr);
        List<User> ReadAll();
        List<string> ReadAllNames(string nameToExclude);
        void NUKE();
    }
}
