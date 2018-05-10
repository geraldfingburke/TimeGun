using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingScene : MonoBehaviour {

    public Text lin;
    public Text sarge;
    public Image panel;
    public AudioClip mumble1;
    public AudioClip mumble2;
    public AudioClip laugh;

    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine("Scene");
	}
    IEnumerator Scene()
    {
        lin.text = "In the clear";
        audioSource.clip = mumble1;
        audioSource.Play();
        yield return new WaitForSeconds(2f);
        lin.text = "";
        audioSource.clip = mumble2;
        audioSource.Play();
        sarge.text = "Chopper coming for you now. The client will be very happy";
        yield return new WaitForSeconds(3f);
        lin.text = "Gonna kill baby Hitler?";
        audioSource.clip = mumble1;
        audioSource.Play();
        sarge.text = "";
        yield return new WaitForSeconds(3f);
        sarge.text = "Baby Gandhi, finally do away with this whole 'Passive Resistance' thing.";
        audioSource.clip = mumble2;
        audioSource.Play();
        lin.text = "";
        yield return new WaitForSeconds(3f);
        lin.text = "HAHAHAHA";
        audioSource.clip = laugh;
        audioSource.Play();
        sarge.text = "HAHAHAHA";
        yield return new WaitForSeconds(1.5f);
        StartCoroutine("Fade");
        yield return new WaitForSeconds(3f);
        
        SceneManager.LoadScene("Menu");
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
