using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class yuangongrenwushanchu : MonoBehaviour {
    //public 
    daytaskinfoModel a=new daytaskinfoModel();
    //public GameObject gird;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ShanchuButtonClick()
    {
        GameObject gird= GameObject.Find("Canvas/Administrator/yuangongrenwuguanli/main/Panel/body/Body/gird");
        // DataBaseTool.Instance.ExcuteNonQuerySql()
        //GameObject gird = GameObject.Find("Canvas/Administrator/Manage employee informationUI (1)/Body/body/gird");
        string str = transform.parent.GetChild(0).GetComponent<Text>().text;
        string str1= transform.parent.GetChild(3).GetComponent<Text>().text;
        for (int i = 0; i < gird.transform.childCount; i++)
        {
            Destroy(gird.transform.GetChild(i).gameObject);
        }
        DataBaseTool.Instance.ExcuteNonQuerySql("delete from `daytaskinfo` where id='" + str + "' and task_title='"+str1+"';");
        string sqlstr = "select* from daytaskinfo";
        List<ArrayList> models = DataBaseTool.Instance.ExcSelectMoreSql(sqlstr);
        //Debug.Log(models.Count);
        if (models.Count != 0)
        {
           
            Debug.Log(models.Count);
            foreach (ArrayList i in models)
            {
                a.id = int.Parse(i[0].ToString());
                a.dep_name = i[1].ToString();
                a.yyear = i[2].ToString();
                a.mmouth = i[3].ToString();
                a.task_title = i[4].ToString();
                a.task_content = i[5].ToString();
                //Debug.Log(a.id);
                GameObject go = GameObject.Instantiate(Resources.Load<GameObject>("adminyuangongchakanrenwuItem"));
                go.transform.SetParent(gird.transform);
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
        else
        {
            Order.Instance.ShowTip("没人");
        }
        Order.Instance.ShowTip("删除成功");
    }

}
