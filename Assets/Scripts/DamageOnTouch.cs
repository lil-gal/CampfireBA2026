using UnityEngine;
using UnityEngine.Events;

public class DamageOnTouch : MonoBehaviour
{
    public bool dieOnTouch = false;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision != null && collision.tag == "Hurtbox") {
            collision.transform.parent.gameObject.GetComponent<PlayerMovement>().Death();
        }
    }

}
