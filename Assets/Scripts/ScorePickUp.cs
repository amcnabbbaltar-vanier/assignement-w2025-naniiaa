using UnityEngine;

public class ScorePickUp : MonoBehaviour
{
    [SerializeField] private int scoreValue = 50;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            if (GameManager.Instance != null)
            {
                GameManager.Instance.AddScore(scoreValue);
                gameObject.SetActive(false);

            }

            Destroy(gameObject);
        }
    }
}