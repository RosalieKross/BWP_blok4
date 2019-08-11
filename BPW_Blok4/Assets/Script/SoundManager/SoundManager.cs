using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip playerHitSound, playerWalkSound, coinPickup,
        PlayerDamage, EnemyDamage, DrikPotion, Click, OpenPanel, ItemPickUp, PotBreak, UnlockDoor, OpenChest;
    static AudioSource audicoSrc;
    // Start is called before the first frame update
    void Start()
    {
        playerHitSound = Resources.Load<AudioClip>("playerHit");
        playerWalkSound = Resources.Load<AudioClip>("playerWalk");
        coinPickup = Resources.Load<AudioClip>("coinPickup");
        PlayerDamage = Resources.Load<AudioClip>("PlayerDamage");
        EnemyDamage = Resources.Load<AudioClip>("EnemyDamage");
        DrikPotion = Resources.Load<AudioClip>("DrikPotion");
        Click = Resources.Load<AudioClip>("Click");
        OpenPanel = Resources.Load<AudioClip>("OpenPanel");
        ItemPickUp = Resources.Load<AudioClip>("ItemPickUp");
        PotBreak = Resources.Load<AudioClip>("PotBreak");
        UnlockDoor = Resources.Load<AudioClip>("UnlockDoor");
        OpenChest = Resources.Load<AudioClip>("OpenChest");

        audicoSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlayeSound(string clip)
    {
        switch (clip)
        {
            case "playerHit":
                audicoSrc.PlayOneShot(playerHitSound);
                break;
            case "playerWalk":
                audicoSrc.PlayOneShot(playerWalkSound);
                break;
            case "coinPickup":
                audicoSrc.PlayOneShot(coinPickup);
                break;
            case "PlayerDamage":
                audicoSrc.PlayOneShot(PlayerDamage);
                break;
            case "EnemyDamage":
                audicoSrc.PlayOneShot(EnemyDamage);
                break;
            case "DrikPotion":
                audicoSrc.PlayOneShot(DrikPotion);
                break;
            case "Click":
                audicoSrc.PlayOneShot(Click);
                break;
            case "OpenPanel":
                audicoSrc.PlayOneShot(OpenPanel);
                break;
            case "ItemPickUp":
                audicoSrc.PlayOneShot(ItemPickUp);
                break;
            case "PotBreak":
                audicoSrc.PlayOneShot(PotBreak);
                break;
            case "UnlockDoor":
                audicoSrc.PlayOneShot(UnlockDoor);
                break;
            case "OpenChest":
                audicoSrc.PlayOneShot(OpenChest);
                break;
        }
    }
}
