using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueDemo.Models
{
    public class Suits
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
        /// 卡片/服装
        /// </summary>
        public List<All> All { get; set; }
    }
}
