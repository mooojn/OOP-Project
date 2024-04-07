using AzureBankDLL.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureBankDLL.DLInterfaces
{
    public interface IUserFunc
    {
        //int CheckPortfolio(string userName);
        void DepositCash(string userName, int amount);
        void WithdrawCash(string userName, int amount);
        void TransferCash(string sender, string reciever, int amount);
    }
}
