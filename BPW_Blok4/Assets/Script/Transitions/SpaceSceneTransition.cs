using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceSceneTransition : MonoBehaviour
{
    public string sceneToLoad;
    //public Vector2 playerPosition;
   // public VectorValue playerStorage;
    public bool playerInRange;



    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            //playerStorage.initialValue = playerPosition;
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("player in range");
        }
    }
}

