using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerShoot : MonoBehaviour
{
#region Attributes
    public bool canShoot;
    [SerializeField] private GameObject projectile;
    [SerializeField] private int ammunition;
    [SerializeField] private int roundsInMagazine;
    [SerializeField] private int magSize;
    [SerializeField] private float projectileVelocity;
#endregion

    // Start is called before the first frame update
    void Start()
    {
        //canShoot = false;
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
                ReloadWeapon();
            }
        }
        
    }
    
    private void FireProjectile()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Acos(Vector2.Dot(mousePos, Vector2.up) / mousePos.magnitude) * Mathf.Rad2Deg;
        if (mousePos.x > 0)
        {
            angle *= - 1;
        }

        GameObject temp = Instantiate(projectile, transform);
        temp.transform.Rotate(0f,0f,angle);
        temp.GetComponent<Rigidbody2D>().AddForce(mousePos.normalized * projectileVelocity,ForceMode2D.Impulse);
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
