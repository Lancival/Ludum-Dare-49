using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioItemPickupSingleton : MonoBehaviour
{
    public static AudioItemPickupSingleton instance = null;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
}
