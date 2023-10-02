using System.Collections;
using UnityEngine;

public class EnemyReact : MonoBehaviour
{
    public void ReactToHit()                     //1
    {
        GetComponent<EnemyAI>().SetAlive(false); //2

        StartCoroutine(EnemyDie());              //3
    }
    
    private IEnumerator EnemyDie()               //4
    {
        this.transform.Rotate(-75, 0, 0);        //5

        yield return new WaitForSeconds(1.5f);   //6

        Destroy(this.gameObject);                //7
    }
}