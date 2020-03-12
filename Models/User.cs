using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueDemo.Models
{
    public class User
    {
        //指定主键和自增列，当然数据库中也要设置主键和自增列才会有效
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        public string Uid { get; set; }

        public string Name { get; set; }

        [SugarColumn(IsIgnore = true)]
        public string PassWord { get; set; }

        [SugarColumn(IsIgnore = true)]
        public string AddTime { get; set; }
    }
}
