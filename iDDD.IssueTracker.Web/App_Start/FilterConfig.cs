﻿using System.Web;
using System.Web.Mvc;

namespace iDDD.IssueTracker.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}