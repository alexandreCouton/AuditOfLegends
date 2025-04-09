using UnityEngine;

[System.Serializable]
public class Person
{
    public string personName;

    public float trustPercentage;
    public float knowledgePercentage;
    

    public Person(string name, float knowledgePercentage, float trustPercentage)
    {
        this.personName = name;
        this.knowledgePercentage = Mathf.Clamp(knowledgePercentage, 0f, 100f);
        this.trustPercentage = Mathf.Clamp(trustPercentage, 0f, 100f);
    }

    public void IncreaseTrust(float increase)
    {
        trustPercentage = Mathf.Clamp(trustPercentage + increase, 0f, 100f);
    }
}
