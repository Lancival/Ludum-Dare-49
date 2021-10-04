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
	}

	public void SetSpeaker(string[] parameters)
	{
		if (parameters != null)
			runner.transform.position = (parameters[0] == "MC" ? player.transform.position + offset : initPos);
	}

	private void SetInitPos()
	{
		initPos = runner.transform.position;
	}
}
