using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu( fileName =" listPowerUP" , menuName ="ScriptableObject/listPowerUP")]
public class PowerList : ScriptableObject
{
    public DataPowerSO[] list;
}
