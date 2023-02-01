using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject player;
    public float shootInterval = 1f;
    public float bulletSpeed = 10f;
    private AudioSource audioSource;
    public AudioClip enemyShootSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(ShootCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator ShootCoroutine()
    {
        while (true)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            Vector2 direction = (player.transform.position - transform.position).normalized;
            rb.velocity = direction * bulletSpeed * Time.deltaTime;
            audioSource.PlayOneShot(enemyShootSound);
            Destroy(bullet, 2f);
            yield return new WaitForSeconds(shootInterval);
        }
    }

    }
