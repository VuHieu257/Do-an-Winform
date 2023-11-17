using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XuTool
{
    internal class Customer
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string SĐT { get; set; }
        public int Number0fDay { get; set; }
        public Customer() { }
        public Customer(string name, string userName, string passWord, string sĐT, int number0fDay)
        {
            Name = name;
            UserName = userName;
            PassWord = passWord;
            SĐT = sĐT;
            Number0fDay = number0fDay;
        }
    }
}
