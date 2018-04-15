using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class sysguanlixiugaimima : MonoBehaviour {

    public InputField oldpwd;
    public InputField newpwd;
    public InputField renewpwd;
    public Button queding;
    public Button quxiao;
    //public Admin embutton;
    // Use this for initialization
    void Start()
    {
        quxiao.onClick.AddListener(delegate { Sys.Instance.ShowMain(); });
        queding.onClick.AddListener(delegate
        {
            if (oldpwd.text != "" && newpwd.text != "" && renewpwd.text != "")
            {
                if (newpwd.text != renewpwd.text)
                {
                    Order.Instance.ShowTip("新密码与确认密码不一致！");
                    return;
                }
                if (oldpwd.text != PlayerPrefs.GetString("PWD"))
                {
                    Debug.Log(PlayerPrefs.GetString("PWD"));
                    Order.Instance.ShowTip("旧密码输入错误！！");
                }
                else
                {
                    DataBaseTool.Instance.ExcuteNonQuerySql("UPDATE `admin` SET `password`='" + newpwd.text + "' WHERE `id`='" + PlayerPrefs.GetInt("id") + "';");
                    Order.Instance.ShowTip("修改密码成功！！");
                    oldpwd.text = "";
                    newpwd.text = "";
                    renewpwd.text = "";
                    Sys.Instance.ShowMain();
                }
            }
            else
            {
                Order.Instance.ShowTip("密码不能为空！！");
            }

        });
    }

    // Update is called once per frame
    void Update () {
		
	}
}
