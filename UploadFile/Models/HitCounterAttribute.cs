using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace Open_Library.Models
{
    public class HitCounterAttribute : ActionFilterAttribute
    {
        private static Dictionary<string, int> _hitCount = new Dictionary<string, int>();

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string path = filterContext.HttpContext.Request.Path;

            if (_hitCount.ContainsKey(path))
            {
                _hitCount[path]++;
            }
            else
            {
                _hitCount[path] = 1;
            }

            // Lưu lượt truy cập vào file để xem lại
            SaveHitCountToFile();

            // Gửi thông tin lượt truy cập đến ViewBag để hiển thị
            filterContext.Controller.ViewBag.HitCount = _hitCount[path];

            base.OnActionExecuting(filterContext);
        }

        private void SaveHitCountToFile()
        {
            string filePath = HttpContext.Current.Server.MapPath("~/App_Data/hitCount.txt");
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var entry in _hitCount)
                {
                    writer.WriteLine($"{entry.Key}: {entry.Value}");
                }
            }
        }
    }
}
