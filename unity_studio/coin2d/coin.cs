using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int coinValue = 1;
    [SerializeField] private AudioClip collectSound;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            if (GameManager.Instance != null)
                GameManager.Instance.AddScore(coinValue);


            if (collectSound != null)
                AudioSource.PlayClipAtPoint(collectSound, transform.position);


            Destroy(gameObject);
        }
    }
}
