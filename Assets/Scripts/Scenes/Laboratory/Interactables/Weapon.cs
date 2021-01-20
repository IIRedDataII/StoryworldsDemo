using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Interactable


{
    public GameObject projectile;
    public Transform bernd;
    public Transform playerPos;
    public MessageBox messageBox;
    public void Awake()
    {
        if (GameData.Instance.CanShoot)
        {
            Destroy(gameObject);
        }
    }
    
    protected override void SpecificAction()
    {
        GameData.Instance.CanShoot = true;
        UndoAction();
        //Enter TextBox Stuff for weapon, Maybe enable Weapon GUI Stuff
       
    }

    protected override void UndoSpecificAction()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
      gameObject.tag = "Untagged";
      StartCoroutine(killBernd());
    }

    protected override void SpecificUpdate()
    {
        //Not necessary, but it has to be there, cause abstract class n stuff
    }

    IEnumerator killBernd()
    {
        Bernd.moveToWeapon = false;
        PlayerMovement.CanMove = false;
        PlayerShoot.AllowInput = false;
        string[] messages = {
            "jo wtf",
            "ich wusste du Veräter gehörst zu den Alien \nHiiielfe",
            "Halts Maul sonst bekommen des noch die Wächter da draußen mit",
            "AHHHHH"
        };
        messageBox.ShowDialogue("Jordan", "Bernd", messages);
        yield return new WaitWhile(()=>messageBox.GetMessageActive());
        Vector2 projectileDir = bernd.position - playerPos.position;
        float angle = Mathf.Acos(Vector2.Dot(projectileDir, Vector2.up) / projectileDir.magnitude) * Mathf.Rad2Deg;
        if (projectileDir.x > 0)
        {
            angle *= - 1;
        }
        GameObject temp = Instantiate(projectile, playerPos);
        temp.transform.Rotate(0f,0f,angle);
        temp.GetComponent<Rigidbody2D>().AddForce(projectileDir.normalized * 15, ForceMode2D.Impulse);
        Destroy(gameObject);
    }
    
}
