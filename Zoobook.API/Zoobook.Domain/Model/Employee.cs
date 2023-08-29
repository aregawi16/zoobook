using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoobook.Domain.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName => GetFullName();

        private string GetFullName()
        {
            var fullNameBuilder = new StringBuilder();
            fullNameBuilder.Append(FirstName);

            if (!string.IsNullOrEmpty(MiddleName))
            {
                fullNameBuilder.Append(" ");
                fullNameBuilder.Append(MiddleName);
            }

            fullNameBuilder.Append(" ");
            fullNameBuilder.Append(LastName);

            return fullNameBuilder.ToString();
        }
    }
}
