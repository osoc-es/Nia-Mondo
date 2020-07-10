using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WeaponSelector : MonoBehaviour
{
    //Panel to show when user triggers to select the weapon
    public GameObject selectorCanvas;

    //Buttons to select each weapon and confirm that selection
    public Button badWeaponButton;
    public Button goodWeaponButton;
    public Button confirmButton;

    public TMP_Text selectionText;


    [Space]
    [Header("Bad and good weapon")]
    public ScriptableWeapons badWeapon;
    public ScriptableWeapons goodWeapon;

    private ScriptableWeapons currentWeapon;

    private GameObject player;

    private void Start()
    {
        selectorCanvas.SetActive(false);
        confirmButton.onClick.AddListener(SelectionConfirmed);
        
        badWeaponButton.onClick.AddListener(BadWeaponSelected);
        goodWeaponButton.onClick.AddListener(GoodWeaponSelected);

        player = GameObject.FindGameObjectWithTag("arbo");

    }

    //When the player triggers the point the time is stopped and the panel shows up
    private void OnTriggerEnter2D(Collider2D col)
    {

#if UNITY_EDITOR
        Debug.Log("Weapon Selector triggered");
#endif

        Time.timeScale = 0.0f;
        selectorCanvas.SetActive(true);
    }

    private void BadWeaponSelected()
    {
      SetSelectionText(badWeapon.weaponName);
      currentWeapon = badWeapon;

    }
    private void GoodWeaponSelected()
    {
        SetSelectionText(goodWeapon.weaponName);
        currentWeapon = goodWeapon;
    }

    private void SelectionConfirmed()
    {
        selectorCanvas.SetActive(false);
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);
        #if UNITY_EDITOR
        Debug.Log(player);
        #endif
        player.GetComponent<PlayerWeaponController>().SetWeapon(currentWeapon);
    }
    
    private void SetSelectionText(string weaponName){
        selectionText.SetText("Has seleccionado como arma:\n" + weaponName );
    }

}
