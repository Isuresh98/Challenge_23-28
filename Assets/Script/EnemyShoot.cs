using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject EnemyBulatPrefabs;
    public GameObject Player;
    public float ShootIntavel =1f;
    public float BulatSpeed =10f;
    private AudioSource audioSource;
    public AudioClip EnemyShootSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(ShootCorotine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   IEnumerator ShootCorotine()
    {
        while (true)
        {
            GameObject bulat = Instantiate(EnemyBulatPrefabs, transform.position, Quaternion.identity);
            Rigidbody2D rb = bulat.GetComponent<Rigidbody2D>();
            Vector2 Dix = (Player.transform.position - transform.position).normalized;
            rb.velocity = Dix * BulatSpeed * Time.deltaTime;
            audioSource.PlayOneShot(EnemyShootSound);
            Destroy(bulat, 3f);
            yield return new WaitForSeconds(ShootIntavel);
        }
    }
    }
