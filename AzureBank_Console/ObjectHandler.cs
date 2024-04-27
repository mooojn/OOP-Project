using AzureBankConsole.Util;
using AzureBankDLL.DL.FH;
using AzureBankDLL.DLInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzureBankDLL.DL.DB;

namespace AzureBankConsole
{
    internal class ObjectHandler
    {
        // file paths
        public const string USER_FILE = "D:\\c# files\\OOP-Project\\FileHandling\\users.csv";
        public const string ASSET_FILE = "D:\\c# files\\OOP-Project\\FileHandling\\assets.csv";
        public const string ACCOUNT_FILE = "D:\\c# files\\OOP-Project\\FileHandling\\accounts.csv";
        public const string TRANSACTION_FILE = "D:\\c# files\\OOP-Project\\FileHandling\\transactions.csv";

        // file_handling objects
        //private static IUser userDL = UserFH.getInstance(USER_FILE);
        //private static ITransaction transactionDL = TransactionFH.getInstance(TRANSACTION_FILE);
        //private static IAsset assetDL = AssetFH.getInstance(ASSET_FILE);
        //private static IAccount accountDL = AccountFH.getInstance(ACCOUNT_FILE);

        // database objects
        private static IUser userDL = UserDB.getInstance();
        private static ITransaction transactionDL = TransactionDB.getInstance();
        private static IAsset assetDL = AssetDB.getInstance();
        private static IAccount accountDL = AccountDB.getInstance();

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
