using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DialogueControl : MonoBehaviour
{

    private DialogueRunner runner;
    // Start is called before the first frame update
    void Start()
    {
      runner = GameObject.FindObjectOfType<DialogueRunner>();
      if (runner == null)
      {
        Debug.Log("DialogueInteractable unable to locate DialogueRunner.");
        Destroy(this);
      }
    }

    public void EnablePlayerControls()
    {
      GameObject.Find("Player").GetComponent<Player>().SetPlayerControls(true);
    }
    public void DisablePlayerControls()
    {
      GameObject.Find("Player").GetComponent<Player>().SetPlayerControls(false);
    }
}
