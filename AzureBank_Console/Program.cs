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

namespace AzureBankConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IUser userDL = new UserFH();

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
            while (true) {
                choice = MainUi.AdminMenu();
                switch (choice) {
                    case Choice.ADD_USER:
                        int num = -1;
                        while (num != 0) {
                            Common.SignUp(userDL);
                            num = AdminUi.GetAnotherInput();
                        }
                        break;
                    
                    case Choice.VIEW_USERS:
                        users = userDL.ReadAll();
                        Common.ShowAllUsers(userDL, users);
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
                        MainUi.Header();

                        string newPass = UtilUi.GetMaskedInput("Set new password: ");

                        UtilUi.Process();
                        user.setPassword(newPass);
                        userDL.Update(user);

                        UtilUi.Success("Password Changed Successfully");
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
                        amount = UserUi.GetDepositAmount();
                        status = user.DepositCash(amount);
                        if (status == -1)
                            UtilUi.Error("Invalid Amount");
                        else if (status == -2)
                            UtilUi.Error("Deposit Amount can't be Zero");
                        else {
                            UtilUi.Success("Cash Deposited Successfully");
                            userDL.Update(user);
                        }

                        break;

                    case Choice.WITHDRAW_CASH:
                        if (!user.getTransactionStatus()) {
                            UtilUi.Error("Transactions are Blocked");
                            break;
                        }
                        MainUi.Header();
                        amount = UserUi.GetWithdrawAmount();
                        status = user.WithdrawCash(amount);
                        if (status == -1)
                            UtilUi.Error("Invalid Amount");
                        else if (status == -2)
                            UtilUi.Error("Deposit Amount can't be Zero");
                        else if (status == -3)
                            UtilUi.Error("Deposit Amount was greater than available Balance");
                        else {
                            UtilUi.Success("Cash Withdrawal was Successful");
                            userDL.Update(user);
                        }
                        break;
                    case Choice.TRANSFER_CASH:
                        if (!user.getTransactionStatus()) {
                            UtilUi.Error("Transactions are Blocked");
                            break;
                        }
                        MainUi.Header();
                        amount = UserUi.GetWithdrawAmount();
                        name = UserUi.GetName();
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
                        }
                        break;

                    case Choice.BLOCK_TRANSACTIONS:
                        bool flag = user.getTransactionStatus();
                        string res = flag ? "Blocked" : "Unblocked";
                        user.setTransactionStatus(!flag);
                        userDL.Update(user);
                        UtilUi.Success($"Transaction Status {res} Successfully");
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
