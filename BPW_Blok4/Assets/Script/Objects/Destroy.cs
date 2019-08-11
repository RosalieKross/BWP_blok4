using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : Powerup
{

    public LootTable thisLoot;
    private Animator breakanim;
    public bool breaking;
    public BoolValue isbroken;
    //public Inventory playerInventory;

    // Start is called before the first frame update
    void Start()
    {
        breakanim = GetComponent<Animator>();
        breaking = isbroken.RunTimeValue;
        if (breaking)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void MakeLoot() // spawn loot wanneer enemy dood gaat
    {
        if (thisLoot != null)
        {
            Powerup current = thisLoot.LootPowerup();
            if (current != null)
            {
                Instantiate(current.gameObject, transform.position, Quaternion.identity);
            }
        }
    }

    public void Breaking()
    {
        SoundManager.PlayeSound("PotBreak");
        breaking = true;
        isbroken.RunTimeValue = breaking;
        breakanim.SetBool("break", true);
        
        MakeLoot();
        //playerInventory.coins += 1;
        //powerupSignal.Raise();
        Destroy(gameObject);
    }
}
 