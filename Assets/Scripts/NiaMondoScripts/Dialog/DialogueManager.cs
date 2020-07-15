using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public Text nameText;
	public Text dialogueText;
	public GameObject dialogCanvas;
	public Animator animator;

	public LevelLoader levelLoader;

	private Queue<string> sentences;

	// Use this for initialization
	void Start () {
		dialogCanvas.SetActive(false);
		sentences = new Queue<string>();
	}

	public void StartDialogue (Dialogue dialogue)
	{
		Debug.Log("empezar dialogo");
		dialogCanvas.SetActive(true);
		animator.SetBool("IsOpen", true);

		nameText.text = dialogue.name;

		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence ()
	{
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}

	public void ConfirmWeaponSelection(){
		animator.SetBool("IsOpen", false);
		dialogCanvas.SetActive(false);
	}
	void EndDialogue()
	{
		animator.SetBool("IsOpen", false);
		dialogCanvas.SetActive(false);
		
		//Aqui habría que hacer la animación de que te ataca el pez, quitarte la vida y luego pasar a los créditos
		levelLoader.LoadNextLevel();
	}

}
