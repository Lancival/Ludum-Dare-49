using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class QuestCompletion : MonoBehaviour
{

	private DialogueRunner runner;
    [SerializeField] private AudioQuestComplete audioQuestComplete;

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
    	Settings.QUESTS_COMPLETED++;
        audioQuestComplete.DoAudioStuff();
    	if (Settings.QUESTS_COMPLETED == 4)
    		SceneLoader.SceneLoaderInstance.LoadNextScene("FinalScene");
    }

    // Temporary testing
    void Update()
    {
    	if (Input.GetKeyDown(KeyCode.Equals))
    	{
    		Debug.Log("Quest Complete!");
    		QuestComplete(null);
    	}
    }
}
