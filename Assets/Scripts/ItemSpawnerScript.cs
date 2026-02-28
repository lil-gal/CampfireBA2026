using UnityEngine;

public class ItemSpawnerScript : MonoBehaviour {

public Transform SpawnInto;
public Camera CameraObject;
public int PreSpawnUnits = 2;
public float UnitSize = 1;
public float MinSpawnDistanceFromPlayer = 10f;

private Transform camera_transform;
private float camera_width;

private int max_x_covered;
private int min_x_covered;
private int lastSpawnedZone = -1;

private GameManager gameManager;
private Transform player_transform;

[System.Serializable]
public class ItemSpawnerEntry {
    public GameObject PrefabToSpawn;
    public float MaxY;
    public float MinY;
    public float Density = 10;
    public float DensityMultiplier = 1;
    public bool Disabled = false;

    [Header("Zone Settings")]
    public bool UseZoneBounds = false;
    public int ZoneOverride = -1;
}

public ItemSpawnerEntry[] SpawningRules;
private float[] density_accumulation;

void Start() {
    CameraObject = FindFirstObjectByType<Camera>();
    camera_transform = CameraObject.transform;
    camera_width = CameraObject.orthographicSize * 2 * CameraObject.aspect;
    density_accumulation = new float[SpawningRules.Length];
    gameManager = FindFirstObjectByType<GameManager>();
    player_transform = GameObject.FindWithTag("Player").transform;
    lastSpawnedZone = gameManager.deepestZoneReached;

    max_x_covered = getBoundryLeft() - 1;
    min_x_covered = getBoundryLeft();

    int should_cover_right = getBoundryRight();
    for (int ix = max_x_covered + 1; ix <= should_cover_right; ix++)
        SpawnColumn(ix);
    max_x_covered = should_cover_right;
    min_x_covered = getBoundryLeft();
}


void FixedUpdate() {
    int currentZone = gameManager.deepestZoneReached;

    if (currentZone != lastSpawnedZone) {
        foreach (Transform item in SpawnInto)
            if (item != null) Destroy(item.gameObject);

        max_x_covered = getBoundryRight();
        min_x_covered = getBoundryLeft();
        lastSpawnedZone = currentZone;
    }

    int should_cover_right = getBoundryRight();
    for (int ix = max_x_covered + 1; ix <= should_cover_right; ix++)
        SpawnColumn(ix);
    max_x_covered = should_cover_right;

    int should_cover_left = getBoundryLeft();
    for (int ix = min_x_covered - 1; ix >= should_cover_left; ix--)
        SpawnColumn(ix);
    min_x_covered = should_cover_left;

    float remove_right = (getBoundryRight() + PreSpawnUnits + 1) * UnitSize;
    float remove_left  = (getBoundryLeft()  - PreSpawnUnits - 1) * UnitSize;

    foreach (Transform item in SpawnInto)
        if (item != null && (item.position.x > remove_right || item.position.x < remove_left))
            Destroy(item.gameObject);
}

void SpawnColumn(int ix) {
    float x = ix * UnitSize;
    float w = UnitSize;
    for (int i = 0; i < SpawningRules.Length; i++) {
        var entry = SpawningRules[i];

        if (entry.Disabled) continue;
        if (entry.ZoneOverride >= 0 && gameManager.deepestZoneReached != entry.ZoneOverride) continue;

        int targetZone = entry.ZoneOverride >= 0
            ? entry.ZoneOverride
            : gameManager.deepestZoneReached;

        float zoneBoundsMinY = -(targetZone + 1) * gameManager.ZoneSize;
        float zoneBoundsMaxY = -targetZone * gameManager.ZoneSize;

        float spawnMinY = entry.UseZoneBounds ? zoneBoundsMinY : entry.MinY;
        float spawnMaxY = entry.UseZoneBounds ? zoneBoundsMaxY : entry.MaxY;

        float density = entry.Density * entry.DensityMultiplier + density_accumulation[i];
        density_accumulation[i] = density % 1;
        RandomlySpawnInArea(entry.PrefabToSpawn, (int)density, x, spawnMinY, w, spawnMaxY - spawnMinY);
    }
}

int getBoundryRight() {
    return (int)Mathf.Ceil((camera_transform.position.x + camera_width / 2 + PreSpawnUnits) / UnitSize);
}

int getBoundryLeft() {
    return (int)Mathf.Floor((camera_transform.position.x - camera_width / 2 - PreSpawnUnits) / UnitSize);
}

void RandomlySpawnInArea(GameObject prefab, int amount, float x, float y, float w, float h) {
    var pos = Vector3.zero;
    for (int i = 0; i < amount; i++) {
        int attempts = 0;
        do {
            pos.x = Random.Range(x, x + w);
            pos.y = Random.Range(y, y + h);
            attempts++;
        } while (Vector2.Distance(pos, player_transform.position) < MinSpawnDistanceFromPlayer && attempts < 10);

        if (attempts < 10)
            Instantiate(prefab, pos, transform.rotation, SpawnInto);
    }
}

}
