using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Model
{
    public class EmployeeSaveDataResponse
    {
        // 可以根據需求添加回傳屬性，例如：
        /// <summary>
        /// 操作是否成功
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 操作訊息
        /// </summary>
        public string Message { get; set; }
    }
}
