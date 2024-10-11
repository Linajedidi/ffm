using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Health playerHealth;
    [SerializeField]  private Image totalehealthBar;
    [SerializeField] private Image CurrentlehealthBar;

    private void Start()
    {
        totalehealthBar.fillAmount = playerHealth.Currenthealth/10;
    }
    private void Update()
    {
        CurrentlehealthBar.fillAmount = playerHealth.Currenthealth/10;
    }

}
