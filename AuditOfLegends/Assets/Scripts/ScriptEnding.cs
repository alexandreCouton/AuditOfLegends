using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class EndingScreen : MonoBehaviour
{
    public TextMeshProUGUI mainText;
    public Image background;
    public Image emoji;

    public Sprite happyFace;
    public Sprite sadFace;
    public Sprite partyFace;
    public int result;
    public float fadeDuration = 1f;

    private void Start()
    {
        StartCoroutine(ShowAuditResult());
    }

    IEnumerator ShowAuditResult()
    {
        yield return StartCoroutine(FadeText("Le comité d'audit a soigneusement examiné votre rapport."));
        yield return new WaitForSeconds(2f);
        yield return StartCoroutine(FadeText(""));
        yield return new WaitForSeconds(0.5f);

        //int result = ....
        //Mettre dans résultat le pourcentage de validité du rapport

        if(result == 100){
            background.color = ColorUtility.TryParseHtmlString("#006ec4", out var c) ? c : Color.blue;
            emoji.sprite = partyFace;
            emoji.color = Color.white;
            yield return StartCoroutine(FadeText("Ils ont adoré votre rapport, tout est parfait ! <b>Toutes les informations</b> de votre rapport sont correctes."));
        }
        else if(result < 100 && result >= 60){
            background.color = ColorUtility.TryParseHtmlString("#009309", out var c) ? c : Color.green;
            emoji.sprite = happyFace;
            emoji.color = Color.white;
            yield return StartCoroutine(FadeText("Ils ont bien aimé ce qu'ils ont lu, mais ont quelques doutes sur certaines parties. Après une deuxième analyse, <b>" + result + "</b> % des informations de votre rapport se sont révélées correctes."));
        }
        else {
            background.color = ColorUtility.TryParseHtmlString("#920909", out var c) ? c : Color.red;
            emoji.sprite = sadFace;
            emoji.color = Color.white;
            yield return StartCoroutine(FadeText("Ils ne sont pas du tout satisfaits : trop d'éléments ne sont pas cohérents entre eux. Après une deuxième analyse, seulement <b>" + result + "</b> % des informations de votre rapport se sont révélées correctes."));
        }

    }

    IEnumerator FadeText(string newText)
    {
        float t = 0;
        Color originalColor = mainText.color;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            mainText.color = new Color(originalColor.r, originalColor.g, originalColor.b, 1 - t / fadeDuration);
            yield return null;
        }

        mainText.text = newText;

        t = 0;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            mainText.color = new Color(originalColor.r, originalColor.g, originalColor.b, t / fadeDuration);
            yield return null;
        }
    }
}
