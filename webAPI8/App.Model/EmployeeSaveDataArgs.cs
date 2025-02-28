using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Model
{
    public class EmployeeSaveDataArgs
    {
        /// <summary>
        /// 員工ID
        /// </summary>
        [DisplayName("員工ID")]
        public int EmployeeID { get; set; }

        /// <summary>
        /// 姓氏
        /// </summary>
        [Required(ErrorMessage = "{0}為必填")]
        [StringLength(20, ErrorMessage = "{0}長度需小於20")]
        [DisplayName("姓氏")]
        public string LastName { get; set; }

        /// <summary>
        /// 名字
        /// </summary>
        [Required(ErrorMessage = "{0}為必填")]
        [StringLength(10, ErrorMessage = "{0}長度需小於10")]
        [DisplayName("名字")]
        public string FirstName { get; set; }

        /// <summary>
        /// 職稱
        /// </summary>
        [StringLength(30, ErrorMessage = "{0}長度需小於30")]
        [DisplayName("職稱")]
        public string Title { get; set; }

        /// <summary>
        /// 尊稱
        /// </summary>
        [StringLength(25, ErrorMessage = "{0}長度需小於25")]
        [DisplayName("尊稱")]
        public string TitleOfCourtesy { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        [DisplayName("出生日期")]
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// 雇用日期
        /// </summary>
        [DisplayName("雇用日期")]
        public DateTime? HireDate { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [StringLength(60, ErrorMessage = "{0}長度需小於60")]
        [DisplayName("地址")]
        public string Address { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        [StringLength(15, ErrorMessage = "{0}長度需小於15")]
        [DisplayName("城市")]
        public string City { get; set; }

        /// <summary>
        /// 地區
        /// </summary>
        [StringLength(15, ErrorMessage = "{0}長度需小於15")]
        [DisplayName("地區")]
        public string Region { get; set; }

        /// <summary>
        /// 郵遞區號
        /// </summary>
        [StringLength(10, ErrorMessage = "{0}長度需小於10")]
        [DisplayName("郵遞區號")]
        public string PostalCode { get; set; }

        /// <summary>
        /// 國家
        /// </summary>
        [StringLength(15, ErrorMessage = "{0}長度需小於15")]
        [DisplayName("國家")]
        public string Country { get; set; }

        /// <summary>
        /// 家庭電話
        /// </summary>
        [StringLength(24, ErrorMessage = "{0}長度需小於24")]
        [DisplayName("家庭電話")]
        public string HomePhone { get; set; }

        /// <summary>
        /// 分機號碼
        /// </summary>
        [StringLength(4, ErrorMessage = "{0}長度需小於4")]
        [DisplayName("分機號碼")]
        public string Extension { get; set; }

        /// <summary>
        /// 照片
        /// </summary>
        [DisplayName("照片")]
        public byte[] Photo { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        [DisplayName("備註")]
        public string Notes { get; set; }

        /// <summary>
        /// 直屬主管ID
        /// </summary>
        [DisplayName("直屬主管ID")]
        public int? ReportsTo { get; set; }

        /// <summary>
        /// 照片路徑
        /// </summary>
        [StringLength(255, ErrorMessage = "{0}長度需小於255")]
        [DisplayName("照片路徑")]
        public string PhotoPath { get; set; }
    }
}
