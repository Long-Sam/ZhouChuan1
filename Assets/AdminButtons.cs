﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AdminButtons : MonoBehaviour {

    public Button[] buttons;
    public GameObject[] mianban;
    public GameObject Login;
    // Use this for initialization
    void Start()
    {
        buttons[0].onClick.AddListener(button0);
        buttons[1].onClick.AddListener(delegate { for (int i = 0; i < mianban.Length; i++) { mianban[i].gameObject.SetActive(false); }
            mianban[1].gameObject.SetActive(true);
            for (int i = 0; i < mianban[1].transform.childCount; i++) { mianban[1].transform.GetChild(i).gameObject.SetActive(false); }
            mianban[1].transform.GetChild(0).gameObject.SetActive(true); });
        buttons[2].onClick.AddListener(delegate { for (int i = 0; i < mianban.Length; i++) { mianban[i].gameObject.SetActive(false); } mianban[2].gameObject.SetActive(true); mianban[2].transform.GetChild(0).gameObject.SetActive(true); mianban[2].transform.GetChild(1).gameObject.SetActive(false); mianban[2].transform.GetChild(2).gameObject.SetActive(false); });
        buttons[3].onClick.AddListener(delegate { for (int i = 0; i < mianban.Length; i++) { mianban[i].gameObject.SetActive(false); } mianban[3].gameObject.SetActive(true); });
        buttons[4].onClick.AddListener(delegate { for (int i = 0; i < mianban.Length; i++) { mianban[i].gameObject.SetActive(false); } mianban[4].gameObject.SetActive(true); });
        //buttons[3].onClick.AddListener(delegate { for (int i = 0; i < mianban.Length; i++) { mianban[i].gameObject.SetActive(false); } mianban[3].gameObject.SetActive(true); });
        buttons[5].onClick.AddListener(delegate { for (int i = 0; i < mianban.Length; i++) { mianban[i].gameObject.SetActive(false); } Login.gameObject.SetActive(true); transform.parent.gameObject.SetActive(false); });
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void button0()
    {
        for (int i = 0; i < mianban.Length; i++) { mianban[i].gameObject.SetActive(false); }
        mianban[0].gameObject.SetActive(true);
    }
}
