using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using System.Linq;

public class radialObject : MonoBehaviour
{
    public GameObject[] stops;
    public GameObject targetImage;
    public Sprite pressed;
    public Sprite not_pressed;

    private List<GameObject> pcls = new List<GameObject>();
    private bool[] onLabels = new bool[14];
    private string[] labels = new string[14] { "flo", "wal", "win", "doo", "bed", "sof", "cab", "cha", "tab", "boo", "oth", "des", "pic", "all" };
    private bool[] activeTimes = new bool[5];
    private Button[] btns = new Button[14];

    void Start()
    {
        foreach (Transform child in targetImage.transform)
            if (child.gameObject.name != "seq_1") pcls.Add(child.gameObject);

        // Fill the array with the buttons
        for (int i = 0; i < labels.Length; i++)
            btns[i] = GameObject.Find(labels[i] + "1").GetComponent<Button>();

        onLabels = new bool[14];
        activeTimes = new bool[5];

        for (int i = 0; i < onLabels.Length; i++)
            btns[i].GetComponent<Image>().sprite = not_pressed;

        UpdatePclsAndTime();
    }

    public void ClickButtonObj(string btnName)
    {
        int index = Array.IndexOf(labels, btnName);

        if (btnName == "all")
        {
            // if the bool all is true, deactivate everything, and the opposite
            if (onLabels[index]) for (int i = 0; i < onLabels.Length; i++) onLabels[i] = false;
            else for (int i = 0; i < onLabels.Length; i++) onLabels[i] = true;
        }
        else
        {
            onLabels[index] = !onLabels[index];
            onLabels[onLabels.Length - 1] = false;
        }


        // update the images
        for (int i = 0; i < onLabels.Length; i++)
        {
            if (onLabels[i]) btns[i].GetComponent<Image>().sprite = pressed;
            else btns[i].GetComponent<Image>().sprite = not_pressed;
        }

        UpdatePclsAndTime();
    }

    void UpdatePclsAndTime()
    {
        // set the array all false
        activeTimes = new bool[5];

        for (int i = 0; i < pcls.Count; i++)
        {
            string name = pcls[i].name;
            // Find the index of the specific pcl label in the labels array
            int index = Array.IndexOf(labels, name.Substring(6, 3));
            if (onLabels[onLabels.Length - 1] || onLabels[index]) // if "all" is true
            {
                pcls[i].SetActive(true);
                // if at least one pcl of a time is visible, then the time is activated
                activeTimes[(int)Char.GetNumericValue(name[4])] = true;
            }
            else pcls[i].SetActive(false);
        }

        // Update time
        for (int j = 0; j < activeTimes.Length; j++) stops[j].SetActive(activeTimes[j]);
    }
}
