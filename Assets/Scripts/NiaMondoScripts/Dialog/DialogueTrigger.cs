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

    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        playerWeaponController = playerController.gameObject.GetComponent<PlayerWeaponController>();
    }
    public void TriggerDialogue()
    {

        playerController.enabled = false;
        //TODO: seguramente habra que desactivar los disparos tambien

        if (playerWeaponController.GetWeapon().name == "Espray")
            dialogueManager.StartDialogue(badWeaponDialogue);
		else if(playerWeaponController.GetWeapon().name == "Jabón")
			dialogueManager.StartDialogue(goodWeaponDialogue);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {

#if UNITY_EDITOR
        Debug.Log("Dialog triggered");
#endif

        TriggerDialogue();
    }

}
