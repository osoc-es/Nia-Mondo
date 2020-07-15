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
    public Image hoverGoodWeapon;
    public Image hoverBadWeapon;

    [Space]
    [Header("Bad and good weapon")]
    public ScriptableWeapons badWeapon;
    public ScriptableWeapons goodWeapon;

    private ScriptableWeapons currentWeapon;
    private Platformer.Mechanics.PlayerController playerController;
    public GameObject player;

    private void Start()
    {
        disableHover();
        selectorCanvas.SetActive(false);
        confirmButton.onClick.AddListener(SelectionConfirmed);

        badWeaponButton.onClick.AddListener(BadWeaponSelected);
        goodWeaponButton.onClick.AddListener(GoodWeaponSelected);

        playerController= player.GetComponent<Platformer.Mechanics.PlayerController>();
    }

    //When the player triggers the point the time is stopped and the panel shows up
    private void OnTriggerEnter2D(Collider2D col)
    {

#if UNITY_EDITOR
        Debug.Log("Weapon Selector triggered");
#endif

        //Time.timeScale = 0.0f;
        playerController.controlEnabled = false;
        selectorCanvas.SetActive(true);
    }

    private void BadWeaponSelected()
    {
        disableHover();
        SetHover(hoverBadWeapon);
        currentWeapon = badWeapon;

    }
    private void GoodWeaponSelected()
    {
        disableHover();
        SetHover(hoverGoodWeapon);
        currentWeapon = goodWeapon;
    }

    private void SelectionConfirmed()
    {
        selectorCanvas.SetActive(false);
                playerController.controlEnabled = true;

       // Time.timeScale = 1.0f;
        if (!player.TryGetComponent(out PlayerWeaponController playerWeaponCon))
            Debug.LogError("No se encuentra el componente PLAYERWEAPONCONTROLLER", this);
        else playerWeaponCon.SetWeapon(currentWeapon);

        gameObject.SetActive(false);

        #if UNITY_EDITOR
        Debug.Log(player);
        #endif
        player.GetComponent<PlayerWeaponController>().SetWeapon(currentWeapon);

    }

    private void SetHover(Image hover)
    {
        hover.enabled = true;
    }

    private void disableHover(){
        hoverGoodWeapon.enabled = false;
        hoverBadWeapon.enabled = false;
    }

}
