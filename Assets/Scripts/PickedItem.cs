using UnityEngine;
using UnityEngine.Events;

public class PickedItem : MonoBehaviour
{
    public float points;
    GameManager gameManager;
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        points = -transform.position.y;
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision == null) { return; }
        if (collision.tag == "PlayerCollector") {
            gameManager.changeScoreBy(points);
            collision.transform.parent.GetComponent<PlayerMovement>().UpdateStats();
            Destroy(transform.parent.gameObject);
            GameSounds.instance.PlaySoundEffect("collect");
        }
    }
}
