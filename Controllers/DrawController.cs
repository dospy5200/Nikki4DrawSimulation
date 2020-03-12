using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VueDemo.Models;

namespace VueDemo.Controllers
{
    /// <summary>
    /// 抽阁
    /// </summary>
    [Route("[controller]/[action]")]
    [ApiController]
    public class DrawController : ControllerBase
    {
        /// <summary>
        /// 单抽
        /// </summary>
        /// <returns></returns>
        public Record Once()
        {
            Random random = new Random();
            int rd = random.Next(1, 1000);
            double value = 0;
            Probability probability = new Probability();

            var list = db.Queryable<Probability>().ToList();
            for (int i = 0; i < list.Count; i++)
            {
                //rd范围1-1000，value范围1-100
                if (value * 10 > rd)
                {
                    //此时概率范围已经超出随机数范围
                    break;
                }
                probability = list[i];
                value += probability.Value;
            }

            //根据等级随机一个套装
            List<Suit> suits = db.Queryable<Suit>().Where(it => it.Grade == probability.Grade).ToList();
            Suit suit = suits[random.Next(0, suits.Count - 1)];

            Record record = new Record();
            record.Suit = suit.Name;
            record.Grade = suit.Grade;
            record.Designer = suit.Designer;
            record.Type = probability.Type;

            //套装抖落繁星没有衣服
            if (record.Suit == "抖落繁星" && record.Type == "Clothes")
            {
                return Once();
            }
            //套装闪耀衣服、非凡衣服、稀有衣服没有卡
            if ((record.Suit == "闪耀衣服" || record.Suit == "非凡衣服" || record.Suit == "稀有衣服") && record.Type == "Card")
            {
                return Once();
            }

            //根据套装和类型随机一个卡或衣服
            if (record.Type == "Card")
            {
                List<Card> cards = db.Queryable<Card>().Where(it => it.Suit == suit.Name).ToList();
                Card c = cards[random.Next(0, cards.Count - 1)];
                record.Id = c.Id;
                record.Name = c.Name;
            }
            if (record.Type == "Clothes")
            {
                List<Clothes> clothes = db.Queryable<Clothes>().Where(it => it.Suit == suit.Name).ToList();
                Clothes c = clothes[random.Next(0, clothes.Count - 1)];
                record.Id = c.Id;
                record.Name = c.Name;
                record.Part = c.Part;
            }

            record.User = GetUid();

            //比对用户、类型和Id，有完全一致的就不是新获得
            record.IsNew = db.Queryable<Record>().Where(it => it.User == record.User && it.Id == record.Id && it.Type == record.Type).ToList().Count > 0
                ? false
                : true;
            record.GetTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

            //插入抽阁记录
            db.Insertable(record).ExecuteCommand();

            return record;
        }

        /// <summary>
        /// n连
        /// </summary>
        /// <param name="times">连抽次数</param>
        /// <returns></returns>
        public IEnumerable<Record> Combo(int times)
        {
            List<Record> records = new List<Record>();
            for (int i = 0; i < times; i++)
            {
                records.Add(Once());
            }
            return records;
        }
    }
}