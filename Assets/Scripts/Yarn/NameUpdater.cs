using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Yarn.Unity;

public class NameUpdater : MonoBehaviour
{
    // Drag and drop your Dialogue Runner into this variable.
    [SerializeField] private DialogueRunner dialogueRunner;
    private TextMeshProUGUI name;

    public void Awake()
    {
    	name = transform.GetComponent<TextMeshProUGUI>();

    	if (dialogueRunner != null)
        	dialogueRunner.AddCommandHandler("setSpeaker", SetSpeaker);
    }

    private void SetSpeaker(string[] parameters) {
    	if (parameters != null)
        	name.text = parameters[0];
        else
        	name.text = "";
    }
}
