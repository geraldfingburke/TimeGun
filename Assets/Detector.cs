﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            GetComponentInParent<Enemy>().isAlert = true;
            GetComponentInParent<Enemy>().StartCoroutine("MoveShoot");
        }
    }
}
