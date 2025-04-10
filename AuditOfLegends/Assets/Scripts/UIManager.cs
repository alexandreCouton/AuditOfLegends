using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private InformationManager informationManager;

    [Header("Character Interaction Buttons")]
    [SerializeField] private Button[] increaseTrustButtons;
    [SerializeField] private Button[] checkKnowledgeButtons;
    [SerializeField] private Button[] checkTrustButtons;

    [Header("Information Buttons")]
    [SerializeField] private InformationButton[] informationButtons;

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI messageDisplay;
    [SerializeField] private float messageDuration = 3f;

    private PlayerActions playerActions;
    private List<Person> people;
    private float messageTimer;
    private bool messageActive = false;

    void Start()
    {
        // Initialiser PlayerActions avec GameManager
        if (gameManager == null)
            gameManager = FindObjectOfType<GameManager>();

        playerActions = new PlayerActions(gameManager);
        people = gameManager.GetPeople();

        // Initialiser les informations
        if (informationManager == null)
            informationManager = FindObjectOfType<InformationManager>();

        informationManager.InitializeInformations();

        // Initialiser l'affichage des messages
        if (messageDisplay != null)
            messageDisplay.gameObject.SetActive(false);

        // Associer les informations aux boutons
        InitializeInformationButtons();
    }

    void Update()
    {
        // Gestion de l'affichage temporaire des messages
        if (messageActive)
        {
            messageTimer -= Time.deltaTime;
            if (messageTimer <= 0)
            {
                messageDisplay.gameObject.SetActive(false);
                messageActive = false;
            }
        }
    }

    // Méthode pour afficher un message temporairement
    public void DisplayMessage(string message)
    {
        if (messageDisplay != null)
        {
            messageDisplay.text = message;
            messageDisplay.gameObject.SetActive(true);
            messageTimer = messageDuration;
            messageActive = true;
        }
    }

    private void InitializeInformationButtons()
    {
        // Vérifier si on a le bon nombre de boutons
        if (informationButtons.Length == 0)
        {
            Debug.LogWarning("Pas de boutons d'information assignés!");
            return;
        }

        // Associer chaque information à un bouton
        for (int i = 0; i < informationButtons.Length; i++)
        {
            if (i < informationManager.GetAllInformations().Count)
            {
                Information info = informationManager.GetInformation(i);
                informationButtons[i].SetInformation(info, i);

                // Configuration du bouton pour qu'il appelle VerifyInformation quand cliqué
                int buttonIndex = i; // Nécessaire pour la capture dans la lambda
                Button buttonComponent = informationButtons[i].GetComponent<Button>();
                if (buttonComponent != null)
                {
                    buttonComponent.onClick.RemoveAllListeners();
                    buttonComponent.onClick.AddListener(() => OnInformationButtonClicked(buttonIndex));
                }
            }
        }
    }

    // Mettre à jour tous les boutons d'information
    public void UpdateInformationButtons()
    {
        for (int i = 0; i < informationButtons.Length; i++)
        {
            if (i < informationManager.GetAllInformations().Count)
            {
                informationButtons[i].UpdateUI();
            }
        }
    }

    // Appelé quand un bouton d'information est cliqué
    public void OnInformationButtonClicked(int informationIndex)
    {
        // Déléguer à PlayerActions pour gérer la vérification de l'information
        playerActions.VerifyInformation(informationIndex);
    }

    // Méthodes pour les boutons de personnage
    public void OnIncreaseTrustButtonClicked(int personIndex)
    {
        playerActions.IncreaseTrust(personIndex);
    }
    public void OnDecreaseTrustButtonClicked(int personIndex)
    {
        playerActions.DecreaseTrust(personIndex);
    }

    public void OnCheckKnowledgeButtonClicked(int personIndex)
    {
        playerActions.CheckKnowledge(personIndex);
    }

    public void OnCheckTrustButtonClicked(int personIndex)
    {
        playerActions.CheckTrust(personIndex);
    }

    // Méthode pour réinitialiser les informations (pour un nouveau tour par exemple)
    public void ResetInformations()
    {
        informationManager.InitializeInformations();
        InitializeInformationButtons();
    }
}