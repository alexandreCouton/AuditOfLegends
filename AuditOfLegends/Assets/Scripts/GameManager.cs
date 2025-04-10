using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
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
    }

    public Person GetPerson(int index)
    {
        if (index >= 0 && index < people.Count)
            return people[index];
        return null;
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

    public float CalculateScore()
    {
        if (informationManager == null)
            informationManager = GetComponent<InformationManager>();
        
        List<Information> allInfo = informationManager.GetAllInformations();
        
        int verifiedTrueCount = 0;    // Informations vérifiées et vraies
        int totalVerifiedCount = 0;   // Total des informations vérifiées
        int totalUnverifiedCount = 0; // Total des informations non vérifiées
        
        foreach (Information info in allInfo)
        {
            if (info.State == Information.InformationState.Verified && info.IsTrue)
            {
                verifiedTrueCount++;
                totalVerifiedCount++;
            }
            else if (info.State == Information.InformationState.Verified || info.State == Information.InformationState.False)
            {
                totalVerifiedCount++;
            }
            else if (info.State == Information.InformationState.Unverified)
            {
                totalUnverifiedCount++;
            }
        }
        
        // Calcul de la note : nombre d'infos vraies vérifiées divisé par (vérifiées + non vérifiées)
        float denominator = totalVerifiedCount + totalUnverifiedCount;
        
        if (denominator == 0)
            return 100f; // Si aucune information n'est disponible, note parfaite par défaut
        
        return (verifiedTrueCount / denominator) * 100f;
    }
}