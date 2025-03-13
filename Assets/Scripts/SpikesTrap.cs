using UnityEngine;

public class SpikesTrap : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {

        if (GameManager.Instance != null)
        {
           GameManager.Instance.TakeDamage(1);
        }

    }
}
