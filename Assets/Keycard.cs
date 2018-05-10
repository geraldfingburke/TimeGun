using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keycard : MonoBehaviour {

    public AudioClip pickup;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
	void OnTriggerEnter2D (Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            audioSource.clip = pickup;
            audioSource.Play();
            FindObjectOfType<GameManager>().hasKeycard = true;
            Destroy(gameObject, .01f);
        }
    }
}
