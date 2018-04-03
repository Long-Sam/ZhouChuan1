using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class chakanrenwu : MonoBehaviour {
    public InputField yuangongbianhao;
    public Button chaxun;
    public Transform gird;
    string sqlstr = "select* from daytaskinfo";
    daytaskinfoModel a;
    // Use this for initialization
    void Start () {
        a = new daytaskinfoModel();
        chaxun.onClick.AddListener(delegate { chaxunButtonClick(); });
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void chaxunButtonClick()
    {
        Debug.Log(1);
        if (yuangongbianhao.text == "")
        {
            

            List<ArrayList> models=DataBaseTool.Instance.ExcSelectMoreSql(sqlstr);
            Debug.Log(models.Count); 
            foreach (ArrayList i in models)
            {
                a.id = int.Parse(i[0].ToString());
                a.dep_name = i[1].ToString();
                a.yyear = i[2].ToString();
                a.mmouth= i[3].ToString();
                a.task_title= i[4].ToString();
                a.task_content= i[5].ToString();
                GameObject go = Resources.Load<GameObject>("yuangongchakanrenwuItem");
                go.transform.SetParent(gird);
                go.transform.GetChild(0).GetComponent<Text>().text = a.id.ToString();
                go.transform.GetChild(1).GetComponent<Text>().text = a.dep_name.ToString();
                go.transform.GetChild(2).GetComponent<Text>().text = a.yyear+"-"+a.mmouth;
                go.transform.GetChild(3).GetComponent<Text>().text = a.task_title;
                //Debug.Log(a.id + a.pname + a.to_time);
                //foreach (var go in i)
                //{
                //    Debug.Log(go.ToString() + "   \n" + go.GetType() + "   " + i.GetType());
                //}
            }
        }else
        {
            
            List<ArrayList> models = DataBaseTool.Instance.ExcSelectMoreSql(sqlstr);
            foreach (ArrayList i in models)
            {
                a.id = int.Parse(i[0].ToString());
                a.dep_name = i[1].ToString();
                a.yyear = i[2].ToString();
                a.mmouth = i[3].ToString();
                a.task_title = i[4].ToString();
                a.task_content = i[5].ToString();
                GameObject go = Resources.Load<GameObject>("yuangongchakanrenwuItem");
                go.transform.SetParent(gird);
                go.transform.GetChild(0).GetComponent<Text>().text = a.id.ToString();
                go.transform.GetChild(1).GetComponent<Text>().text = a.dep_name.ToString();
                go.transform.GetChild(2).GetComponent<Text>().text = a.yyear + "-" + a.mmouth;
                go.transform.GetChild(3).GetComponent<Text>().text = a.task_title;
                //Debug.Log(a.id + a.pname + a.to_time);
                //foreach (var go in i)
                //{
                //    Debug.Log(go.ToString() + "   \n" + go.GetType() + "   " + i.GetType());
                //}
            }
        }
    }
}
