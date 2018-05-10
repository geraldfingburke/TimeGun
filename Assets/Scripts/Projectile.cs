using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && !col.GetComponent<Player>().isImmune)
        {
            col.GetComponent<Player>().playerHealth--;
            Destroy(gameObject, .01f);
        }
        else if (col.CompareTag("Enemy"))
        {
            col.GetComponent<Enemy>().health--;
            Destroy(gameObject, .01f);
        }
        else if (col.CompareTag("Detector"))
        {
        }
        else if (col.CompareTag("Projectile"))
        {

        }
        else
        {

            Destroy(gameObject, .01f);
        }
    }
}
