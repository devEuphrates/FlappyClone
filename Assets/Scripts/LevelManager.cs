using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [SerializeField] Transform _pipeSpawn;
    [SerializeField] GameObject _pipePrefab;

    public float _speed = 5f;
    [SerializeField] float _obstacleDuration = 1.5f;
    [SerializeField] float _speedUpDuration = 5f;
    float _timePasseed = 0f;
    float _speedUpTimer = 0f;

    [SerializeField] float _maxY = 3.3f, _minY = -1.15f;

    bool _spawnEnabled = false;

    private void Awake()
    {
        if (Instance != null)
            Destroy(this);

        Instance = this;

        if (_pipeSpawn == null || _pipePrefab == null)
            Destroy(this);

        _timePasseed = 0f;
    }

    private void Update()
    {
        if (!_spawnEnabled) return;

        _timePasseed += Time.deltaTime;
        _speedUpTimer += Time.deltaTime;

        if (_speedUpTimer >= _speedUpDuration)
        {
            _speed += 0.5f;
            _speedUpTimer = 0f;
        }

        if (_timePasseed >= _obstacleDuration)
        {
            _timePasseed = 0f;
            Vector2 pipePos = _pipeSpawn.transform.position;
            Vector2 pos = new Vector2(pipePos.x, Random.Range(_minY, _maxY));
            GameObject go = Instantiate(_pipePrefab, pos, Quaternion.identity, _pipeSpawn);
        }
    }

    public void StartLevel() => _spawnEnabled = true;

    public void StopLevel()
    {
        _spawnEnabled = false;
        _speed = 0f;
    }
}
