using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueDemo.Models
{
    /// <summary>
    /// 抽阁记录
    /// </summary>
    public class Record
    {
        /// <summary>
        /// 用户
        /// </summary>
        public string User { get; set; }

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
        /// 是否首次获得
        /// </summary>
        public bool IsNew { get; set; }

        /// <summary>
        /// 获取时间
        /// </summary>
        public string GetTime { get; set; }
    }
}
