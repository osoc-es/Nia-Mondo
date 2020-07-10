using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    private ScriptableWeapons weapon;

    public void SetWeapon(ScriptableWeapons weapon){
        this.weapon = weapon;
        Debug.Log(this.weapon);
    }

    public ScriptableWeapons GetWeapon(){
        return weapon;
    }
}
