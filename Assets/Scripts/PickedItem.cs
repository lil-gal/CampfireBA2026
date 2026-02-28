using UnityEngine;
using UnityEngine.Events;

public class PickedItem : MonoBehaviour
{
    public float points;
    GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameController").gameObject.GetComponent<GameManager>();
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision == null) { return; }
        if (collision.tag == "PlayerCollector") {
            gameManager.addScore(points);
            collision.transform.parent.GetComponent<PlayerMovement>().UpdateStats();
            Destroy(transform.parent.gameObject);
        }
    }
}
