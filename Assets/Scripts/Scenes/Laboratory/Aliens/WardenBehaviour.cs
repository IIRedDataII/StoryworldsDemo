using UnityEngine;

public class WardenBehaviour : MonoBehaviour
{
    
    #region Variables
    
    // Unity variables
    [SerializeField] private Collider2D innerCollider;
    [SerializeField] private int id;

    #endregion

    private void Start()
    {
        
        #region Initialization

        if (GameData.Instance.DeadWardens[id])
            Destroy(gameObject);
        
        #endregion

    }
    
    #region Helper Functions

    private void MakeDead()
    {
        // TODO NTH: death animation
        Destroy(gameObject);
    }
    
    #endregion

    #region Public Functions

    public void Die()
    {
        GameData.Instance.DeadWardens[id] = true;
        MakeDead();
    }
    
    public bool CompareInnerCollider(Collider2D otherCollider)
    {
        return otherCollider.Equals(innerCollider);
    }

    #endregion
    
}
