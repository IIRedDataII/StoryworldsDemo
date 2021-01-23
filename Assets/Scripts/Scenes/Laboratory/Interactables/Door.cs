using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] protected float doorSpeed;

    [SerializeField] protected bool open;

    public void Update()
    {
        if (open)
        {
            if ((target.transform.position - transform.position).magnitude > 0.1)
            {
                transform.Translate((target.transform.position - transform.position) * doorSpeed * Time.deltaTime);  
            }
            else
            {
                open = false;
            }
        }
    }

    public void Open()
    {
        open = true;
    }
}
