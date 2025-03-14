using UnityEngine;

public class ScorePickUp : MonoBehaviour
{
    [SerializeField] private int scoreValue = 50;

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

            if (GameManager.Instance != null)
            {
                GameManager.Instance.AddScore(scoreValue);
                gameObject.SetActive(false);

            }

            Destroy(gameObject);
        }
    }
}