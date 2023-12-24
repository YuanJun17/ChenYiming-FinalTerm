using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassController : MonoBehaviour
{
    public walkstatemanager iron;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 检测碰撞是否是玩家
        if (collision.gameObject.CompareTag("Player")&& iron.script2.enabled)
        {
            // 当碰撞发生时，将方形物体的质量设置为1
            GetComponent<Rigidbody2D>().mass = 1f;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // 检测碰撞是否是玩家
        if (collision.gameObject.CompareTag("Player"))
        {
            // 当碰撞结束时，将方形物体的质量设置为1000
            GetComponent<Rigidbody2D>().mass = 1000f;
        }
    }
}
