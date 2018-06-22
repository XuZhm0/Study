using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MvcRoute.App_Code {
	public class DataTableToList<T> where T : new() {

		///<summary>

		///利用反射将Datatable转换成List模型

		///</summary>

		///<param name="dt"></param>

		///<returns></returns>

		public static List<T> ConvertToList(DataTable dt) {

			List<T> list = new List<T>();

			Type type = typeof(T);

			string tempName = string.Empty;

			foreach (DataRow dr in dt.Rows) {

				T t = new T();

				PropertyInfo[] propertys =t.GetType().GetProperties();

				foreach (PropertyInfo pi in propertys) {

					tempName = pi.Name;

					if (dt.Columns.Contains(tempName)) {

						if (!pi.CanWrite) { 
							continue; 
						}

						var value = dr[tempName];	

						if (value != DBNull.Value) {

							pi.SetValue(t, value, null);

						}

					}

				}

				list.Add(t);

			}

			return list;

		}

	}
}