using UnityEngine;
using System.Collections.Generic;

// Enum pour définir les différents types de personnalité
public enum PersonalityType
{
    Boss,           // Autoritaire mais cool (Zimmerwoman)
    Reserved,       // Froid et distant (CDP)
    Friendly,       // Normal et cool (Jean)
    Shy             // Gentille et timide (Daenerys)
}

// Enum pour définir les niveaux de confiance
public enum TrustLevel
{
    Low,            // 0-33%
    Medium,         // 33-66%
    High            // 66-100%
}

// Classe pour gérer les réponses personnalisées
public class PersonalityManager : MonoBehaviour
{
    // Structure pour organiser les messages selon la personnalité et le niveau de confiance
    [System.Serializable]
    public class ResponseSet
    {
        public string greeting;                   // Message d'accueil
        public string trustIncreased;             // Réaction à l'augmentation de la confiance
        public string trustDecreased;             // Réaction à la diminution de confiance
        public string knowledgeSuccess;           // A une information à partager
        public string knowledgeFailure;           // N'a pas d'information
        public string trustRequest;               // Demande quelle information vérifier
        public string trustNoInfo;                // Pas d'information à vérifier
        public string truthConfirmation;          // Confirme une vraie information
        public string falseConfirmation;          // Dénie une fausse information
        public string noMoreInfo;                 // Ne sait rien de plus
    }

    // Dictionnaire stockant les réponses pour chaque personnalité et niveau de confiance
    private Dictionary<PersonalityType, Dictionary<TrustLevel, ResponseSet>> personalityResponses = 
        new Dictionary<PersonalityType, Dictionary<TrustLevel, ResponseSet>>();

    void Awake()
    {
        InitializePersonalityResponses();
    }

    private void InitializePersonalityResponses()
    {
        // Initialisation des réponses pour chaque personnalité et niveau de confiance
        
        // --- BOSS (Zimmerwoman) ---
        Dictionary<TrustLevel, ResponseSet> bossResponses = new Dictionary<TrustLevel, ResponseSet>();
        
        // Boss - Confiance faible
        bossResponses[TrustLevel.Low] = new ResponseSet
        {
            greeting = "Que voulez-vous ? Soyez bref.",
            trustIncreased = "Mmh... Je commence à vous apprécier.",
            trustDecreased = "Vous commencez à m'agacer avec vos questions.",
            knowledgeSuccess = "Voici une information importante : {0}",
            knowledgeFailure = "Je n'ai rien à vous dire pour le moment.",
            trustRequest = "Quelle information voulez-vous vérifier exactement ?",
            trustNoInfo = "Vous n'avez rien à vérifier. Revenez quand vous aurez des informations pertinentes.",
            truthConfirmation = "C'est exact : {0}",
            falseConfirmation = "C'est faux : {0}",
            noMoreInfo = "Je ne m'avancerai pas sur ce sujet."
        };
        
        // Boss - Confiance moyenne
        bossResponses[TrustLevel.Medium] = new ResponseSet
        {
            greeting = "Que puis-je faire pour vous ?",
            trustIncreased = "Je vois que nous pouvons collaborer efficacement.",
            trustDecreased = "J'ai du travail, vous savez.",
            knowledgeSuccess = "Voici ce que je sais : {0}",
            knowledgeFailure = "Je n'ai pas cette information pour l'instant.",
            trustRequest = "Quelle information souhaitez-vous vérifier ?",
            trustNoInfo = "Vous n'avez pas d'information à vérifier actuellement.",
            truthConfirmation = "Oui, c'est tout à fait vrai : {0}",
            falseConfirmation = "Non, c'est inexact : {0}",
            noMoreInfo = "Je préfère ne pas me prononcer là-dessus."
        };
        
        // Boss - Confiance élevée
        bossResponses[TrustLevel.High] = new ResponseSet
        {
            greeting = "Ah, vous voilà ! Comment puis-je vous aider ?",
            trustIncreased = "Je savais que je pouvais compter sur vous.",
            trustDecreased = "Est-ce vraiment nécessaire de me poser tant de questions ?",
            knowledgeSuccess = "Entre nous, voici ce que je sais : {0}",
            knowledgeFailure = "Désolée, même moi je ne sais pas tout.",
            trustRequest = "Je vous écoute, quelle information voulez-vous vérifier ?",
            trustNoInfo = "Vous n'avez pas encore d'information à vérifier.",
            truthConfirmation = "Tout à fait correct : {0}",
            falseConfirmation = "C'est complètement faux : {0}",
            noMoreInfo = "Franchement, je ne suis pas certaine à ce sujet."
        };
        
        // --- RESERVED (CDP) ---
        Dictionary<TrustLevel, ResponseSet> reservedResponses = new Dictionary<TrustLevel, ResponseSet>();
        
        // Reserved - Confiance faible
        reservedResponses[TrustLevel.Low] = new ResponseSet
        {
            greeting = "...",
            trustIncreased = "Hmm.",
            trustDecreased = "...",
            knowledgeSuccess = "Information : {0}",
            knowledgeFailure = "Rien à signaler.",
            trustRequest = "Quelle information ?",
            trustNoInfo = "Pas d'information à vérifier.",
            truthConfirmation = "Correct : {0}",
            falseConfirmation = "Incorrect : {0}",
            noMoreInfo = "Sans commentaire."
        };
        
        // Reserved - Confiance moyenne
        reservedResponses[TrustLevel.Medium] = new ResponseSet
        {
            greeting = "Que voulez-vous ?",
            trustIncreased = "Acceptable.",
            trustDecreased = "Je dois retourner travailler.",
            knowledgeSuccess = "Je dispose de cette information : {0}",
            knowledgeFailure = "Je n'ai pas cette donnée.",
            trustRequest = "Quelle information souhaitez-vous vérifier ?",
            trustNoInfo = "Aucune information à vérifier dans la base de données.",
            truthConfirmation = "Cette information est exacte : {0}",
            falseConfirmation = "Cette information est erronée : {0}",
            noMoreInfo = "Je ne peux pas confirmer."
        };
        
        // Reserved - Confiance élevée
        reservedResponses[TrustLevel.High] = new ResponseSet
        {
            greeting = "Bonjour, que puis-je faire pour vous ?",
            trustIncreased = "Je vous remercie de votre collaboration.",
            trustDecreased = "J'ai des dossiers qui m'attendent.",
            knowledgeSuccess = "Voici l'information demandée : {0}",
            knowledgeFailure = "Je ne dispose pas de cette information actuellement.",
            trustRequest = "Veuillez préciser l'information à vérifier.",
            trustNoInfo = "Il n'y a pas d'information à vérifier pour le moment.",
            truthConfirmation = "Je confirme la véracité de cette information : {0}",
            falseConfirmation = "Je démens formellement cette information : {0}",
            noMoreInfo = "Je ne souhaite pas me prononcer sur ce point."
        };
        
        // --- FRIENDLY (Jean) ---
        Dictionary<TrustLevel, ResponseSet> friendlyResponses = new Dictionary<TrustLevel, ResponseSet>();
        
        // Friendly - Confiance faible
        friendlyResponses[TrustLevel.Low] = new ResponseSet
        {
            greeting = "Salut, tu veux quoi ?",
            trustIncreased = "Cool, merci !",
            trustDecreased = "Hey, c'est un interrogatoire ?",
            knowledgeSuccess = "Je crois savoir un truc : {0}",
            knowledgeFailure = "Désolé, je ne sais pas.",
            trustRequest = "Qu'est-ce que tu veux vérifier ?",
            trustNoInfo = "T'as rien à vérifier pour l'instant.",
            truthConfirmation = "Ouais c'est vrai : {0}",
            falseConfirmation = "Non c'est faux : {0}",
            noMoreInfo = "Je préfère pas me prononcer là-dessus."
        };
        
        // Friendly - Confiance moyenne
        friendlyResponses[TrustLevel.Medium] = new ResponseSet
        {
            greeting = "Hey ! Comment je peux t'aider ?",
            trustIncreased = "Sympa de bosser ensemble !",
            trustDecreased = "Tant de questions... Je devrais retourner bosser.",
            knowledgeSuccess = "Tiens, je sais que : {0}",
            knowledgeFailure = "Désolé, j'ai rien pour toi sur ça.",
            trustRequest = "Quelle info tu veux vérifier ?",
            trustNoInfo = "T'as pas d'info à vérifier pour le moment.",
            truthConfirmation = "Oui c'est bien vrai : {0}",
            falseConfirmation = "Non c'est complètement faux : {0}",
            noMoreInfo = "Franchement, je sais pas trop pour celle-là."
        };
        
        // Friendly - Confiance élevée
        friendlyResponses[TrustLevel.High] = new ResponseSet
        {
            greeting = "Salut mon pote ! Qu'est-ce que je peux faire pour toi ?",
            trustIncreased = "T'es vraiment cool comme mec !",
            trustDecreased = "Mec, tu me poses beaucoup de questions aujourd'hui !",
            knowledgeSuccess = "Entre nous, voilà ce que je sais : {0}",
            knowledgeFailure = "Désolé mon ami, j'ai rien sur ça.",
            trustRequest = "Dis-moi, qu'est-ce que tu veux que je vérifie ?",
            trustNoInfo = "T'as rien à vérifier pour l'instant, reviens plus tard !",
            truthConfirmation = "Absolument, c'est vrai : {0}",
            falseConfirmation = "Pas du tout, c'est faux : {0}",
            noMoreInfo = "Honnêtement, je peux pas t'aider sur ce coup-là."
        };
        
        // --- SHY (Daenerys) ---
        Dictionary<TrustLevel, ResponseSet> shyResponses = new Dictionary<TrustLevel, ResponseSet>();
        
        // Shy - Confiance faible
        shyResponses[TrustLevel.Low] = new ResponseSet
        {
            greeting = "Euh... bonjour ?",
            trustIncreased = "Merci...",
            trustDecreased = "Je... dois y aller...",
            knowledgeSuccess = "Je crois que... {0}",
            knowledgeFailure = "Je... je ne sais pas, désolée.",
            trustRequest = "Quelle... quelle information voulez-vous vérifier ?",
            trustNoInfo = "Il n'y a rien à vérifier, désolée...",
            truthConfirmation = "C'est... c'est vrai : {0}",
            falseConfirmation = "Hum, c'est faux : {0}",
            noMoreInfo = "Je ne suis pas sûre..."
        };
        
        // Shy - Confiance moyenne
        shyResponses[TrustLevel.Medium] = new ResponseSet
        {
            greeting = "Bonjour, je peux vous aider ?",
            trustIncreased = "Merci beaucoup !",
            trustDecreased = "Je suis un peu mal à l'aise avec toutes ces questions...",
            knowledgeSuccess = "Je sais que... {0}",
            knowledgeFailure = "Je n'ai pas d'information, désolée.",
            trustRequest = "Quelle information souhaitez-vous vérifier ?",
            trustNoInfo = "Vous n'avez pas d'information à vérifier pour le moment.",
            truthConfirmation = "Oui, c'est bien vrai : {0}",
            falseConfirmation = "Non, ce n'est pas vrai : {0}",
            noMoreInfo = "Je ne suis pas certaine à ce sujet..."
        };
        
        // Shy - Confiance élevée
        shyResponses[TrustLevel.High] = new ResponseSet
        {
            greeting = "Bonjour ! Comment puis-je vous aider aujourd'hui ?",
            trustIncreased = "C'est vraiment gentil, merci !",
            trustDecreased = "Désolée, mais j'ai vraiment du travail qui m'attend...",
            knowledgeSuccess = "Je peux vous dire que : {0}",
            knowledgeFailure = "Je suis désolée, mais je n'ai pas d'information.",
            trustRequest = "Quelle information souhaitez-vous que je vérifie pour vous ?",
            trustNoInfo = "Vous n'avez pas encore d'information à vérifier.",
            truthConfirmation = "Oui, c'est tout à fait exact : {0}",
            falseConfirmation = "Non, cette information est incorrecte : {0}",
            noMoreInfo = "Je préfère ne pas me prononcer sans être certaine."
        };
        
        // Ajouter tous les dictionnaires au dictionnaire principal
        personalityResponses[PersonalityType.Boss] = bossResponses;
        personalityResponses[PersonalityType.Reserved] = reservedResponses;
        personalityResponses[PersonalityType.Friendly] = friendlyResponses;
        personalityResponses[PersonalityType.Shy] = shyResponses;
    }
    
    // Obtenir le niveau de confiance en fonction du pourcentage
    public TrustLevel GetTrustLevel(float trustPercentage)
    {
        if (trustPercentage < 33f)
            return TrustLevel.Low;
        else if (trustPercentage < 66f)
            return TrustLevel.Medium;
        else
            return TrustLevel.High;
    }
    
    // Obtenir un message spécifique selon le type de personnalité et le niveau de confiance
    public string GetResponse(PersonalityType personality, TrustLevel trustLevel, string responseType, string param = null)
    {
        if (personalityResponses.ContainsKey(personality) && personalityResponses[personality].ContainsKey(trustLevel))
        {
            ResponseSet responses = personalityResponses[personality][trustLevel];
            string response = "";
            
            switch (responseType)
            {
                case "greeting":
                    response = responses.greeting;
                    break;
                case "trustIncreased":
                    response = responses.trustIncreased;
                    break;
                case "trustDecreased":
                    response = responses.trustDecreased;
                    break;    
                case "knowledgeSuccess":
                    response = responses.knowledgeSuccess;
                    break;
                case "knowledgeFailure":
                    response = responses.knowledgeFailure;
                    break;
                case "trustRequest":
                    response = responses.trustRequest;
                    break;
                case "trustNoInfo":
                    response = responses.trustNoInfo;
                    break;
                case "truthConfirmation":
                    response = responses.truthConfirmation;
                    break;
                case "falseConfirmation":
                    response = responses.falseConfirmation;
                    break;
                case "noMoreInfo":
                    response = responses.noMoreInfo;
                    break;
                default:
                    response = "...";
                    break;
            }
            
            // Remplacer le paramètre si nécessaire
            if (param != null && response.Contains("{0}"))
            {
                response = string.Format(response, param);
            }
            
            return response;
        }
        
        return "...";
    }
}