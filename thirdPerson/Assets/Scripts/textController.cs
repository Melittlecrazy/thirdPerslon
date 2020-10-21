using System.Collections;
using TMPro;
using UnityEngine;

public class textController : MonoBehaviour
{
    [SerializeField]
    private float fade;
    private CanvasGroup canvasGroup;
    private TMP_Text messageText;

    void Start()
    {

        canvasGroup = GetComponent<CanvasGroup>();
        messageText = GetComponent<TMP_Text>();

        canvasGroup.alpha = 0;

    }

    private IEnumerator ShowMessage(string message, float duration)
    {
        canvasGroup.alpha = 1;
        messageText.text = message;
        //wait for duration
        yield return new WaitForSeconds(duration);
        //start to fage out
        float elapse = 0;
        float fadeStart = Time.time;
        while (elapse<fade)
        {
            elapse = Time.time - fadeStart;
            canvasGroup.alpha = 1 - elapse / fade;
            yield return null;
        }
        canvasGroup.alpha = 0;
    }

    private void OnMessageTriggered(string message, float messageDuration)
    {
        StopAllCoroutines();
        StartCoroutine(ShowMessage("Honk", 2));
    }
    private void OnEnable()
    {
        messageTrigger.MessagedTriggered += OnMessageTriggered;
    }

    private void OnDisable()
    {
        messageTrigger.MessagedTriggered -= OnMessageTriggered;
    }
}
