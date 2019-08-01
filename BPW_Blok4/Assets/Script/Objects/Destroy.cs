using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : Powerup
{
    private Animator breakanim;
    //public Inventory playerInventory;

    // Start is called before the first frame update
    void Start()
    {
        breakanim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Breaking()
    {
        breakanim.SetBool("break", true);
        //playerInventory.coins += 1;
        //powerupSignal.Raise();
        Destroy(gameObject);
    }
}
 