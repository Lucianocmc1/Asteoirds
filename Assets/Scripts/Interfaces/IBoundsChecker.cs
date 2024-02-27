using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBoundsChecker 
{
    bool IsWithinBounds(Vector3 position);
}
