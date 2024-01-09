using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ironwalk : MonoBehaviour
{
    float walkspeed = 3;
    public Rigidbody2D myrigidbody;
    public Animator myanim;
    public GameObject walkParticleEffectPrefab; // 从 Inspector 中拖拽行走粒子特效的预制体
    private GameObject currentParticleEffect;

    // Start is called before the first frame update
    void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
        myanim = GetComponent<Animator>();
        

    }


    // Update is called once per frame
    void Update()
    {
        //Walk();
        Filp();
        float horizontalInput = Input.GetAxis("Horizontal");
        if (Mathf.Abs(horizontalInput) > 0.1f)
        {
            Walk();
        }
        else
        {
            StopWalk();
        }

    }
    void Walk()
    {
        float moveDir = Input.GetAxis("Horizontal");
        Vector2 playerVel = new Vector2(moveDir * walkspeed, myrigidbody.velocity.y);
        myrigidbody.velocity = playerVel;
        bool playerHasXAxisSpeed = Mathf.Abs(myrigidbody.velocity.x) > Mathf.Epsilon;
        myanim.SetBool("iron-walk", playerHasXAxisSpeed);
        if (currentParticleEffect == null)
        {
            currentParticleEffect = Instantiate(walkParticleEffectPrefab, transform);
            currentParticleEffect.transform.localPosition = new Vector3(0f, -1f, 0f);
        }

    }
    public void StopWalk()
    {
        // 在这里执行停止行走逻辑

        // 销毁行走粒子特效
        if (currentParticleEffect != null)
        {
            Destroy(currentParticleEffect);
            currentParticleEffect = null;
        }

        // 在这里添加其他停止行走逻辑
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
