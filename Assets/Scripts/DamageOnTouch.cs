using UnityEngine;
using UnityEngine.Events;

public class DamageOnTouch : MonoBehaviour
{
    public bool dieOnTouch = false;
    public UnityEvent onHurt;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision != null && collision.tag == "Player") {
            onHurt.Invoke();
        }
    }

}
