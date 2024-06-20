using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LoadAll : MonoBehaviour
{
    private GameObject[] prefabs;
    private GameObject[] gos;

    private GameObject example;
    private int modelsCount;

    void Start()
    {
        // first check how many folders in the resources
        string[] dir = Directory.GetDirectories(Directory.GetCurrentDirectory() + "/Assets/Resources");
        modelsCount = dir.Length;
        Debug.Log(modelsCount.ToString() + " models loaded");

        example = gameObject.transform.GetChild(0).gameObject;
        prefabs = Resources.LoadAll<GameObject>("segments");
        gos = new GameObject[prefabs.Length];
        // call method to instantiate all prefabs and place them in the correct transform
        InstantiateObjects();
    }

    void InstantiateObjects()
    {
        // loop through all items in the library
        for (int i = 0; i < prefabs.Length; i++)
        {
            // instantiate each prefab from library
            GameObject clone = Instantiate(prefabs[i], Vector3.zero, Quaternion.identity);
            // Make it a parent of the image target
            clone.transform.parent = gameObject.transform;
            clone.transform.position = example.transform.position;
            clone.transform.rotation = example.transform.rotation;
            clone.transform.localScale = example.transform.localScale;
            // fill the array with the game objects
            gos[i] = clone;
            gos[i].tag = "pcl";
            // Deactivate it because we are starting from the "Now"
            gos[i].SetActive(false);
        }
    }
}
