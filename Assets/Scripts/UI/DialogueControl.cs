using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DialogueControl : MonoBehaviour
{

	private Player player;
	private DialogueRunner runner;
	private CustomUI ui;
	private Vector3 initPos;
	private Vector3 offset = new Vector3(0, 1f, 0);
	private InMemoryVariableStorage thisInv;

	void Awake()
	{
		player = GameObject.FindObjectOfType<Player>().GetComponent<Player>();
		if (player == null)
		{
			Debug.Log("DialogueControl not provided Player.");
			Destroy(this);
		}
	}

	// Start is called before the first frame update
	void Start()
	{
		runner = GameObject.FindObjectOfType<DialogueRunner>();
		if (runner == null)
		{
			Debug.Log("DialogueControl unable to locate DialogueRunner.");
			Destroy(this);
		}
		ui = GameObject.FindObjectOfType<CustomUI>();

		if (ui == null)
		{
			Debug.Log("DialogueControl unable to locate CustomUI");
			Destroy(this);
	  	}
		runner.AddCommandHandler("setSpeaker", SetSpeaker);
		ui.onDialogueStart.AddListener(player.DisablePlayerControls);
		ui.onDialogueStart.AddListener(SetInitPos);
		ui.onDialogueEnd.AddListener(player.EnablePlayerControls);
		thisInv = runner.GetComponent<InMemoryVariableStorage>();
	}

	public void SetMem(){
		foreach(var i in player.GetInventory().GetItemsPickedUp()){
			thisInv.SetValue(i, true);
		}
		foreach(var i in player.GetInventory().GetCharsTalkedTo()){
			thisInv.SetValue(i, true);
		}
	}

	public void SetSpeaker(string[] parameters)
	{
		if (parameters != null)
			runner.transform.position = (parameters[0] == "MC" ? player.transform.position + offset : initPos);
		else
			runner.transform.position = initPos;
	}

	private void SetInitPos()
	{
		initPos = runner.transform.position;
	}


}
