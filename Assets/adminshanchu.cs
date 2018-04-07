using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class adminshanchu : MonoBehaviour {
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnShanchuClick()
    {
        GameObject gird = GameObject.Find("Canvas/Administrator/Manage employee informationUI (1)/Body/body/gird");
        string str= transform.parent.GetChild(0).GetComponent<Text>().text;
        for (int i = 0; i < gird.transform.childCount; i++)
        {
            Destroy(gird.transform.GetChild(i).gameObject);
        }
        DataBaseTool.Instance.ExcuteNonQuerySql("delete from `employeeinfo` where id='"+str+"';");
        string sqlstr = "select* from employeeinfo";
        List<ArrayList> models = DataBaseTool.Instance.ExcSelectMoreSql(sqlstr);
        //Debug.Log(models.Count);
        if (models.Count != 0)
        {
            foreach (ArrayList i in models)
            {
                //Debug.Log(a.id);
                GameObject go = GameObject.Instantiate(Resources.Load<GameObject>("adminchakanrenwuItem"));
                go.transform.SetParent(gird.transform);
                go.transform.GetChild(0).GetComponent<Text>().text = i[0].ToString();
                go.transform.GetChild(1).GetComponent<Text>().text = i[5].ToString();
                go.transform.GetChild(2).GetComponent<Text>().text = i[11].ToString();
                go.transform.GetChild(3).GetComponent<Text>().text = i[12].ToString();
                go.transform.GetChild(4).GetComponent<Text>().text = i[3].ToString();
                go.transform.GetChild(5).GetComponent<Text>().text = i[4].ToString();

            }
        }
        else
        {
            Order.Instance.ShowTip("没人");
        }
        Order.Instance.ShowTip("删除成功");
    }
}
