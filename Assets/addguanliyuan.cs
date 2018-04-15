using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class addguanliyuan : MonoBehaviour {
    public InputField zhanghao;
    public InputField xingming;
    public InputField pwd;
    public InputField bumenname;
    public Button tianjia;
    public Button fanhui;
	// Use this for initialization
	void Start () {
        fanhui.onClick.AddListener(delegate { transform.parent.GetChild(0).gameObject.SetActive(true); this.gameObject.SetActive(false); });
        tianjia.onClick.AddListener(delegate {


                if (zhanghao.text != "" && xingming.text != "" && pwd.text != ""&&bumenname.text!="")
                {
                    string sql = "INSERT INTO `departmentinfo` (`dep_id`, `dep_pwd`, `dep_name`, `dep_principal`) VALUES('" + zhanghao.text + "', '" + pwd.text + "', '" + bumenname.text + "', '" + xingming.text + "');";
                    //DataBaseTool.Instance.ExcuteNonQuerySql("insert into employeeinfo (`username`, `password`, `position`, `educationInfo`,'xingming','dianhua','shenfhenzheng','shouji','email','dizhi','xingbie','shengri')VALUES ('" + id.text + "', '" + pwd.text + "', '" + bumenxiala.captionText.text.ToString() + "', '" + xueli.captionText.text.ToString() + "',  '" + name.text + "',  '" + dianhua.text + "',  '" + shenfenzheng.text + "',  '" + shoujihao.text + "',  '" + Email.text + "',  '" + jiatingdizhi.text + "' , '" + xingbie.captionText.text.ToString() + "',  '" + chushengriqi.text + "');");
                    DataBaseTool.Instance.ExcuteNonQuerySql(sql);
                    Order.Instance.ShowTip("添加管理员工成功!!");
                    Bumenguanliyuanguanli.Instance.bumen();
                    transform.parent.GetChild(0).gameObject.SetActive(true); this.gameObject.SetActive(false);
            }
                else
                {
                    Order.Instance.ShowTip("必要信息必须要添写!!");
                }

           




        }
        );

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
