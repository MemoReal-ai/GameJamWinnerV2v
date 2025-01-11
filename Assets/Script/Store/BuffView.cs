using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuffView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cost;
    [SerializeField] private TextMeshProUGUI name;
    [SerializeField] private Buff buff;
    [SerializeField] private Image prefabImage;
    private void Start()
    {
        cost.text = buff.Cost.ToString();
        name.text = buff.Name;
        prefabImage.sprite=buff.Image;
    }
 

}
