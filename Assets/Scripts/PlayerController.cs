using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Vector3 mousePosition;
    private new Camera camera;
    private Vector3 currentPos;
    private bool isWalking = false;
    private Animator anim;

    public AudioClip shot;
    public AudioClip shotDelay;
    public AudioSource audioSource;
    public GameObject projectile;
    public float playerSpeed;
    public float projectileSpeed;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        camera = FindObjectOfType<Camera>();
	}

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Input.inputString);
        camera.transform.position = new Vector3(transform.position.x, transform.position.y, -5);

        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        //transform.LookAt(new Vector3(mousePosition.x, mousePosition.y, transform.position.x));
        Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);
        transform.rotation = rot;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);

        if (Input.GetButton("Forward"))
        {
            anim.SetBool("isWalking", true);
            GetComponent<Rigidbody2D>().velocity = Vector3.up * playerSpeed;
            //GetComponent<Rigidbody2D>().velocity = transform.up * playerSpeed;
        } else if (Input.GetButton("Back"))
        {
            anim.SetBool("isWalking", true);
            GetComponent<Rigidbody2D>().velocity = Vector3.down * playerSpeed;
            //GetComponent<Rigidbody2D>().velocity = -transform.up * playerSpeed;
        } if (Input.GetButton("StrafeLeft"))
        {
            anim.SetBool("isWalking", true);
            GetComponent<Rigidbody2D>().velocity = Vector3.left * playerSpeed;
            //GetComponent<Rigidbody2D>().velocity = -transform.right * playerSpeed;
        } else if (Input.GetButton("StrafeRight"))
        {
            anim.SetBool("isWalking", true);
            GetComponent<Rigidbody2D>().velocity = Vector3.right * playerSpeed;
            //GetComponent<Rigidbody2D>().velocity = transform.right * playerSpeed;
        } else {
            anim.SetBool("isWalking", false);
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }

        if (Input.GetButtonDown("Shoot"))
        {
            StartCoroutine(Fire());
        }
    }

    IEnumerator Fire ()
    {
        Quaternion rot = Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);
        currentPos = transform.position;
        audioSource.clip = shotDelay;
        audioSource.Play();
        yield return new WaitForSeconds(Random.Range(1, 5)); 
        GameObject projectileClone;
        projectileClone = Instantiate(projectile, currentPos + transform.up, rot);
        yield return new WaitForSeconds(1);
        audioSource.clip = shot;
        audioSource.Play();
        projectileClone.GetComponent<Rigidbody2D>().velocity = projectileClone.transform.up * projectileSpeed;
    }

}
