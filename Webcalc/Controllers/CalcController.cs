using Calc;
using System;
using System.Web.Mvc;
using System.Collections.Generic;
using Webcalc.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Reflection;
using Domain.Managers;
using Domain.Models;
using System.Linq;

namespace Webcalc.Controllers
{
    public class CalcController : Controller
    {
        private IHistoryManager Manager { get; set; }

        public CalcController()
        {
            Manager = new HistoryManager();
        }

        public Helper calcHelper { get; set; }

        // GET: Calc
        public ActionResult Index(CalcModel data)
        {
            var model = data ?? new CalcModel();
            var reasons = data ?? new CalcModel();

            var calcHelper = new Helper();
            var methods = calcHelper.metods();
            var su = model.Reason;

            List<SelectListItem> listItems = new List<SelectListItem>();
            foreach (var met in methods)
            {
                listItems.Add(new SelectListItem
                {
                    Text = met.Name,
                    Value = met.Name
                });
            }
            model.Reason = listItems;

            if (model.actions != null)
            {
                string nameMethod = model.actions.ToString();
                MethodInfo m = calcHelper.GetType().GetMethod(nameMethod);
                model.result = (double)m.Invoke(calcHelper, new object[] { model.x, model.y });
                var oper = string.Format("{0} {1} {2} = {3}{4}", model.x, nameMethod, model.y, model.result, Environment.NewLine);
                addOperation(data);
            }
            return View(model);
        }


        #region Работа с БД
        private void addOperation(CalcModel data)
        {
            //var connectionString = ConfigurationManager.ConnectionStrings["ElmaCon"].ConnectionString;
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    var queryString = string.Format("INSERT INTO [dbo].[History] ([Operation]) VALUES (N'{0}')", oper);
            //    SqlCommand command = new SqlCommand(queryString, connection);
            //    command.Connection.Open();
            //    command.ExecuteNonQuery();
            //}
            var history = new History();

            history.CreationDate = DateTime.Now;
            history.X = data.x;
            history.Y = data.y;
            history.Operation = data.actions.ToString();
            history.Result = data.result;

            Manager.Add(history);
        }


        private IEnumerable<History> getOperation()
        {
            return Manager.List();
            //var connectionString = ConfigurationManager.ConnectionStrings["ElmaCon"].ConnectionString;

            //var result = new List<string>();
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    var queryString = "SELECT [Operation] FROM [dbo].[History]";

            //    SqlCommand command = new SqlCommand(queryString, connection);
            //    command.Connection.Open();
            //    var reader = command.ExecuteReader();
            //    if (reader.HasRows)
            //    {
            //        while (reader.Read())
            //        {
            //            result.Add(reader.GetString(0));
            //        }
            //    }
            //    reader.Close();
            //}
            //return result;
        }
        #endregion


        public ActionResult History()
        {
            return View(getOperation());
        }

    }
}