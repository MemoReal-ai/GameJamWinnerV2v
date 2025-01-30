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
    [SerializeField] private int costRerol = 1;
    
    [SerializeField] private Player _player;

    
    
    private List<GameObject> baffConteinerList = new List<GameObject>();
    private void Start()
    {
        rerolButton.onClick.AddListener(ReloadBuffs);
        exitButton.onClick.AddListener(ExitInShop);
        StartReloadShop();
    }

    private void StartReloadShop()
    {
        foreach (Transform child in transformConteiner)
            Destroy(child.gameObject);

        baffConteinerList.Clear();

        for (int i = 0; i < countBuff; i++)
        {
            var randomBuff = Random.Range(0, baffConteiner.Count);
            var buff = Instantiate(baffConteiner[randomBuff], transformConteiner);
            if (buff.TryGetComponent(out Buff buffs))
            {
                baffConteinerList.Add(buff);
                buffs.Button.onClick.AddListener(() => BuyBuff(buff));
            }
        }
    }

    private void BuyBuff(GameObject buffGo)
    {
        if (buffGo.TryGetComponent(out Buff buff) && playerResources.BucketPlayer >= buff.Cost)
        {
            playerResources.SpendCoin(buff.Cost);
            buff.ApplyBuff(playerStats);
            baffConteinerList.Remove(buffGo);
            Destroy(buffGo);
        }
    }


    private void ReloadBuffs()
    {
        if (playerResources.BucketPlayer < costRerol)
        {
            return;
        }
        playerResources.SpendCoin(costRerol);
        StartReloadShop();
    }


    private void ExitInShop()
    {
        gameObject.SetActive(false);
        _player.enabled = true;
        

    }
}

