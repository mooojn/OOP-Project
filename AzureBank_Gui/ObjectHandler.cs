using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzureBankDLL.DLInterfaces;
using AzureBankDLL.DL.DB;
using AzureBankDLL.DL.FH;
using AzureBankDLL.BL;

namespace AzureBankGui
{
    internal class ObjectHandler
    {
        private static IUser userDL = new UserFH();
        private static ITransaction transactionDL = new TransactionFH();
        private static IAsset assetDL = new AssetFH();
        public static IUser GetUserDL() 
        {
            return userDL;
        }
        public static ITransaction GetTransactionDL()
        {
            return transactionDL;
        }
        public static IAsset GetAssetDL()
        {
            return assetDL;
        }
    }
}
