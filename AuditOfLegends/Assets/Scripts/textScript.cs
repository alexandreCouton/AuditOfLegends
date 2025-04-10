using UnityEngine;
using TMPro;

public class textScript : MonoBehaviour
{
    private string[,] tab =
    {
        { "Objectif de la charte", "Définition et mission de l'audit interne", "Les domaines d’actions du contrôle interne", "Déontologie de l'auditeur interne", "Procédures d'audit interne", "Ressources de l'audit interne", "Évaluation de la fonction d'audit interne","" },
        { "En temps normal, la charte précise les missions et responsabilités de l'audit interne, définit son organisation, son champ d'action et les principes garantissant son indépendance. Mais là on t’en propose une qui simplifiée et qui va uniquement les informations dont tu pourrais avoir besoin : de la définition d’un audit à de petits tips sur quels points il est bien de faire attention.",
        "L'audit interne est une activité indépendante et objective qui évalue le degré de maîtrise des opérations de l'université et propose des conseils pour l'améliorer. Il s'assure de l'efficacité des dispositifs de contrôle interne, aidant ainsi l'université à atteindre ses objectifs en évaluant et en améliorant les processus de gouvernance, de gestion des risques et de contrôle.",
        "Le contrôle interne doit analyser ces différentes sections lors de l’audit :\r\nEnvironnement de contrôle : Climat organisationnel influençant la conscience du contrôle par le personnel.\r\n\r\n\r\nÉvaluation des risques : Identification et analyse des risques liés à l'atteinte des objectifs.​\r\n\r\n\r\nActivités de contrôle : Actions mises en place pour maîtriser les risques et atteindre les objectifs.​\r\n\r\n\r\nInformation et communication : Diffusion des informations pertinentes pour le fonctionnement du contrôle interne.\r\n\r\n\r\nPilotage : Suivi et amélioration continue du dispositif de contrôle interne.\r\n\r\n\r\n",
        "Les obligations des auditeurs sont essentielles pour garantir la confiance et la crédibilité de l’audit interne.\r\nLes auditeurs doivent respecter un code de déontologie professionnel, adapté au secteur public par le CHAIE. Cela signifie qu’ils mènent leurs missions :\r\nAvec intégrité : en respectant les règles de la fonction publique, de leur métier et de l’université.\r\nAvec objectivité : ils restent neutres et ne se laissent influencer ni par leurs opinions personnelles, ni par des pressions extérieures.\r\nDans la confidentialité : les informations collectées sont protégées, partagées uniquement avec autorisation.\r\nAvec compétence : ils utilisent les connaissances et l’expérience nécessaires, et continuent à se former.\r\n\r\nIls appliquent aussi les normes professionnelles du métier, tant qu’elles sont adaptées à l’université.\r\nIls ne critiquent jamais les personnes, mais se concentrent uniquement sur les systèmes et les processus.\r\n",
        "Les missions d'audit suivent une méthodologie structurée incluant la planification, la réalisation, la communication des résultats et le suivi des recommandations. Chaque étape est documentée pour assurer la traçabilité et la qualité des travaux.​\r\n",
        "L'université s'engage à fournir les ressources nécessaires, en termes de personnel et de moyens, pour permettre à l'audit interne de remplir efficacement ses missions.​\r\nTous les membres du personnel que tu interroges sont supposés te donner les informations qu’ils possèdent. Libre à toi d’instaurer une meilleure relation de confiance pour simplifier l’échange.\r\n",
        "La performance de l'audit interne est évaluée régulièrement, notamment par le comité d'audit interne, pour assurer l'amélioration continue de ses activités et le respect des normes professionnelles.​\r\nDonc n’essaies pas de bâcler ton travail !\r\nCette charte établit le cadre de fonctionnement de l'audit interne à l'Université de Strasbourg, garantissant son efficacité, son indépendance et sa contribution à la bonne gouvernance de l'établissement.\r\n",
        ""}
    };

    private int i = 0;

    [SerializeField] private TextMeshProUGUI titreGauche;
    [SerializeField] private TextMeshProUGUI pageGauche;
    [SerializeField] private TextMeshProUGUI titreDroite;
    [SerializeField] private TextMeshProUGUI pageDroite;


    void Start()
    {
        titreGauche.text = tab[0, i];
        pageGauche.text = tab[1, i];
        titreDroite.text = tab[0, i + 1];
        pageDroite.text = tab[1, i + 1];
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void nextButton()
    {
        i++;
        i = i % 7;
        titreGauche.text = tab[0, i];
        pageGauche.text = tab[1, i];
        titreDroite.text = tab[0, i + 1];
        pageDroite.text = tab[1, i + 1];
    }

    public void prevButton()
    {
        i--;
        if (i < 0)
        {
            i = 6;
        }
        titreGauche.text = tab[0, i];
        pageGauche.text = tab[1, i];
        titreDroite.text = tab[0, i + 1];
        pageDroite.text = tab[1, i + 1];
    }
}
