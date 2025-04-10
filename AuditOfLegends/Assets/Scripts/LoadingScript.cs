using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class TypewriterEffect : MonoBehaviour
{
    public TextMeshProUGUI textUI;
    [TextArea]
    public string fullText;
    public float delay = 0.02f;

    public AudioSource typingSound;
    public CanvasGroup buttonCanvasGroup;
    public float fadeDuration = 1f;
    
    void Start()
    {
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        textUI.text = "";

        if (typingSound != null)
            typingSound.Play();

        foreach (char letter in fullText)
        {
            textUI.text += letter;
            yield return new WaitForSeconds(delay);
        }

        if (typingSound != null)
            typingSound.Stop();

        StartCoroutine(FadeInButton());
    }

    IEnumerator FadeInButton()
    {
        float elapsed = 0f;
        buttonCanvasGroup.gameObject.SetActive(true);

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsed / fadeDuration);
            buttonCanvasGroup.alpha = alpha;
            yield return null;
        }

        buttonCanvasGroup.interactable = true;
        buttonCanvasGroup.blocksRaycasts = true;
    }
}

