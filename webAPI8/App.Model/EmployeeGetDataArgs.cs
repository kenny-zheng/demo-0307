using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    namespace Northwind.Models
    {
        // 員工表格
        public class EmployeeGetDataArgs
        {
            /// <summary>
            /// // 員工ID
            /// </summary>
            public int EmployeeID { get; set; } 

        }
    }
}
