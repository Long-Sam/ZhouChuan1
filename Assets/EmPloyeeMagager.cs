using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EmPloyeeMagager : MonoBehaviour {
    public InputField yuangongbianhao;
    public InputField xingming;
    public Dropdown bumenxiala;
    public Button chaxun;
    public Transform gird;

	// Use this for initialization
	void Start () {
        List<ArrayList> bumen = DataBaseTool.Instance.ExcSelectMoreSql("select * from daytaskinfo");
        //Dropdown.OptionData q = new Dropdown.OptionData();
        //q.text ="全部";
        //bumenxiala.options.Add(q);
        foreach (ArrayList i in bumen)
        {
            Dropdown.OptionData o=new Dropdown.OptionData();
            o.text = i[1].ToString();
            bumenxiala.options.Add(o) ;
        }
        chaxun.onClick.AddListener(delegate {
            for (int i = 0; i < gird.childCount; i++)
            {
                Destroy(gird.GetChild(i).gameObject);
            }
            gird.gameObject.GetComponent<RectTransform>().sizeDelta =
                         new Vector2(gird.gameObject.GetComponent<RectTransform>().sizeDelta.x, 550);
            int o = 0;
            if (yuangongbianhao.text != "")
            {
                string sqlstr = "select* from employeeinfo where id='"+ yuangongbianhao.text + "';";
                List<ArrayList> models = DataBaseTool.Instance.ExcSelectMoreSql(sqlstr);
                Debug.Log(models.Count);
                if (models.Count != 0)
                {
                    foreach (ArrayList i in models)
                    {
                        //Debug.Log(a.id);
                        o += 1;
                        GameObject go = GameObject.Instantiate(Resources.Load<GameObject>("adminchakanrenwuItem"));
                        go.transform.SetParent(gird);
                        go.transform.GetChild(0).GetComponent<Text>().text = i[0].ToString();
                        go.transform.GetChild(1).GetComponent<Text>().text = i[5].ToString();
                        go.transform.GetChild(2).GetComponent<Text>().text = i[11].ToString();
                        go.transform.GetChild(3).GetComponent<Text>().text = i[12].ToString();
                        go.transform.GetChild(4).GetComponent<Text>().text = i[3].ToString();
                        go.transform.GetChild(5).GetComponent<Text>().text = i[4].ToString();
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
                    Order.Instance.ShowTip("没有此id的人");
                }
               
            }
            else if (xingming.text != "")
            {
                string sqlstr = "select* from employeeinfo where xingming='" + xingming.text+"';";
                List<ArrayList> models = DataBaseTool.Instance.ExcSelectMoreSql(sqlstr);
                Debug.Log(models.Count);
                if (models.Count != 0)
                {
                  
                    foreach (ArrayList i in models)
                    {
                        //Debug.Log(a.id);
                        o++;
                        GameObject go = GameObject.Instantiate(Resources.Load<GameObject>("adminchakanrenwuItem"));
                        go.transform.SetParent(gird);
                        go.transform.GetChild(0).GetComponent<Text>().text = i[0].ToString();
                        go.transform.GetChild(1).GetComponent<Text>().text = i[5].ToString();
                        go.transform.GetChild(2).GetComponent<Text>().text = i[11].ToString();
                        go.transform.GetChild(3).GetComponent<Text>().text = i[12].ToString();
                        go.transform.GetChild(4).GetComponent<Text>().text = i[3].ToString();
                        go.transform.GetChild(5).GetComponent<Text>().text = i[4].ToString();
                        if (o > 9)
                            gird.gameObject.GetComponent<RectTransform>().sizeDelta =
                          new Vector2(gird.gameObject.GetComponent<RectTransform>().sizeDelta.x,
                          gird.gameObject.GetComponent<RectTransform>().sizeDelta.y + gird.GetComponent<GridLayoutGroup>().cellSize.y
                          + gird.GetComponent<GridLayoutGroup>().spacing.y);
                    }

                    gird.GetComponent<RectTransform>().localPosition = new Vector3(0, -10000, 0);
                }
                else
                {
                    Order.Instance.ShowTip("没有此姓名的人");
                }

            }
            else if(bumenxiala.captionText.text=="全部") {
                string sqlstr = "select* from employeeinfo";
                List<ArrayList> models = DataBaseTool.Instance.ExcSelectMoreSql(sqlstr);
                //Debug.Log(models.Count);
          
                if (models.Count != 0)
                {
                    foreach (ArrayList i in models)
                    {
                        //Debug.Log(a.id);
                        o += 1;
                        GameObject go = GameObject.Instantiate(Resources.Load<GameObject>("adminchakanrenwuItem"));
                        go.transform.SetParent(gird);
                        go.transform.GetChild(0).GetComponent<Text>().text = i[0].ToString();
                        go.transform.GetChild(1).GetComponent<Text>().text = i[5].ToString();
                        go.transform.GetChild(2).GetComponent<Text>().text = i[11].ToString();
                        go.transform.GetChild(3).GetComponent<Text>().text = i[12].ToString();
                        go.transform.GetChild(4).GetComponent<Text>().text = i[3].ToString();
                        go.transform.GetChild(5).GetComponent<Text>().text = i[4].ToString();
                        if (o > 9)
                            gird.gameObject.GetComponent<RectTransform>().sizeDelta =
                          new Vector2(gird.gameObject.GetComponent<RectTransform>().sizeDelta.x,
                          gird.gameObject.GetComponent<RectTransform>().sizeDelta.y + gird.GetComponent<GridLayoutGroup>().cellSize.y
                          + gird.GetComponent<GridLayoutGroup>().spacing.y);
                    }
                    gird.GetComponent<RectTransform>().localPosition = new Vector3(0, -10000,0);
                }
                else
                {
                    Order.Instance.ShowTip("没人");
                }

            }else
            {
                string sqlstr = "select* from employeeinfo where position='" + bumenxiala.captionText.text + "';";
                List<ArrayList> models = DataBaseTool.Instance.ExcSelectMoreSql(sqlstr);
                Debug.Log(models.Count);
                if (models.Count != 0)
                {
                    foreach (ArrayList i in models)
                    {
                        //Debug.Log(a.id);
                        o++;
                        GameObject go = GameObject.Instantiate(Resources.Load<GameObject>("adminchakanrenwuItem"));
                        go.transform.SetParent(gird);
                        go.transform.GetChild(0).GetComponent<Text>().text = i[0].ToString();
                        go.transform.GetChild(1).GetComponent<Text>().text = i[5].ToString();
                        go.transform.GetChild(2).GetComponent<Text>().text = i[11].ToString();
                        go.transform.GetChild(3).GetComponent<Text>().text = i[12].ToString();
                        go.transform.GetChild(4).GetComponent<Text>().text = i[3].ToString();
                        go.transform.GetChild(5).GetComponent<Text>().text = i[4].ToString();
                        if (o > 9)
                            gird.gameObject.GetComponent<RectTransform>().sizeDelta =
                          new Vector2(gird.gameObject.GetComponent<RectTransform>().sizeDelta.x,
                          gird.gameObject.GetComponent<RectTransform>().sizeDelta.y + gird.GetComponent<GridLayoutGroup>().cellSize.y
                          + gird.GetComponent<GridLayoutGroup>().spacing.y);
                    }
                    gird.GetComponent<RectTransform>().localPosition = new Vector3(0, -10000, 0);
                }
                else
                {
                    Order.Instance.ShowTip("这个部门没有员工");
                }
            }
                
                
                
                });
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnAddYuanGongButtonClick()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);
    }
}
