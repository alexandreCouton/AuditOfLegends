using System.Collections.Generic;
using UnityEngine;

public class Boutonsbureaux : MonoBehaviour
{
    public GameObject boutonBureauEmployebasGauche;
    public GameObject boutonBureauEmployebasDroite;
    public GameObject boutonManager;
    public GameObject boutonChefProjet;
    public GameObject canvaManager;
    public GameObject canvaEmployeBasGauche;
    public GameObject canvaEmployeBasDroite;
    public GameObject canvaChefProjet;
    public GameObject map;
    [SerializeField] private GameManager gameManager;
    private Person onePeople;

    public void clickBoutonBureauEmployeBasGauche()
    {
        onePeople = gameManager.GetPerson(2);
        float trust = onePeople.getTrustPercentage();
        canvaEmployeBasGauche.SetActive(true);
        Debug.Log($"Button Employee Bottom Left clicked : {trust}");
        map.SetActive(false);
    }
    public void clickBoutonBureauEmployeBasDroite()
    {
        onePeople = gameManager.GetPerson(3);
        float trust = onePeople.getTrustPercentage();
        canvaEmployeBasDroite.SetActive(true);
      
        Debug.Log("Button Employee Bottom Right clicked");
        map.SetActive(false);
    }
    public void clickBoutonBureauManager()
    {
        onePeople = gameManager.GetPerson(0);
        float trust = onePeople.getTrustPercentage();
        canvaManager.SetActive(true);
      
        Debug.Log("Button Manager clicked");
        map.SetActive(false);
    }
    public void clickBoutonBureauChefProjet()
    {
        onePeople = gameManager.GetPerson(1);
        float trust = onePeople.getTrustPercentage();
        canvaChefProjet.SetActive(true);
  
        Debug.Log("Button Project Manager clicked");
        map.SetActive(false);
    }
    public void clickBoutonBureauFermer()
    {
        Debug.Log("Button Close clicked");
        canvaEmployeBasGauche.SetActive(false);
  
        canvaEmployeBasDroite.SetActive(false);
        canvaManager.SetActive(false);
        canvaChefProjet.SetActive(false);
        map.SetActive(true);
    }
}
