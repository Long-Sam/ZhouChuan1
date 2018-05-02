using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bumenguanliyuanguanli : MonoSingleton<Bumenguanliyuanguanli> {
    //public InputField yuangongbianhao;
    //public InputField xingming;
    //public Dropdown bumenxiala;
    //public Button chaxun;
    public Transform gird;

    // Use this for initialization
    void Start()
    {
        
     
           
    }
    private void OnEnable()
    {
        bumen();
    }
    public void OnAddGuanliClick()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);
    }
     public void bumen()
    {
        List<ArrayList> bumen = DataBaseTool.Instance.ExcSelectMoreSql("select * from departmentinfo");
        //Dropdown.OptionData q = new Dropdown.OptionData();
        //q.text ="全部";
        //bumenxiala.options.Add(q);

        for (int i = 0; i < gird.childCount; i++)
        {
            Destroy(gird.GetChild(i).gameObject);
        }

        //List<ArrayList> models = DataBaseTool.Instance.ExcSelectMoreSql(sqlstr);
        Debug.Log(bumen.Count);
        if (bumen.Count != 0)
        {
            gird.gameObject.GetComponent<RectTransform>().sizeDelta =
                     new Vector2(gird.gameObject.GetComponent<RectTransform>().sizeDelta.x, 550);
            int o = 0;
            foreach (ArrayList i in bumen)
            {
                //Debug.Log(a.id);
                o++;
                GameObject go = GameObject.Instantiate(Resources.Load<GameObject>("guanliyuanxinxi"));
                go.transform.SetParent(gird);
                go.transform.GetChild(0).GetComponent<Text>().text = i[0].ToString();
                go.transform.GetChild(1).GetComponent<Text>().text = i[2].ToString();
                go.transform.GetChild(2).GetComponent<Text>().text = i[3].ToString();
                go.transform.GetChild(3).GetComponent<Text>().text = i[4].ToString();
                go.transform.GetChild(4).GetComponent<Text>().text = i[1].ToString();
                //go.transform.GetChild(4).GetComponent<Text>().text = i[3].ToString();
                //go.transform.GetChild(5).GetComponent<Text>().text = i[4].ToString();
                if (o >9)
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

    }
