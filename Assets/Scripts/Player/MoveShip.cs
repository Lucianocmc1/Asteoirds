using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;


[RequireComponent(typeof(Rigidbody2D))]
public class MoveShip : MonoBehaviour , IShip
{
    [SerializeField] InputPC input;
    [SerializeField] GameObject spriteFire;
    [SerializeField] DataPlayer player;
    [SerializeField] BarEnergy barEnergy;
    [SerializeField] float minEnergyBurst;
    bool burst = false;
    Rigidbody2D body;
    IBoundPlayer bounds;
    public Transform _Transform { get { return transform; } private set { } }
    private void Awake()
    {
        AdapterServiceLocator.Singlenton.RegisterService<IShip>(this);
    }
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        bounds = AdapterServiceLocator.Singlenton.GetService<IBoundPlayer>();
    }

    public Transform GetTransform() => _Transform;
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


        Vector2 clampedPosition = new Vector2
       (
           Mathf.Clamp(transform.position.x, bounds.GetBoundX().x, bounds.GetBoundX().y),
           Mathf.Clamp(transform.position.y, bounds.GetBoundY().x, bounds.GetBoundY().y)
       );


      transform.position = new Vector3(clampedPosition.x,clampedPosition.y, transform.position.z);
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
    // void Rotate() => transform.Rotate(0f, 0f, -input.GetAxisX() * player.speedRotate * Time.deltaTime);
    void Rotate() 
    {
        var target = input.PositionMouseWorld();
        float angleRadianes = Mathf.Atan2( target.y - transform.position.y , target.x - transform.position.x);
        float angleGrade = (180 /  Mathf.PI) * angleRadianes - 90; // le resto la rotacion inicial
        transform.rotation = Quaternion.Euler(0f, 0f, angleGrade);
    }

    bool SufficientPower() => barEnergy.GetEnergy() > minEnergyBurst; 
}
