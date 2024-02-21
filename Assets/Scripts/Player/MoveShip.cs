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
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        var speed = rb.velocity.magnitude;

        if(barEnergy.GetEnergy() < 100f)
        barEnergy.MoreEnergy();

        if (input.GetAxisY() > 0f && speed < ship.speedBurstMax) 
        {
            if (!burst && speed < ship.speedMax)
            {
                rb.AddRelativeForce(speedNormal);
            }
            else if (burst && SufficientPower())
            {
                
                rb.AddRelativeForce(speedNormal * ship.speedBurst);
                barEnergy.LowEnergy();
                return;
            }
        }
    }
    
    void Rotate() => transform.Rotate(0f, 0f, -input.GetAxisX() * player.speedRotate * Time.deltaTime);

    bool SufficientPower() => barEnergy.GetEnergy() > minEnergyBurst; 
}
