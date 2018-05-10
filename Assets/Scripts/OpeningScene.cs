using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpeningScene : MonoBehaviour {

    public Text lin;
    public Text sarge;
    public Image panel;
    public AudioClip mumble1;
    public AudioClip mumble2;
    public AudioClip alarm;

    private AudioSource audioSource;


	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine("Scene");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Scene ()
    {
        /*
        sarge.text = "";
        lin.text = "";
        yield return new WaitForSeconds(.5f);
        yield return new WaitForSeconds(1f);
        yield return new WaitForSeconds(2f);
        yield return new WaitForSeconds(3f);
        */

        sarge.text = "Do you have it?";
        audioSource.clip = mumble1;
        audioSource.Play();
        yield return new WaitForSeconds(2f);
        lin.text = "I got it";
        audioSource.clip = mumble2;
        audioSource.Play();
        sarge.text = "";
        yield return new WaitForSeconds(2f);
        lin.text = "";
        audioSource.clip = mumble1;
        audioSource.Play();
        sarge.text = "The Time Gun. Capable of sending a bullet to any point in time";
        yield return new WaitForSeconds(3f);
        sarge.text = "";
        audioSource.clip = alarm;
        audioSource.Play();
        lin.text = "It's crazy how easy-";
        yield return new WaitForSeconds(3f);
        lin.text = "";
        audioSource.clip = mumble1;
        audioSource.Play();
        sarge.text = "Damn! Security sealed the vents! You're going to need to fight your way out!";
        yield return new WaitForSeconds(4f);
        sarge.text = "";
        audioSource.clip = mumble2;
        audioSource.Play();
        lin.text = "With what? My looks?";
        yield return new WaitForSeconds(3f);
        lin.text = "";
        audioSource.clip = mumble1;
        audioSource.Play();
        sarge.text = "Use the Time Gun! There should be a dial on the side. Set it to 'Present'";
        yield return new WaitForSeconds(3f);
        sarge.text = "";
        audioSource.clip = mumble2;
        audioSource.Play();
        lin.text = "It's in Spanish! What's 'Aleatorio' mean?";
        yield return new WaitForSeconds(2f);
        StartCoroutine("Fade");
        audioSource.clip = mumble1;
        audioSource.Play();
        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene("Main");
    }

    IEnumerator Fade()
    {
        while (panel.color.a < 1)
        {
            panel.color += new Color(0, 0, 0, 1 * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
}
