using UnityEngine;

public class MoveParalel : MonoBehaviour
{
    [SerializeField] float _speed = -1f;
    [SerializeField] float _repeatAfter = -1f;
    Vector2 _firstPos;
    public bool _disabled = false;

    private void Awake() => _firstPos = transform.position;

    private void Update()
    {
        if (_disabled) return;
        transform.Translate(new Vector2(_speed * Time.deltaTime, 0f));
        if ((_repeatAfter < 0 && transform.position.x <= _repeatAfter) || (_repeatAfter >= 0 && transform.position.x >= _repeatAfter))
            transform.position = _firstPos;
    }
}
