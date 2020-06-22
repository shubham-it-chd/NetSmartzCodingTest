
using System;
using System.Web;
using System.Web.Mvc;
//using Elmah;

namespace NetSmartzCodingTest.Filters
{
   // [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method,AllowMultiple=true)]
    public class ErrorHandlingAttribute : System.Web.Mvc.HandleErrorAttribute
    {
        
        #region Exception Handling Functions
        /// <summary>
        /// <Author>Sunil</Author>       
        /// <Description>Logs the exception into the database </Description>
        /// </summary>
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            LogException(filterContext.Exception);

            // Output a nice error page
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new
                    {
                        error = true,
                        message = filterContext.Exception.Message
                    }
                };
            }
            else if (filterContext.HttpContext.IsCustomErrorEnabled)
            {
                filterContext.Controller.TempData["ErrorMsg"] = filterContext.Exception.Message;

                //Normal Exception
                //So let it handle by its default ways.
                base.OnException(filterContext);
            }
        }

        /// <summary>
        /// <Author>Sunil</Author>       
        /// <Description>Logs the exception into the database </Description>
        /// </summary>
        private  void LogException(Exception e)
        {
            var context = HttpContext.Current;
          //  SqlErrorLog.GetDefault(context).Log(new Error(e, context));
            LogExceptionIntoDatabase(e);
        }

        public  void LogExceptionIntoDatabase(Exception objException)
        {
            System.Diagnostics.StackTrace objTrace = new System.Diagnostics.StackTrace(objException, true);
            String ErrorMessage = String.Empty;
            string CustomMessage = string.Empty;

            if (objTrace != null)
            {
                Int32 frameToBeSelected = objTrace.FrameCount - 1;


                String FileName = objTrace.GetFrame(frameToBeSelected).GetFileName();

                ErrorMessage = "ControllerName = " + (FileName == null ? "" : FileName.Substring(FileName.LastIndexOf("\\") + 1))
                               + ", MethodName = " + objTrace.GetFrame(frameToBeSelected).GetMethod().Name
                               + ", Line Number =" + objTrace.GetFrame(frameToBeSelected).GetFileLineNumber()
                               + ", ColumnNumber = " + objTrace.GetFrame(frameToBeSelected).GetFileColumnNumber()
                               + ", ErrorMessage:- " + objException.Message;
            }

            Boolean sessionNull;
            sessionNull = (HttpContext.Current.Session == null);
            ///  CustomMessage = "[PracticeID : " + (sessionNull ? "-" : Convert.ToString(Session["PracticeID"])) + "], ";

            if (HttpContext.Current.Request != null)
            {
                foreach (String item in HttpContext.Current.Request.QueryString.AllKeys)
                    CustomMessage += "[" + item + " : " + HttpContext.Current.Request.QueryString[item] + "], ";

                foreach (String item in HttpContext.Current.Request.Form.AllKeys)
                    CustomMessage += "[" + item + " : " + HttpContext.Current.Request.Form[item] + "], ";
            }

            try
            {
                string ScreenUrl = HttpContext.Current.Request.Url.ToString();
               // new ServiceLayer.Services.ErrorlogService().SaveException(objException, ErrorMessage, CustomMessage, ScreenUrl);

            }
            catch (Exception ex) {
                ex.ToString();
            }
        }
        #endregion
    }
}
