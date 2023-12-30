using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class information : MonoBehaviour
{
    public CanvasGroup explanationCanvasGroup;

    // Start is called before the first frame update
    void Start()
    {
        HideExplanation();
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        // 当玩家进入触发区域时显示说明
        if (other.CompareTag("Player"))
        {
            ShowExplanation();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // 当玩家离开触发区域时隐藏说明
        if (other.CompareTag("Player"))
        {
            HideExplanation();
        }
    }

    void ShowExplanation()
    {
        // 显示说明，设置 CanvasGroup 的透明度和互动性
        explanationCanvasGroup.alpha = 1f;
        explanationCanvasGroup.interactable = true;
        explanationCanvasGroup.blocksRaycasts = true;
    }

    void HideExplanation()
    {
        // 隐藏说明，设置 CanvasGroup 的透明度和互动性
        explanationCanvasGroup.alpha = 0f;
        explanationCanvasGroup.interactable = false;
        explanationCanvasGroup.blocksRaycasts = false;
    }
}
