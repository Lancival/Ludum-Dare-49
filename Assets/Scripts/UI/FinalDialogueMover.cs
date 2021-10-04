using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class FinalDialogueMover : MonoBehaviour
{

	[SerializeField] private Transform player;
	[SerializeField] private Transform oliver;
	[SerializeField] private Transform dennis;
	[SerializeField] private Transform alice;
	[SerializeField] private Transform harper;
	[SerializeField] private Transform delilah;
	[SerializeField] private DialogueRunner runner;

	private Vector3 offset = new Vector3(0, 1f, 0);

    // Start is called before the first frame update
    void Start()
    {
        runner.AddCommandHandler("setSpeaker", SetSpeaker);
    }

    private void SetSpeaker(string[] parameters)
    {
    	if (parameters == null)
    		runner.transform.position = player.transform.position + offset;
    	else if (parameters[0] == "MC")
    		runner.transform.position = player.transform.position + offset;
    	else if (parameters[0] == "Oliver")
    		runner.transform.position = oliver.transform.position;
    	else if (parameters[0] == "Dennis")
    		runner.transform.position = dennis.transform.position + offset;
    	else if (parameters[0] == "Alice")
    		runner.transform.position = alice.transform.position;
    	else if (parameters[0] == "Harper")
    		runner.transform.position = harper.transform.position;
    	else if (parameters[0] == "Delilah")
    		runner.transform.position = delilah.transform.position;
    }
}
