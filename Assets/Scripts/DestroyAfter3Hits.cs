using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter3Hits : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger the reduction of hit points")]
    [SerializeField] string triggeringTag;

    [Tooltip("Number of hit points")]
    [SerializeField] int hitPoints = 3;

    public UnityEngine.UI.Text hitPointsText;  // Reference to the UI Text element

    private void Start()
    {
        UpdateHitPointsText();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == triggeringTag && enabled)
        {
            TakeDamage();

            // Check if hit points are zero or less
            if (hitPoints <= 0)
            {
                Destroy(this.gameObject);
            }

            UpdateHitPointsText();  // Update the UI Text after taking damage
        }
    }

    private void UpdateHitPointsText()
    {
        // Update the UI Text with the current hit points
        if (hitPointsText != null)
        {
            hitPointsText.text = "Hit Points: " + hitPoints.ToString();
        }
    }

    private void TakeDamage()
    {
        hitPoints--;
    }
}
