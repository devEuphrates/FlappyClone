using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdMovement : MonoBehaviour
{
    public static BirdMovement Instance;

    Rigidbody2D _rigidbody;

    [SerializeField] float _flapVelocity = 1.5f;
    bool _disable = false;
    bool _started = false;

    private void Awake()
    {
        if (Instance != null)
            Destroy(this);

        Instance = this;

        
        _rigidbody = transform.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        transform.eulerAngles = new Vector3(0f, 0f, _rigidbody.velocity.y * 10f);
        
        if (_disable == true) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!_started)
            {
                _rigidbody.simulated = true;
                _started = true;
                GameManager.Instance.StartGame();
            }

            _rigidbody.velocity = Vector2.up * _flapVelocity;
        }
            
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer != 7)
            return;

        GameManager.Instance.GameOver();
        _rigidbody.simulated = false;
    }

    public void PipeHit()
    {
        if (_disable) return;
        _disable = true;
        _rigidbody.velocity = Vector2.zero;
    }
}
