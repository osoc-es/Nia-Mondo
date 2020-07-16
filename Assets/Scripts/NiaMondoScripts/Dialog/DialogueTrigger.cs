using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue badWeaponDialogue;
	public Dialogue goodWeaponDialogue;
    
    public Platformer.Mechanics.PlayerController playerController;
    private PlayerWeaponController playerWeaponController;
    private DialogueManager dialogueManager;

    public Animator pezAnimator;

    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        playerWeaponController = playerController.gameObject.GetComponent<PlayerWeaponController>();
    }
    public void TriggerDialogue()
    {

        playerController.controlEnabled = false;
        //TODO: seguramente habra que desactivar los disparos tambien
        if (playerWeaponController.GetWeapon().weaponName == "Espray")
        {

            //Aqui activamos la anim, la anim en el ultimo frame llamara a StartBadWeaponDialogue()
             dialogueManager.StartDialogue(badWeaponDialogue,true);
        }
            
		else if(playerWeaponController.GetWeapon().weaponName == "Jabón")
			dialogueManager.StartDialogue(goodWeaponDialogue,false);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {

#if UNITY_EDITOR
        Debug.Log("Dialog triggered");
#endif

        TriggerDialogue();
    }

}
