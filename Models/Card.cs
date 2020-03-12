using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueDemo.Models
{
    /// <summary>
    /// 设计师之影
    /// </summary>
    public class Card
    {
        //指定主键和自增列，当然数据库中也要设置主键和自增列才会有效
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        /// <summary>
        /// 套装
        /// </summary>
        public string Suit { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// 等级
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public string Grade { get; set; }

        /// <summary>
        /// 属性
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public string Property { get; set; }

        /// <summary>
        /// 设计师
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public string Designer { get; set; }
    }
}
