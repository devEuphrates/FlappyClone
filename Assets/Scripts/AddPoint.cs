using UnityEngine;

public class AddPoint : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision) => GameManager.Instance.AddPoint();
}
