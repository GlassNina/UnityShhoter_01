using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;            //1

    void Update()
    {
        ObjectMove();                                       //2
    }

    void OnTriggerEnter(Collider other)                     //3
    {
        Destroy(this.gameObject);                           //3
    }

    void ObjectMove()                                       //4
    {
        transform.Translate(0, 0, _speed * Time.deltaTime); //4
    }
}