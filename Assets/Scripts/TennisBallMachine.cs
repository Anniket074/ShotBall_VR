using UnityEngine;
using System.Collections.Generic;

public class TennisBallMachine : MonoBehaviour
{
    public float DefficultyPercent;
    public GameObject ballPrefab;
    public Transform launchPoint;
    public Transform[] bots;
    public bool isShoot;
    private int randomPlayerNum;
    public float initialBallSpeed = 10f; // Initial speed of the ball
    public float maxBallSpeed = 15f; // Maximum speed of the ball
    public float accelerationRate = 0.02f; // Rate at which ball speed increases over time
    int powerUp = 0;
    bool isBubble;
    public GameObject bubbleVisible;
    List<Transform> botList;
    float startTime;
    float elapsedTime;

    private void Start()
    {
        bubbleVisible.SetActive(false);
        botList = new List<Transform>(bots);
        startTime = Time.time; // Record the start time
    }

    void Update()
    {
        elapsedTime = Time.time - startTime; // Calculate the elapsed time since the start

        BotOut();

        if (isShoot)
        {
            randomPlayerNum = Random.Range(0, botList.Count);
            ShootBall();
            isShoot = false;
        }

        // Increase ball speed over time
        float currentSpeed = initialBallSpeed + accelerationRate * elapsedTime;
        initialBallSpeed = Mathf.Min(currentSpeed, maxBallSpeed);
       
    }

    void BotOut()
    {
        for (int i = 0; i < bots.Length; i++)
        {
            if (!bots[i].gameObject.activeSelf)
            {
                Transform botToRemove = botList[i];
                botList.Remove(botToRemove);
                bots = botList.ToArray();
            }
        }
    }

    void ShootBall()
    {
       
        GameManager.instance.currentPlayerTurn = bots[randomPlayerNum].gameObject;
        GameObject ball = Instantiate(ballPrefab, launchPoint.position, Quaternion.identity);
        Rigidbody rb = ball.GetComponent<Rigidbody>();

        if (rb != null)
        {
            Vector3 targetPosition = bots[randomPlayerNum].position;
            Vector3 direction = (targetPosition - launchPoint.position).normalized;

            // Define horizontal recoil amount based on probability
            float recoilAmount = (Random.value < DefficultyPercent) ? 0f : 0.3f;
            //float recoilAmount = (Random.Range(0, DefficultyPercent) == 0) ? 0.05f : 0f;

             Debug.Log(recoilAmount);
           // Debug.Log(DefficultyPercent);
            Vector3 recoil = new Vector3(Random.Range(-recoilAmount, recoilAmount), 0f, Random.Range(-recoilAmount, recoilAmount));

            // Add recoil only to horizontal direction
            direction += recoil;
            Debug.Log("Check");

            rb.velocity = direction * initialBallSpeed; // Use the current calculated speed
        }
        else
        {
            Debug.LogError("Ball prefab does not have a Rigidbody component!");
        }

        if (powerUp == 10)
        {
            powerUp = 0;
            isBubble = true;
            Invoke("PowerUp", 0.5f);
        }
    }

    void PowerUp()
    {
        bubbleVisible.SetActive(true);
        gameObject.GetComponent<SphereCollider>().enabled = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            bubbleVisible.SetActive(false);
            gameObject.GetComponent<SphereCollider>().enabled = false;
            powerUp++;
            isShoot = true;
            Destroy(collision.collider.gameObject);
            //
        }
    }
}
