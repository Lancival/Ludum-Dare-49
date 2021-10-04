using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DialogueInteractable : Interactable
{
	[SerializeField] private string startNode;
	[SerializeField] private float talkCooldown = 2.0f;

	private DialogueRunner runner;
	private CustomUI ui;
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
		ui = runner.GetComponent<CustomUI>();
	}

    public override void interact()
    {
    	if (dialogueStarted)
    		ui.MarkLineComplete();
    	else
    	{
				setState();
    		runner.transform.position = transform.position;
    		runner.onDialogueComplete.AddListener(exitDialogue);
        	runner.StartDialogue(startNode);
        	dialogueStarted = true;
    	}
    }

    private void exitDialogue()
    {
    	StartCoroutine(Wait(talkCooldown));
    }

    private IEnumerator Wait(float duration)
    {
    	yield return new WaitForSeconds(duration);
    	dialogueStarted = false;
    	runner.onDialogueComplete.RemoveListener(exitDialogue);
    }

		private void setState(){
			Inventory inventory = GameObject.Find("Player").GetComponent<Player>().GetInventory();
			switch (this.name){
				case "Harper":
					inventory.setChar("Harper");
					break;
				case "Alice":
					inventory.setChar("Alice");
					break;
				case "Dennis":
					inventory.setChar("Brother");
					break;
				case "Husband":
					inventory.setChar("Husband");
					break;
			}
		}
}
