using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ScriptableWeapon", menuName = "Scriptable Weapons", order = 1)]
public class ScriptableWeapons : ScriptableObject
{
    public string weaponName;
   public float damage;
   public float cooldown;
   public float range;
   public Sprite image; 
}