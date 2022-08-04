using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam
{
    class NewProduct : Product, IDisposable
    {
        public int discount { get; set; }
        public NewProduct(string Name, double Cost, int Age, string Country) : 
            base(Name, Cost, Age, Country) 
        {
            Sort1();
        }
        
        public void Dispose()
        {
        }

        public override void Sort1()
        {
            this.Sort = "Первый";
        }
    }
}
