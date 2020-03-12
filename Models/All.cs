using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueDemo.Models
{
    /// <summary>
    /// 所有阁池
    /// </summary>
    public class All
    {
        /// <summary>
        /// 套装
        /// </summary>
        public string Suit { get; set; }

        /// <summary>
        /// 等级
        /// </summary>
        public string Grade { get; set; }

        /// <summary>
        /// 属性
        /// </summary>
        public string Property { get; set; }

        /// <summary>
        /// 设计师
        /// </summary>
        public string Designer { get; set; }

        /// <summary>
        /// 类型，Card或Clothes
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 对应Card或Clothes表的Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 部位
        /// </summary>
        public string Part { get; set; }

        /// <summary>
        /// 是否获得
        /// </summary>
        public bool IsHave { get; set; }
    }
}
