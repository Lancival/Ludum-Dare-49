using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DialogueControl : MonoBehaviour
{

    [SerializeField] private GameObject player;

    private DialogueRunner runner;
    private CustomUI ui;
    private Vector3 initPos;
    private Vector3 offset = new Vector3(0, 1f, 0);

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

      ui.onDialogueStart.AddListener(DisablePlayerControls);
      ui.onDialogueStart.AddListener(SetInitPos);
      ui.onDialogueEnd.AddListener(EnablePlayerControls);
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

    public void EnablePlayerControls()
    {
      player.GetComponent<Player>().SetPlayerControls(true);
    }

    public void DisablePlayerControls()
    {
      player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
      player.GetComponent<Animator>().Play("PlayerIdle");
      player.GetComponent<Player>().SetPlayerControls(false);
    }
}
