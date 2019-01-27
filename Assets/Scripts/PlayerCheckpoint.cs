using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCheckpoint : MonoBehaviour
{
    [SerializeField]
    private Image screenImage;

    private void Awake()
    {
        if(screenImage == null)
        {
            // Find the first Image from Canvas
            screenImage = FindObjectOfType<Image>();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Lava")
        {
            StartCoroutine("ShowEndScreen");
            SendPlayerToCheckpoint();
        }
    }

    private void SendPlayerToCheckpoint()
    {
        CheckpointManager checkpointManager = FindObjectOfType<CheckpointManager>();

        var checkpoint = checkpointManager.GetLastCheckpointThatWasPassed();

        transform.position = checkpoint.transform.position;
    }

    private IEnumerator ShowEndScreen()
    {
        screenImage.enabled = true;
        yield return new WaitForSeconds(3f);
        screenImage.enabled = false;
    }
}
