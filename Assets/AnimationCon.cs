using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCon : MonoBehaviour
{
    private Animator animator;
    public TennisBallMachine tennisBall;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tennisBall.isShoot)
        {
            Debug.Log("Ani");
            animator.Play("Attack01", 0, 0);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
           
            
        }
    }
}
