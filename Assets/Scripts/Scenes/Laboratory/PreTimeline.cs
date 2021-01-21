using UnityEngine;
using UnityEngine.Playables;

public class PreTimeline : MonoBehaviour
{

    [SerializeField] private GameObject timeline;
    
    private void Start()
    {
        if (GameData.Instance.SetGetlastRoom == GameData.LastRoom.City || GameData.Instance.Respawned)
        {
            PlayableDirector director = timeline.GetComponent<PlayableDirector>();
            director.time = director.duration;
            GetComponent<PlayerLabPos>().enabled = true;
        }
    }

    private void Update()
    {
        Debug.Log(transform.position);
    }
    
}
