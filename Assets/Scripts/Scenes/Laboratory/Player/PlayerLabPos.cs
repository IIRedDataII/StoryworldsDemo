using UnityEngine;

public class PlayerLabPos : MonoBehaviour
{
    [SerializeField] private Transform start;
    private void Start()
    {
        //Former Starting Position new Vector3(-6.14f,1.77f,0)
        gameObject.transform.position = GameData.Instance.SetGetlastRoom == GameData.LastRoom.Start ? start.position : new Vector3(46.74f,-13,0);
    }
    
}
