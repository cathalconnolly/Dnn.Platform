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

using System;
using System.Web.Mvc;
using System.Web.Routing;
using Dnn.Mvc.Framework.Modules;
using DotNetNuke.Entities.Modules;

namespace Dnn.Mvc.Framework.Controllers
{
    public class DnnControllerAdapter : IDnnController  
    {
        private readonly Controller _adaptedController;
        private readonly ResultCapturingActionInvoker _actionInvoker;

        public DnnControllerAdapter(Controller controller)
        {
            _adaptedController = controller;
            _actionInvoker = new ResultCapturingActionInvoker();
            _adaptedController.ActionInvoker = _actionInvoker; 
        }

        public void Execute(RequestContext requestContext) 
        {
            if(_adaptedController.ActionInvoker != _actionInvoker) 
            {
                throw new InvalidOperationException("Could not construct Controller");
            }
            ((IController)_adaptedController).Execute(requestContext);
        }

        public ActionResult ResultOfLastExecute 
        {
            get { return _actionInvoker.ResultOfLastInvoke; }
        }

        public ModuleInfo ActiveModule { get; set; }

        public ControllerContext ControllerContext 
        {
            get { return _adaptedController.ControllerContext; }
        }

        public MvcMode MvcMode { get; set; }
    }
}