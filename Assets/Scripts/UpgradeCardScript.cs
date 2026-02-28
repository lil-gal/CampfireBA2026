using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class UpgradeCardScript : MonoBehaviour
{
    public UpgradeCard card;

    public TextMeshPro Name;
    public TextMeshPro Description;

    void Awake()
    {
        Name = transform.Find("Name").gameObject.GetComponent<TextMeshPro>();
        Description = transform.Find("Desc").gameObject.GetComponent<TextMeshPro>();
        Name.text = card.name;
        Description.text = card.description;
        Image img = GetComponent<Image>();
        
        if (img != null) {
            img.sprite = card.icon;
        }

    }

    public void Onclick() {
        card.Take();
    }
}
