﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropellerController : MonoBehaviour {

    public float propellerSpeed;

    private AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.Play();
    }

    void Update () {  
        transform.Rotate(Vector3.down * propellerSpeed );
    }
}
