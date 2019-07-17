using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioMagnet : MonoBehaviour {
    public static AudioClip spineSound;
    static AudioSource audioSrc;

	// Use this for initialization
	void Start () {
        spineSound = Resources.Load<AudioClip>("spineSound");
        audioSrc = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "spineSound":
                audioSrc.PlayOneShot(spineSound);
                break;
        }
    }
}
