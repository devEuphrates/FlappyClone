using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private static int _best = 0;

    private void Awake()
    {
        if (Instance != null)
            Destroy(this);

        Instance = this;
    }

    public MoveParalel _groundMove;
    int _points = 0;

    public void StartGame()
    {
        LevelManager.Instance.StartLevel();
        UIManager.Instance.GameScreen();
    }

    public void AddPoint() => UIManager.Instance.UpdatePoints(++_points);

    public void GameOver()
    {
        _groundMove._disabled = true;
        LevelManager.Instance.StopLevel();
        if (_points > _best) _best = _points;
        UIManager.Instance.EndScreen(_points, _best);
    }

    public void ResetGame() => SceneManager.LoadScene(0);
}
