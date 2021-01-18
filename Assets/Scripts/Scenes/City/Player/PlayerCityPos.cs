using UnityEngine;

public class PlayerCityPos : MonoBehaviour
{
    
    #region Variables
    
    [SerializeField] private GameObject laboratoryJunction;
    [SerializeField] private GameObject spaceshipJunction;
    [SerializeField] private GameObject curchJunction;
    
    #endregion
    
    private void Start()
    {
        
        #region Player Positioning
            
        switch (GameData.Instance.SetGetlastRoom)
        {
            case GameData.LastRoom.Spaceship:
                gameObject.transform.position = spaceshipJunction.transform.position + new Vector3(0.0f, -2.0f, 0.0f);
                break;
            case GameData.LastRoom.Lab:
                gameObject.transform.position = laboratoryJunction.transform.position + new Vector3(2.0f, 0.0f, 0.0f);
                break;
            case GameData.LastRoom.Church:
                gameObject.transform.position = curchJunction.transform.position + new Vector3(-2.0f, 0.0f, 0.0f);
                break;
            default:
                gameObject.transform.position = laboratoryJunction.transform.position + new Vector3(2.0f, 0.0f, 0.0f);
                break;
        }
            
        #endregion

    }
    
}
