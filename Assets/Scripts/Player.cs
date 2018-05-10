using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    private AudioSource audioSource;

    public int playerHealth;
    public float playerDamage;
    public bool isImmune;

    public AudioClip die;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerHealth <= 0)
        {
            StartCoroutine("Death");
        }
	}

    IEnumerator Death()
    {
        audioSource.clip = die;
        audioSource.Play();
        GetComponent<Animator>().SetTrigger("Death");
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject, 1);
        SceneManager.LoadScene("Main");
    }
}
