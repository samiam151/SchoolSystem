using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Data.Attributes
{
    public class SqlDefaultValue : Attribute
    {
        protected string value;
        public SqlDefaultValue(string value)
        {
            this.value = value;
        }
    }
}
