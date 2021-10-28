using UnityEngine;

public class PipeScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        BirdMovement bird = collision.GetComponent<BirdMovement>();
        if (bird == null)
            return;

        bird.PipeHit();
    }
}
