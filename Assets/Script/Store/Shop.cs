using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<GameObject> baffConteiner = new List<GameObject>();
    [SerializeField] private Transform transformConteiner;
    [SerializeField] private PlayerResources playerResources;
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private byte countBuff = 3;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button rerolButton;
    
    private List<GameObject> baffConteinerList=new List<GameObject>();
    private void Start()
    {
        rerolButton.onClick.AddListener(ReloadShop);
        exitButton.onClick.AddListener(ExitInShop);
        ReloadShop();
    }

    private void ReloadShop()
    {
        foreach (Transform child in transformConteiner)
            Destroy(child.gameObject);
              baffConteinerList.Clear();

        for (int i = 0; i < countBuff; i++)
        {  
            var randomBuff=Random.Range(0,baffConteiner.Count);
            var buff=Instantiate(baffConteiner[randomBuff], transformConteiner);
            baffConteinerList.Add(buff);
     } }



    private void ExitInShop()
    {
        gameObject.SetActive(false);

    }
}
