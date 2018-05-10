using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private Player player;
    private Animator anim;
    private float distance;
    private AudioSource audioSource;

    public AudioClip shoot;
    public AudioClip die;
    public GameObject projectile;
    public float moveSpeed;
    public float projectileSpeed;
    public float health;
    public bool isAlert;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        anim.SetBool("isWalking", true);
        player = FindObjectOfType<Player>();
    }
	
	// Update is called once per frame
	void Update () {
        Quaternion rot = Quaternion.LookRotation(transform.position - player.transform.position, Vector3.forward);
        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
        if (health <= 0)
        {
            StartCoroutine("Death");
        }
        distance = Vector3.Distance(player.transform.position, transform.position);
        Debug.Log(distance);
    }

    IEnumerator MoveShoot ()
    {
        while (isAlert)
        {
            if (distance > 7)
            {
                anim.SetBool("isWalking", true);
                GetComponent<Rigidbody2D>().velocity = transform.up * moveSpeed;
            }
            yield return new WaitForSeconds(Random.Range(1, 2));
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            GameObject projectileClone;
            anim.SetBool("isWalking", false);
            Quaternion rot = Quaternion.Euler(0, 0, transform.eulerAngles.z);
            projectileClone = Instantiate(projectile, transform.position + transform.up, rot);
            audioSource.clip = shoot;
            audioSource.Play();
            projectileClone.GetComponent<Rigidbody2D>().velocity = projectileClone.transform.up * projectileSpeed;
            yield return new WaitForSeconds(Random.Range(1, 2));
        }
    }

    IEnumerator Death ()
    {
        audioSource.clip = die;
        audioSource.Play();
        anim.SetTrigger("Death");
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
