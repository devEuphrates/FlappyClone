using UnityEngine;

public class PipeMove : MonoBehaviour
{
    void Update() => transform.Translate(new Vector2(-LevelManager.Instance._speed * Time.deltaTime, 0f));
}
