using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bomb : MonoBehaviour
{
    [SerializeField] GameObject bomb;
    [SerializeField, Min(0)] float timeForExploit;
    private GameObject bombDefault;
    void Start()
    {
        bombDefault = bomb;
        StartCoroutine(BombActive());
    }
    private IEnumerator BombActive()
    {
        yield return new WaitForSeconds(timeForExploit);
        var fvx = Instantiate(bomb, transform.position, Quaternion.identity);
        this.gameObject.SetActive(false);
    }
    public void SetBomb(GameObject newBoom){ bomb = newBoom; }
    public void defaultBomb() => bomb = bombDefault;
}
