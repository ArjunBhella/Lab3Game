using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int score = 0; // Variable to keep track of the score

    private void Awake()
    {
        // Implement singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional: keep GameManager across scenes
        }
        else
        {
            Destroy(gameObject); // Ensure only one GameManager exists
        }
    }

    // Method to increment the score
    public void IncrementScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score); // Optional: for debugging purposes
    }
}

