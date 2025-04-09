using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class InformationManager : MonoBehaviour
{
    // Listes d'informations en dur
    private List<string> trueInformations = new List<string> {
        "v1", "v2", "v3", "v4", "v5", "v6", "v7", "v8", "v9", "v10"
    };
    
    private List<string> falseInformations = new List<string> {
        "f1", "f2", "f3", "f4", "f5", "f6", "f7", "f8", "f9", "f10"
    };
    
    [SerializeField] private int numberOfButtons = 5;
    
    private List<Information> activeInformations = new List<Information>();
    
    // Liste pour garder trace des informations déjà utilisées
    private List<string> usedInformations = new List<string>();
    
    public void InitializeInformations()
    {
        // Vider les listes
        activeInformations.Clear();
        usedInformations.Clear();
        
        // Créer des informations aléatoires pour chaque bouton
        for (int i = 0; i < numberOfButtons; i++)
        {
            // Choisir aléatoirement si l'information est vraie ou fausse
            bool isTrue = Random.value > 0.5f;
            
            // Récupérer le texte depuis la liste appropriée (sans répétition)
            string text = GetUniqueRandomInformation(isTrue);
            
            // Créer l'information (initialiser en état "Empty" et non cliquable)
            Information info = new Information(text, isTrue);
            info.SetEmpty();
            info.DisableClick();
            
            // Ajout à la liste active
            activeInformations.Add(info);
        }
    }
    
    private string GetUniqueRandomInformation(bool isTrue)
    {
        List<string> sourceList = isTrue ? trueInformations : falseInformations;
        
        // Filtrer pour n'avoir que les informations non utilisées
        List<string> availableInfos = sourceList.Where(info => !usedInformations.Contains(info)).ToList();
        
        // Si aucune information disponible dans la liste préférée, essayer l'autre liste
        if (availableInfos.Count == 0)
        {
            isTrue = !isTrue;
            sourceList = isTrue ? trueInformations : falseInformations;
            availableInfos = sourceList.Where(info => !usedInformations.Contains(info)).ToList();
            
            // Si toujours aucune information disponible, réinitialiser les utilisations
            if (availableInfos.Count == 0)
            {
                usedInformations.Clear();
                availableInfos = sourceList;
            }
        }
        
        // Récupérer une information aléatoire
        int randomIndex = Random.Range(0, availableInfos.Count);
        string selectedInfo = availableInfos[randomIndex];
        
        // Marquer comme utilisée
        usedInformations.Add(selectedInfo);
        
        return selectedInfo;
    }
    
    // Récupérer la première information vide
    public Information GetFirstEmptyInformation()
    {
        return activeInformations.FirstOrDefault(info => info.State == Information.InformationState.Empty);
    }
    
    // Vérifier s'il y a des informations non vérifiées
    public bool HasUnverifiedInformation()
    {
        return activeInformations.Any(info => info.State == Information.InformationState.Unverified);
    }
    
    // Rendre toutes les informations non vérifiées cliquables ou non
    public void MakeUnverifiedInformationsClickable(bool clickable)
    {
        foreach (Information info in activeInformations)
        {
            if (info.State == Information.InformationState.Unverified)
            {
                if (clickable)
                    info.EnableClick();
                else
                    info.DisableClick();
            }
        }
    }
    
    // Récupérer une information à un index spécifique
    public Information GetInformation(int index)
    {
        if (index >= 0 && index < activeInformations.Count)
        {
            return activeInformations[index];
        }
        return null;
    }
    
    // Récupérer toutes les informations actives
    public List<Information> GetAllInformations()
    {
        return activeInformations;
    }
    
    // Mettre à jour l'état d'une information
    public void UpdateInformationState(int index, Information.InformationState newState)
    {
        if (index >= 0 && index < activeInformations.Count)
        {
            activeInformations[index].State = newState;
        }
    }
}