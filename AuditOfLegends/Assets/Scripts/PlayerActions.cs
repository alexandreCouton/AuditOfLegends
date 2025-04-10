using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerActions : MonoBehaviour
{
    private GameManager gameManager;
    private InformationManager informationManager;
    private UIManager uiManager;
    private DialogueManager dialogueManager;

    // État pour suivre si on est en mode "vérification d'information"
    private bool isCheckingTrustInfo = false;
    private int currentPersonIndex = -1;

    public PlayerActions(GameManager gameManager)
    {
        this.gameManager = gameManager;
        this.informationManager = Object.FindObjectOfType<InformationManager>();
        this.uiManager = Object.FindObjectOfType<UIManager>();
        this.dialogueManager = Object.FindObjectOfType<DialogueManager>();
    }

    // Action pour augmenter la confiance
    public void IncreaseTrust(int personIndex)
    {
        Person person = gameManager.GetPerson(personIndex);
        person.IncreaseTrust(10f);

        // Message personnalisé pour l'augmentation de confiance
        string message = gameManager.GetPersonalizedResponse(person, "trustIncreased");
        DisplayMessage(person, message);
    }

    public void DecreaseTrust(int personIndex)
    {
        Person person = gameManager.GetPerson(personIndex);
        person.DecreaseTrust(7f);

        // Message personnalisé pour la diminution de confiance
        string message = gameManager.GetPersonalizedResponse(person, "trustDecreased");
        DisplayMessage(person, message);
    }

    // Action pour vérifier les connaissances
    public void CheckKnowledge(int personIndex)
    {
        Person person = gameManager.GetPerson(personIndex);
        float randomValue = Random.Range(0f, 100f);

        // Réduire la confiance à chaque question posée
        bool trustLevelChanged = person.DecreaseTrust(10f);

        if (trustLevelChanged)
        {
            // Afficher un message spécial si le niveau de confiance a changé
            string trustMessage = gameManager.GetPersonalizedResponse(person, "trustDecreased");
            DisplayMessage(person, trustMessage);
            return; // Arrêter l'action pour mettre l'accent sur le changement de confiance
        }

        if (randomValue <= person.knowledgePercentage)
        {
            // Le personnage sait quelque chose - chercher une information vide à révéler
            Information emptyInfo = informationManager.GetFirstEmptyInformation();

            if (emptyInfo != null)
            {
                // Révéler une information avec un message personnalisé
                emptyInfo.SetUnverified();
                string message = gameManager.GetPersonalizedResponse(person, "knowledgeSuccess", emptyInfo.LongText);
                DisplayMessage(person, message);

                // Mettre à jour l'UI
                uiManager.UpdateInformationButtons();
            }
            else
            {
                // Plus d'informations à révéler
                string message = gameManager.GetPersonalizedResponse(person, "noMoreInfo");
                DisplayMessage(person, message);
            }
        }
        else
        {
            // Le personnage ne sait pas - utiliser une information bidon aléatoire
            string randomBogusInfo = informationManager.GetRandomBogusInformation();
            string message = gameManager.GetPersonalizedResponse(person, "knowledgeFailure");

            // 50% de chance de donner une info bidon au lieu de simplement dire qu'il ne sait pas
            if (Random.Range(0f, 1f) > 0.5f)
            {
                message = gameManager.GetPersonalizedResponse(person, "knowledgeSuccess", randomBogusInfo);
            }

            DisplayMessage(person, message);
        }
    }


    // Action pour vérifier la confiance et sélectionner une information
    public void CheckTrust(int personIndex)
    {
        Person person = gameManager.GetPerson(personIndex);

        // Réduire la confiance à chaque question posée
        bool trustLevelChanged = person.DecreaseTrust(10f);

        if (trustLevelChanged)
        {
            // Afficher un message spécial si le niveau de confiance a changé
            string trustMessage = gameManager.GetPersonalizedResponse(person, "trustDecreased");
            DisplayMessage(person, trustMessage);
            return; // Arrêter l'action pour mettre l'accent sur le changement de confiance
        }
        // Vérifier s'il y a des informations non vérifiées
        if (informationManager.HasUnverifiedInformation())
        {
            // Préparer pour la vérification d'information
            isCheckingTrustInfo = true;
            currentPersonIndex = personIndex;

            // Rendre les informations non vérifiées cliquables
            informationManager.MakeUnverifiedInformationsClickable(true);

            // Mettre à jour l'interface
            uiManager.UpdateInformationButtons();

            string message = gameManager.GetPersonalizedResponse(person, "trustRequest");
            DisplayMessage(person, message);
        }
        else
        {
            string message = gameManager.GetPersonalizedResponse(person, "trustNoInfo");
            DisplayMessage(person, message);
        }
    }

    // Méthode appelée quand un bouton d'information est cliqué en mode vérification
    public void VerifyInformation(int informationIndex)
    {
        if (!isCheckingTrustInfo || currentPersonIndex < 0)
            return;

        Person person = gameManager.GetPerson(currentPersonIndex);
        Information info = informationManager.GetInformation(informationIndex);

        if (info == null)
            return;

        float randomValue = Random.Range(0f, 100f);

        if (randomValue <= person.trustPercentage)
        {
            // Le personnage confirme l'information
            if (info.IsTrue)
            {
                info.SetVerified();
                string message = gameManager.GetPersonalizedResponse(person, "truthConfirmation", info.LongText);
                DisplayMessage(person, message);
            }
            else
            {
                info.SetFalse();
                string message = gameManager.GetPersonalizedResponse(person, "falseConfirmation", info.LongText);
                DisplayMessage(person, message);
            }
        }
        else
        {
            // Le personnage ne fait pas confiance et ne confirme pas
            string message = gameManager.GetPersonalizedResponse(person, "noMoreInfo");
            DisplayMessage(person, message);
        }

        // Désactiver le mode vérification
        isCheckingTrustInfo = false;
        currentPersonIndex = -1;

        // Rendre toutes les informations non cliquables
        informationManager.MakeUnverifiedInformationsClickable(false);

        // Mettre à jour l'interface
        uiManager.UpdateInformationButtons();
    }

    // Méthode pour afficher un message
    private void DisplayMessage(Person person, string message)
    {
        // Log dans la console pour le débogage
        Debug.Log($"{person.personName}: {message}");

        // Afficher dans la bulle de dialogue du personnage
        if (dialogueManager != null)
        {
            int characterIndex = gameManager.GetPersonIndex(person);
            if (characterIndex >= 0)
            {
                dialogueManager.DisplayDialogue(characterIndex, message, 4f);  // Afficher pendant 4 secondes
            }
        }

        // Également afficher le message dans l'UI si disponible (pour compatibilité)
        if (uiManager != null)
        {
            uiManager.DisplayMessage($"{person.personName}: {message}");
        }
    }
}