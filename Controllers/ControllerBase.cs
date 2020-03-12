using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;
using VueDemo.Models;
using VueDemo.Utility;

namespace VueDemo.Controllers
{
    public class ControllerBase : Controller
    {
        public SqlSugarClient db = new SqlSugarInit().db;
        //public string Uid;

        public ControllerBase()
        {
            
        }

        public string GetUid()
        {
            //尝试从Session中读取用户
            string Uid = HttpContext.Session.GetString("Uid");
            //如果没有用户则创建一个临时用户
            if (string.IsNullOrEmpty(Uid))
            {
                Uid = Guid.NewGuid().ToString();
                HttpContext.Session.SetString("Uid", Uid);

                //把创建的临时用户记录到用户表
                User user = new User();
                user.Uid = Uid;
                user.Name = "临时用户";
                db.Insertable(user).ExecuteCommand(); ;
            }
            return Uid;
        }
    }
}