using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
#region Attributes
    public bool canShoot;
    [SerializeField] private GameObject projectile;
    [SerializeField] private int ammunition;
    [SerializeField] private int roundsInMagazine;
    [SerializeField] private int magSize;
#endregion

    // Start is called before the first frame update
    void Start()
    {
        canShoot = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot)
        {
            //check if rounds in Mag and Fire pressed, fire if true
            if (roundsInMagazine > 0 && Input.GetButtonDown("Fire1"))
            {
                FireProjectile();
            }
            //Check for ammo and if Reload pressed, reload if true
            if (ammunition > 0 && Input.GetButtonDown("Reload"))
            {
                Debug.Log("Tactical Reload!");
                ReloadWeapon();
            }
        }
        
    }
    
    private void FireProjectile()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Instantiate(projectile, transform).gameObject.transform.Rotate(0f,0f,Mathf.Atan2(mousePos.x, mousePos.y));
        roundsInMagazine--;
    }

    private void ReloadWeapon()
    {
        //get missing bullets
        int bulletDif = magSize - roundsInMagazine;
        //check if more ammo then missing bullets
        if (ammunition >= bulletDif)
        {
            //if ture, reload bullets, subtract bullets from ammunition
            roundsInMagazine += bulletDif;
            ammunition -= bulletDif;
        }
        else
        {
            //if false add remaining ammunition to magazine, set ammo to 0
            roundsInMagazine += ammunition;
            ammunition = 0;
        }
    }
}
