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
    const KeyCode enter = KeyCode.Return;
    const string burst = "Fire2";
    const string Fire = "Fire1";

    public float GetAxisX() { return  Input.GetAxis(axisX); }
    public float GetAxisY() { return Input.GetAxis(axisY); }
    public bool OnPressBar() { return Input.GetKeyDown(spaceBar); }
    public float OnFire() { return Input.GetAxis(Fire); }
    public float OnBurst() { return Input.GetAxis(burst); }
    public Vector2 GetDirection() { return new Vector2(GetAxisX(), GetAxisY()); }
    public bool GetEnter()=> Input.GetKeyDown(enter);
    public Vector3 PositionMouseWorld()=> Camera.main.ScreenToWorldPoint(Input.mousePosition) ;
    public float AngleRespectMouse(float angleInitial) 
    {
        var target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angleRadianes = Mathf.Atan2(target.y - transform.position.y, target.x - transform.position.x);
        return (180 / Mathf.PI) * angleRadianes - angleInitial; // le resto la rotacion inicial
    }
    //   void RotateShip()
}
