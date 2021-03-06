using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderOrder : MonoBehaviour
{

    [SerializeField] private float offset = 0f;
    private GameObject player;
    private SpriteRenderer renderer;
    private float location;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        if (player == null){
          Debug.Log(this.gameObject.name + "lacks a player to render against.");
          Destroy(this);
        }
        renderer = GetComponent<SpriteRenderer>();
        location = transform.position.y + offset + .5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.Find("Player");
        }
        if (player.transform.position.y > location)
          renderer.sortingOrder = 1; // Render above player
        else
          renderer.sortingOrder = -1; // Render below player
    }
}
