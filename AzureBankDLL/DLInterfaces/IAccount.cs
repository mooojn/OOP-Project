using AzureBankDLL.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureBankDLL.DLInterfaces
{
    public interface IAccount
    {
        bool Create(Account acc);
        Account Read(string name);
        bool Update(Account account);
    }
}
