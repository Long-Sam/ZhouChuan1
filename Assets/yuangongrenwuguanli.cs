﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class yuangongrenwuguanli : MonoBehaviour {
    public InputField yuangongbianhao;
    public Button chaxun;
    public Transform gird;
    public Button xinjianrenwu;
    string sqlstr = "select* from daytaskinfo";
    public GameObject xinrenwu;
    daytaskinfoModel a;
    // Use this for initialization
    void Start()
    {
        a = new daytaskinfoModel();
        chaxun.onClick.AddListener(chaxunButtonClick);
        xinjianrenwu.onClick.AddListener(delegate { xinrenwu.gameObject.SetActive(true); transform.GetChild(0).gameObject.SetActive(false); });
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void chakanmeiribaogaoButton()
    {
        this.transform.GetChild(0).gameObject.SetActive(false);
        this.transform.GetChild(2).gameObject.SetActive(true);
    }
    public void chaxunButtonClick()
    {
        Debug.Log(1);
        for (int i = 0; i < gird.childCount; i++)
        {
            Destroy(gird.GetChild(i).gameObject);
        }
        if (yuangongbianhao.text == "")
        {
            gird.gameObject.GetComponent<RectTransform>().sizeDelta =
                       new Vector2(gird.gameObject.GetComponent<RectTransform>().sizeDelta.x, 550);
            int o = 0;
            sqlstr = "select* from daytaskinfo";
            List<ArrayList> models = DataBaseTool.Instance.ExcSelectMoreSql(sqlstr);
            Debug.Log(models.Count);
            foreach (ArrayList i in models)
            {
                o++;
                a.id = int.Parse(i[0].ToString());
                a.dep_name = i[1].ToString();
                a.yyear = i[2].ToString();
                a.mmouth = i[3].ToString();
                a.task_title = i[4].ToString();
                a.task_content = i[5].ToString();
                //Debug.Log(a.id);
                GameObject go = GameObject.Instantiate(Resources.Load<GameObject>("adminyuangongchakanrenwuItem"));
                go.transform.SetParent(gird);
                go.transform.GetChild(0).GetComponent<Text>().text = a.id.ToString();
                go.transform.GetChild(1).GetComponent<Text>().text = a.dep_name.ToString();
                go.transform.GetChild(2).GetComponent<Text>().text = a.yyear + "-" + a.mmouth;
                go.transform.GetChild(3).GetComponent<Text>().text = a.task_title;
                if (o > 9)
                {
                    gird.gameObject.GetComponent<RectTransform>().sizeDelta =
                new Vector2(gird.gameObject.GetComponent<RectTransform>().sizeDelta.x,
                gird.gameObject.GetComponent<RectTransform>().sizeDelta.y + gird.GetComponent<GridLayoutGroup>().cellSize.y
                + gird.GetComponent<GridLayoutGroup>().spacing.y);
                }

            }
            gird.GetComponent<RectTransform>().localPosition = new Vector3(0, -10000, 0);
        }
        else
        {
            for (int i = 0; i < gird.childCount; i++)
            {
                Destroy(gird.GetChild(i).gameObject);
            }
            sqlstr = "select* from daytaskinfo where id=" + yuangongbianhao.text;
            List<ArrayList> models = DataBaseTool.Instance.ExcSelectMoreSql(sqlstr);
            gird.gameObject.GetComponent<RectTransform>().sizeDelta =
                      new Vector2(gird.gameObject.GetComponent<RectTransform>().sizeDelta.x, 550);
            int o = 0;
            if (models != null)
            {
                foreach (ArrayList i in models)
                {
                    o++;
                    a.id = int.Parse(i[0].ToString());
                    a.dep_name = i[1].ToString();
                    a.yyear = i[2].ToString();
                    a.mmouth = i[3].ToString();
                    a.task_title = i[4].ToString();
                    a.task_content = i[5].ToString();
                    GameObject go = GameObject.Instantiate(Resources.Load<GameObject>("adminyuangongchakanrenwuItem"));
                    go.transform.SetParent(gird);
                    go.transform.GetChild(0).GetComponent<Text>().text = a.id.ToString();
                    go.transform.GetChild(1).GetComponent<Text>().text = a.dep_name.ToString();
                    go.transform.GetChild(2).GetComponent<Text>().text = a.yyear + "-" + a.mmouth;
                    go.transform.GetChild(3).GetComponent<Text>().text = a.task_title;
                    if (o > 9)
                    {
                        gird.gameObject.GetComponent<RectTransform>().sizeDelta =
                    new Vector2(gird.gameObject.GetComponent<RectTransform>().sizeDelta.x,
                    gird.gameObject.GetComponent<RectTransform>().sizeDelta.y + gird.GetComponent<GridLayoutGroup>().cellSize.y
                    + gird.GetComponent<GridLayoutGroup>().spacing.y);
                    }

                }
                gird.GetComponent<RectTransform>().localPosition = new Vector3(0, -10000, 0);
            }
            else
            {

            }

        }
    }
    
}
