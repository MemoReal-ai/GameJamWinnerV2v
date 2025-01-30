using UnityEngine;
using TMPro;
public class MoneyView : MonoBehaviour
{
    [SerializeField] private PlayerResources player;
    [SerializeField] private TextMeshProUGUI textMeshPro; 
    private void OnEnable()
    {
        player.OnCoinChenged += CoinView;
    }

    private void OnDisable()
    {
        player.OnCoinChenged -= CoinView;
    }


    private void CoinView() => textMeshPro.text=player.BucketPlayer.ToString();

}
