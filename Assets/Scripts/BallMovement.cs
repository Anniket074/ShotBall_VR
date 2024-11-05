using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Wall"))
        {

            GameManager.instance.IsBotOut();
            Destroy(gameObject);
        }
    }

}
