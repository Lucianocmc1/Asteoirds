using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class HealthShip : MonoBehaviour, IDestroy , IHealtPlayer
{
    [SerializeField] Transform positionTemplate;
    [SerializeField] GameObject templeateHealt;
    [SerializeField , Min(1)] int healtInitial;
    [SerializeField] float offSet;
    [SerializeField] LayerMask layerEnemy;
    [SerializeField] LayerMask layerBulletEnemy;
    [SerializeField] BarrierPower barrier;
    readonly Transform _transform; 
    int index = 0;
    Rigidbody2D body;
    public UnityEvent OnPlayerDeath;
    public HealthShip Instance { get { return this; } private set { } }
    void Awake() 
    {
        var adapterServiceLocator = AdapterServiceLocator.Singlenton;
        adapterServiceLocator.RegisterService<IHealtPlayer>(this);
    }
    void Start()
    {
       body = GetComponent<Rigidbody2D>();
       for (int i = healtInitial; i >= 1; i--)
       InstanceHealt(); 
    }
    void InstanceHealt()
    {
        GameObject health = Instantiate(templeateHealt, positionTemplate.position, Quaternion.identity, positionTemplate);
        health.SetActive(true);
        RectTransform healthRectTransform = health.GetComponent<RectTransform>();
        healthRectTransform.anchoredPosition = new Vector2 (positionTemplate.position.x + index * offSet, positionTemplate.position.y);
        HealtShipUI.Instance.AddHealt(health, index);
        index++;
    }
    public void MoreHealt()=> InstanceHealt();
    void LowHealt() 
    {
        index--;
        HealtShipUI.Instance.LostHealt(index);
    }

    void Destroy()
    {
        if( index > 1)
        { 
         LowHealt();
         Respawn();
         InstanceBarrier();
         return;
        }
        else
        {
         OnPlayerDeath.Invoke();
         gameObject.SetActive(false);
        }
        
    }
    void Respawn() 
    {
        transform.position = Vector3.zero;
        body.velocity = Vector3.zero;
    }
    public void OnDestroyed(bool forPlayer) => Destroy();
    private void OnCollisionEnter2D(Collision2D other)
    {
       bool enemy = (other.gameObject.layer == LayerMask.NameToLayer("Enemy") || other.gameObject.layer == LayerMask.NameToLayer("BulletEnemy"));
       if (enemy) Destroy();
    }
    public void OnDeath() => InstanceBarrier();
    void InstanceBarrier()=> barrier.gameObject.SetActive(true);
    public HealthShip Get() => Instance;

    public Transform GetTransform() => transform;
}
