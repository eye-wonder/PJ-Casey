using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public bool Passed { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerCheckpoint player = collision.GetComponent<PlayerCheckpoint>();
        if(player != null)
        {
            Passed = true;
        }
    }
}
