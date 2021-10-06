using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class QuestCompletion : MonoBehaviour
{

	private DialogueRunner runner;

    // Start is called before the first frame update
    void Start()
    {
    	runner = FindObjectOfType<DialogueRunner>();
    	if (runner == null)
    	{
    		Debug.Log("QuestCompletion unable to find Dialogue Runner");
    		Destroy(this);
    	}

    	runner.AddCommandHandler("questComplete", QuestComplete);
    }

    private void QuestComplete(string[] parameters)
    {
        if (parameters != null)
        {
            AudioQuestComplete.instance.DoAudioStuff();
            switch (parameters[0])
            {
                case "Alice":
                    Settings.ALICE_QUEST_COMPLETE = true;
                    break;
                case "Dennis":
                    Settings.DENNIS_QUEST_COMPLETE = true;
                    break;
                case "Harper":
                    Settings.HARPER_QUEST_COMPLETE = true;
                    break;
                case "Oliver":
                    Settings.OLIVER_QUEST_COMPLETE = true;
                    break;
                default:
                    break;
            }
            if (Settings.ALICE_QUEST_COMPLETE && Settings.DENNIS_QUEST_COMPLETE && Settings.HARPER_QUEST_COMPLETE && Settings.OLIVER_QUEST_COMPLETE)
                SceneLoader.SceneLoaderInstance.LoadNextScene("FinalScene");
        }
    }

    // Temporary testing
    void Update()
    {
    	if (Input.GetKeyDown(KeyCode.Equals))
    	{
    		Debug.Log("Quest Complete!");
    		QuestComplete(new string[] {"Alice"});
            QuestComplete(new string[] {"Dennis"});
            QuestComplete(new string[] {"Harper"});
            QuestComplete(new string[] {"Oliver"});
    	}
    }
}
