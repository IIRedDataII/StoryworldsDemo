using System.Collections;
using UnityEngine;

public class PlayerLabPos : MonoBehaviour
{
    
    [SerializeField] private Transform start;
    [SerializeField] private MessageBox messageBox;
    [SerializeField] private GameObject alienRebel;
    
    public void Start()
    {

        Utils.SetPlayerControls(false);
        // Former Starting Position: new Vector3(-6.14f, 1.77f, 0)
        // TODO MH: player doesnt spawn at start
        transform.position = GameData.Instance.SetGetlastRoom == GameData.LastRoom.Start ? start.position : new Vector3(46.74f, -13, 0);
        if (GameData.Instance.SetGetlastRoom == GameData.LastRoom.Start)
        {
            StartCoroutine(InitialDelay());
        }
        
    }

    private void Update()
    {
        Debug.Log(transform.position);
    }

    private void Monologue()
    {
        messageBox.ShowMonologue("Jordan", Texts.StartMonologue);
    }
    
    private IEnumerator InitialDelay()
    {
        // rebel flee animation
        yield return new WaitForSeconds(1);
        for (int i = 0; i < 150; i++)
        {
            alienRebel.transform.position += new Vector3(0.12f, 0, 0);
            yield return new WaitForSeconds(0.01f);
        }
        Destroy(alienRebel);
        Utils.SetPlayerControls(true);
        if (!GameData.Instance.Respawned)
            Monologue();
    }
    
}
