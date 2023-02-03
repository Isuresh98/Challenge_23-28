using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_Script : MonoBehaviour
{
    public GameObject _bulatPrefabs;
    public float _bulatSpeed;
    Vector3 mousePos;
    Vector3 worlPos;
    private AudioSource audioSoce;
    public AudioClip PlayerShootSound;
    public GameObject EnemyPrefabs;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSoce = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();


    }

    public void OnHit(bool isHit)
    {
        if (isHit)
        {
            enemyIns();
        }
        
       
    }

   private void Shoot()
    {

        if (Input.GetMouseButtonDown(0))
        {
            mousePos = Input.mousePosition;
            worlPos = Camera.main.ScreenToWorldPoint(mousePos);
            Vector2 roundPos = new Vector2(Mathf.RoundToInt(worlPos.x), Mathf.RoundToInt(worlPos.y));

            GameObject bullat = Instantiate(_bulatPrefabs, transform.position, Quaternion.identity);

            Rigidbody2D _rbody = bullat.GetComponent<Rigidbody2D>();
            Vector2 direction = (roundPos - (Vector2)transform.position).normalized;
            _rbody.velocity = direction * _bulatSpeed * Time.deltaTime;
            Destroy(bullat, 2f);
            audioSoce.clip = PlayerShootSound;
            audioSoce.Play();
            
        }
    }

    public void enemyIns()
    {
        GameObject enemy = Instantiate(EnemyPrefabs, worlPos, Quaternion.identity);
    }

}
