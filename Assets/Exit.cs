using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {

    public AudioClip alert;
    public AudioClip exit;
    public Text alertText;

    private AudioSource audioSource;

    void Start ()
    {
        audioSource = GetComponent<AudioSource>();
    }

	void OnTriggerEnter2D (Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (FindObjectOfType<GameManager>().hasKeycard)
            {
                audioSource.clip = exit;
                audioSource.Play();
                SceneManager.LoadScene("End");
            }
            else {
                audioSource.clip = alert;
                audioSource.Play();
                alertText.color = Color.red;
            }
        }
    }

    void OnTriggerExit2D (Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            alertText.color = new Color(0, 0, 0, 0);
        }
    }
}
