using UnityEngine;

public class Coin : MonoBehaviour
{
     [SerializeField] private PlayerResources playerS;
        
     private int coinValue;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerResources>(out PlayerResources player))
        {
            player.PutCoin(coinValue);
            Destroy(this.gameObject);
        } 
       
    }


    public void SetCoinValue(int value)
    {
        coinValue = value;
  
    }


}
