using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
   // public Transform Player;
    private GameObject Player;
    public float Speed;
    [SerializeField]private float _stopDistans;
    [SerializeField] private float _distans;
  
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
       
    }

    // Update is called once per frame
    void Update()
    {
        _distans = Vector2.Distance(transform.position, Player.transform.position);
        if (_distans > _stopDistans)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, Speed * Time.deltaTime);

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bulat"))
        {
            
            Destroy(collision.gameObject,2f);
            Destroy(gameObject);
            
        }
    }

}
