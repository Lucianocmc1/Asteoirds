using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PowerUP : MonoBehaviour , IPowerUP
{
   [SerializeField] InputPC input;
   [SerializeField] Image blur;
   [SerializeField] Image iconPower;
   [SerializeField] DataPowerSO power;
   [SerializeField] DataPowerSO powerDefault;
   [SerializeField] TextMeshProUGUI txtAmountUses;
   GameObject lastPrefabPower;
   TypePower typePower;
    int amountUses = 0;
    private void Start()=>  SetPower(powerDefault);
    void Update()
    {
      if (CanUsesPower())
      OnPower();
      
      txtAmountUses.text = amountUses.ToString();
      IconActive();
      UpdateBarEnergy();
    }
    bool CanUsesPower() => input.OnPressBar() && (power.timeMin == 0) && amountUses > 0;
    void OnPower()
    {
      amountUses--;
      if (lastPrefabPower is not null) Destroy(lastPrefabPower.gameObject);
      lastPrefabPower = Instantiate(power.prefab, transform.position, Quaternion.identity);
      power.timeMin = power.timeMax;
    }
    public void PowerDefault()=> power = powerDefault;
    void IconActive() => iconPower.gameObject.active = amountUses > 0; 
    public void SetPower( DataPowerSO powerUP)
    {
     power = powerUP;
     power.powerReset();
     iconPower.sprite = powerUP.iconPower;
     amountUses = powerUP.ammountUses;
     typePower = powerUP.typePower;
    }

    void UpdateBarEnergy()
    {
      power.timeMin = ((power.timeMin / power.timeMax) <= 0) ? 0 : (power.timeMin - Time.deltaTime);
      blur.fillAmount = (power.timeMin / power.timeMax);
    }
}
