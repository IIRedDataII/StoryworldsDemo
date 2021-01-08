using System;
using UnityEngine;
using UnityEngine.UI;

public class FPS : MonoBehaviour
{

    private Text text;
    private float time;

    private void Start()
    {
        text = GetComponent<Text>();
        time = 0.0f;
    }
    
    private void Update()
    {
        time += Time.deltaTime;
        if (time >= 0.1f)
        {
            time = 0.0f;
            text.text = (int) (1.0f / Time.deltaTime) + "";
        }
    }
    
}
