using UnityEngine;
using UnityEngine.UI;

public class FPS : MonoBehaviour
{

    private Text _text;
    private float _time;

    private void Start()
    {
        _text = GetComponent<Text>();
        _time = 0.0f;
    }
    
    private void Update()
    {
        _time += Time.deltaTime;
        if (_time >= 0.1f)
        {
            _time = 0.0f;
            _text.text = (int) (1.0f / Time.deltaTime) + "";
        }
    }
    
}
