﻿using System.Collections;
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
        chaxun.onClick.AddListener(chaxunButtonClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void chaxunButtonClick()
    {
        Debug.Log(1);
        for(int i = 0; i < gird.childCount; i++)
        {
            Destroy(gird.GetChild(i).gameObject);
        }
        if (yuangongbianhao.text == "")
        {

            sqlstr = "select* from daytaskinfo";
            List<ArrayList> models=DataBaseTool.Instance.ExcSelectMoreSql(sqlstr);
            Debug.Log(models.Count);
            gird.gameObject.GetComponent<RectTransform>().sizeDelta =
              new Vector2(gird.gameObject.GetComponent<RectTransform>().sizeDelta.x,550);
            int o = 0;
            foreach (ArrayList i in models)
            {
                o += 1;
                a.id = int.Parse(i[0].ToString());
                a.dep_name = i[1].ToString();
                a.yyear = i[2].ToString();
                a.mmouth= i[3].ToString();
                a.task_title= i[4].ToString();
                a.task_content= i[5].ToString();
                //Debug.Log(a.id);
                GameObject go = GameObject.Instantiate( Resources.Load<GameObject>("yuangongchakanrenwuItem"));
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
                if(o>9)
                gird.gameObject.GetComponent<RectTransform>().sizeDelta =
              new Vector2(gird.gameObject.GetComponent<RectTransform>().sizeDelta.x,
              gird.gameObject.GetComponent<RectTransform>().sizeDelta.y + gird.GetComponent<GridLayoutGroup>().cellSize.y
              + gird.GetComponent<GridLayoutGroup>().spacing.y);
            }
            gird.GetComponent<RectTransform>().position = new Vector2(gird.GetComponent<RectTransform>().position.x, -10000);
        }
        else
        {
            for (int i = 0; i < gird.childCount; i++)
            {
                Destroy(gird.GetChild(i).gameObject);
            }
            gird.gameObject.GetComponent<RectTransform>().sizeDelta =
            new Vector2(gird.gameObject.GetComponent<RectTransform>().sizeDelta.x, 550);
            sqlstr = "select* from daytaskinfo where id="+ yuangongbianhao.text;
            List<ArrayList> models = DataBaseTool.Instance.ExcSelectMoreSql(sqlstr);
            if (models!=null)
            { int o = 0;
                foreach (ArrayList i in models)
                {
                    o += 1;
                    a.id = int.Parse(i[0].ToString());
                    a.dep_name = i[1].ToString();
                    a.yyear = i[2].ToString();
                    a.mmouth = i[3].ToString();
                    a.task_title = i[4].ToString();
                    a.task_content = i[5].ToString();
                    GameObject go = GameObject.Instantiate(Resources.Load<GameObject>("yuangongchakanrenwuItem"));
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
                if (o > 9)
                {
                    gird.gameObject.GetComponent<RectTransform>().sizeDelta =
           new Vector2(gird.gameObject.GetComponent<RectTransform>().sizeDelta.x,
           gird.gameObject.GetComponent<RectTransform>().sizeDelta.y + gird.GetComponent<GridLayoutGroup>().cellSize.y
           + gird.GetComponent<GridLayoutGroup>().spacing.y);
                }
                gird.GetComponent<RectTransform>().position = new Vector2(gird.GetComponent<RectTransform>().position.x, -10000);
            }
            else
            {

            }
           
        }
    }
}
