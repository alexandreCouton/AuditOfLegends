using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public List<Person> people;
    private PersonalityManager personalityManager;

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
}