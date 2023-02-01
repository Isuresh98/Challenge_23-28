using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private GameObject player;
    public float speed = 2f;
    public float stopDistance = 0.5f;
    private AudioSource audioSource;
    public AudioClip enemyDeathSound;
    public bool hit;
    public bool hito;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        Fallow();
    }

    private void Fallow()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance > stopDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

        }
    }//Fallow

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bulat"))
        {
            audioSource.PlayOneShot(enemyDeathSound);
            Destroy(collision.gameObject);
            Destroy(this.gameObject,0.8f);

            
        }

    }
    
}
