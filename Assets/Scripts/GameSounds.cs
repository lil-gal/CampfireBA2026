using UnityEngine;

public class GameSounds : MonoBehaviour {
    public static GameSounds instance;

    public SoundEntry[] Sounds;

    [System.Serializable]
    public class SoundEntry {
        public string name;
        public AudioClip[] AudioClips;
    }

    void Awake() {
        if (instance == null) instance = this;
    }
    

    public void PlaySoundEffect(string name) {
        Debug.Log(name);
        foreach (var item in Sounds) {
            if (item.name == name) {
                AudioSource.PlayClipAtPoint(item.AudioClips[Random.Range(0,item.AudioClips.Length)], transform.position, 1f);
                Debug.Log(item.name);
            }
        }
    }
}
