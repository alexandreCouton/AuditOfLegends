using UnityEngine;
using System;

[Serializable]
public class Information
{
    // Enum pour représenter les différents états possibles d'une information
    public enum InformationState
    {
        Empty,
        Unverified,
        Verified,
        False
    }

    [SerializeField] private string fullText; // Version information qu'on va mettre sur le bouton
    [SerializeField] private bool isTrue; // Si l'information est vraie ou fausse
    [SerializeField] private InformationState state; // État actuel de l'information
    [SerializeField] private bool clickable; // Si le joueur peut interagir avec cette information

    // Constructeur par défaut
    public Information()
    {
        fullText = "";
        isTrue = false;
        state = InformationState.Empty;
        clickable = false;
    }

    // Constructeur avec paramètres
    public Information(string fullText, bool isTrue)
    {
        this.fullText = fullText;
        this.isTrue = isTrue;
        this.state = InformationState.Unverified;
        this.clickable = true;
    }

    public string FullText
    {
        get { return fullText; }
        set { fullText = value; }
    }

    public bool IsTrue
    {
        get { return isTrue; }
        set { isTrue = value; }
    }

    public InformationState State
    {
        get { return state; }
        set { state = value; }
    }

    public bool Clickable
    {
        get { return clickable; }
        set { clickable = value; }
    }

    // Méthodes pour changer l'état de l'information
    public void SetEmpty()
    {
        state = InformationState.Empty;
    }

    public void SetUnverified()
    {
        state = InformationState.Unverified;
    }

    public void SetVerified()
    {
        state = InformationState.Verified;
    }

    public void SetFalse()
    {
        state = InformationState.False;
    }

    // Méthode pour activer/désactiver la possibilité de cliquer
    public void EnableClick()
    {
        clickable = true;
    }

    public void DisableClick()
    {
        clickable = false;
    }
}