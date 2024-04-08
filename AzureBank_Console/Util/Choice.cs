﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureBankConsole.Util
{
    internal class Choice
    {
        // main choices
        public const string LOGIN = "1";
        public const string USER_SIGN_UP = "2";
        public const string EXIT = "3";
        // user choices
        public const string CHECK_PORTFOLIO = "1";
        public const string DEPOSIT_CASH = "2";
        public const string WITHDRAW_CASH = "3";
        public const string TRANSFER_CASH = "4";
        public const string BLOCK_TRANSACTIONS = "5";
        public const string DELETE_ACCOUNT = "6";
        public const string USER_LOGOUT = "7";
        // admin choices
        public const string ADD_USER = "1";
        public const string VIEW_USERS = "2";
        public const string DELETE_USER = "3";
        public const string CHANGE_ADMIN_Password = "4";
        public const string ADMIN_LOGOUT = "5";
    }
}
