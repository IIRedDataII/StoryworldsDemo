using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerLabPos : MonoBehaviour
{

    [SerializeField] private Transform start;
    [SerializeField] private MessageBox messageBox;
    [SerializeField] private GameObject alienRebel;
    
    public void Start()
    {

        GetComponentInChildren<Light2D>().enabled = true;
        
        if (GameData.Instance.SetGetlastRoom == GameData.LastRoom.Start)
        {
            transform.position = start.position;
            if (GameData.Instance.Respawned)
                Destroy(alienRebel);
            else
                StartCoroutine(InitialDelay());
        }
        else
        {
            transform.position = new Vector3(47f, -13f, 0);    //new Vector3(-6.14f, 1.77f, 0)
            Destroy(alienRebel);
        }
        
    }
    
    private IEnumerator InitialDelay()
    {
        Utils.SetPlayerControls(false);
        
        // rebel flee animation
        yield return new WaitForSeconds(1);
        for (int i = 0; i < 150; i++)
        {
            alienRebel.transform.position += new Vector3(0.12f, 0, 0);
            yield return new WaitForSeconds(0.01f);
        }
        Destroy(alienRebel);
    
        Utils.SetPlayerControls(true);
        messageBox.ShowMonologue("Jordan", Texts.StartMonologue);
    }
    
}
