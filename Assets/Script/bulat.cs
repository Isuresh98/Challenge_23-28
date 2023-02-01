using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulat : MonoBehaviour
{
   public bool hit;

    public Shoot_Script shootScript;

    // Start is called before the first frame update
    void Start()
    {
        hit = false;

       shootScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Shoot_Script>();
     // shootScript = GetComponent<SetHit>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            hit = true;

            if (shootScript != null)
            {
                shootScript.OnHit(hit);
                print(hit);
            }
            
        }
        

    }
    
}
