using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveShip : MonoBehaviour
{
    [SerializeField] InputPC input;
    [SerializeField] GameObject spriteFire;
    [SerializeField] DataPlayer player;
    [SerializeField] BarEnergy barEnergy;
    [SerializeField] float minEnergyBurst;
    bool burst = false;
    Rigidbody2D body;
    IBoundsChecker boundsChecker;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        boundsChecker = new ScreenBoundsChecker();
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        Move();
        Burst();
    }
    void Burst()  
    {
       burst = input.OnBurst() > 0f;
       spriteFire.active = (burst && SufficientPower() && (input.GetAxisY() > 0f)); 
    }

    void Move() 
    {
        var ship = player;
        var speedNormal = Vector2.up * ship.speed;
        var speed = body.velocity.magnitude;

        if (barEnergy.GetEnergy() < 100f)
        barEnergy.MoreEnergy();

      /*  Vector3 newPosition = transform.position + new Vector3(0f, input.GetAxisY() * ship.speed * Time.deltaTime, 0f); ;
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(newPosition);

        if (boundsChecker.IsWithinBounds(screenPosition))
        { 
          rb.velocity = Vector2.zero;
          return;
        }
      */

      if (input.GetAxisY() > 0f && speed < ship.speedBurstMax) 
      {
        if (!burst && speed < ship.speedMax)
        {
         body.AddRelativeForce(speedNormal);
        }
        else if (burst && SufficientPower())
        {
          body.AddRelativeForce(speedNormal * ship.speedBurst);
          barEnergy.LowEnergy();
        }
      }

    }
    void Rotate() => transform.Rotate(0f, 0f, -input.GetAxisX() * player.speedRotate * Time.deltaTime);

    bool SufficientPower() => barEnergy.GetEnergy() > minEnergyBurst; 
}
