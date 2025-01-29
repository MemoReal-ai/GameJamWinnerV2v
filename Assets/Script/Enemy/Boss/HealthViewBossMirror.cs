using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthViewBossMirror : MonoBehaviour
{
    [SerializeField] private Mirror boss;
    [SerializeField] private Image health;
    [SerializeField] private float fillDuration = 1f;

    private float maxFilling = 1f;
    private float imageFillBar = 0f;
    private float currentFilling = 0f;
    private void Start()
    {
        health.fillAmount = imageFillBar;
        StartCoroutine(Fillilng());

    }


    private void OnEnable()
    {
        boss.OnHealthChanged += ViewHealth;
    }
    private void OnDisable()
    {
        boss.OnHealthChanged -= ViewHealth;
    }
    private void ViewHealth(float health)
    {
        this.health.fillAmount = health;

    }


    private IEnumerator Fillilng()
    {
        var elepsedTime = 0f;
        var startFill = currentFilling;
        while (elepsedTime <= fillDuration)
        {
            elepsedTime += Time.deltaTime;
            currentFilling = Mathf.Lerp(imageFillBar, maxFilling, elepsedTime / fillDuration);
            health.fillAmount = currentFilling;
            yield return null;
        }
        health.fillAmount = maxFilling;


    }
}