using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BarEnergy : MonoBehaviour
{
    [SerializeField] Image barEnergy;
    [SerializeField] float lerpSpeed;
    [SerializeField] float maxEnergy;
    [SerializeField] float currentEnergy;
    [SerializeField] float lowEnergy;
    [SerializeField] float moreEnergy;
   
    void Update()
    {
        float targetFillAmount = Mathf.Lerp(barEnergy.fillAmount, currentEnergy / maxEnergy, Time.deltaTime * lerpSpeed);
        barEnergy.fillAmount = targetFillAmount;
        ChangeColor();
    }

    void ChangeColor()
    {
        if (currentEnergy >= 65f)
            barEnergy.color = Color.green;
        else
            barEnergy.color = (currentEnergy > 30f) ? Color.white : Color.red;

    }
    public void LowEnergy()=> currentEnergy = ((currentEnergy - lowEnergy) < 0) ? 0 : (currentEnergy - (Time.deltaTime + lowEnergy));
    public void MoreEnergy()=> currentEnergy = ((currentEnergy + moreEnergy) >= maxEnergy) ? maxEnergy: currentEnergy + moreEnergy;

    public float GetEnergy() { return currentEnergy; }
}
