using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    [Header("New Scene Variables")]
    public string sceneToLoad;
    public Vector2 playerPosition;
    public VectorValue playerStorage;
    public Vector2 cameraNewMax;
    public Vector2 cameraNewMin;
    public VectorValue cameraMin;
    public VectorValue cameraMax;


    [Header("Transition Variables")]
    public GameObject fadeInPanel;
    public GameObject fadeOutPanel;
    public float fadeWait;

    

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            playerStorage.initialValue = playerPosition;
            SceneManager.LoadScene(sceneToLoad);
            ResetCameraBounds();
        }
    }

    

    public void ResetCameraBounds()
    {
        cameraMax.initialValue = cameraNewMax;
        cameraMin.initialValue = cameraNewMin;
    }
}
