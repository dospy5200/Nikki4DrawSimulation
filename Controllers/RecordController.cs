using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using VueDemo.Models;

namespace VueDemo.Controllers
{
    /// <summary>
    /// 抽阁记录
    /// </summary>
    [Route("[controller]/[action]")]
    [ApiController]
    public class RecordController : ControllerBase
    {
        /// <summary>
        /// 抽阁次数
        /// </summary>
        /// <returns></returns>
        public int Times()
        {
            int times = db.Queryable<Record>().Where(it => it.User == GetUid()).Count();
            return times;
        }

        /// <summary>
        /// 按照套装分类
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Suits> Suits()
        {
            //连接查询，返回All，包括套装、等级、属性、设计师、ID、名称、部位
            var cards = db.Queryable<Card, Suit>((c, s) => new object[] { JoinType.Left, c.Suit == s.Name }).Select<All>().ToList();
            var clothes = db.Queryable<Clothes, Suit>((c, s) => new object[] { JoinType.Left, c.Suit == s.Name }).Select<All>().ToList();

            //填充类型和是否拥有
            foreach (var item in cards)
            {
                item.Type = "Card";
                item.IsHave = db.Queryable<Record>().Where(it => it.User == GetUid() && it.Type == item.Type && it.Id == item.Id).Count() > 0
                    ? true
                    : false;
            }

            foreach (var item in clothes)
            {
                item.Type = "Clothes";
                item.IsHave = db.Queryable<Record>().Where(it => it.User == GetUid() && it.Type == item.Type && it.Id == item.Id).Count() > 0
                    ? true
                    : false;
            }

            //合并两个list
            var list = new List<All>();
            list.AddRange(cards);
            list.AddRange(clothes);
            list = list.OrderBy(it => it.Suit).ToList();
            List<Suits> suits = list.GroupBy(it => new { it.Suit,it.Grade,it.Property,it.Designer})
                .Select(it => new Suits { Suit = it.Key.Suit, Grade = it.Key.Grade, Property = it.Key.Property, Designer = it.Key.Designer, All = it.ToList() }).ToList();
            return suits;
        }

        /// <summary>
        /// 阁池总数
        /// </summary>
        /// <returns></returns>
        public int Total()
        {
            int cards = db.Queryable<Card>().Count();
            int clothes = db.Queryable<Clothes>().Count();
            int total = cards + clothes;
            return total;
        }

        /// <summary>
        /// 已抽到的数量
        /// </summary>
        /// <returns></returns>
        public int Have()
        {
            int cards = db.Queryable<Record>().Where(it => it.User == GetUid() && it.IsNew == true && it.Type == "Card").Count();
            int clothes = db.Queryable<Record>().Where(it => it.User == GetUid() && it.IsNew == true && it.Type == "Clothes").Count();
            int have = cards + clothes;
            return have;
        }

        public Data Data()
        {
            Data data = new Data();
            data.Total = Total();
            data.Times = Times();
            data.Have = Have();
            return data;
        }
    }
}