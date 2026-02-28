using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class ItemSpawnerScript : MonoBehaviour {
    
    // please excuse my headache :)

    public Transform SpawnInto;
    public Camera CameraObject;
    public int PreSpawnUnits = 2;
    public float UnitSize = 1;

    private Transform camera_transform;
    private float camera_width; // about 21; !it isnt counted in pixels!

    private int max_x_covered;

    [System.Serializable]
    public class ItemSpawnerEntry {
        public GameObject PrefabToSpawn;
        public float MinY;
        public float MaxY;
        public float Density = 10; // in one unity unit
        public float DensityMultiplier = 1; // for external configuring; might remove it if useless.. it might be useless--
        public bool Disabled = false;
    }

    public ItemSpawnerEntry[] SpawningRules;
    private float[] density_accumulation; // to allow densities as 10.5 or 0.01; use: final_density = [...]+density_accumulation[i]; density_accumulation[i] = final_density%1
    // i didnt know how to name this lmao


    void Start() {
        CameraObject = FindFirstObjectByType<Camera>();
        camera_transform = CameraObject.transform;
        camera_width = CameraObject.orthographicSize*2*CameraObject.aspect;
        max_x_covered = getBoundryLeft();
        density_accumulation = new float[SpawningRules.Length];
    }

    void FixedUpdate() {
        int should_cover = getBoundryRight();
        for (int ix = max_x_covered+1; ix <= should_cover; ix++) {
            float x = ix*UnitSize;
            float w = UnitSize;
            for (int i = 0; i < SpawningRules.Length; i++) {
                var entry = SpawningRules[i];
                float density = entry.Density*entry.DensityMultiplier+density_accumulation[i];
                density_accumulation[i] = density%1;
                RandomlySpawnInArea(entry.PrefabToSpawn, (int)density, x, entry.MinY, w, entry.MaxY-entry.MinY);
            }
        }
        max_x_covered = should_cover;

        float remove_after = getBoundryLeft()*UnitSize;

        foreach (Transform item in SpawnInto)
            if (item != null && item.position.x < remove_after)
                Destroy(item.gameObject);
    }

    int getBoundryRight() {
        return (int)Mathf.Ceil((camera_transform.position.x+camera_width/2)/UnitSize);
    }

    int getBoundryLeft() {
        return (int)Mathf.Floor((camera_transform.position.x-camera_width/2)/UnitSize);
    }

    void RandomlySpawnInArea(GameObject prefab, int amount, float x, float y, float w, float h) {
        var pos = Vector3.zero;
        for (int i = 0; i < amount; i++) {
            pos.x = Random.Range(x,x+w);
            pos.y = Random.Range(y,y+h);
            Instantiate(prefab, pos, transform.rotation, SpawnInto);
        }
    }
}
