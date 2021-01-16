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
    public static bool AllowInput;
    [SerializeField] private GameObject projectile;
    [SerializeField] private int magSize;
    [SerializeField] private float projectileVelocity;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        canShoot = false;
        AllowInput = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot && AllowInput)
        {
            //check if rounds in Mag and Fire pressed, fire if true
            if (GameData.Instance.RoundsInMagazine > 0 && Input.GetButtonDown("Fire1"))
            {
                FireProjectile();
            }
            //Check for ammo and if Reload pressed, reload if true
            if (GameData.Instance.Ammunition > 0 && Input.GetButtonDown("Reload"))
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
        GameData.Instance.RoundsInMagazine--;
    }

    private void ReloadWeapon()
    {
        //get missing bullets
        int bulletDif = magSize - GameData.Instance.RoundsInMagazine;
        //check if more ammo then missing bullets
        if (GameData.Instance.Ammunition >= bulletDif)
        {
            //if ture, reload bullets, subtract bullets from ammunition
            GameData.Instance.RoundsInMagazine += bulletDif;
            GameData.Instance.Ammunition -= bulletDif;
        }
        else
        {
            //if false add remaining ammunition to magazine, set ammo to 0
            GameData.Instance.RoundsInMagazine += GameData.Instance.Ammunition;
            GameData.Instance.Ammunition = 0;
        }
    }
}
