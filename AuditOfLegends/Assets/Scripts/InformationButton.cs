using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InformationButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI textDisplay;
    [SerializeField] private Image backgroundImage;
    
    [Header("Colors")]
    [SerializeField] private Color emptyColor = Color.gray;
    [SerializeField] private Color unverifiedColor = Color.white;
    [SerializeField] private Color verifiedColor = Color.green;
    [SerializeField] private Color falseColor = Color.red;
    
    private Information linkedInformation;
    private int informationIndex;
    
    // Initialisation du bouton avec une information
    public void SetInformation(Information info, int index)
    {
        linkedInformation = info;
        informationIndex = index;
        
        // Mettre à jour l'interface
        UpdateUI();
    }
    
    // Mettre à jour l'apparence du bouton en fonction de l'état de l'information
    public void UpdateUI()
    {
        if (linkedInformation == null)
        {
            // Si pas d'information liée, rendre le bouton vide
            textDisplay.text = "";
            backgroundImage.color = emptyColor;
            button.interactable = false;
            return;
        }
        
        // Mettre à jour le texte (afficher seulement si pas en état Empty)
        textDisplay.text = linkedInformation.State == Information.InformationState.Empty ? "" : linkedInformation.FullText;
        
        // Mettre à jour la couleur selon l'état
        switch (linkedInformation.State)
        {
            case Information.InformationState.Empty:
                backgroundImage.color = emptyColor;
                break;
            case Information.InformationState.Unverified:
                backgroundImage.color = unverifiedColor;
                break;
            case Information.InformationState.Verified:
                backgroundImage.color = verifiedColor;
                break;
            case Information.InformationState.False:
                backgroundImage.color = falseColor;
                break;
        }
        
        // Mettre à jour l'interactivité
        button.interactable = linkedInformation.Clickable;
    }
}