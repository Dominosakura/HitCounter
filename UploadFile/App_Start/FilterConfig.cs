﻿using Open_Library.Models;
using System.Web;
using System.Web.Mvc;

namespace UploadFile
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new HitCounterAttribute());
        }
    }
}
