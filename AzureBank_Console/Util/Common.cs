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
    // this class is used to store common methods b/w client and admin
    internal class Common
    {
        public static void ShowAllUsers(IUser userDL, List<User> users)
        {
            users = userDL.ReadAll();
            if (users == null) {
                UtilUi.Error("No Users Found", false);    // no users found in database
                return;
            }
            MainUi.Header();
            
            // show all users
            AdminUi.UserInfoHeader();
            for (int i = 0; i < users.Count; i++)
                Console.WriteLine($"{i}, {users[i].toString()}");
        }
        public static void ChangePassword(IUser userDL, User user) 
        {
            MainUi.Header();
            string newPass = UtilUi.GetMaskedInput("Set new password: ");   // get new password
            
            // set new pass
            UtilUi.Process();
            user.setPassword(newPass);
            userDL.Update(user);

            UtilUi.Success("Password Changed Successfully");
        }

        public static bool SignUp()
        {
            MainUi.Header();
            string name = UserUi.GetName();
            if (ObjectHandler.GetUserDL().UserNameExists(name)) {
                UtilUi.Process();
                UtilUi.Error("User already exists.");    //userName is not unique so back to menu
                return false;
            }
            string password = UtilUi.GetMaskedInput();    // as user unique so getting password
            UtilUi.Process();
            User user = new User(name, password);
            ObjectHandler.GetUserDL().Create(user);    // create new user
            return true;
        }
    }
}
