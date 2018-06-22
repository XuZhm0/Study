using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDbHelper {
	interface IDbHelper {
		//返回指定类型对象
		T QueryForObject<T>(string sql);
		//返回指定类型对象集合
		IList<T> QueryForObjects<T>(string sql);

		//返回指定类型对象字典
		Dictionary<TKEY,TVALUE> QueryForDict<TKEY,TVALUE>(int column,string sql);
		 
		//返回Ilist<List<object>> 
		IList<List<object>> Querys(string sql);


		//执行Sql语句并返回成功还是失败
		int Execute(string sql); 
	}
}
