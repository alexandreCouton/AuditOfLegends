using UnityEngine;

[System.Serializable]
public class Person
{
    public string personName;
    public PersonalityType personality;
    public float trustPercentage;
    public float knowledgePercentage;

    public Person(string name, float knowledgePercentage, float trustPercentage, PersonalityType personality)
    {
        this.personName = name;
        this.knowledgePercentage = Mathf.Clamp(knowledgePercentage, 0f, 100f);
        this.trustPercentage = Mathf.Clamp(trustPercentage, 0f, 100f);
        this.personality = personality;
    }

    public void IncreaseTrust(float increase)
    {
        trustPercentage = Mathf.Clamp(trustPercentage + increase, 0f, 100f);
    }

    public float getTrustPercentage()
    {
        return trustPercentage;
    }
    
    public float getKnowledgePercentage()
    {
        return knowledgePercentage;
    }
    
    public TrustLevel getTrustLevel()
    {
        if (trustPercentage < 33f)
            return TrustLevel.Low;
        else if (trustPercentage < 66f)
            return TrustLevel.Medium;
        else
            return TrustLevel.High;
    }
}