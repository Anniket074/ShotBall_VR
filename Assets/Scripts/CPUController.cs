using UnityEngine;

public class CPUController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float hitChanceNormal = 0.7f; // Adjust based on difficulty
    public float hitChanceHard = 0.9f; // Adjust based on difficulty
    public bool hasBubble = false; // Set to true if CPU has bubble

    private void Update()
    {
        // Implement CPU movement (left/right/random)
        // ...

        // Check if the ball is within range
        if (IsBallInRange())
        {
            // Decide whether to hit or miss
            //float hitChance = (GameManager.difficulty == Difficulty.Hard) ? hitChanceHard : hitChanceNormal;
            /*if (Random.value < hitChance)
            {
                HitBall();
            }
            else
            {
                MissBall();
            }*/
        }
    }

    private bool IsBallInRange()
    {
        // Check if the ball is close enough to the CPU
        // Implement your own logic here
        return false;
    }

    private void HitBall()
    {
        // Calculate ball direction and pass it to GameManager
        // ...
    }

    private void MissBall()
    {
        // Remove CPU from the game
        // ...
    }
}
