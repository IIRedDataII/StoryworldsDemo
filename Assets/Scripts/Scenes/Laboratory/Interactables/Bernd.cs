using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bernd : Interactable
{
    public GameObject projectile;
    public MessageBox messageBox;
    public Sprite alive;
    public Sprite dead;
    public GameObject WeaponPos;
    public Transform PlayerPos;
    public static bool moveToWeapon;

    private void Awake()
    {
        if (GameData.Instance.BerndDead)
        {
            gameObject.tag = "Untagged";
            gameObject.GetComponent<SpriteRenderer>().sprite = dead;
        }
    }

    protected override void SpecificAction()
    {
        WeaponPos.tag = "Interactable";
        UndoAction();
    }

    protected override void UndoSpecificAction()
    {
        string[] messages = {
            "jo wegen dir bin ich hier",
            "halts maul wir haben größere Probleme, wir kommen hier nie wieder weg deswegen bring ich dich jetzt um",
        };
        messageBox.ShowDialogue("Jordan", "Bernd", messages);
        StartCoroutine(startBernd());
    }

    protected override void SpecificUpdate()
    {
        if (moveToWeapon)
        {
            Vector3 dir = WeaponPos.transform.position - gameObject.transform.position;
            dir = dir.normalized;
            Vector2 weapon = new Vector2(WeaponPos.transform.position.x, WeaponPos.transform.position.y);
            if (gameObject.transform.position.x < weapon.x && gameObject.transform.position.y > weapon.y)
            {
                gameObject.transform.Translate(dir * 5 *Time.deltaTime);
            }
        }
    }
    
    public void Kill()
    {
        GameData.Instance.BerndDead = true;
        gameObject.tag = "Untagged";
        gameObject.GetComponent<SpriteRenderer>().sprite = dead;
        PlayerMovement.CanMove = true;
        PlayerShoot.AllowInput = true;
    }

    IEnumerator startBernd()
    {   yield return new WaitWhile(()=>messageBox.GetMessageActive());
        moveToWeapon = true;
    }

    IEnumerator killPlayer()
    {
        string[] messages = {
            "stirb du scheiß Alien",
            "jo warte wir sind Kollegen"
        };
        messageBox.ShowDialogue("Bernd","Jordan",messages);
        yield return new WaitWhile(()=>messageBox.GetMessageActive());
        Vector2 projectileDir = PlayerPos.position - transform.position;
        float angle = Mathf.Acos(Vector2.Dot(projectileDir, Vector2.up) / projectileDir.magnitude) * Mathf.Rad2Deg;
        if (projectileDir.x > 0)
        {
            angle *= - 1;
        }

        GameObject temp = Instantiate(projectile, transform);
        temp.transform.Rotate(0f,0f,angle);
        temp.GetComponent<Rigidbody2D>().AddForce(projectileDir.normalized * 15, ForceMode2D.Impulse);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.name.Equals("Weapon"))
        {
            moveToWeapon = false;
            PlayerMovement.CanMove = false;
            WeaponPos.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(killPlayer());
        }
    }
}
