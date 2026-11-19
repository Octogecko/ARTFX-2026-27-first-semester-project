using System.Collections;
using UnityEngine;

public class Scimitar : MonoBehaviour
{
    public bool attacking = false;

    public void Attack()
    {
        attacking = true;
        gameObject.SetActive(true);
        GetComponent<Animator>().Play(0);
        StartCoroutine(StopAttacking());
    }

    private IEnumerator StopAttacking()
    {
        yield return new WaitWhile(() => attacking == true);
        gameObject.SetActive(false);
    }
}
