using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodCutManager : MonoBehaviour
{
    IEnumerator CutWood(GameObject go)
    {
        yield return new WaitForSeconds(.4f);
        Destroy(go);
        UIManager.instance.AddWood(10);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Tags.wood))
        {
            StartCoroutine(CutWood(other.gameObject));
        }
    }
}
