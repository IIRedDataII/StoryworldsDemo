using UnityEngine;

public class TrackPlayer : MonoBehaviour
{
    
    private GameObject _player;
    
    void Update()
    {
        if (_player)
            transform.rotation = Quaternion.Euler(0, _player.transform.position.x < transform.position.x ? 180 : 0, 0);
    }

    public void SetPlayerObject(GameObject player)
    {
        _player = player;
    }
    
}
