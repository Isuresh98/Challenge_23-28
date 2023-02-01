using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_Script : MonoBehaviour
{
    private GameObject bulletPrefab;
    public float Bulatspeed = 10f;
    private AudioSource audioSource;
    public AudioClip playerShootSound;
   [SerializeField] private GameObject enemyPrefab;
    Vector3 mousePoss;
    public bulat bulatScript;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        bulletPrefab = GameObject.FindWithTag("Bulat");
        bulatScript = bulletPrefab.GetComponent<bulat>();
        // enemyPrefab = GameObject.FindWithTag("Enemy");

    }

    // Update is called once per frame
    void Update()
    {
        Shoot();

    }
    public void OnHit(bool isHit)
    {
        if (!isHit)
        {
            print("hit true");
            enemyIns();

        }

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
            Destroy(bullet,1f);
            audioSource.clip = playerShootSound;
            audioSource.Play();

            mousePoss= worldPos ; 

        }
    }
    
        void enemyIns()
    {

        GameObject enemy = Instantiate(enemyPrefab, mousePoss, Quaternion.identity);

    }






}
