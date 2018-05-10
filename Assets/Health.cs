using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public AudioClip pickup;

    private AudioSource audioSource;

    void Start ()
    {
        audioSource = GetComponent<AudioSource>();
    }

	void OnTriggerEnter2D (Collider2D col)
    {
        if (col.CompareTag("Player")) {
            audioSource.clip = pickup;
            audioSource.Play();
            col.GetComponent<Player>().playerHealth = 10;
            Destroy(gameObject, .01f);
        }
    }
}
