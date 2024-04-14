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
        private static IUser userDL = new UserDB();
        private static ITransaction transactionDL = new TransactionDB();
        private static IAsset assetDL = new AssetDB();
        private static IAccount accountDL = new AccountDB();
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
        public static IAccount GetAccountDL()
        {
            return accountDL;
        }
    }
}
