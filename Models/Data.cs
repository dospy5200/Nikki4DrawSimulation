using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueDemo.Models
{
    /// <summary>
    /// 所有页面上要用的数据
    /// </summary>
    public class Data
    {
        /// <summary>
        /// 抽阁次数
        /// </summary>
        public int Times { get; set; }

        /// <summary>
        /// 阁池总数
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// 已抽到的数量
        /// </summary>
        public int Have { get; set; }
    }
}
