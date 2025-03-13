using UnityEngine;

public class DoubleJumpPickUp : MonoBehaviour
{
    private CharacterMovement playerMovement;
    [SerializeField] private float jumpBoostDuration = 30f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerMovement = other.GetComponent<CharacterMovement>();

            if (playerMovement != null)
            {
                playerMovement.EnableDoubleJump(jumpBoostDuration);
                Invoke("EndJumpBoost", jumpBoostDuration);
                gameObject.SetActive(false);
            }
        }

    }

    private void EndJumpBoost()
    {
        if (playerMovement != null)
        {
            playerMovement.DisableDoubleJump();
        }
        Destroy(gameObject);
    }
}
