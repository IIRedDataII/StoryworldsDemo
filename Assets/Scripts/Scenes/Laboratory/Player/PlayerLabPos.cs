using UnityEngine;

public class PlayerLabPos : MonoBehaviour
{
    
    private void Start()
    {
        gameObject.transform.position = GameData.Instance.SetGetlastRoom == GameData.LastRoom.Start ? new Vector3(-6.14f,1.77f,0) : new Vector3(46.74f,-13,0);
    }
    
}
