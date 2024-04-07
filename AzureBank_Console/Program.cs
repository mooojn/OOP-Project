using System;
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

        logout:
            string choice = "";
            while (true)
            {
                choice = MainUi.Menu();
                switch (choice)
                {
                    case Choice.LOGIN:
                        MainUi.Header();
                        User user = UserUi.GetUserInput();

                        UtilUi.Process();
                        //admin password is correct
                        if (!userDL.UserNameExists(user.getName()))
                        {
                            UtilUi.Error("User does not exist...");
                            break;
                        }
                        int res = userDL.FindUser(user);        // 1 for admin, 2 for user, 0 for invalid password
                        if (res == 1 || res == 2)
                            UtilUi.Success("Authentication was Successful");
                        if (res == 1)
                            goto adminLogin;
                        else if (res == 2)
                            goto userLogin;
                        else
                        {
                            UtilUi.Error("Invalid Password");
                            break;
                        }
                    case Choice.USER_SIGN_UP:
                        MainUi.Header();
                        string name = UserUi.GetName();
                        //userName is not unique so back to menu
                        if (userDL.UserNameExists(name))
                        {
                            UtilUi.Process();
                            UtilUi.Error("User already exists.");
                            break;
                        }
                        string password = UtilUi.GetMaskedInput();   // as user unique so getting password
                        UtilUi.Process();
                        userDL.Create(new User(name, password));
                        UtilUi.Success("User Created Successfully");
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
            while (true)
            {
                choice = MainUi.AdminMenu();
                switch (choice)
                {
                    case Choice.ADD_USER:
                        Console.WriteLine("Add New User");
                        Console.ReadKey();
                        break;

                    case Choice.VIEW_USERS:
                        Console.WriteLine("View Users");
                        Console.ReadKey();
                        break;

                    case Choice.CHANGE_USER_NAME:
                        Console.WriteLine("Change User Name");
                        Console.ReadKey();
                        break;

                    case Choice.DELETE_USER:
                        Console.WriteLine("Delete User");
                        Console.ReadKey();
                        break;

                    case Choice.ADMIN_LOGOUT:
                        goto logout;

                    default:
                        UtilUi.InvalidChoice();
                        break;
                }
            }
        userLogin:
            while (true)
            {
                choice = MainUi.UserMenu();
                switch (choice)
                {
                    case Choice.CHECK_PORTFOLIO:
                        //UserFunc.CheckPortfolio();
                        break;

                    case Choice.DEPOSIT_CASH:
                        //UserFunc.DepositCash();
                        break;

                    case Choice.WITHDRAW_CASH:
                        //UserFunc.WithdrawCash();
                        break;

                    case Choice.BLOCK_TRANSACTIONS:
                        Console.WriteLine("Block Transactions");
                        break;

                    case Choice.DELETE_ACCOUNT:
                    //UserFunc.DeleteAccount();
                    //goto logout;   // after deleting account, user is logged out

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
