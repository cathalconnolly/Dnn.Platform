﻿#region Copyright
// 
// DotNetNuke® - http://www.dnnsoftware.com
// Copyright (c) 2002-2014
// by DNN Corporation
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
// the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and 
// to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or substantial portions 
// of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED 
// TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
// CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
// DEALINGS IN THE SOFTWARE.
#endregion

using System.Web.Mvc;
using System.Web.Routing;
using Dnn.Mvc.Framework;
using DotNetNuke.Common;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Portals;
using DotNetNuke.Entities.Tabs;
using DotNetNuke.Entities.Users;

namespace Dnn.Mvc.Helpers
{
    public class DnnHelper
    {
        public DnnHelper(ViewContext viewContext, IViewDataContainer viewDataContainer) 
            : this(viewContext, viewDataContainer, RouteTable.Routes) 
        {
        }

        public DnnHelper(ViewContext viewContext, IViewDataContainer viewDataContainer, RouteCollection routeCollection)
        {
            Requires.NotNull("viewContext", viewContext);
            Requires.NotNull("viewDataContainer", viewDataContainer);
            Requires.NotNull("routeCollection", routeCollection);

            RouteCollection = routeCollection;
            ViewContext = viewContext;
            ViewDataContainer = viewDataContainer;
            ViewData = new ViewDataDictionary(viewDataContainer.ViewData);
        }

        public ModuleInfo ActiveModule
        {
            get { return SiteContext.ActiveModuleRequest.Module; }
        }

        public TabInfo ActivePage
        {
            get { return SiteContext.ActivePage; }
        }

        public PortalInfo ActiveSite
        {
            get { return SiteContext.ActiveSite; }
        }

        public PortalAliasInfo ActiveSiteAlias
        {
            get { return SiteContext.ActiveSiteAlias; }
        }

        public RouteCollection RouteCollection { get; private set; }

        public SiteContext SiteContext
        {
            get { return ViewContext.HttpContext.GetSiteContext(); }
        }

        public UserInfo User
        {
            get { return SiteContext.User; }
        }

        public ViewContext ViewContext { get; private set; }

        public ViewDataDictionary ViewData { get; private set; }

        public IViewDataContainer ViewDataContainer { get; private set; }
    }
}