using UnityEngine;

public class ImageDisappear : MonoBehaviour
{
    public CanvasGroup imageCanvasGroup; // 在Inspector中将图片的CanvasGroup拖拽到这里
    public float customDisappearTime;
    void Start()
    {
        // 开始时隐藏图片
        imageCanvasGroup.alpha = 1f;

        // 自定义的消失时间，例如3秒
        

        // 启动协程以在自定义的时间后淡出图片
        StartCoroutine(DisappearAfterDelay(customDisappearTime));
    }

    private System.Collections.IEnumerator DisappearAfterDelay(float delay)
    {
        // 等待指定的延迟时间
        yield return new WaitForSeconds(delay);

        // 淡出图片
        yield return FadeOut(imageCanvasGroup, 1f);
    }

    private System.Collections.IEnumerator FadeOut(CanvasGroup canvasGroup, float duration)
    {
        float timer = 0f;
        while (timer < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, timer / duration);
            timer += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = 0f;
    }
}
