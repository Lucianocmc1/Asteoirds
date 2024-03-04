using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ CreateAssetMenu( fileName = "PowerUP" , menuName = "ScriptableObject/PowerUP")]
public class DataPowerSO : ScriptableObject
{
    public Sprite iconPower;
    public float timeMax;
    public float timeMin;
    public int ammountUses;
    public GameObject prefab;
    public TypePower typePower;
    public void powerReset()=> timeMin = 1;
}
