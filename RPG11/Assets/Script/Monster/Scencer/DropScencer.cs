﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropScencer : MonoBehaviour
{
    public GameObject Monster;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject.Find(Monster.name).GetComponent<DropGravity>().gra = true;
        }
    }
}
