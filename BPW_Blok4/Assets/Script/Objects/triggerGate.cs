using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class triggerGate : MonoBehaviour
{
    [Header("Door variables")]
    
    public bool open = false;
    public BoolValue isOpened;
    public SpriteRenderer doorSprite;
    public BoxCollider2D physicsCollider;
   // public BoxCollider2D physicsCollider2;

    

    


    void Start()
    {

        open = isOpened.RunTimeValue;
        if (open)
        {
            doorSprite.enabled = true;
            physicsCollider.enabled = true;
            //physicsCollider2.enabled = true;
        }
    }


    private void Update()
    {

        
    }

    

    public void close()
    {
        doorSprite.enabled = true;
        open = true;
        isOpened.RunTimeValue = open;
        physicsCollider.enabled = true;
        //physicsCollider2.enabled = true;
    }


    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            close();
        }
    }


}


