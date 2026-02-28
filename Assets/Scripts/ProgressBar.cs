using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    RectTransform parent;
    GameManager gameManager;
    RectTransform rectTransform;
    void Start()
    {
        parent = transform.parent.gameObject.GetComponent<RectTransform>();
        gameManager = FindFirstObjectByType<GameManager>();
        rectTransform = GetComponent<RectTransform>();
    }
    float exp = 50;
    float levelTreshold = 100; //replace by actual that will be stored in game manager
    
    void Update()
    {
        
        rectTransform.sizeDelta = new Vector2(parent.sizeDelta.x * (exp/levelTreshold), parent.sizeDelta.y);

        rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, rectTransform.rect.width);
        rectTransform.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, rectTransform.rect.height);
    }

    void Reset() {

    }
}
