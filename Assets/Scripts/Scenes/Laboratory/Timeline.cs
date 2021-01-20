using UnityEngine;
using UnityEngine.Playables;

public class Timeline : MonoBehaviour
{

    [SerializeField] private GameObject timeline;
    [SerializeField] private GameObject player;
    
    private void Start()
    {
        if (GameData.Instance.SeenIntro)
        {
            timeline.GetComponent<PlayableDirector>().time = 20;
            player.GetComponent<PlayerLabPos>().enabled = true;
        }
    }

    // called by timeline
    public void SetSeenIntro()
    {
        GameData.Instance.SeenIntro = true;
    }
    
}
