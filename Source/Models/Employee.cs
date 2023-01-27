using Source.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Source.Models
{
    public class Employee : BaseEntity
    {
        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                age = value;
                OnPropertyChanged(nameof(Age));
            }
        }
    }
}
