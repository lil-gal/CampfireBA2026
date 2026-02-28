using UnityEngine;

public class AmbientDeepSea : MonoBehaviour {
    public float StopFadingY = -10;
    public float MaxVolume = .4f;
    
    private AudioSource audioSource;
    private Transform player_transform;

    void Start() {
        player_transform = FindFirstObjectByType<PlayerMovement>().transform;

        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.volume = 0f;
        audioSource.Play();
    }
    void Update() {
        audioSource.volume = Mathf.Clamp01(player_transform.position.y/StopFadingY)*MaxVolume;
    }
}
