using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulat : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip hitSound;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            audioSource.PlayOneShot(hitSound);
        }
    }
}
