using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class chakanmeiribaogao : MonoBehaviour {

    public InputField yuangongbianhao;
    public Button chaxun;
    public Transform gird;
    public Button fanhui;
    string sqlstr = "select* from daytaskinfo";
    //public GameObject xinrenwu;
    //daytaskinfoModel a;
    // Use this for initialization
    void Start()
    {
        //a = new daytaskinfoModel();
        chaxun.onClick.AddListener(chaxunButtonClick);
        fanhui.onClick.AddListener(delegate {
            this.transform.parent.GetChild(0).gameObject.SetActive(true);
            for (int i = 0; i < gird.childCount; i++)
            {
                Destroy(gird.GetChild(i).gameObject);
            }
            this.gameObject.SetActive(false); });
    }

    // Update is called once per frame
    void Update()
    {

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

            sqlstr = "select* from loginfo";
            List<ArrayList> models = DataBaseTool.Instance.ExcSelectMoreSql(sqlstr);
            Debug.Log(models.Count);
            foreach (ArrayList i in models)
            {
                //Debug.Log(a.id);
                GameObject go = GameObject.Instantiate(Resources.Load<GameObject>("yuangongmeirenbaogaoItem"));
                go.transform.SetParent(gird);
                go.transform.GetChild(0).GetComponent<Text>().text = (i[0].ToString());
                go.transform.GetChild(1).GetComponent<Text>().text = i[1].ToString();
                go.transform.GetChild(2).GetComponent<Text>().text = i[3].ToString();
                go.transform.GetChild(3).GetComponent<Text>().text =  i[2].ToString();
                go.transform.GetChild(4).GetComponent<Text>().text = i[4].ToString();
                //Debug.Log(a.id + a.pname + a.to_time);
                //foreach (var go in i)
                //{
                //    Debug.Log(go.ToString() + "   \n" + go.GetType() + "   " + i.GetType());
                //}
            }
        }
        else
        {
            for (int i = 0; i < gird.childCount; i++)
            {
                Destroy(gird.GetChild(i).gameObject);
            }
            sqlstr = "select* from loginfo where id=" + yuangongbianhao.text;
            List<ArrayList> models = DataBaseTool.Instance.ExcSelectMoreSql(sqlstr);
            if (models != null)
            {
                foreach (ArrayList i in models)
                {
                   
                    GameObject go = GameObject.Instantiate(Resources.Load<GameObject>("yuangongmeirenbaogaoItem"));
                    go.transform.SetParent(gird);
                    go.transform.GetChild(0).GetComponent<Text>().text = (i[0].ToString());
                    go.transform.GetChild(1).GetComponent<Text>().text = i[1].ToString();
                    go.transform.GetChild(2).GetComponent<Text>().text = i[2].ToString();
                    go.transform.GetChild(3).GetComponent<Text>().text = i[3].ToString().Substring(0, 8);
                    go.transform.GetChild(4).GetComponent<Text>().text = i[4].ToString();
                    //Debug.Log(a.id + a.pname + a.to_time);
                    //foreach (var go in i)
                    //{
                    //    Debug.Log(go.ToString() + "   \n" + go.GetType() + "   " + i.GetType());
                    //}
                }
            }
            else
            {

            }

        }
    }

}
