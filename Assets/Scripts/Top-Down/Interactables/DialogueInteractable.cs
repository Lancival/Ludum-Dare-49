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
			runner.GetComponent<DialogueControl>().SetMem();
    	if (dialogueStarted)
    		ui.MarkLineComplete();
    	else
    	{
    		runner.transform.position = transform.position;
    		runner.onDialogueComplete.AddListener(exitDialogue);
      	runner.StartDialogue(startNode);

				foreach(var i in runner.GetComponent<InMemoryVariableStorage>()){
					Debug.Log(i);
				}

      	dialogueStarted = true;
				addToList();
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

		private void addToList()
		{
			Inventory inv = GameObject.Find("Player").GetComponent<Player>().GetInventory();
			switch (this.name){
				case "Harper":
					inv.setChar("$hasTalkedToHarper");
					break;
				case "Alice":
					inv.setChar("$hasTalkedToAlice");
					break;
				case "Husband":
					inv.setChar("$hasTalkedToHusband");
					break;
				case "Dennis":
					inv.setChar("$hasTalkedToBrother");
					break;
			}
		}

}
