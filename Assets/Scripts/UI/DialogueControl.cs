using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DialogueControl : MonoBehaviour
{

    [SerializeField] private GameObject player;

    private DialogueRunner runner;
    private Vector3 initPos;
    private Vector3 playerPos;
    // Start is called before the first frame update
    void Start()
    {
      runner = GameObject.FindObjectOfType<DialogueRunner>();
      if (runner == null)
      {
        Debug.Log("DialogueInteractable unable to locate DialogueRunner.");
        Destroy(this);
      }
    	runner.AddCommandHandler("setSpeaker", SetSpeaker);
    }

    public void SetSpeaker(string[] parameters) {
      runner.transform.position = parameters[0] == "MC" ? playerPos : initPos;
    }

    public void SetInitPos(){
      initPos = runner.transform.position;
      playerPos = player.transform.position + new Vector3(0,.33f,0);
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
