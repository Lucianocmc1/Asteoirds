using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class InputPC : MonoBehaviour
{
    const string axisX = "Horizontal";
    const string axisY = "Vertical";
    const KeyCode spaceBar = KeyCode.Space;
    const string burst = "Fire2";
    const string Fire = "Fire1";

    public float GetAxisX() { return  Input.GetAxis(axisX); }
    public float GetAxisY() { return Input.GetAxis(axisY); }
    public bool OnPressBar() { return Input.GetKeyDown(spaceBar); }
    public float OnFire() { return Input.GetAxis(Fire); }
    public float OnBurst() { return Input.GetAxis(burst); }
    public Vector2 GetDirection() { return new Vector2(GetAxisX(), GetAxisY()); }

    //   void RotateShip()
}
