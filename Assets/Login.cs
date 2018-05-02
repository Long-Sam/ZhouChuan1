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
    public GameObject sys;
    public GameObject admin;
    public GameObject employee;
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
            Debug.Log(shenfen.captionText.text.ToString());
           // Order.Instance.ShowTip("denglu");
            switch (shenfen.captionText.text.ToString())
            {
               
                case "普通员工":
                    try
                    {
                        go = DataBaseTool.Instance.ExcSelectMoreSql("select * from employeeinfo where username='" + name.text + "';");
                       // Order.Instance.ShowTip("puton");
                    }
                    catch
                    {
                        Order.Instance.ShowTip("普通员工不存在该账户");
                        break;
                    }
                   
                    
                    if (go.Count==0)
                    {
                        Order.Instance.ShowTip("普通员工不存在该账户");
                        Debug.Log("普通员工不存在该账户");
                        return;
                    }else
                    {
                        if (go[0][2].ToString() == pwd.text)
                        {
                            Order.Instance.ShowTip("登陆成功");
                            PlayerPrefs.SetString("PWD", pwd.text);
                            PlayerPrefs.SetString("name", name.text);
                            PlayerPrefs.SetInt("id", int.Parse(go[0][0].ToString()));
                            Debug.Log("登陆成功");
                            employee.gameObject.SetActive(true);
                            this.gameObject.SetActive(false);
                        }
                        else
                        {
                            Order.Instance.ShowTip("密码输入错误");
                            Debug.Log("密码输入错误");
                        }
                    }
                    break;
                case "管理员":
                    try
                    {
                        go = DataBaseTool.Instance.ExcSelectMoreSql("select * from departmentinfo where dep_id='" + name.text + "';");
                        Debug.Log(1);
                    }
                    catch
                    {
                        Debug.Log(2);
                        Order.Instance.ShowTip("管理员不存在该账户");
                        break;
                    }
                    Debug.Log(go);
                    if (go.Count == 0)
                    {
                        Debug.Log(4);
                        Order.Instance.ShowTip("管理员不存在该账户");
                        return;
                    }
                    else
                    {
                        if (go[0][4].ToString() == pwd.text)
                        {
                            Order.Instance.ShowTip("登陆成功");
                            PlayerPrefs.SetString("PWD", pwd.text);
                            PlayerPrefs.SetString("name", name.text);
                            PlayerPrefs.SetInt("id", int.Parse(go[0][0].ToString()));
                            admin.gameObject.SetActive(true);
                            this.gameObject.SetActive(false);
                        }
                        else
                        {
                            Order.Instance.ShowTip("密码输入错误");
                        }
                    }
                    break;
                case "系统管理":
                    try
                    {
                        go = DataBaseTool.Instance.ExcSelectMoreSql("select * from admin where pname='" + name.text + "';");
                    }
                    catch
                    {
                        Order.Instance.ShowTip("系统管理不存在该账户");
                        break;
                    }
                    
                    if (go.Count==0)
                    {
                        Order.Instance.ShowTip("系统管理不存在该账户");
                        return;
                    }
                    else
                    {
                        if (go[0][5].ToString() == pwd.text)
                        {
                            Order.Instance.ShowTip("登陆成功");
                            PlayerPrefs.SetString("PWD", pwd.text);
                            PlayerPrefs.SetString("name", name.text);
                            PlayerPrefs.SetInt("id", int.Parse(go[0][0].ToString()));
                            sys.gameObject.SetActive(true);
                            this.gameObject.SetActive(false);
                        }
                        else
                        {
                            Order.Instance.ShowTip("密码输入错误");
                        }
                    }
                   
                    break;
               

            }
           // Debug.Log(go[0][2]+"   "+ shenfen.captionText.ToString());
            name.text = ""; pwd.text = ""; //shenfen.value = 0;
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
