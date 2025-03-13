using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.Instance != null)
            {
                // Takes all the dmg since it is the water is considered death zone.
                GameManager.Instance.TakeDamage(3);

            }
        }
    }
}