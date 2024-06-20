using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS : MonoBehaviour
{
    //Metrics to evaluate
    private int FPS_cur;
    private int FPSall;
    private int countFrames = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FPS_cur = (int)(1f / Time.unscaledDeltaTime);
        Debug.Log("FPS: " + FPS_cur.ToString());
        FPSall += FPS_cur;
        Debug.Log("FPS TOTAL: " + FPSall.ToString());

        countFrames++;
        Debug.Log("NUMBER OF FRAMES " + countFrames.ToString());
    }
}
