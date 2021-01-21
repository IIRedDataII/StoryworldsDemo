using System.Collections;
using UnityEngine;

public class MonologueNode : MonoBehaviour
{

    [SerializeField] private MessageBox messageBox;
    [SerializeField] private string[] messages;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            messageBox.ShowMonologue("Jordan", messages);
            StartCoroutine(WaitForMessageBox());
        }
    }

    private IEnumerator WaitForMessageBox()
    {
        yield return new WaitWhile(() => messageBox.GetMessageActive());
        Destroy(gameObject);
    }
    
}
