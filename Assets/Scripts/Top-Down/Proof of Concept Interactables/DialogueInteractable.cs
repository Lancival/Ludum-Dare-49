using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DialogueInteractable : Interactable
{
	[SerializeField] private string startNode;
	private DialogueRunner runner;
	private DialogueUI ui;
	private bool dialogueStarted = false;

	void Start()
	{
		if (startNode == null)
		{
			Debug.Log("DialogueInteractable not provided with startNode for Yarn.");
			Destroy(this);
		}

		runner = GameObject.FindObjectOfType<DialogueRunner>();
		if (runner == null)
		{
			Debug.Log("DialogueInteractable unable to locate DialogueRunner.");
			Destroy(this);
		}
		ui = runner.GetComponent<DialogueUI>();
	}

    public override void interact()
    {
    	if (dialogueStarted)
    		ui.MarkLineComplete();
    	else
    	{
    		runner.transform.position = transform.position;
        	runner.StartDialogue(startNode);
        	dialogueStarted = true;
    	}
    }
}
