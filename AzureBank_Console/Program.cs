﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AzureBankDLL.DLInterfaces;
using AzureBankDLL.DL;
using AzureBankDLL.BL;
using AzureBankDLL.DL.DB;
using AzureBankConsole.Util;


namespace AzureBankConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IUser userDL = new UserDB();
            ITransaction transactionDL = new TransactionDB();
            IAsset assetDL = new AssetDB();

        logout:
            User user;
            string name;
            string password;
            string choice;
            while (true) {
                choice = MainUi.Menu();
                switch (choice) {
                    case Choice.LOGIN:
                        MainUi.Header();

                        name = UserUi.GetName();

                        //admin password is correct
                        if (!userDL.UserNameExists(name)) {
                            UtilUi.Process();
                            UtilUi.Error("User does not exist...");
                            break;
                        }
                        password = UtilUi.GetMaskedInput();
                        UtilUi.Process();
                        user = new User(name, password);
                        int res = userDL.FindUser(user);        // 1 for admin, 2 for user, 0 for invalid password
                        if (res == 1 || res == 2) {
                            user = userDL.Read(user.getName());
                            UtilUi.Success("Authentication was Successful");
                        }
                        if (res == 1)
                            goto adminLogin;
                        else if (res == 2)
                            goto userLogin;
                        else {
                            UtilUi.Error("Invalid Password");
                            break;
                        }
                    case Choice.USER_SIGN_UP:
                        Common.SignUp(userDL);
                        break;
                    case Choice.EXIT:
                        Environment.Exit(0);
                        break;
                    default:
                        UtilUi.InvalidChoice();
                        break;
                }
            }
        adminLogin:
            List<User> users;
            List<Asset> assets;
            while (true) {
                choice = MainUi.AdminMenu();
                switch (choice) {
                    case Choice.CHECK_BANKS_LIQUIDITY:
                        MainUi.Header();
                       
                        int liquidity = 0;
                        assets = assetDL.ReadAll();
                        users = userDL.ReadAll();
                        
                        assets.ForEach(a => liquidity += a.getWorth());
                        users.ForEach(u => liquidity += u.getCash());
                        
                        Console.WriteLine($"Total available Liquidity: ${liquidity}");
                        UtilUi.PressAnyKey();
                        
                        break;

                    case Choice.ADD_USER:
                        int num = -1;
                        while (num != 0) {
                            Common.SignUp(userDL);
                            num = AdminUi.GetAnotherInput();
                        }
                        break;
                    
                    case Choice.ADD_ASSET:
                        MainUi.Header();
                        Asset asset = AdminUi.GetAssetInput();
                        assetDL.Create(asset);
                        UtilUi.Success("Asset Added Successfully");
                        break;

                    case Choice.VIEW_USERS:
                        users = userDL.ReadAll();
                        Common.ShowAllUsers(userDL, users);
                        UtilUi.PressAnyKey();
                        break;

                    case Choice.VIEW_ASSETS:
                        MainUi.Header();
                        assets = assetDL.ReadAll();
                        AdminUi.assetInfoHeader();
                        int i = 0;
                        foreach (Asset a in assets) {
                            Console.WriteLine($"{i}, {a.toString()}");
                            ++i;
                        }
                        UtilUi.PressAnyKey();
                        break;
                    
                    case Choice.DELETE_USER:
                        users = userDL.ReadAll();
                        Common.ShowAllUsers(userDL, users);
                        
                        int index = AdminUi.GetIndex();
                        if (index < 0 || index >= users.Count) {
                            UtilUi.Process();
                            UtilUi.Error("Invalid Index");
                            break;
                        }
                        UtilUi.Process();
                        userDL.Delete(users[index].getName());
                        
                        Common.ShowAllUsers(userDL, users);
                        UtilUi.PressAnyKey();

                        break;
                    case Choice.CHANGE_ADMIN_Password:
                        Common.ChangePassword(userDL, user);
                        break;

                    case Choice.ADMIN_LOGOUT:
                        goto logout;

                    default:
                        UtilUi.InvalidChoice();
                        break;
                }
            }
        userLogin:
            int amount;
            int status;
            while (true) {
                choice = MainUi.UserMenu();
                switch (choice) {
                    case Choice.CHECK_PORTFOLIO:
                        MainUi.Header();
                        Console.WriteLine($"Cash: ${user.getCash()}");
                        Console.ReadKey();
                        break;

                    case Choice.DEPOSIT_CASH:
                        if (!user.getTransactionStatus()) {
                            UtilUi.Error("Transactions are Blocked");
                            break;
                        }
                        MainUi.Header();
                        amount = UserUi.GetAmount("Deposit");
                        status = user.DepositCash(amount);
                        if (status == -1)
                            UtilUi.Error("Invalid Amount");
                        else if (status == -2)
                            UtilUi.Error("Deposit Amount can't be Zero");
                        else {
                            UtilUi.Success("Cash Deposited Successfully");
                            userDL.Update(user);
                            transactionDL.Save(user.getName(), new History("Deposit", amount));
                        }

                        break;

                    case Choice.WITHDRAW_CASH:
                        if (!user.getTransactionStatus()) {
                            UtilUi.Error("Transactions are Blocked");
                            break;
                        }
                        MainUi.Header();
                        amount = UserUi.GetAmount("Withdraw");
                        status = user.WithdrawCash(amount);
                        if (status == -1)
                            UtilUi.Error("Invalid Amount");
                        else if (status == -2)
                            UtilUi.Error("Withdraw Amount can't be Zero");
                        else if (status == -3)
                            UtilUi.Error("Withdraw Amount was greater than available Balance");
                        else {
                            UtilUi.Success("Cash Withdrawal was Successful");
                            userDL.Update(user);
                            transactionDL.Save(user.getName(), new History("Withdraw", amount));
                        }
                        break;
                    case Choice.TRANSFER_CASH:
                        if (!user.getTransactionStatus()) {
                            UtilUi.Error("Transactions are Blocked");
                            break;
                        }
                        MainUi.Header();
                        amount = UserUi.GetAmount("Transfer");
                        name = UserUi.GetName("Enter the name of the reciever: ");
                        User usr = userDL.Read(name);
                        if (usr == null) {
                            UtilUi.Error("User does not exist");
                            break;
                        }
                        status = user.TransferCash(usr, amount);
                        if (status == -1)
                            UtilUi.Error("Invalid Amount");
                        else if (status == -2)
                            UtilUi.Error("Transfer Amount can't be Zero");
                        else if (status == -3)
                            UtilUi.Error("Transfer Amount was greater than available Balance");
                        else {
                            UtilUi.Success("Cash Transfer was Successful");
                            userDL.Update(user);
                            userDL.Update(usr);
                            // as in transfer, amount is withdrawn from one account and deposited in another
                            transactionDL.Save(user.getName(), new History("Withdraw", amount));
                            transactionDL.Save(usr.getName(), new History("Deposit", amount));
                        }
                        break;

                    case Choice.VIEW_TRANSACTIONS_HISTORY:
                        MainUi.Header();
                        List<History> history = transactionDL.ReadAll(user.getName());
                        UserUi.TransactionHeader();
                        foreach (History h in history) {
                            Console.WriteLine(h.toString());
                        }
                        UtilUi.PressAnyKey();
                        break;

                    case Choice.BLOCK_TRANSACTIONS:
                        bool flag = user.getTransactionStatus();
                        string res = flag ? "Blocked" : "Unblocked";
                        user.setTransactionStatus(!flag);
                        userDL.Update(user);
                        UtilUi.Success($"Transaction Status {res} Successfully");
                        break;
                    case Choice.CHANGE_USER_PASSWORD:
                        Common.ChangePassword(userDL, user);
                        break;
                    case Choice.DELETE_ACCOUNT:
                        userDL.Delete(user.getName());
                        goto logout;   // after deleting account, user is logged out

                    case Choice.USER_LOGOUT:
                        goto logout;

                    default:
                        UtilUi.InvalidChoice();
                        break;
                }
            } 
        }
    }
}
