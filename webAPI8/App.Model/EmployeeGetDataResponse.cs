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
        public class EmployeeGetDataResponse
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
            /// 尊稱
            /// </summary>
            public string TitleOfCourtesy { get; set; }

            /// <summary>
            /// 出生日期
            /// </summary>
            public DateTime? BirthDate { get; set; }

            /// <summary>
            /// 雇用日期
            /// </summary>
            public DateTime? HireDate { get; set; }

            /// <summary>
            /// 地址
            /// </summary>
            public string Address { get; set; }

            /// <summary>
            /// 城市
            /// </summary>
            public string City { get; set; }

            /// <summary>
            /// 地區
            /// </summary>
            public string Region { get; set; }

            /// <summary>
            /// 郵遞區號
            /// </summary>
            public string PostalCode { get; set; }

            /// <summary>
            /// 國家
            /// </summary>
            public string Country { get; set; }

            /// <summary>
            /// 家庭電話
            /// </summary>
            public string HomePhone { get; set; }

            /// <summary>
            /// 分機號碼
            /// </summary>
            public string Extension { get; set; }

            /// <summary>
            /// 照片
            /// </summary>
            public byte[] Photo { get; set; }

            /// <summary>
            /// 備註
            /// </summary>
            public string Notes { get; set; }

            /// <summary>
            /// 直屬主管ID
            /// </summary>
            public int? ReportsTo { get; set; }

            /// <summary>
            /// 照片路徑
            /// </summary>
            public string PhotoPath { get; set; }

        }
    }
}
