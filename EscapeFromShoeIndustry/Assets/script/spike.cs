using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike : MonoBehaviour
{
    public bool IsIron;
    public ironwalk isiron;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckIron();
    }
    private void CheckIron()
    {
        if (isiron.enabled)
        {
            IsIron = true;
        }
        else
        {
            IsIron = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !IsIron)
        {
            Debug.Log("You Die");
            Time.timeScale = 0f;
            CheckDeath.Instance.IsDeath = true;
        }
    }
}
