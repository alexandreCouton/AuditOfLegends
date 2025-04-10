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
    
    [SerializeField] private int numberOfButtons = 5;
    
    private List<Information> activeInformations = new List<Information>();
    
    // Liste pour garder trace des informations déjà utilisées
    private List<int> usedInformationIndices = new List<int>();
    
    public void InitializeInformations()
    {
        // Vider les listes
        activeInformations.Clear();
        usedInformationIndices.Clear();
        
        // Mélanger aléatoirement les informations disponibles
        System.Random rng = new System.Random();
        availableInformations = availableInformations.OrderBy(x => rng.Next()).ToList();
        
        // Créer des informations aléatoires pour chaque bouton
        for (int i = 0; i < numberOfButtons; i++)
        {
            // Créer l'information (initialiser en état "Empty" et non cliquable)
            Information info = new Information();
            info.SetEmpty();
            info.DisableClick();
            
            // Ajout à la liste active
            activeInformations.Add(info);
        }
    }
    
    // Récupérer une information aléatoire non utilisée
    public InfoTextPair GetRandomUnusedInformation()
    {
        // Filtrer pour n'avoir que les informations non utilisées
        List<int> availableIndices = Enumerable.Range(0, availableInformations.Count)
            .Where(i => !usedInformationIndices.Contains(i))
            .ToList();
        
        // Si toutes les informations ont été utilisées, réinitialiser
        if (availableIndices.Count == 0)
        {
            usedInformationIndices.Clear();
            availableIndices = Enumerable.Range(0, availableInformations.Count).ToList();
        }
        
        // Récupérer un index aléatoire
        int randomIndex = Random.Range(0, availableIndices.Count);
        int selectedIndex = availableIndices[randomIndex];
        
        // Marquer comme utilisée
        usedInformationIndices.Add(selectedIndex);
        
        return availableInformations[selectedIndex];
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