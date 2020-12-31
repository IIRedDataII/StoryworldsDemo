using UnityEngine;
using UnityEngine.UI;

public class FPS : MonoBehaviour
{

    private Text text;

    private void Start()
    {
        text = GetComponent<Text>();
    }
    
    private void Update()
    {
        text.text = (int) (1.0f / Time.deltaTime) + "";
    }
    
}
