using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    
    #region Attributes

    public static bool AllowInput;

    [SerializeField] private Sprite looksLeft;
    [SerializeField] private Sprite looksRight;
    [SerializeField] private Sprite looksLeftShoot;
    [SerializeField] private Sprite looksRightShoot;
    
    [SerializeField] private GameObject projectile;
    [SerializeField] private float projectileVelocity;
    [SerializeField] private int magSize;

    [SerializeField] private Image weaponStatsImage;
    [SerializeField] private Text weaponStatsText;

    private SpriteRenderer _spriteRenderer;

    private Coroutine _shooting;

    #endregion

    void Start()
    {
        weaponStatsText.enabled = false;
        weaponStatsImage.enabled = false;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        //GameData.Instance.CanShoot = false;
        AllowInput = true;
    }

    void Update()
    {
        if (!GameData.Instance.CanShoot && (weaponStatsImage || weaponStatsText))
        {
            weaponStatsImage.enabled = false;
            weaponStatsText.enabled = false;
        }

        if (GameData.Instance.CanShoot && AllowInput)
        {
            if (!weaponStatsImage.enabled || !weaponStatsText.enabled)
            {
                weaponStatsImage.enabled = true;
                weaponStatsText.enabled = true;
                UpdateTextfield();
            }

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
        _spriteRenderer.sprite = PlayerMovement.LookingRight ? looksRightShoot : looksLeftShoot;
        if (!(_shooting is null))
            StopCoroutine(_shooting);
        _shooting = StartCoroutine(ChangeSprite());
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Acos(Vector2.Dot(mousePos, Vector2.up) / mousePos.magnitude) * Mathf.Rad2Deg;
        if (mousePos.x > 0)
        {
            angle *= -1;
        }

        GameObject temp = Instantiate(projectile, transform);
        temp.transform.Rotate(0f, 0f, angle);
        temp.GetComponent<Rigidbody2D>().AddForce(mousePos.normalized * projectileVelocity, ForceMode2D.Impulse);
        GameData.Instance.RoundsInMagazine--;
        UpdateTextfield();
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

        UpdateTextfield();
    }

    private void UpdateTextfield()
    {
        weaponStatsText.text = GameData.Instance.RoundsInMagazine + "/" +
                               GameData.Instance.Ammunition;
    }

    private IEnumerator ChangeSprite()
    {
        yield return new WaitForSeconds(1f);
        _spriteRenderer.sprite = PlayerMovement.LookingRight ? looksRight : looksLeft;
    }
    
}