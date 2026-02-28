using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeCardScript : MonoBehaviour
{
    public UpgradeCard card;

    public TextMeshProUGUI Name;
    public TextMeshProUGUI Description;
    public Image img;

    void Awake()
    {
        Name = transform.Find("Name").gameObject.GetComponent<TextMeshProUGUI>();
        Description = transform.Find("Desc").gameObject.GetComponent<TextMeshProUGUI>();
    }

    private void Start() {
        Name.text = card.name;
        Description.text = card.description;
        //img = GetComponentInChildren<Image>();

        if (img != null) {
            img.sprite = card.icon;
        }
    }

    public void Onclick() {
        card.Take();
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().UpdateStats();
        transform.parent.GetComponent<upgradePanelScript>().AfterPick();
    }
}
