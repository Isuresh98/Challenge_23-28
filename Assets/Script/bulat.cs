﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulat : MonoBehaviour
{
    public AudioSource audioSouce;
    public AudioClip HitSound;
    private bool hit;
    public Shoot_Script shootScript;

    // Start is called before the first frame update
    void Start()
    {
        audioSouce = GetComponent<AudioSource>();
        shootScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Shoot_Script>();

    }

    // Update is called once per frame
    void Update()
    {
       

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            audioSouce.PlayOneShot(HitSound);
            hit = false;
            if (shootScript != null)
            {
                shootScript.OnHit(hit);
            }
        }
        if (collision.gameObject.CompareTag("bound"))
        {
            hit = true;
            if (shootScript != null)
            {
                shootScript.OnHit(hit);
            }
            Destroy(gameObject);
        }

    }

}
    

