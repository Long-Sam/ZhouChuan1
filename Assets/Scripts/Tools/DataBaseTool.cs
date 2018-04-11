using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Mono.Data.Sqlite;
using MySql.Data.MySqlClient;
using System;
using System.Data;
public class DataBaseTool
{
	static public DataBaseTool Instance = new DataBaseTool ();

	// 数据库的连接对象
	MySqlConnection con;

    //指令执行对象
    MySqlCommand command;

    //查询结果集对象
    MySqlDataReader reader;

	private	DataBaseTool ()
	{
		string datapath =
            string.Format("Server={0};Database={1};User ID={2};Password={3};Port={4}", "39.108.170.235", "efficiency", "root", "Sjy_1994_02", "3306");


        try
        {
			if (con == null) {
				con = new MySqlConnection(datapath);
			}
		} catch (System.Exception ex) {
			Debug.Log ("数据库连接失败 ：" + ex);
		}

		try {
			command = con.CreateCommand ();
		} catch (System.Exception ex) {
			Debug.Log (" 创建指令对象失败 ：" + ex);
		}
		Instance = this;
	}

	/// <summary>
	/// Opens the data base.
	/// </summary>
	private void OpenDataBase ()
	{
		try {
			con.Open ();
		} catch (System.Exception ex) {
			Debug.Log ("数据库打开错误" + ex);
		}
	}

	/// 关闭数据库
	private void CloesDataBase ()
	{
		try {
			con.Close ();
		} catch (System.Exception ex) {
			Debug.Log ("数据库关闭错误" + ex);
		}
	}

	///执行插入、删除、更新的操作
	public int  ExcuteNonQuerySql (string sql)
	{
		
		// 先打开数据库
		OpenDataBase ();

		int value = -1000;

		try {
			command.CommandText = sql;
			value =	command.ExecuteNonQuery ();
		} catch (System.Exception ex) {
			Debug.Log ("执行语句出错" + ex);
		}

		// 关闭数据库
		CloesDataBase ();
		return value;
	}
		
	// 查询一条结果的操作
	public object ExcSelectOneItem (string sql)
	{
		OpenDataBase ();
		object obj = new object ();

		try {
			command.CommandText = sql;
			obj = command.ExecuteScalar ();
		} catch (System.Exception ex) {
			Debug.Log ("数据库执行查询一条数据语句错误" + ex);
		}

		CloesDataBase ();

		return obj;
	}
		
	// 返回多个数据
	public List<ArrayList> ExcSelectMoreSql (string sql)
	{
		OpenDataBase ();
		List<ArrayList> list = new List<ArrayList> ();
		try {
			command.CommandText = sql;
			reader = command.ExecuteReader ();
					while (reader.Read ()) {
				ArrayList array = new ArrayList ();
				for (int i = 0; i < reader.FieldCount; i++) {
					array.Add (reader.GetValue (i));
				}
				list.Add (array);
			}
			reader.Close ();

		} catch (System.Exception ex) {
			Debug.Log ("查询多条语句错误" + ex);
		}
		CloesDataBase ();	
		return list;
	}
}
