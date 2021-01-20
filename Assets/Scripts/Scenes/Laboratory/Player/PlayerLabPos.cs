using System.Collections;
using UnityEngine;

public class PlayerLabPos : MonoBehaviour
{
    
    [SerializeField] private Transform start;
    [SerializeField] private MessageBox messageBox;
    
    public void Start()
    {

        Utils.SetPlayerControls(false);
        // Former Starting Position: new Vector3(-6.14f, 1.77f, 0)
        transform.position = GameData.Instance.SetGetlastRoom == GameData.LastRoom.Start ? start.position : new Vector3(46.74f, -13, 0);
        if (GameData.Instance.SetGetlastRoom == GameData.LastRoom.Start)
        {
            StartCoroutine(InitialDelay());
        }
        
    }
    
    private void Monologue()
    {
        string[] messages = {
            "Ohh Mann, Alter mein Kopf. Wo hab ich den das Asperi..?",
            "Moment.\nWo bin ich denn bitte? Das ist nicht unser Schiff.",
            "Das ist auf jeden Fall nicht unser Schiff. Diese Behälter schauen sehr seltsam aus.",
            "Und an was erinnere ich mich? Ich lag auf einem Tisch, und ich hab irgendwelche Dinger gesehen.",
            "Vermischt mit meinen Erinnerungen. Sehr seltsam. Auf jeden Fall steht eins fest:",
            "ICH SOLLTE HIER SCHLEUNIGST RAUS!",
        };
        messageBox.ShowMonologue("Jordan", messages);
    }
    
    private IEnumerator InitialDelay()
    {
        yield return new WaitForSeconds(1.5f);
        Utils.SetPlayerControls(true);
        if (!GameData.Instance.Respawned)
            Monologue();
    }
    
}
