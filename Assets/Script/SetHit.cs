using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetHit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnHit(bool isHit)
    {
        if (isHit)
        {
            print("hit true");
        }
    }
}
