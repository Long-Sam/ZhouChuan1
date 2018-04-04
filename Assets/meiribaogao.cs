using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class meiribaogao : MonoBehaviour {
    public int id;
    public string username;
    public InputField biaoti;
    public InputField neirong;
    public Button tijiao;
    public Button fanhui;
    public GameObject zhuye;
	// Use this for initialization
	void Start () {
        
        
        //ShowTip("开始更新" + dt.ToString());//2005-11-05T14:06:25);
        
        tijiao.onClick.AddListener(delegate {
            if (biaoti.text==""|| neirong.text == "")
            {
                Order.Instance.ShowTip("标题或内容未填写!!");
                return;
            }
                DateTime dt = DateTime.Now;
            // 1/22/2017 3:43:19 PM ;
            try
            {
                DataBaseTool.Instance.ExcuteNonQuerySql("insert into logInfo (`id`, `username`, `log_title`, `log_time`, `log_content`) VALUES ('" + PlayerPrefs.GetInt("id")+ "', '" + PlayerPrefs.GetString("name") + "', '" + biaoti.text + "', '" + dt.ToString() + "',  '" + neirong.text + "');");
                biaoti.text = ""; neirong.text = "";
                Order.Instance.ShowTip("提交成功！");
                zhuye.gameObject.SetActive(true); this.gameObject.SetActive(false);
            }
            catch
            {
                Order.Instance.ShowTip("你输入了不该输入的东西（Sql语句）");
            }
           
        });
        fanhui.onClick.AddListener(delegate { biaoti.text = ""; neirong.text = ""; zhuye.gameObject.SetActive(true);this.gameObject.SetActive(false); });

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
