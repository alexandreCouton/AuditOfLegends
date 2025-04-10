using UnityEngine;
using TMPro;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    [System.Serializable]
    public class CharacterDialogue
    {
        public Person character;              // Référence au personnage
        public GameObject dialogueBubble;     // Bulle de dialogue (image)
        public TextMeshProUGUI dialogueText;  // Texte de la bulle de dialogue
    }

    [SerializeField] private CharacterDialogue[] characterDialogues;
    [SerializeField] private float defaultDialogueDuration = 4f;  // Durée par défaut d'affichage
    [SerializeField] private GameManager gameManager;

    private Coroutine[] activeDialogueCoroutines;

    void Start()
    {
        if (gameManager == null)
            gameManager = FindObjectOfType<GameManager>();

        activeDialogueCoroutines = new Coroutine[characterDialogues.Length];
        
        // Initialiser toutes les bulles de dialogue en mode caché
        for (int i = 0; i < characterDialogues.Length; i++)
        {
            characterDialogues[i].dialogueBubble.SetActive(false);
        }
        
        // Afficher le message de salutation personnalisé pour tous les personnages
        StartCoroutine(ShowInitialGreetings());
    }

    // Affiche un message initial personnalisé pour tous les personnages
    private IEnumerator ShowInitialGreetings()
    {
        for (int i = 0; i < characterDialogues.Length; i++)
        {
            yield return new WaitForSeconds(0.5f);  // Attendre un peu entre chaque personnage
            
            Person person = characterDialogues[i].character;
            string greeting = gameManager.GetPersonalizedResponse(person, "greeting");
            DisplayDialogue(i, greeting, 0);  // 0 signifie ne pas disparaître automatiquement
        }
    }

    // Afficher un dialogue pour un personnage spécifique
    public void DisplayDialogue(int characterIndex, string message, float duration = 0)
    {
        if (characterIndex < 0 || characterIndex >= characterDialogues.Length)
            return;

        CharacterDialogue charDialogue = characterDialogues[characterIndex];
        
        // Annuler le coroutine précédente si elle est active
        if (activeDialogueCoroutines[characterIndex] != null)
        {
            StopCoroutine(activeDialogueCoroutines[characterIndex]);
        }
        
        // Afficher la bulle de dialogue
        charDialogue.dialogueBubble.SetActive(true);
        charDialogue.dialogueText.text = message;
        
        // Si une durée est spécifiée, masquer après la durée
        if (duration > 0)
        {
            activeDialogueCoroutines[characterIndex] = StartCoroutine(HideDialogueAfterDelay(characterIndex, duration));
        }
    }

    // Cacher un dialogue après un délai
    private IEnumerator HideDialogueAfterDelay(int characterIndex, float delay)
    {
        yield return new WaitForSeconds(delay);
        HideDialogue(characterIndex);
        activeDialogueCoroutines[characterIndex] = null;
    }

    // Cacher un dialogue spécifique
    public void HideDialogue(int characterIndex)
    {
        if (characterIndex >= 0 && characterIndex < characterDialogues.Length)
        {
            characterDialogues[characterIndex].dialogueBubble.SetActive(false);
        }
    }

    // Réinitialiser tous les dialogues à l'état initial (message de salutation personnalisé)
    public void ResetDialogues()
    {
        for (int i = 0; i < characterDialogues.Length; i++)
        {
            Person person = characterDialogues[i].character;
            string greeting = gameManager.GetPersonalizedResponse(person, "greeting");
            DisplayDialogue(i, greeting, 0);
        }
    }

    // Obtenir l'index d'un personnage à partir de l'objet Person
    public int GetCharacterIndex(Person person)
    {
        for (int i = 0; i < characterDialogues.Length; i++)
        {
            if (characterDialogues[i].character == person)
                return i;
        }
        
        return -1;  // Personnage non trouvé
    }
}