using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AddEmployee : MonoBehaviour {
    public InputField id;
    public InputField name;
    public InputField shoujihao;
    public InputField dianhua;
    public InputField Email;
    public InputField pwd;
    public InputField chushengriqi;
    public InputField shenfenzheng;
    public InputField jiatingdizhi;
    public Dropdown bumenxiala;
    public Dropdown xingbie;
    public Dropdown xueli;
    public Button tijiao;
    public Button quxiao;
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
            //bumenxiala.
        }
        tijiao.onClick.AddListener(delegate {
            if (id.text != "" && name.text != "" && pwd.text != ""&& dianhua.text!=""&& shenfenzheng.text!=""&& Email.text!="")
            {
                string sql = "INSERT INTO `employeeinfo` (`username`, `password`, `position`, `educationInfo`, `xingming`, `dianhua`, `shenfenzheng`, `shouji`, `email`, `dizhi`, `xingbie`, `shengri`) VALUES('" + id.text + "', '" + pwd.text + "', '" + bumenxiala.captionText.text.ToString() + "', '" + xueli.captionText.text.ToString() + "', '" + name.text + "',  '" + dianhua.text + "',  '" + shenfenzheng.text + "',  '" + shoujihao.text + "',  '" + Email.text + "',  '" + jiatingdizhi.text + "',  '" + xingbie.captionText.text.ToString() + "',  '" + chushengriqi.text + "');";
                //DataBaseTool.Instance.ExcuteNonQuerySql("insert into employeeinfo (`username`, `password`, `position`, `educationInfo`,'xingming','dianhua','shenfhenzheng','shouji','email','dizhi','xingbie','shengri')VALUES ('" + id.text + "', '" + pwd.text + "', '" + bumenxiala.captionText.text.ToString() + "', '" + xueli.captionText.text.ToString() + "',  '" + name.text + "',  '" + dianhua.text + "',  '" + shenfenzheng.text + "',  '" + shoujihao.text + "',  '" + Email.text + "',  '" + jiatingdizhi.text + "' , '" + xingbie.captionText.text.ToString() + "',  '" + chushengriqi.text + "');");
                DataBaseTool.Instance.ExcuteNonQuerySql(sql);
                Order.Instance.ShowTip("添加员工成功!!");
            }else
            {
                Order.Instance.ShowTip("必要信息必须要添写!!");
            }
           
        });
        quxiao.onClick.AddListener(delegate { transform.parent.GetChild(0).gameObject.SetActive(true);this.gameObject.SetActive(false); });
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
