using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class gualiyuanshanchubutton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public  void OnShanChu()
    {
        GameObject gird = GameObject.Find("Canvas/SysAdministrator/Department management information/main/Body/gird");
        string str = transform.parent.GetChild(0).GetComponent<Text>().text;
        for (int i = 0; i < gird.transform.childCount; i++)
        {
            Destroy(gird.transform.GetChild(i).gameObject);
        }
        DataBaseTool.Instance.ExcuteNonQuerySql("delete from `departmentinfo` where id='" + str + "';");
        List<ArrayList> bumen = DataBaseTool.Instance.ExcSelectMoreSql("select * from departmentinfo");
        //Dropdown.OptionData q = new Dropdown.OptionData();
        //q.text ="全部";
        //bumenxiala.options.Add(q);

        for (int i = 0; i < gird.transform.childCount; i++)
        {
            Destroy(gird.transform.GetChild(i).gameObject);
        }

        //List<ArrayList> models = DataBaseTool.Instance.ExcSelectMoreSql(sqlstr);
        Debug.Log(bumen.Count);
        if (bumen.Count != 0)
        {
            foreach (ArrayList i in bumen)
            {
                //Debug.Log(a.id);
                GameObject go = GameObject.Instantiate(Resources.Load<GameObject>("guanliyuanxinxi"));
                go.transform.SetParent(gird.transform);
                go.transform.GetChild(0).GetComponent<Text>().text = i[0].ToString();
                go.transform.GetChild(1).GetComponent<Text>().text = i[2].ToString();
                go.transform.GetChild(2).GetComponent<Text>().text = i[3].ToString();
                go.transform.GetChild(3).GetComponent<Text>().text = i[4].ToString();
                go.transform.GetChild(4).GetComponent<Text>().text = i[1].ToString();
                //go.transform.GetChild(4).GetComponent<Text>().text = i[3].ToString();
                //go.transform.GetChild(5).GetComponent<Text>().text = i[4].ToString();

            }
        }
        Order.Instance.ShowTip("删除成功!!!!!");
    }
}
