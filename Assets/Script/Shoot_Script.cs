using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_Script : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float Bulatspeed = 10f;
    private AudioSource audioSource;
    public AudioClip playerShootSound;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            Vector2 roundedPos = new Vector2(Mathf.RoundToInt(worldPos.x), Mathf.RoundToInt(worldPos.y));

            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            Vector2 direction = (roundedPos - (Vector2)transform.position).normalized;
            rb.velocity = direction * Bulatspeed*Time.deltaTime;
            Destroy(bullet,2f);
            audioSource.clip = playerShootSound;
            audioSource.Play();


        }
       
    }
}
