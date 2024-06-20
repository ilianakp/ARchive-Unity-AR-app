using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainToggle : MonoBehaviour
{
    // 0 the GO with the time labels and 1 the time machine
    public GameObject[] timeGOs;
    public GameObject[] objGOs;
    // the UI images that represent the toggle, 0 is time 1 is object
    public GameObject[] imagesToggle = new GameObject[2];
    public Button btnTime;
    public Button btnObj;

    RadialSlider timeSlider;
    radialObject objRadial;

    void Start()
    {
        Button btnT = btnTime.GetComponent<Button>();
        btnT.onClick.AddListener(updateTime);

        Button btnO = btnObj.GetComponent<Button>();
        btnO.onClick.AddListener(updateObj);
    }

    public void updateTime()
    {
        for (int i = 0; i < timeGOs.Length; i++)
        {
            objGOs[i].SetActive(false);
            timeGOs[i].SetActive(true);
        }
        //timeSlider.InitTime();
        imagesToggle[0].SetActive(true);
        imagesToggle[1].SetActive(false);
    }

    public void updateObj()
    {
        for (int i = 0; i < objGOs.Length; i++)
        {
            objGOs[i].SetActive(true);
            timeGOs[i].SetActive(false);
        }
        //objRadial.InitObj();
        imagesToggle[0].SetActive(false);
        imagesToggle[1].SetActive(true);
    }
}
