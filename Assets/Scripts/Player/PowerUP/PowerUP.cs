using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUP : MonoBehaviour
{
   [SerializeField] InputPC input;
   [SerializeField] Image blur;
   [SerializeField] Image iconPower;
   [SerializeField] DataPowerSO power;
   [SerializeField] DataPowerSO powerDefault;
   
    private void Start()=>  SetPower(powerDefault);
    void Update()
    {
        if (input.OnPressBar() && ( power.timeMin == 0) )
        OnPower();

        power.timeMin = ((power.timeMin / power.timeMax) <= 0) ? 0 : (power.timeMin - Time.deltaTime)  ;
        blur.fillAmount = ( power.timeMin / power.timeMax );  // 15/1 ahora, yo quiero 1/15 
    }
    void OnPower()
    {
      Instantiate(power.prefab, transform.position,Quaternion.identity);
      power.timeMin = 15f;
    }
    public void PowerDefault()=> power = powerDefault;
    public void SetPower( DataPowerSO powerUP)
    {
        power = powerUP;
        power.powerReset();
        iconPower.sprite = powerUP.iconPower;
        Debug.Log("se ejecuto powerUP");
    }

}
