using System.Collections.Generic;
using UnityEngine;

public class Boutonsbureaux : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject boutonBureauEmployebasGauche;
    public GameObject boutonBureauEmployebasDroite;
    public GameObject boutonManager;
    public GameObject boutonChefProjet;
    public GameObject canvaManager;
    public GameObject canvaManager_Confiant;
    public GameObject canvaManager_PasConfiant;
    public GameObject canvaManager_Moyen;
    public GameObject canvaEmployeBasGauche;

    public GameObject canvaEmployeBasGauche_Confiant;
    public GameObject canvaEmployeBasGauche_PasConfiant;
    public GameObject canvaEmployeBasGauche_Moyen;
    public GameObject canvaEmployeBasDroite;
    public GameObject canvaEmployeBasDroite_Confiant;
    public GameObject canvaEmployeBasDroite_PasConfiant;
    public GameObject canvaEmployeBasDroite_Moyen;
    public GameObject canvaChefProjet;

    public GameObject canvaChefProjet_Confiant;
    public GameObject canvaChefProjet_BofConfiant;
    public GameObject canvaChefProjet_PasConfiant;
    public GameObject map;
    [SerializeField] private GameManager gameManager;
    private Person onePeople;


    void Start()
    {
    }

    void Update()
    {
        // Update logic if needed
    }

    void OnEnable()
    {

    }

    public void clickBoutonBureauEmployeBasGauche()
    {

        // Check if the employee is confident or not and set the appropriate canvas
        onePeople = gameManager.GetPerson(2);
        float trust = onePeople.getTrustPercentage();
        canvaEmployeBasGauche.SetActive(true);

        if (trust < 33f)
        {
            canvaEmployeBasGauche_PasConfiant.SetActive(true);
            canvaEmployeBasGauche_Confiant.SetActive(false);
            canvaEmployeBasGauche_Moyen.SetActive(false);
        }
        else if (trust < 66f)
        {
            canvaEmployeBasGauche_Confiant.SetActive(false);
            canvaEmployeBasGauche_PasConfiant.SetActive(false);
            canvaEmployeBasGauche_Moyen.SetActive(true);
        }
        else if (trust >= 66f)
        {
            canvaEmployeBasGauche_Confiant.SetActive(true);
            canvaEmployeBasGauche_PasConfiant.SetActive(false);
            canvaEmployeBasGauche_Moyen.SetActive(false);
        }

        Debug.Log($"Button Employee Bottom Left clicked : {trust}");
        map.SetActive(false);
    }
    public void clickBoutonBureauEmployeBasDroite()
    {
        // Check if the employee is confident or not and set the appropriate canvas
        onePeople = gameManager.GetPerson(3);
        float trust = onePeople.getTrustPercentage();
        canvaEmployeBasDroite.SetActive(true);
        if (trust < 33f)
        {
            canvaEmployeBasDroite_PasConfiant.SetActive(true);
            canvaEmployeBasDroite_Confiant.SetActive(false);
            canvaEmployeBasDroite_Moyen.SetActive(false);
        }
        else if (trust < 66f)
        {
            canvaEmployeBasDroite_Confiant.SetActive(false);
            canvaEmployeBasDroite_PasConfiant.SetActive(false);
            canvaEmployeBasDroite_Moyen.SetActive(true);
        }
        else if (trust >= 66f)
        {
            canvaEmployeBasDroite_Confiant.SetActive(true);
            canvaEmployeBasDroite_PasConfiant.SetActive(false);
            canvaEmployeBasDroite_Moyen.SetActive(false);
        }
        Debug.Log("Button Employee Bottom Right clicked");
        map.SetActive(false);
    }
    public void clickBoutonBureauManager()
    {
        // Check if the manager is confident or not and set the appropriate canvas
        onePeople = gameManager.GetPerson(0);
        float trust = onePeople.getTrustPercentage();
        canvaManager.SetActive(true);
        if (trust < 33f)
        {
            canvaManager_PasConfiant.SetActive(true);
            canvaManager_Confiant.SetActive(false);
            canvaManager_Moyen.SetActive(false);
        }
        else if (trust < 66f)
        {
            canvaManager_Confiant.SetActive(false);
            canvaManager_PasConfiant.SetActive(false);
            canvaManager_Moyen.SetActive(true);
        }
        else if (trust >= 66f)
        {
            canvaManager_Confiant.SetActive(true);
            canvaManager_PasConfiant.SetActive(false);
            canvaManager_Moyen.SetActive(false);
        }
        Debug.Log("Button Manager clicked");
        map.SetActive(false);
    }
    public void clickBoutonBureauChefProjet()
    {
        // Check if the project manager is confident or not and set the appropriate canvas
        onePeople = gameManager.GetPerson(1);
        float trust = onePeople.getTrustPercentage();
        canvaChefProjet.SetActive(true);
        if (trust < 33f)
        {
            canvaChefProjet_PasConfiant.SetActive(true);
            canvaChefProjet_Confiant.SetActive(false);
            canvaChefProjet_BofConfiant.SetActive(false);
        }
        else if (trust < 66f)
        {
            canvaChefProjet_Confiant.SetActive(false);
            canvaChefProjet_PasConfiant.SetActive(false);
            canvaChefProjet_BofConfiant.SetActive(true);
        }
        else if (trust >= 66f)
        {
            canvaChefProjet_Confiant.SetActive(true);
            canvaChefProjet_PasConfiant.SetActive(false);
            canvaChefProjet_BofConfiant.SetActive(false);
        }
        Debug.Log("Button Project Manager clicked");
        map.SetActive(false);
    }
    public void clickBoutonBureauFermer()
    {
        Debug.Log("Button Close clicked");
        canvaEmployeBasGauche.SetActive(false);
        //LE BUREAU

        canvaEmployeBasGauche_Confiant.SetActive(false);
        canvaEmployeBasGauche_PasConfiant.SetActive(false);


        canvaEmployeBasDroite.SetActive(false);

        canvaEmployeBasDroite_Confiant.SetActive(false);
        canvaEmployeBasDroite_PasConfiant.SetActive(false);

        canvaManager.SetActive(false);

        canvaManager_Confiant.SetActive(false);
        canvaManager_PasConfiant.SetActive(false);

        canvaChefProjet.SetActive(false);

        canvaChefProjet_BofConfiant.SetActive(false);
        canvaChefProjet_PasConfiant.SetActive(false);

        map.SetActive(true);
    }


}
