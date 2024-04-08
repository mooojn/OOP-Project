using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureBankDLL.BL
{
    public class History
    {
        private string type;
        private int amount;
        private DateTime date;
        public History(string type, int amount)
        {
            this.type = type;
            this.amount = amount;
            this.date = DateTime.Now;
        }
        public History(string type, int amount, DateTime date)
        {
            this.type = type;
            this.amount = amount;
            this.date = date;
        }
        public string getType()
        {
            return type;
        }
        public int getAmount()
        {
            return amount;
        }
        public DateTime getDate()
        {
            return date;
        }
        public string toString()
        {
            return $"{type}, {amount}, {date}";
        }
    }
}
