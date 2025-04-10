using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class InformationManager : MonoBehaviour
{
    // Structure pour stocker les informations
    [System.Serializable]
    public struct InfoTextPair
    {
        public string shortText;  // Texte pour les boutons
        public string longText;   // Texte détaillé pour les dialogues
        public bool isTrue;       // Si l'information est vraie ou fausse
    }

    // Liste des informations disponibles
    private List<InfoTextPair> availableInformations = new List<InfoTextPair>
    {
        new InfoTextPair { shortText = "Logiciels pas à jour", longText = "Personne ne met à jour les logiciels ici.", isTrue = false },
        new InfoTextPair { shortText = "Réutilisation de mot de passe", longText = "On utilise le même mot de passe sur plusieurs services.", isTrue = false },
        new InfoTextPair { shortText = "Journaux non surveillés", longText = "Les journaux système ne sont jamais vérifiés.", isTrue = false },
        new InfoTextPair { shortText = "Clés USB non sécurisées", longText = "Certains fichiers sensibles sont stockés sur des clés USB non chiffrées.", isTrue = false },
        new InfoTextPair { shortText = "Pas de plan d'urgence", longText = "Il n'y a pas de plan de réaction en cas d'attaque.", isTrue = false },
        new InfoTextPair { shortText = "Comptes inactifs non désactivés", longText = "Les anciens comptes utilisateurs sont encore actifs.", isTrue = false },
        new InfoTextPair { shortText = "Wi-Fi mal isolé", longText = "Le réseau Wi-Fi invité donne accès au réseau principal.", isTrue = false },
        new InfoTextPair { shortText = "Phishing réussi", longText = "Un collègue a cliqué sur un lien de phishing récemment.", isTrue = false },
        new InfoTextPair { shortText = "Documents non protégés", longText = "On envoie des documents confidentiels sans mot de passe.", isTrue = false },
        new InfoTextPair { shortText = "Absence d'antivirus", longText = "Certains postes n'ont pas d'antivirus.", isTrue = false },
        new InfoTextPair { shortText = "Authentification 2FA active", longText = "L'authentification à deux facteurs est activée sur tous les comptes.", isTrue = true },
        new InfoTextPair { shortText = "Mots de passe sécurisés", longText = "Les mots de passe sont longs, complexes et changés tous les 90 jours.", isTrue = true },
        new InfoTextPair { shortText = "Connexions sécurisées par VPN", longText = "On utilise un VPN pour toutes les connexions à distance.", isTrue = true },
        new InfoTextPair { shortText = "Sauvegardes fiables", longText = "Les sauvegardes sont automatiques et stockées hors ligne.", isTrue = true },
        new InfoTextPair { shortText = "Pare-feu actif et intelligent", longText = "Le pare-feu bloque automatiquement les connexions suspectes.", isTrue = true },
        new InfoTextPair { shortText = "Formation cybersécurité régulière", longText = "Tous les employés reçoivent une formation cybersécurité annuelle.", isTrue = true },
        new InfoTextPair { shortText = "Gestion des droits d'accès", longText = "L'accès aux données sensibles est limité selon les rôles.", isTrue = true },
        new InfoTextPair { shortText = "Logiciels sûrs", longText = "On utilise uniquement des logiciels officiels et vérifiés.", isTrue = true },
        new InfoTextPair { shortText = "Site web sécurisé", longText = "Le site web utilise HTTPS avec un certificat à jour.", isTrue = true },
        new InfoTextPair { shortText = "Accès physique restreint", longText = "L'accès aux serveurs physiques est strictement contrôlé.", isTrue = true }
    };
    
    // Liste d'informations bidon pour les réponses quand un personnage ne sait pas
    private List<string> bogusInformation = new List<string>
    {
        "L'imprimante n'est pas sécurisée",
        "Le stagiaire utilise '123456' comme mot de passe",
        "Quelqu'un a laissé sa session ouverte hier",
        "Le badge de sécurité est facile à copier",
        "On utilise encore Windows XP sur certains postes",
        "Il y a un post-it avec des mots de passe sur l'écran d'Éric",
        "Le réseau wifi invité n'a pas changé de mot de passe depuis 2 ans",
        "La porte du local serveur est souvent laissée ouverte",
        "Les anciens employés gardent leur accès email",
        "Personne ne verrouille son ordinateur pendant la pause déjeuner"
    };
    
    [SerializeField] private int numberOfButtons = 5;
    
    private List<Information> activeInformations = new List<Information>();
    
    // Liste pour garder trace des informations déjà utilisées
    private List<int> usedInformationIndices = new List<int>();
    
    public void InitializeInformations()
    {
        // Vider les listes
        activeInformations.Clear();
        usedInformationIndices.Clear();
        
        // Préparer deux listes séparées pour les infos vraies et fausses
        List<InfoTextPair> trueInformations = availableInformations.Where(info => info.isTrue).ToList();
        List<InfoTextPair> falseInformations = availableInformations.Where(info => !info.isTrue).ToList();
        
        // Mélanger aléatoirement les deux listes
        System.Random rng = new System.Random();
        trueInformations = trueInformations.OrderBy(x => rng.Next()).ToList();
        falseInformations = falseInformations.OrderBy(x => rng.Next()).ToList();
        
        // Créer des informations pour chaque bouton
        for (int i = 0; i < numberOfButtons; i++)
        {
            // Créer l'information (initialiser en état "Empty" et non cliquable)
            Information info = new Information();
            info.SetEmpty();
            info.DisableClick();
            
            // Ajout à la liste active
            activeInformations.Add(info);
        }
        
        // Garder trace des vrais éléments et faux éléments pour garantir au moins 4 vrais
        usedTrueCount = 0;
        usedFalseCount = 0;
    }

    // Modifier la méthode GetRandomUnusedInformation pour garantir au moins 4 infos vraies
    private int usedTrueCount = 0;
    private int usedFalseCount = 0;
    private const int MinTrueInformations = 4;

    public InfoTextPair GetRandomUnusedInformation()
    {
        // Séparer les infos disponibles entre vraies et fausses
        List<int> availableTrueIndices = Enumerable.Range(0, availableInformations.Count)
            .Where(i => !usedInformationIndices.Contains(i) && availableInformations[i].isTrue)
            .ToList();
        
        List<int> availableFalseIndices = Enumerable.Range(0, availableInformations.Count)
            .Where(i => !usedInformationIndices.Contains(i) && !availableInformations[i].isTrue)
            .ToList();
        
        // Si on a utilisé toutes les infos, réinitialiser
        if (availableTrueIndices.Count == 0 && availableFalseIndices.Count == 0)
        {
            usedInformationIndices.Clear();
            usedTrueCount = 0;
            usedFalseCount = 0;
            
            availableTrueIndices = Enumerable.Range(0, availableInformations.Count)
                .Where(i => availableInformations[i].isTrue)
                .ToList();
            
            availableFalseIndices = Enumerable.Range(0, availableInformations.Count)
                .Where(i => !availableInformations[i].isTrue)
                .ToList();
        }
        
        int selectedIndex;
        
        // Logique pour garantir au moins MinTrueInformations infos vraies
        int remainingSlots = numberOfButtons - (usedTrueCount + usedFalseCount);
        int requiredTrueInfos = MinTrueInformations - usedTrueCount;
        
        if (requiredTrueInfos > 0 && remainingSlots <= requiredTrueInfos && availableTrueIndices.Count > 0)
        {
            // Forcer une info vraie car on doit atteindre le minimum et il reste peu de slots
            int randomIndex = Random.Range(0, availableTrueIndices.Count);
            selectedIndex = availableTrueIndices[randomIndex];
            usedTrueCount++;
        }
        else if (usedTrueCount < MinTrueInformations && availableTrueIndices.Count > 0 && Random.Range(0, 2) == 0)
        {
            // Favoriser les infos vraies jusqu'à atteindre le minimum
            int randomIndex = Random.Range(0, availableTrueIndices.Count);
            selectedIndex = availableTrueIndices[randomIndex];
            usedTrueCount++;
        }
        else if (availableFalseIndices.Count > 0)
        {
            // Choisir une info fausse
            int randomIndex = Random.Range(0, availableFalseIndices.Count);
            selectedIndex = availableFalseIndices[randomIndex];
            usedFalseCount++;
        }
        else if (availableTrueIndices.Count > 0)
        {
            // S'il ne reste que des infos vraies, prendre une vraie
            int randomIndex = Random.Range(0, availableTrueIndices.Count);
            selectedIndex = availableTrueIndices[randomIndex];
            usedTrueCount++;
        }
        else
        {
            // Cas improbable mais pour la sécurité
            selectedIndex = 0;
        }
        
        // Marquer l'index comme utilisée
        usedInformationIndices.Add(selectedIndex);
        
        return availableInformations[selectedIndex];
    }
    
    // Récupérer une information bidon aléatoire
    public string GetRandomBogusInformation()
    {
        if (bogusInformation.Count == 0)
            return "Je n'ai rien d'intéressant à dire.";
            
        int randomIndex = Random.Range(0, bogusInformation.Count);
        return bogusInformation[randomIndex];
    }
    
    // Récupérer la première information vide
    public Information GetFirstEmptyInformation()
    {
        Information emptyInfo = activeInformations.FirstOrDefault(info => info.State == Information.InformationState.Empty);
        
        if (emptyInfo != null)
        {
            // Remplir cette information avec un contenu aléatoire
            InfoTextPair randomInfo = GetRandomUnusedInformation();
            emptyInfo.FullText = randomInfo.shortText;
            emptyInfo.LongText = randomInfo.longText;
            emptyInfo.IsTrue = randomInfo.isTrue;
        }
        
        return emptyInfo;
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