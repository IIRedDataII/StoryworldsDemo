using System.Collections;
using UnityEngine;

public abstract class MonologueNode : MonoBehaviour
{

    [SerializeField] protected MessageBox messageBox;
    protected string[] Messages;
    protected int ID;

    private void Start()
    {
        SpecificStart();
        
        if (GameData.Instance.TriggeredMonologueNodes.Contains(ID))
            Destroy(gameObject);
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
        GameData.Instance.TriggeredMonologueNodes.Add(ID);
        Destroy(gameObject);
    }
    
}
