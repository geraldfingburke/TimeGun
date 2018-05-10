using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

	void Update ()
    {
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }
}
