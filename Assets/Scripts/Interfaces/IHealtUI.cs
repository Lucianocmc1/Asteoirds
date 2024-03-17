using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealtUI
{
   public void AddHealt(GameObject prefabHealt , int index);
   public void LostHealt(int index);
}
