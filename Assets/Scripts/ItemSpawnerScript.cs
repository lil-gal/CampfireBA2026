using UnityEngine;

public class ItemSpawnerScript : MonoBehaviour {

    public Transform SpawnInto;

    [System.Serializable]
    public class ItemSpawnerEntry {
        public GameObject PrefabToSpawn;
        public float MinY;
        public float MaxY;
        public int Propability = 10; // one in X
        public float PropabilityMultiplier = 1; // for external configuring; might remove it if useless.. it might be useless--
        public bool Disabled = false;
    }

    public ItemSpawnerEntry[] SpawningRules;


    void Start() {
        
    }

    void FixedUpdate() {
        foreach (var entry in SpawningRules) {
            if (entry.PrefabToSpawn == null || entry.Disabled || Random.Range(0, entry.Propability) != 0) continue;
            if (Random.Range(0, (int)(entry.Propability*entry.PropabilityMultiplier)) != 0) continue;
            var pos = transform.position;
            pos.y = Random.Range(entry.MinY,entry.MaxY);
            transform.position = pos;
            Instantiate(entry.PrefabToSpawn, transform.position, transform.rotation, SpawnInto);
        }
    }
}
