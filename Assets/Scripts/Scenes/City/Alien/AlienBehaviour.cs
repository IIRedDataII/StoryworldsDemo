using UnityEngine;

public class AlienBehaviour : MonoBehaviour
{
    
    #region Variables
    
    // Unity variables
    public Collider2D innerCollider;
    public int id;

    #endregion

    private void Start()
    {
        
        #region Initialization

        if (id >= 0 && GameData.Instance.DeadAliens[id])
            Destroy(gameObject);
        
        #endregion

    }
    
    #region Helper Functions

    private void MakeDead()
    {
        // TODO NTH: Just destroy game object? Or give it exploding animation? Or change sprite to a dead version? Or...?
        Destroy(gameObject);
    }
    
    #endregion

    #region Public Functions

    public void Die()
    {
        if (id >= 0)
            GameData.Instance.DeadAliens[id] = true;
        MakeDead();
    }
    
    public bool CompareInnerCollider(Collider2D otherCollider)
    {
        return otherCollider.Equals(innerCollider);
    }

    #endregion
    
}
