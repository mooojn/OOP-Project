using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureBankDLL.BL
{
    public class Asset
    {
        private string name;
        private int worth;
        public Asset(string name, int worth)
        {
            this.name = name;
            this.worth = worth;
        }
        public string getName() 
        {
            return name;
        }
        public int getWorth()
        {
            return worth;
        }
        public void setName(string name) 
        {
            this.name = name;
        }
        public void setWorth(int worth)
        {
            this.worth = worth; 
        }
        public string toString() 
        {
            return $"{name}, {worth}";
        }
    }
}
