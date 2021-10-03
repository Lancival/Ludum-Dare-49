using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
	public string nodeName;	// Name of the Yarn node to start when this is interacted with
    public abstract void interact();
}
