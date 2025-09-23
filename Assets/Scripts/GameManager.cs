using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI statsText;
    [SerializeField] private Button retryButton;

    private int score;
    private void Start()
    {
        Birb.Instance.OnCrossingPipe += Birb_OnCrossingPipe;
        retryButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(0);
        });
    }

    private void Birb_OnCrossingPipe()
    {
        score++;
    }

    private void Update()
    {
        statsText.text = score.ToString();

       
    }
    
}
