using UnityEngine;

public class GameOverUI : MonoBehaviour
{

    private void Start()
    {
        Hide();
        Birb.Instance.OnGameOver += Birb_OnGameOver;
    }

    private void Birb_OnGameOver()
    {
        Show();
    }

    private void Hide()
    {
        this.gameObject.SetActive(false);

    }
    private void Show()
    {
        this.gameObject.SetActive(true);

    }
}
