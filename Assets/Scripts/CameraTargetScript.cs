using UnityEngine;

public class CameraTargetScript : MonoBehaviour
{
    private Transform player_transform;
    private GameManager gameManager;
    private CharacterController playerController;
    private PlayerMovement playerMovement;

    [Header("Horizontal Bounds")]
    public float XLimit = 10f;

    private int lastZone = 0;

    void Start()
    {
        player_transform = GameObject.FindWithTag("Player").transform;
        gameManager = FindFirstObjectByType<GameManager>();
        playerController = player_transform.GetComponent<CharacterController>();
        playerMovement = player_transform.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        var pos = player_transform.position;

        float depth = Mathf.Abs(pos.y);
        int currentZone = Mathf.FloorToInt(depth / gameManager.ZoneSize);
        float threshold = gameManager.GetThresholdForZone(currentZone - 1 < 0 ? 0 : currentZone - 1);

        if (currentZone > lastZone) {
            gameManager.score = 0f;
            gameManager.deepestZoneReached = currentZone;
            lastZone = currentZone;
            playerMovement.upgradePanel.LevelUp();
        }

        float upperBoundary = (-gameManager.deepestZoneReached * gameManager.ZoneSize) - 2f;
        float lowerBoundary = gameManager.score >= threshold
            ? float.MinValue
            : (-(gameManager.deepestZoneReached + 1) * gameManager.ZoneSize) + 1f;

        playerMovement.upperBoundaryY = upperBoundary;
        playerMovement.lowerBoundaryY = lowerBoundary;

        pos.x = Mathf.Clamp(pos.x, -XLimit, XLimit);
        player_transform.position = pos;
        transform.position = player_transform.position;
    }
}