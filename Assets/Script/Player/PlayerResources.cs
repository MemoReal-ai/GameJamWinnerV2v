using System;
using UnityEngine;

public class PlayerResources : MonoBehaviour
{  
    [SerializeField] private int bucketPlayer = 1;

    public int BucketPlayer=>bucketPlayer;

    public event Action OnCoinChenged;


    private void Start()
    {
        OnCoinChenged?.Invoke();
    }

   public void PutCoin(int amount)
    {
        bucketPlayer +=amount;
        OnCoinChenged?.Invoke();
    }


    public void SpendCoin(int amount) 
    {
        if (TrySpend(amount)==true)
        {
            bucketPlayer -=amount;
            OnCoinChenged?.Invoke();
        }

    }

    private bool TrySpend(int cost)
    {
        if (bucketPlayer >= cost)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
  
    
}
