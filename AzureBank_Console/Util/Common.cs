using AzureBankDLL.BL;
using AzureBankDLL.DLInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AzureBankConsole.Util
{
    internal class Common
    {
        public static void ShowAllUsers(IUser userDL, List<User> users)
        {
            MainUi.Header();
            users = userDL.ReadAll();
            int i = 0;
            AdminUi.userInfoHeader();
            foreach (User usr in users) {
                Console.WriteLine($"{i}, {usr.toString()}");
                i++;
            }
        }
        public static void ChangePassword(IUser userDL, User user) 
        {
            MainUi.Header();

            string newPass = UtilUi.GetMaskedInput("Set new password: ");

            UtilUi.Process();
            user.setPassword(newPass);
            userDL.Update(user);

            UtilUi.Success("Password Changed Successfully");
        }

        public static void SignUp(IUser userDL)
        {
            MainUi.Header();
            string name = UserUi.GetName();
            //userName is not unique so back to menu
            if (userDL.UserNameExists(name))
            {
                UtilUi.Process();
                UtilUi.Error("User already exists.");
                return;
            }
            string password = UtilUi.GetMaskedInput();   // as user unique so getting password
            UtilUi.Process();
            userDL.Create(new User(name, password));
            UtilUi.Success("User Created Successfully");
        }
    }
}
