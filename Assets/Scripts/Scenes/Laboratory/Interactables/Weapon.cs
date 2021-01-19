using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Interactable


{
    public GameObject projectile;
    public Transform bernd;
    public Transform playerPos;
    public void Start()
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
        Destroy(gameObject);
        StartCoroutine(killBernd());
    }

    protected override void UndoSpecificAction()
    {
        //Not necessary, but it has to be there, cause abstract class n stuff
    }

    protected override void SpecificUpdate()
    {
        //Not necessary, but it has to be there, cause abstract class n stuff
    }

    IEnumerator killBernd()
    {
        Debug.Log("1");
        Bernd.moveToWeapon = false;
        PlayerMovement.CanMove = false;
        PlayerShoot.AllowInput = false;
        Debug.Log("2");
        yield return new WaitForSeconds(0.5f);
        Debug.Log("3");
        Vector2 projectileDir = bernd.position - playerPos.position;
        float angle = Mathf.Acos(Vector2.Dot(projectileDir, Vector2.up) / projectileDir.magnitude) * Mathf.Rad2Deg;
        if (projectileDir.x > 0)
        {
            angle *= - 1;
        }

        GameObject temp = Instantiate(projectile, playerPos);
        temp.transform.Rotate(0f,0f,angle);
        temp.GetComponent<Rigidbody2D>().AddForce(projectileDir.normalized * 15, ForceMode2D.Impulse);
        Debug.Log("4");
    }
    
}
