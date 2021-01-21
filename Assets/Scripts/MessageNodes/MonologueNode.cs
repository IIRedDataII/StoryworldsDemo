using System.Collections;
using UnityEngine;

public abstract class MonologueNode : MonoBehaviour
{

    [SerializeField] protected MessageBox messageBox;
    protected string[] Messages;

    private void Start()
    {
        SpecificStart();
    }

    protected abstract void SpecificStart();
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            messageBox.ShowMonologue("Jordan", Messages);
            StartCoroutine(WaitForMessageBox());
        }
    }

    private IEnumerator WaitForMessageBox()
    {
        yield return new WaitWhile(() => messageBox.GetMessageActive());
        Destroy(gameObject);
    }
    
}
