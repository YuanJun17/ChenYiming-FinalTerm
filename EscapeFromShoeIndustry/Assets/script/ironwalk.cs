using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ironwalk : MonoBehaviour
{
    float walkspeed = 7;
    public Rigidbody2D myrigidbody;
    public Animator myanim;
    // Start is called before the first frame update
    void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
        myanim = GetComponent<Animator>();
        

    }


    // Update is called once per frame
    void Update()
    {
        Walk();
        Filp();
        
    }
    void Walk()
    {
        float moveDir = Input.GetAxis("Horizontal");
        Vector2 playerVel = new Vector2(moveDir * walkspeed, myrigidbody.velocity.y);
        myrigidbody.velocity = playerVel;
        bool playerHasXAxisSpeed = Mathf.Abs(myrigidbody.velocity.x) > Mathf.Epsilon;
        myanim.SetBool("iron-walk", playerHasXAxisSpeed);
    }
    void Filp()
    {
        Vector3 currentRotation = transform.rotation.eulerAngles;
        bool playerHasXAxisSpeed = Mathf.Abs(myrigidbody.velocity.x) > Mathf.Epsilon;
        if (playerHasXAxisSpeed)
        {
            if (myrigidbody.velocity.x > 0.1f)
            {
                transform.rotation = Quaternion.Euler(0, 0, currentRotation.z);
            }

            if (myrigidbody.velocity.x < -0.1f)
            {
                transform.rotation = Quaternion.Euler(0, 180, currentRotation.z);
            }
        }
    }
}
