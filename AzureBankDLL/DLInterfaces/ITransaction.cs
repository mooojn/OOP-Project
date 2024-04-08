using AzureBankDLL.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureBankDLL.DLInterfaces
{
    public interface ITransaction
    {
        bool Save(string name, History history);
        List<History> ReadAll(string name);
    }
}
