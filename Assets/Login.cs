using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Login : MonoBehaviour {
    public InputField name;
    public InputField pwd;
    public Dropdown shenfen;
    public Button denglu;
    public Button chongzhi;
    public Button tuichu;
	// Use this for initialization
	void Start () {
        chongzhi.onClick.AddListener(delegate {
            name.text = ""; pwd.text = ""; shenfen.value = 0;
           

        });
        denglu.onClick.AddListener(delegate { 
            if (name.text == "" || pwd.text == "")
            {
                Order.Instance.ShowTip("账号或密码为空！");

                return;
            }
            List<ArrayList> go=new List<ArrayList>();
            switch (shenfen.itemText.ToString())
            {
                case "普通员工":
                    go = DataBaseTool.Instance.ExcSelectMoreSql("select * from employeeinfo where username='" + name.text + "';");
                    if (go[0][0] == null)
                    {
                        Order.Instance.ShowTip("普通员工不存在该账户");
                        return;
                    }
                    if (go[0][2].ToString() == pwd.text)
                    {
                        Order.Instance.ShowTip("登陆成功");
                    }
                    else
                    {
                        Order.Instance.ShowTip("密码输入错误");
                    }
                    break;
                case "管理员":
                   go = DataBaseTool.Instance.ExcSelectMoreSql("select * from departmentInfo where username='" + name.text + "';");
                    if (go[0][0] == null)
                    {
                        Order.Instance.ShowTip("管理员不存在该账户");
                        return;
                    }
                    if (go[0][4].ToString() == pwd.text)
                    {
                        Order.Instance.ShowTip("登陆成功");
                    }
                    else
                    {
                        Order.Instance.ShowTip("密码输入错误");
                    }
                    break;
                case "系统管理":
                   go = DataBaseTool.Instance.ExcSelectMoreSql("select * from admin where username='" + name.text + "';");
                    if (go[0][0] == null)
                    {
                        Order.Instance.ShowTip("系统管理不存在该账户");
                        return;
                    }
                    if (go[0][5].ToString() == pwd.text)
                    {
                        Order.Instance.ShowTip("登陆成功");
                    }
                    else
                    {
                        Order.Instance.ShowTip("密码输入错误");
                    }
                    break;
            }
            name.text = ""; pwd.text = ""; shenfen.value = 0;
        });
        tuichu.onClick.AddListener(Application.Quit);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnSelcecIndex(int index)
    {

    }
}
