using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerActions : MonoBehaviour
{
    private GameManager gameManager;
    private InformationManager informationManager;
    private UIManager uiManager;

    // État pour suivre si on est en mode "vérification d'information"
    private bool isCheckingTrustInfo = false;
    private int currentPersonIndex = -1;

    public PlayerActions(GameManager gameManager)
    {
        this.gameManager = gameManager;
        this.informationManager = Object.FindObjectOfType<InformationManager>();
        this.uiManager = Object.FindObjectOfType<UIManager>();
    }

    // Action pour augmenter la confiance
    public void IncreaseTrust(int personIndex)
    {
        Person person = gameManager.GetPerson(personIndex);
        person.IncreaseTrust(10f);
        DisplayMessage(person, "Trust increased by 10.");
    }

    // Action pour vérifier les connaissances
    public void CheckKnowledge(int personIndex)
    {
        Person person = gameManager.GetPerson(personIndex);
        float randomValue = Random.Range(0f, 100f);

        if (randomValue <= person.knowledgePercentage)
        {
            // Le personnage sait quelque chose - chercher une information vide à révéler
            Information emptyInfo = informationManager.GetFirstEmptyInformation();

            if (emptyInfo != null)
            {
                // Révéler une information
                emptyInfo.SetUnverified();
                DisplayMessage(person, $"Je sais quelque chose: {emptyInfo.FullText}");

                // Mettre à jour l'UI
                uiManager.UpdateInformationButtons();
            }
            else
            {
                // Plus d'informations à révéler
                DisplayMessage(person, "J'ai rien de plus à dire.");
            }
        }
        else
        {
            // Le personnage ne sait pas
            DisplayMessage(person, "Je ne sais pas.");
        }
    }

    // Action pour vérifier la confiance et sélectionner une information
    public void CheckTrust(int personIndex)
    {
        Person person = gameManager.GetPerson(personIndex);

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

            DisplayMessage(person, "Quelle information veux-tu vérifier?");
        }
        else
        {
            DisplayMessage(person, "Désolé, tu n'as pas d'informations à vérifier.");
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
                DisplayMessage(person, $"Oui, c'est vrai: {info.FullText}");
            }
            else
            {
                info.SetFalse();
                DisplayMessage(person, $"Non, c'est faux: {info.FullText}");
            }
        }
        else
        {
            // Le personnage ne fait pas confiance et ne confirme pas
            DisplayMessage(person, "Désolé, je n'en sais pas plus à ce sujet.");
        }

        // Désactiver le mode vérification
        isCheckingTrustInfo = false;
        currentPersonIndex = -1;

        // Rendre toutes les informations non cliquables
        informationManager.MakeUnverifiedInformationsClickable(false);

        // Mettre à jour l'interface
        uiManager.UpdateInformationButtons();
    }

    // Méthode pour afficher un message dans les logs
    private void DisplayMessage(Person person, string message)
    {
        Debug.Log($"{person.personName}: {message}");

        // Également afficher le message dans l'UI si disponible
        uiManager.DisplayMessage($"{person.personName}: {message}");
    }
}