using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    [SerializeField] private int maxQuestions = 10;  // Nombre maximum de questions que le joueur peut poser
    [SerializeField] private int remainingQuestions;  // Questions restantes
    [SerializeField] private TextMeshProUGUI questionsCounterText;  // Référence au texte affichant le nombre de questions

    public List<Person> people;
    private PersonalityManager personalityManager;
    private InformationManager informationManager;

    void Start()
    {
        personalityManager = GetComponent<PersonalityManager>();
        if (personalityManager == null)
        {
            personalityManager = gameObject.AddComponent<PersonalityManager>();
        }

        people = new List<Person>
        {
            new Person("Zimmerwoman", 40f, 60f, PersonalityType.Boss),
            new Person("CDP", 90f, 20f, PersonalityType.Reserved),
            new Person("Jean", 60f, 50f, PersonalityType.Friendly),
            new Person("Daenerys", 25f, 60f, PersonalityType.Shy)
        };

        PlayerActions playerActions = new PlayerActions(this);

        remainingQuestions = maxQuestions;
        UpdateQuestionsCounter();
    }

    public Person GetPerson(int index)
    {
        if (index >= 0 && index < people.Count)
            return people[index];
        return null;
    }

    public bool CanAskQuestion()
    {
        return remainingQuestions > 0;
    }

    public int GetPersonIndex(Person person)
    {
        return people.IndexOf(person);
    }

    public List<Person> GetPeople()
    {
        return people;
    }
    
    public string GetPersonalizedResponse(Person person, string responseType, string param = null)
    {
        return personalityManager.GetResponse(person.personality, person.getTrustLevel(), responseType, param);
    }

    public void CalculateScore()
    {
        if (informationManager == null)
            informationManager = GetComponent<InformationManager>();
        
        // Double vérification - si GetComponent ne fonctionne pas, essayons FindObjectOfType
        if (informationManager == null)
            informationManager = FindObjectOfType<InformationManager>();
        
        // Vérification finale pour éviter l'erreur
        if (informationManager == null)
        {
            Debug.LogError("InformationManager est null! Impossible de calculer le score.");
            return; // Sortir de la fonction pour éviter l'erreur
        }
        List<Information> allInfo = informationManager.GetAllInformations();

        int verifiedTrueCount = 0;
        int trueInfoCount = 0;
        int unverifiedCount = 0;
        int emptyCount = 0;

        foreach (Information info in allInfo)
        {
            if (info.IsTrue)
            {
                trueInfoCount++;

                if (info.State == Information.InformationState.Verified)
                    verifiedTrueCount++;
            }

            if (info.State == Information.InformationState.Unverified)
            {
                unverifiedCount++;
            }

            if (info.State == Information.InformationState.Empty)
            {
                emptyCount++;
            }
        }

        float denominator = trueInfoCount + unverifiedCount + (emptyCount * 2);
        float score = (denominator == 0) ? 0f : (verifiedTrueCount / denominator) * 100f;

        Debug.Log("Score = " + score.ToString("F2"));

        // Stocker le score pour l'autre scène
        PlayerPrefs.SetFloat("Score", score);
        PlayerPrefs.Save();

        SceneManager.LoadScene("TransiAfter");
    }

    public bool UseQuestion()
    {
        if (remainingQuestions > 0)
        {
            remainingQuestions--;
            UpdateQuestionsCounter();
            return true;
        }
        return false;
    }

    private void UpdateQuestionsCounter()
    {
        if (questionsCounterText != null)
        {
            questionsCounterText.text = "Questions: " + remainingQuestions + "/" + maxQuestions;
        }
    }
}