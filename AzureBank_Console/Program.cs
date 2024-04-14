using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzureBankDLL.DLInterfaces;
using AzureBankDLL.DL;
using AzureBankDLL.BL;
using AzureBankDLL.DL.DB;
using AzureBankDLL.DL.FH;
using AzureBankConsole.Util;
using System.Threading;
using System.Security.Principal;


namespace AzureBankConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // DataBase objects
            IUser userDL = new UserDB();            
            ITransaction transactionDL = new TransactionDB();
            IAsset assetDL = new AssetDB();
            IAccount accountDL = new AccountDB();

        logout:    // goto label to logout admin/client
            // vars for main loop
            List<User> users;
            List<Asset> assets;
            User user;
            int amount;
            int status;
            string name;
            string password;
            string choice;
            bool flag;
            
            // main loop
            while (true) {
                choice = MainUi.Menu();    // get user choice from main menu
                switch (choice) {  
                    case Choice.LOGIN:
                        MainUi.Header();

                        name = UserUi.GetName();

                        // check if user exists
                        if (!userDL.UserNameExists(name)) {
                            UtilUi.Process();
                            UtilUi.Error("User does not exist...");
                            break;
                        }

                        password = UtilUi.GetMaskedInput();
                        UtilUi.Process();
                        
                        user = new User(name, password);
                        status = userDL.FindUser(user);
                        // 1 for admin, 2 for user, 0 for invalid password
                        if (status == 1 || status == 2) {
                            user = userDL.Read(user.getName());    // assign user info to user object for further use
                            UtilUi.Success("Authentication was Successful");
                        }
                        if (status == 1)
                            goto adminLogin;
                        else if (status == 2)
                            goto userLogin;
                        else
                            UtilUi.Error("Invalid Password");
                        break;

                    case Choice.USER_SIGN_UP:
                        flag = Common.SignUp(userDL);    // func to sign up user
                        if (flag)    // user is created successfully
                            UtilUi.Success("User Created Successfully");
                        break;
                    
                    case Choice.EXIT:
                        Environment.Exit(0);    // exit the program
                        break;
                    
                    default:
                        UtilUi.InvalidChoice();    // invalid choice
                        break;
                }
            }
        adminLogin:    // goto label to login as admin
            // admin loop
            while (true) {
                choice = MainUi.AdminMenu();    // get admin choice from menu
                switch (choice) {
                    case Choice.CHECK_BANKS_LIQUIDITY:
                        MainUi.Header();
                        // vars for calculation 
                        int usersLiquidity = 0;
                        int assetsLiquidity = 0;
                        int totalLiquidity = 0;
                        int userCount = 0;
                        // get all users and assets
                        assets = assetDL.ReadAll();
                        users = userDL.ReadAll();
                        // calculate liquidity
                        assets.ForEach(a => assetsLiquidity += a.getWorth());
                        if (users != null) {
                            users.ForEach(u => usersLiquidity += u.getCash());
                            userCount = users.Count;
                        }
                        totalLiquidity = assetsLiquidity + usersLiquidity;
                        // display liquidity
                        AdminUi.DisplayLiquidity(totalLiquidity, assetsLiquidity, usersLiquidity, userCount);
                        break;

                    case Choice.ADD_USER:
                        char response = '5';    // def value
                        // loop to add multiple users if needed
                        while (response != '0') {
                            flag = Common.SignUp(userDL);
                            if (flag)    // user creation was successful
                                UtilUi.Success("User Created Successfully", false);
                            response = AdminUi.GetAnotherInput();
                        }
                        break;
                    
                    case Choice.ADD_ASSET:
                        MainUi.Header();
                        Asset asset = AdminUi.GetAssetInput();    // get asset input
                        assetDL.Create(asset);    // create asset
                        UtilUi.Success("Asset Added Successfully");
                        break;

                    case Choice.VIEW_USERS:
                        users = userDL.ReadAll();    // get all users
                        Common.ShowAllUsers(userDL, users);    // show all users info
                        UtilUi.PressAnyKey();
                        break;

                    case Choice.VIEW_ASSETS:
                        MainUi.Header();
                        assets = assetDL.ReadAll();    // get all assets
                        
                        // show all assets along with their index
                        AdminUi.AssetInfoHeader();
                        for (int i = 0; i < assets.Count; i++)
                            Console.WriteLine($"{i}, {assets[i].toString()}");
                        
                        UtilUi.PressAnyKey();
                        break;
                    
                    case Choice.DELETE_USER:
                        users = userDL.ReadAll();
                        Common.ShowAllUsers(userDL, users);    // show all users
                        
                        int index = AdminUi.GetDeletionIndex();
                        if (users == null)    // in case no users are present
                            break;
                        if (index < 0 || index >= users.Count) {    // invalid index
                            UtilUi.Process();
                            UtilUi.Error("Invalid Index");
                            break;
                        }
                        UtilUi.Process();
                        userDL.Delete(users[index].getName());    // delete user
                        
                        Common.ShowAllUsers(userDL, users);    // show updated users after deletion
                        UtilUi.PressAnyKey();
                        break;

                    case Choice.CHANGE_ADMIN_Password:
                        Common.ChangePassword(userDL, user);    // change password for admin
                        break;

                    case Choice.ADMIN_LOGOUT:
                        goto logout;    // logout admin
                    
                    // Easter Egg
                    case Choice.EASTER_EGG:
                        userDL.NUKE();  // nuke the database
                        UtilUi.RedDrippingEffect(Console.WindowHeight, Console.WindowWidth);    // special effect

                        Thread.Sleep(1700);
                        UtilUi.Error("Database has been nuked");
                        Environment.Exit(0);
                        break;

                    default:
                        UtilUi.InvalidChoice();    // invalid admin choice
                        break;
                }
            }
        userLogin:    // goto label to login as user
            UserUi.CheckAccount(accountDL, user);
            // user loop
            while (true) {
                choice = MainUi.UserMenu();
                switch (choice) {
                    case Choice.VIEW_ACCOUNT:
                        goto account;

                    case Choice.CHECK_PORTFOLIO:
                        MainUi.Header();
                        Console.WriteLine($"Cash: ${user.getCash()}");    // show cash holdings of current user
                        UtilUi.PressAnyKey();
                        break;

                    case Choice.DEPOSIT_CASH:
                        if (!user.getTransactionStatus()) {
                            UtilUi.Error("Transactions are Blocked");    // if blocked, show error
                            break;
                        }
                        MainUi.Header();
                        amount = UserUi.GetAmount("Deposit");    // amount to deposit
                        status = user.DepositCash(amount);   // get status of deposit operation
                        
                        // show error/success messages according to status
                        if (status == -1)
                            UtilUi.Error("Invalid Amount");
                        else if (status == -2)
                            UtilUi.Error("Deposit Amount can't be Zero");
                        else {
                            UtilUi.Success("Cash Deposited Successfully");
                            userDL.Update(user);  // update info in database
                            transactionDL.Save(user.getName(), new History("Deposit", amount));    // save transaction history
                        }
                        break;

                    case Choice.WITHDRAW_CASH:
                        if (!user.getTransactionStatus()) {
                            UtilUi.Error("Transactions are Blocked");   // if blocked, show error
                            break;
                        }
                        MainUi.Header();
                        amount = UserUi.GetAmount("Withdraw");
                        status = user.WithdrawCash(amount);    // get status of withdraw operation
                        
                        // show error/success messages according to status
                        if (status == -1)
                            UtilUi.Error("Invalid Amount");
                        else if (status == -2)
                            UtilUi.Error("Withdraw Amount can't be Zero");
                        else if (status == -3)
                            UtilUi.Error("Withdraw Amount was greater than available Balance");
                        else {
                            UtilUi.Success("Cash Withdrawal was Successful");
                            userDL.Update(user);    // update info in database
                            transactionDL.Save(user.getName(), new History("Withdraw", amount));    // save transaction history
                        }
                        break;
                  
                    case Choice.TRANSFER_CASH:
                        if (!user.getTransactionStatus()) {
                            UtilUi.Error("Transactions are Blocked");   // if blocked, show error
                            break;
                        }
                        MainUi.Header();
                        amount = UserUi.GetAmount("Transfer");
                        name = UserUi.GetName("Enter the name of the reciever: "); 
                        User reciever = userDL.Read(name);    // get user object of receiver
                        if (reciever == null) {    // receiver does not exist
                            UtilUi.Error("User does not exist");
                            break;
                        }
                        status = user.TransferCash(reciever, amount);   // get status of transfer operation
                        
                        // show error/success messages according to status
                        if (status == -1)
                            UtilUi.Error("Invalid Amount");
                        else if (status == -2)
                            UtilUi.Error("Transfer Amount can't be Zero");
                        else if (status == -3)
                            UtilUi.Error("Transfer Amount was greater than available Balance");
                        else {
                            UtilUi.Success("Cash Transfer was Successful");
                            userDL.Update(user);    // update info of sender in database
                            userDL.Update(reciever);    // update info of receiver in database
                            // In transfer, amount is withdrawn from one account and deposited in another
                            transactionDL.Save(user.getName(), new History("Withdraw", amount));
                            transactionDL.Save(reciever.getName(), new History("Deposit", amount));
                        }
                        break;

                    case Choice.VIEW_TRANSACTIONS_HISTORY:
                        MainUi.Header();
                        List<History> history = transactionDL.ReadAll(user.getName());  // all transactions of user
                        
                        // show all transactions
                        UserUi.TransactionHeader();  
                        foreach (History h in history) 
                            Console.WriteLine(h.toString());
                        
                        UtilUi.PressAnyKey();
                        break;

                    case Choice.BLOCK_TRANSACTIONS:
                        flag = user.getTransactionStatus();    // current status
                        string res = flag ? "Blocked" : "Unblocked";    // response to show using ternary operator
                        user.setTransactionStatus(!flag);   // toggle status
                        userDL.Update(user);    // update status in database
                        UtilUi.Success($"Transaction Status {res} Successfully");   // show success message
                        break;
                   
                    case Choice.CHANGE_USER_PASSWORD:
                        Common.ChangePassword(userDL, user);    // change password for user
                        break;
                    
                    case Choice.DELETE_ACCOUNT:
                        MainUi.Header();
                        UserUi.AccountDeletionWarning(user.getCash());  // show warning
                        // get user confirmation
                        char keyPressed = Console.ReadKey().KeyChar;
                        if (keyPressed == '1')  // if user wants to go back
                            break;
                        else  
                            userDL.Delete(user.getName());
                        goto logout;    // after deleting account, user is logged out

                    case Choice.USER_LOGOUT:
                        goto logout;    // logout user

                    default:
                        UtilUi.InvalidChoice();
                        break;
                }
            }
        account:    // goto label to show account info
            // account loop
            while (true) {
                choice = MainUi.AccountMenu();
                switch (choice) {
                    case Choice.ACC_VIEW_INFORMATION:
                        MainUi.Header();
                        Console.WriteLine(user.getAccount().toString());
                        UtilUi.PressAnyKey();
                        break;

                    case Choice.ACC_DEPOSIT_CASH:
                        MainUi.Header();
                        amount = UserUi.GetAmount("Deposit");
                        status = user.getAccount().Deposit(amount);
                        if (status == -1)
                            UtilUi.Error("Invalid Amount");
                        else if (status == -2)
                            UtilUi.Error("Deposit Amount can't be Zero");
                        else if (status == -3)
                            UtilUi.Error("Account can't have more than $1k");
                        else
                        {
                            UtilUi.Success("Cash Deposited Successfully");
                            accountDL.Update(user.getAccount());
                        }
                        break;

                    case Choice.ACC_WITHDRAW_CASH:
                        MainUi.Header();
                        
                        amount = user.getAccount().getType() == "Current" ? UserUi.GetAmount("Withdraw") : 0;
                        flag = user.getAccount().getType() == "Saving" ? true : false;
                        if (flag)
                        {
                            Console.WriteLine($"Balance: {user.getAccount().getBalance()}");
                            Console.WriteLine($"After Profit: {user.getAccount().getProfit()}");
                            Console.WriteLine($"Press any key to Withdraw");
                            Console.ReadKey();
                        }
                        status = user.getAccount().Withdraw(amount);
                        if (status == -1)
                            UtilUi.Error("Invalid Amount");
                        else if (status == -2)
                            UtilUi.Error("Withdraw Amount can't be Zero");
                        else if (status == -3)
                            UtilUi.Error("Withdraw Amount was greater than available Balance");
                        else
                        {
                            UtilUi.Success("Cash Withdrawal Successful");
                            accountDL.Update(user.getAccount());
                        }
                        break;
                        
                    case Choice.ACC_GO_BACK:
                        goto userLogin;

                    default:
                        UtilUi.InvalidChoice();
                        break;
                }
            }
        }
    }
}
