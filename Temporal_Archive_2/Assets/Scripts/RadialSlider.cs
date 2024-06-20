using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using System.Linq;

public class RadialSlider : MonoBehaviour
{
    public Transform Origin; //center of rotation
    public Image ImageSelected; //drag here the image of type filled radial top
    public TextMeshProUGUI Angle; //value textual feedback
    public int Scale = 360; //value scale to use

    private int CurrentValue;
    public State CircularButtonState = State.NOT_DRAGGING;

    private float value;

    //variables for de-activating models
    public int numTimes;
    public GameObject targetImage;
    public Sprite pressed;
    public Sprite not_pressed;

    private List<GameObject> pcls = new List<GameObject>();
    private int unit;
    private int cur_model;
    // arrays to identify which labels are currently on and off
    private bool[] onLabels = new bool[14];
    private string[] labels;


    public enum State
    {
        NOT_DRAGGING,
        DRAGGING,
    }

    private void Start()
    {
        // We have changed the order of how the scripts run
        // First it will run LoadAll and assign a tag and then this script
        // so we can load the models based on the tag and number
        // Add the list of models based on tag
        foreach (Transform child in targetImage.transform)
            if(child.gameObject.name != "seq_1") pcls.Add(child.gameObject);

        Debug.Log("number of GOs: " + pcls.Count.ToString());
        unit = 360 / numTimes;
        Angle.text = "Now";
        cur_model = -1;
        // set true only the last "all" label
        //onLabels[onLabels.Length - 1] = true;
        // parallel array to check which labels are on
        labels = new string[14] {"flo", "wal", "win", "doo", "bed", "sof", "cab", "cha", "tab", "boo", "oth", "des", "pic", "all"};
        onLabels = new bool[14];

        UpdatePcls();
    }

    public void InitTime()
    {
        cur_model = -1;
        Angle.text = "Now";
        onLabels = new bool[14];

        UpdatePcls();
    }

    public void DragOnCircularArea(bool isClick)
    {
        //we ignore the click event due to dragging in order to 
        //ignore beyond max set with drag and enable it on click / touch
        if (isClick && CircularButtonState == State.DRAGGING)
        {
            CircularButtonState = State.NOT_DRAGGING;
            return;
        }

        if (isClick)
            CircularButtonState = State.NOT_DRAGGING;
        else
        {
            CircularButtonState = State.DRAGGING;
        }

        float f = Vector3.Angle(Vector3.up, Input.mousePosition - Origin.position);
        bool onTheRight = Input.mousePosition.x > Origin.position.x;
        int detectedValue = onTheRight ? (int)f : 180 + (180 - (int)f);
        if (detectedValue > 350)
            detectedValue = 360;
        else if (CurrentValue == 360 && detectedValue < 10)
            detectedValue = 360;
        else if (CurrentValue == 0 && detectedValue > 350)
            detectedValue = 0;
        else if (detectedValue < 10)
            detectedValue = 0;

        if (!isClick)
        {
            if (detectedValue <= CurrentValue && Mathf.Abs(CurrentValue - detectedValue) > 180)
            {
                detectedValue = CurrentValue;
            }
            else if (CurrentValue == 0 && detectedValue > 270)
                detectedValue = CurrentValue;
        }

        CurrentValue = detectedValue;
        ImageSelected.fillAmount = CurrentValue / 360f;

        cur_model = (int)CurrentValue / unit;
        // Set the text showing number in the sequence
        if (CurrentValue == 0)
        {
            Angle.text = "Now";
            cur_model = -1;
            onLabels = new bool[14];
        }
        else Angle.text = "" + cur_model;

        UpdatePcls();
    }


    public void ClickButton(string btnName)
    {
        int index = Array.IndexOf(labels, btnName);

        if(btnName == "all")
        {
            // if the bool all is true, deactivate everything, and the opposite
            if(onLabels[index]) for (int i = 0; i < onLabels.Length; i++) onLabels[i] = false;
            else for (int i = 0; i < onLabels.Length; i++) onLabels[i] = true;
        }
        else
        {
            onLabels[index] = !onLabels[index];
            onLabels[onLabels.Length - 1] = false;
        }

        Debug.Log("onLabels " + onLabels[index].ToString());


        // update the images
        for (int i = 0; i < onLabels.Length; i++)
        {
            Button btn = GameObject.Find(labels[i]).GetComponent<Button>();
            if (onLabels[i]) btn.GetComponent<Image>().sprite = pressed;
            else btn.GetComponent<Image>().sprite = not_pressed;
        }
        

        for (int i = 0; i < onLabels.Length; i++)
        {
           Debug.Log(onLabels[i].ToString() + labels[i]);
        }


        UpdatePcls();
    }

    void UpdatePcls()
    {
        for (int i = 0; i < pcls.Count; i++)
        {
            string name = pcls[i].name;
            // Find the index of the specific pcl label in the labels array
            int index = Array.IndexOf(labels, name.Substring(6, 3));
            if(onLabels[onLabels.Length-1]) // if "all" is true
            {
                if (Char.GetNumericValue(name[4]) == cur_model) pcls[i].SetActive(true);
                else pcls[i].SetActive(false);
            }
            else if(cur_model == -1) pcls[i].SetActive(false); // if it's now then all models should be deactivated
            else if (index != -1)
                if (onLabels[index] && (int)Char.GetNumericValue(name[4]) == cur_model) pcls[i].SetActive(true);
            else pcls[i].SetActive(false);
        }
    }
}
