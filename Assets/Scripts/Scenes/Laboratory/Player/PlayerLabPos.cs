using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLabPos : MonoBehaviour
{
    [SerializeField] private Transform start;
    [SerializeField] private MessageBox _box;
    private void Start()
    {
        //Former Starting Position new Vector3(-6.14f,1.77f,0)
        gameObject.transform.position = GameData.Instance.SetGetlastRoom == GameData.LastRoom.Start ? start.position : new Vector3(46.74f,-13,0);
        if (GameData.Instance.SetGetlastRoom == GameData.LastRoom.Start)
        {
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.5f);
        Monologue();
    }

    private void Monologue()
    {
        LinkedList<string> messages = new LinkedList<string>();
        messages.AddLast("Ohh Mann, F*ck mein Kopf. Wo hab ich den das Asperi..?");
        messages.AddLast("Moment.\n Wo bin ich denn bitte? Das ist nicht unser Schiff.");
        messages.AddLast("Das ist auf jeden Fall nicht unser Schiff. Diese Behälter schauen sehr seltsam aus.");
        messages.AddLast(
            "Und an was erinnere ich mich? Ich lag auf einem Tisch, und ich hab irgendwelche Dinger gesehen.");
        messages.AddLast(
            "Vermischt mit meinen Erinnerungen. Sehr seltsam. Auf jeden Fall steht eins Fest:");
        messages.AddLast("ICH SOLLTE HIER SCHLEUNIGST RAUS!");
        _box.ShowMonologue("Jordan",messages);
    }
    
}
