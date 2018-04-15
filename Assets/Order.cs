using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using UnityEngine.UI;
public class Order : MonoSingleton<Order> {
   
	// Use this for initialization
	void Start () {
        //adminModel a = new adminModel();
        //List<ArrayList> models= DataBaseTool.Instance.ExcSelectMoreSql("select * from admin");
        
      
        //foreach (ArrayList i in models)
        //{
        //   a.id= int .Parse(i[0].ToString());
        //    a.pname = i[1].ToString();
        //    a.to_time = i[2].ToString();
        //    Debug.Log(a.id + a.pname + a.to_time);
        //    foreach (var go in i)
        //    {

        //        Debug.Log(go.ToString() + "   \n"+go.GetType()+"   "+i.GetType());
        //    }
        //}
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ShowTip(string str)
    {
        GameObject go =GameObject.Instantiate( Resources.Load<GameObject>("Tip"));
        go.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform);
        go.GetComponent<RectTransform>().anchoredPosition = new Vector2(430, 320);
        go.GetComponent<Text>().text = str;

    }
}
