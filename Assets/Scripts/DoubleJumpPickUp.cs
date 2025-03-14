using UnityEngine;

public class DoubleJumpPickUp : MonoBehaviour
{
    private CharacterMovement playerMovement;
    [SerializeField] private float jumpBoostDuration = 30f;

    private Vector3 startPos;
    private float rotationSpeed = 90f;
    private float height = 0.2f;
    private float speed = 1f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // rotate
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        // hover
        float newY = startPos.y + (Time.deltaTime * speed * height);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

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
