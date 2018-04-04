using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeEmployeePWD : MonoBehaviour {

    public InputField oldpwd;
    public InputField newpwd;
    public InputField renewpwd;
    public Button queding;
    public Button quxiao;
    public EmPloyeeButtons embutton;
    // Use this for initialization
    void Start () {
        quxiao.onClick.AddListener(delegate { embutton.button0(); });
        queding.onClick.AddListener(delegate
        {
            if(oldpwd.text!=""&& newpwd.text != "" && renewpwd.text != "")
            {
                if (newpwd.text != renewpwd.text)
                {
                    Order.Instance.ShowTip("新密码与确认密码不一致！");
                }
                if (oldpwd.text != PlayerPrefs.GetString("PWD"))
                {
                    Order.Instance.ShowTip("旧密码输入错误！！");
                }else
                {
                    DataBaseTool.Instance.ExcuteNonQuerySql("UPDATE `employeeinfo` SET `password`='"+ newpwd .text+ "' WHERE `id`='"+PlayerPrefs.GetInt("id")+"';");
                }
            }else
            {
                Order.Instance.ShowTip("密码不能为空！！");
            }

        });
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
