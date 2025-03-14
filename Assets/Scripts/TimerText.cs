using TMPro;
using UnityEngine;

/**
 * DEPRECATED NO USE
 */
public class TimerText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI goalText;
    [SerializeField] private TextMeshProUGUI controlText;
    private float timeToAppear = 30f;
    public void enableText()
    {
        titleText.enabled = true;
        goalText.enabled = true;
        controlText.enabled = true;
    }

    public void Update()
    {
        if(titleText.enabled && goalText.enabled && controlText.enabled)
        {   
            //titleText.enabled = false;
            //goalText.enabled = false;
            //controlText.enabled = false;

            Destroy(gameObject, timeToAppear);
        }
    }
}
