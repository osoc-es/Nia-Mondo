using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerWeaponController : MonoBehaviour
{
    private ScriptableWeapons weapon;
    public string goodWeaponName = "Jabón";
    public string badWeaponName = "Espray";

    private bool hasWeapon = false;


    public void SetWeapon(ScriptableWeapons weapon)
    {
        this.weapon = weapon;

        if (weapon.weaponName == goodWeaponName)
        {
            //Activar script 
            Debug.Log("Se esta utilizando el jabon");
            if(TryGetComponent(out shootSomething shootSomethingComponent)){
                shootSomethingComponent.enabled = true;
                hasWeapon = true;
            }

        }
            
        else if (weapon.weaponName == badWeaponName)
        {
            Debug.Log("Se esta utilizando el espray");
            if(TryGetComponent(out SprayShoot sprayShootComponent)){
                sprayShootComponent.enabled = true;
                hasWeapon = true;
            }
            else Debug.LogError("No se encuentra el componente sprayshoot", this);
        }

        else{
            Debug.LogError("No se reconoce el arma seleccionada",this);
        }
    }

    public ScriptableWeapons GetWeapon()
    {
        return weapon;
    }

    public bool HasWeapon(){
        return hasWeapon;
    }
}
