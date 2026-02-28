using UnityEngine;

public class JellyFishScript : MonoBehaviour
{
    public float minBounceDistance = 1f;
    public float minTimeToBounce = 2f;
    public float maxBounceDistance = 8f;
    public float maxTimeToBounce = 10f;

    float bounceDistance;
    float timeToBounce;

    float timer;
    bool up = false;

    Rigidbody2D rb;
    void Start()
    {
        bounceDistance = Random.Range(minBounceDistance, maxBounceDistance);
        timeToBounce = Random.Range(minTimeToBounce, maxTimeToBounce);
        timer = timeToBounce;
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        if (timer > 0) {
            int times = 1;

            if (!up) {
                times = -1;
            }
            
            rb.linearVelocityY = times * Time.deltaTime * 100 * (bounceDistance/timeToBounce);

            

            timer-=Time.deltaTime;
        } else {
            timer = timeToBounce;
            up = !up;
        }
    }
}
