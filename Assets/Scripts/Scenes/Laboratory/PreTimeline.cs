using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Playables;
using UnityEngine.UI;

public class PreTimeline : MonoBehaviour
{

    [SerializeField] private GameObject timeline;
    [SerializeField] private GameObject alienCleric1;
    [SerializeField] private GameObject alienAcademic1;
    [SerializeField] private GameObject alienAcademic2;
    [SerializeField] private GameObject alienAcademic3;
    [SerializeField] private GameObject lampLight;
    [SerializeField] private BoxCollider2D table;
    [SerializeField] private Door door;
    
    private void Start()
    {
        if (GameData.Instance.Respawned || GameData.Instance.SetGetlastRoom == GameData.LastRoom.City)
        {
            timeline.SetActive(false);
            Destroy(alienAcademic1);
            Destroy(alienAcademic2);
            Destroy(alienAcademic3);
            Destroy(alienCleric1);
            lampLight.GetComponent<Light2D>().enabled = false;
            GetComponent<PlayerLabPos>().enabled = true;
            table.enabled = true;
            door.Open();
        }
    }
    
}
