using UnityEngine;
using UnityEngine.UI;

public class FPS : MonoBehaviour
{
    
    private void Update()
    {
        GetComponent<Text>().text = (int) (1.0f / Time.deltaTime) + "";
    }
    
}
