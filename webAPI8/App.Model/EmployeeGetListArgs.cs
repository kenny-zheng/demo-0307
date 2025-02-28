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
        public class EmployeeGetListArgs
        {
            /// <summary>
            /// 員工ID
            /// </summary>
            public int EmployeeID { get; set; } 

            /// <summary>
            /// 姓氏
            /// </summary>
            public string LastName { get; set; } 

            /// <summary>
            /// 名字
            /// </summary>
            public string FirstName { get; set; }

            /// <summary>
            /// 職稱
            /// </summary>
            public string Title { get; set; } 

            /// <summary>
            /// 出生日期
            /// </summary>
            public DateTime? BirthDate { get; set; } 

            /// <summary>
            /// 城市
            /// </summary>
            public string City { get; set; } 

            /// <summary>
            ///  國家
            /// </summary>

            public string Country { get; set; } 

        }
    }
}
