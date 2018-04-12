using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shedingyuangongrenwu : MonoBehaviour {
    public InputField id;
    public InputField nian;
    public InputField yue;
    public InputField ri;
    public InputField zhuti;
    public InputField neirong;
    public Button tijiao;
    public Button fanhui;
    public Dropdown bumenxiala;
    // Use this for initialization
    void Start () {
        List<ArrayList> bumen = DataBaseTool.Instance.ExcSelectMoreSql("select * from daytaskinfo");
        //Dropdown.OptionData q = new Dropdown.OptionData();
        //q.text ="全部";
        //bumenxiala.options.Add(q);
        foreach (ArrayList i in bumen)
        {
            Dropdown.OptionData o = new Dropdown.OptionData();
            o.text = i[1].ToString();
            bumenxiala.options.Add(o);
        }
        
        fanhui.onClick.AddListener(Admin.Instance.ShowMain);
        tijiao.onClick.AddListener( delegate {
            if (id.text != "" && nian.text != "" && zhuti.text != "" && neirong.text != "") {
                DataBaseTool.Instance.ExcuteNonQuerySql("insert into daytaskinfo (`id`, `dep_name`, `yyear`, `mmouth`, `task_title`,'task_content') VALUES ('" + id.text+ "', '" + bumenxiala.captionText.text + "', '" + nian.text + "', '" +yue.ToString() + "',  '" + zhuti.text + "','"+neirong.text+"');");
                Order.Instance.ShowTip("添加任务成功！");
            } else
            {
                Order.Instance.ShowTip("请填写完整！");
            }
        } 
        
        
        );
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
