using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame() {
        SceneManager.LoadScene("Game");
    }

    public void BackToMenu() {
        SceneManager.LoadScene("Menu");
    }

    public void Exit() {
        Application.Quit();
    }
}