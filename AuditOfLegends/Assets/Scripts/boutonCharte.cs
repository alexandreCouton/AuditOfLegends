using UnityEngine;

public class boutonCharte : MonoBehaviour
{
    [SerializeField] private GameObject charte;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        charte.SetActive(!charte.activeSelf);
    }

}
