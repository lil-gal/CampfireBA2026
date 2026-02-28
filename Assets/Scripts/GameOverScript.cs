using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameOverScript : MonoBehaviour {

    public bool ShowGameOver = false;
    public TextMeshProUGUI ScoreText;

    public float YOffScreen;
    public float Smoothness;
    private float y_pos = 0;

    public void setScores(int score, int hiscore) {
        ScoreText.text = $"score: {score}\nhiscore: {hiscore}";
    }

    void FixedUpdate() {
        if (ShowGameOver) y_pos /= Smoothness;
        else y_pos += (YOffScreen-y_pos)/Smoothness;

        transform.localPosition = new Vector3(0,y_pos,0);
    }

}
