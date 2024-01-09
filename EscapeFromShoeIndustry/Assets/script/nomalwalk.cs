using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nomalwalk : MonoBehaviour
{

    float walkspeed = 7;
    float jumpspeed = 11;

    public Rigidbody2D myrigidbody;
    public Animator myanim;
    public BoxCollider2D myfeet;
    private bool IsGround;

    public GameObject particleEffectPrefab;
    

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.gravity = new Vector2(0f, -9.8f);
        myrigidbody = GetComponent<Rigidbody2D>();
        myanim = GetComponent<Animator>();
        
        myfeet = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Walk();
        Filp();
        Jump();
        CheckGround();
        JumpAni();
        
    }

    void CheckGround()
    {
        IsGround = myfeet.IsTouchingLayers(LayerMask.GetMask("ground"));
        Debug.Log(IsGround);

    }
    void Walk()
    {
        float moveDir = Input.GetAxis("Horizontal");
        Vector2 playerVel = new Vector2(moveDir * walkspeed, myrigidbody.velocity.y);
        myrigidbody.velocity = playerVel;
        bool playerHasXAxisSpeed = Mathf.Abs(myrigidbody.velocity.x) > Mathf.Epsilon;
        myanim.SetBool("normal-walk", playerHasXAxisSpeed);


    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (IsGround)
            {
                myanim.SetBool("normal-jump", true);

                Vector2 jumpvel = new Vector2(0.0f, jumpspeed);
                myrigidbody.velocity = Vector2.up * jumpvel;
                GameObject particleEffectInstance = Instantiate(particleEffectPrefab, transform.position, Quaternion.identity);

                // 延迟1秒后销毁粒子特效
                Destroy(particleEffectInstance, 1f);
            }
            
        }
    }

    void JumpAni()
    {
        myanim.SetBool("normal-idle", false );
        if (myanim.GetBool("normal-jump"))
        {
            if (myrigidbody.velocity.y < 0.0f)
            {
                myanim.SetBool("normal-jump", false);
                myanim.SetBool("normal-fall", true);

            }
            
        }
        else if (IsGround)
        {
            myanim.SetBool("normal-fall", false);
            myanim.SetBool("normal-idle", true);
        }
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
