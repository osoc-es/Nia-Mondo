using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SprayShoot : MonoBehaviour
{
    public ScriptableWeapons sprayScriptable;
    public GameObject sprayParticles;

    public GameObject weaponGO;

    public Transform sprayPosition;

    private bool canShoot = true;

    private Vector3 playerDir = new Vector3(0, 0, 0);
    private float dir = 0;

    private Platformer.Mechanics.PlayerController playerController;

    private PlayerWeaponController playerWeaponController;

    public int sprayDuration = 100;


    private bool rechargingSpray = false;
    public void Start()
    {
        weaponGO.SetActive(true);
        playerController = GetComponent<Platformer.Mechanics.PlayerController>();
        playerWeaponController = GetComponent<PlayerWeaponController>();
    }

    public void Update()
    {
        if (playerController.controlEnabled)
        {

            if (playerWeaponController.HasWeapon() && sprayDuration > 0)
            {
                if (canShoot && Input.GetKey(KeyCode.T))
                {

                    if (playerController.IsFacingRight())
                    {
                        playerDir.y = 0;
                        dir = 1;
                    }
                    else
                    {
                        playerDir.y = 180;
                        dir = -1;
                    }
                    SprayBullet sprayBullet = Instantiate(sprayParticles, sprayPosition.position, Quaternion.Euler(playerDir)).GetComponent<SprayBullet>();

                    sprayBullet.velocity = playerController.velocity.x;
                    sprayBullet.dir = dir;
                    sprayBullet.damage = sprayScriptable.damage;
                    sprayDuration -= 20;
                    if (sprayDuration <= 0 && !rechargingSpray)
                    {
                        rechargingSpray = true;
                        StartCoroutine(RechargeSpray());
                    }
                }
            }
        }
    }

    IEnumerator RechargeSpray()
    {
        yield return new WaitForSeconds(sprayScriptable.cooldown);
        sprayDuration = 100;
        rechargingSpray = false;
    }


}
