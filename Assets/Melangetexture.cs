using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melangetexture : MonoBehaviour
{
    private Material material;
    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<MeshRenderer>().sharedMaterial;
        StartCoroutine(ChangeMaterial(1f, 3f)); 
    }

    IEnumerator ChangeMaterial(float target  /*float final de melange*/, float lerpDuration /*combien de temps ca prend pour lerp*/ ) 
    {
        float timeElapsed = 0f;
        float startValue = material.GetFloat("Melange");
        while (material.GetFloat("Melange") != target)
        {
            if (timeElapsed < lerpDuration)
            {
                material.SetFloat("Melange", Mathf.Lerp(startValue, target, timeElapsed / lerpDuration));
                timeElapsed += Time.deltaTime;
            }
            else
            {
                material.SetFloat("Melange", target);
                StartCoroutine(ChangeMaterialRetour(0f, 3f));
                StopCoroutine("ChangeMaterial");
                yield return true;
            }
            yield return null;
        }
    }
    IEnumerator ChangeMaterialRetour(float target  /*float final de melange*/, float lerpDuration /*combien de temps ca prend pour lerp*/ ) 
    {
        float timeElapsed = 0f;
        float startValue = material.GetFloat("Melange");
        while (material.GetFloat("Melange") != target)
        {
            if (timeElapsed > lerpDuration)
            {
                material.SetFloat("Melange", Mathf.Lerp(startValue, target, timeElapsed / lerpDuration));
                timeElapsed -= Time.deltaTime;
            }
            else
            {
                material.SetFloat("Melange", target);
                StartCoroutine(ChangeMaterial(1f, 3f));
                StopAllCoroutines();
                yield return true;
            }
            yield return null;
        }
    }
}
