using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace exam
{
    public class Product
    {
        public delegate void country ();
        public event country ev1;
        public string Name { get; private set; }
        public string Sort { get; set; }
        public double Cost { get; set; }
        public int Srok;
        public string Country { get; set; }

        public Product()
        {
            Sort1();
			ev1 += () => MessageBox.Show("Страна производителя - Япония");
        }

        public Product(string Name) : this()
        {
            this.Name = Name;
        }

        public Product (string Name, double Cost, int Age) : this (Name)
        {
            this.Cost = Cost;
            this.Srok = Age;
        }

        public Product(string Name, double Cost, int Age, string Country) : this(Name, Cost, Age)
        {
            this.Country = Country;
			if (this.Country == "Япония")
            {
                ev1?.Invoke();
            }
        }

        public void Cost_dollars()
        {
            MessageBox.Show((this.Cost / 70.0).ToString());
        }

        public virtual void Sort1()
        {
            this.Sort = "Высший";
        }
    }
}
