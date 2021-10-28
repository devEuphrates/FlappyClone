using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Screens")]
    [SerializeField] GameObject _startMenu;
    [SerializeField] GameObject _inGame;
    [SerializeField] GameObject _endGame;

    [Space, Header("Fields")]
    [SerializeField] Text _inGamePointCounter;
    [SerializeField] Text _endgamePointCounter;
    [SerializeField] Text _bestScore;

    private void Awake()
    {
        if (Instance != null
            || _startMenu == null || _inGame == null || _endGame == null
            || _inGamePointCounter == null || _endgamePointCounter == null || _bestScore == null)
            Destroy(this);

        Instance = this;
    }

    public void GameScreen()
    {
        _startMenu.SetActive(false);
        _inGame.SetActive(true);
    }

    public void UpdatePoints(int points) => _inGamePointCounter.text = points.ToString();

    public void EndScreen(int points, int best)
    {
        _endgamePointCounter.text = points.ToString();
        _bestScore.text = best.ToString();

        _inGame.SetActive(false);
        _endGame.SetActive(true);
    }
}
