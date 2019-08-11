using UnityEngine;
using UnityEngine.Playables;

public class TimeLineOnTrigger : MonoBehaviour
{
    public PlayableDirector timeline;

    // Use this for initialization
    void Start()
    {
        timeline = GetComponent<PlayableDirector>();
    }


    void OntOnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            timeline.Stop();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            timeline.Play();
        }
    }
}