using TMPro;
using UnityEngine;

public class DepthScript : MonoBehaviour
{
    GameObject player;
    public TextMeshProUGUI text;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        text.text = $"{(int)player.transform.position.y}";
    }
}
