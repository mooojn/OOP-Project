﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace AzureBankGui.Utils
{
    internal class Validation
    {
        public static bool ValidDepositAmount(int amount)
        {
            if (amount == 0 || amount < 0)
                return false;
            return true;
        }
        public static bool ValidWithdrawAmount(int amount, int balance)
        {
            if (ValidDepositAmount(amount))
                return amount < balance;
            return false;
        }
        public static bool IsValid(string type, string check, bool flag = true)
        {
            if (string.IsNullOrWhiteSpace(check))
            {
                MessageUi.Error($"{type} can't be empty");
                return false;
            }
            else if (check.Length < 3)
            {
                MessageUi.Error($"{type} should at least contain 3 characters");
                return false;
            }
            else if (check.Length > 20)
            {
                MessageUi.Error($"{type} should be less than 20 characters");
                return false;
            }
            else if (check.Contains(" "))
            {
                MessageUi.Error($"{type} can't have a space");
                return false;
            }
            if (flag)
            {
                if (check.Any(char.IsDigit))
                {
                    MessageUi.Error($"{type} can't have a number");
                    return false;
                }

                else if (ContainsSymbol(check))
                {
                    MessageUi.Error($"{type} can't have a special character");
                    return false;
                }
            }
            else 
            {
                if (check.Contains(",")) 
                { 
                    MessageUi.Error($"{type} can't have comma(,)");
                    return false;
                }
            }
            return true;
        }
        private static bool ContainsSymbol(string str)
        {
            foreach (char c in str)
            {
                if (!char.IsLetterOrDigit(c) && c != ' ')
                {
                    return true;
                }
            }
            return false;
        }
    }
}