using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountLeft : MonoBehaviour
{
    public Text transformCountText;  // 引用UI Text 组件
    public int transformCount;  // 初始变换次数
    private KeyCode lastPressedKey;   // 上一次按下的键

    public CanvasGroup reportCanvasGroup;  // 引用 Canvas Group 组件

    void Start()
    {
        // 在开始时更新 UI
        UpdateUIText();
        UpdateReportVisibility();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3))
        {
            // 获取当前按下的键
            KeyCode pressedKey = KeyCode.None;
            if (Input.GetKeyDown(KeyCode.Alpha1))
                pressedKey = KeyCode.Alpha1;
            else if (Input.GetKeyDown(KeyCode.Alpha2))
                pressedKey = KeyCode.Alpha2;
            else if (Input.GetKeyDown(KeyCode.Alpha3))
                pressedKey = KeyCode.Alpha3;

            // 检查是否与上一次按下的键相同
            if (pressedKey != lastPressedKey)
            {
                // 当按下不同的键时，减少变换次数
                ReduceTransformCount();

                // 更新上一次按下的键
                lastPressedKey = pressedKey;
            }
        }

        if (CheckDeath.Instance.IsDeath)
        {
            // 游戏暂停时显示 "report" 元素
            reportCanvasGroup.alpha = 1f; // 设置透明度为不透明
            reportCanvasGroup.interactable = true; // 启用互动性
        }
        else
        {
            // 游戏未暂停时隐藏 "report" 元素
            reportCanvasGroup.alpha = 0f; // 设置透明度为透明
            reportCanvasGroup.interactable = false; // 禁用互动性
        }
    }

    // 减少变换次数并更新 UI
    void ReduceTransformCount()
    {
        if (transformCount >= 0)
        {
            transformCount--;

            // 在这里执行更新 UI 的逻辑
            UpdateUIText();

            Debug.Log("Remaining transform count: " + transformCount);
            if (transformCount < 0)
            {
                // 当变换次数为 0 时暂停游戏
                PauseGame();
                CheckDeath.Instance.IsDeath = true;
            }
        }
    }

    // 更新 UI Text 显示
    void UpdateUIText()
    {
        // 更新 UI Text 显示为 "剩余变换次数：X"
        transformCountText.text = transformCount.ToString();
    }
    void UpdateReportVisibility()
    {
        // 根据游戏暂停状态设置 "report" 元素的可见性
        reportCanvasGroup.alpha = (Time.timeScale == 0f) ? 1f : 0f; // 设置透明度
        reportCanvasGroup.interactable = (Time.timeScale == 0f); // 设置互动性
    }
    void PauseGame()
    {
        Time.timeScale = 0f;
        Debug.Log("Game Paused");
        
        UpdateReportVisibility();
    }
}
