using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public List<Person> people;

    void Start()
    {
        people = new List<Person>
        {
            new Person("Manager", 40f, 60f),
            new Person("Chef de projet", 90f, 20f),
            new Person("Emp random 1", 60f, 50f),
            new Person("Emp random 2", 25f, 60f)
        };

        PlayerActions playerActions = new PlayerActions(this);
    }

    public Person GetPerson(int index)
    {
        if (index >= 0 && index < people.Count)
            return people[index];
        return null;
    }

    public List<Person> GetPeople()
    {
        return people;
    }
}
