using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeCardScript : MonoBehaviour
{
    public UpgradeCard card;

    public TextMeshProUGUI Name;
    public TextMeshProUGUI Benefits;
    public TextMeshProUGUI Demerits;
    public Image img;

    void Awake()
    {
        Name = transform.Find("Name").gameObject.GetComponent<TextMeshProUGUI>();
        Benefits = transform.Find("Benefits").gameObject.GetComponent<TextMeshProUGUI>();
        Demerits = transform.Find("Demerits").gameObject.GetComponent<TextMeshProUGUI>();
    }

    private void Start() {
        Name.text = card.name;
        Benefits.text = card.benefits;
        Demerits.text = card.demerits;
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
