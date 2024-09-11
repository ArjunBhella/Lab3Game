using UnityEngine;

public class TargetComponent : MonoBehaviour
{
    public int scoreAmount = 10; // Amount of score to increment when hitting this target

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has the tag "Projectile"
        if (collision.gameObject.CompareTag("Projectile"))
        {
            // Increment score in the GameManager
            if (GameManager.Instance != null)
            {
                GameManager.Instance.IncrementScore(scoreAmount);
            }

            // Hide the target after 5 seconds
            Invoke("HideTarget", 5f);

            // Change the parent object's color to green
            Renderer parentRenderer = transform.parent.GetComponent<Renderer>();
            if (parentRenderer != null)
            {
                parentRenderer.material.color = Color.green;
                // Change color back after 5 seconds
                Invoke("ChangeColorBack", 5f);
            }
        }
    }

    void HideTarget()
    {
        // Disable the target GameObject
        gameObject.SetActive(false);
    }

    void ChangeColorBack()
    {
        // Change the parent object's color back to red
        Renderer parentRenderer = transform.parent.GetComponent<Renderer>();
        if (parentRenderer != null)
        {
            parentRenderer.material.color = Color.red;
        }
    }
}

