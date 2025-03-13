using UnityEngine;

public class SpeedBoostPickup : MonoBehaviour
{

    private CharacterMovement movement;
    [SerializeField] private float speedBoostMultiplier = 1.5f;
    [SerializeField] private float speedBoostDuration = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterMovement movement = other.GetComponent<CharacterMovement>();

            if (movement != null)
            {
                movement.speedMultiplier = speedBoostMultiplier;
                Invoke("ResetSpeed", speedBoostDuration);
                gameObject.SetActive(false);
            }
        }

    }

    private void ResetSpeed()
    {
        if (movement != null)
        {
            movement.speedMultiplier = 1.0f;
        }
        Destroy(gameObject);
    }
}