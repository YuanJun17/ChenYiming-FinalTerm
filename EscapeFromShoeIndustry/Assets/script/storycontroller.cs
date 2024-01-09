using UnityEngine;

public class StoryController : MonoBehaviour
{
    public CanvasGroup[] images; // 在Inspector中将三张图片的CanvasGroup拖拽到这里
    public float fadeInDuration; // 图片淡入的时间
    public float fadeOutDuration; // 图片淡出的时间
    public float delayBetweenImages; // 每张图片之间的延迟时间

    private void Start()
    {
        // 开始时隐藏所有图片
        foreach (var image in images)
        {
            image.alpha = 0f;
        }

        // 启动协程以控制图片的出现和消失
        StartCoroutine(ShowImagesSequence());
    }

    private System.Collections.IEnumerator ShowImagesSequence()
    {
        foreach (var image in images)
        {
            // 淡入
            yield return FadeIn(image, fadeInDuration);

            // 延迟一段时间
            yield return new WaitForSeconds(delayBetweenImages);

            // 淡出
            yield return FadeOut(image, fadeOutDuration);
        }
    }

    private System.Collections.IEnumerator FadeIn(CanvasGroup canvasGroup, float duration)
    {
        float timer = 0f;
        while (timer < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, timer / duration);
            timer += Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = 1f;
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
