using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseTransitioner : MonoBehaviour
{
    [SerializeField] private int livingRoom;
    [SerializeField] private int bedroom;
    [SerializeField] private float duration;

    private Collider2D livingRoomDoor;
    private Collider2D bedroomDoor;
    private bool inLivingRoom;
    private float diff;

    private AudioPlayOneShot sfxDoorOpen;

    private void Awake()
    {
        sfxDoorOpen = GetComponent<AudioPlayOneShot>();    
    }

    void Start(){
      inLivingRoom = true;
      diff = (bedroom - livingRoom) / duration;
      Collider2D[] doors = this.GetComponents<BoxCollider2D>();
      if (doors[0].offset.x < 0){
        livingRoomDoor = doors[1];
        bedroomDoor = doors[0];
      }else{
        livingRoomDoor = doors[0];
        bedroomDoor = doors[1];
      }
      bedroomDoor.enabled = false;
    }
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player"){
          if (inLivingRoom){
              StartCoroutine(other.GetComponent<CameraMove>().CamPan(diff, 0, 2f));
              livingRoomDoor.enabled = false;
              bedroomDoor.enabled = true;
          }else{
              StartCoroutine(other.GetComponent<CameraMove>().CamPan(-diff, 0, 2f));
              livingRoomDoor.enabled = true;
              bedroomDoor.enabled = false;
          }
          inLivingRoom = !inLivingRoom;

          sfxDoorOpen.Play();
        }
    }
}
