using System.Collections;
using UnityEngine;

public class FishManager : MonoBehaviour
{
    private Coroutine spinCoroutine; 

    void Start()
    {
        //spinCoroutine = StartCoroutine(SpinFish());
    }

    public void Collected()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = true;
        }
        if (transform.childCount > 0)
        {
            Destroy(transform.GetChild(0).gameObject);
        }

    }

    public void MakeReal()
    {
        if (spinCoroutine != null)
        {
            StopCoroutine(spinCoroutine);
            spinCoroutine = null;
        }
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = true;
        }
    }

    IEnumerator SpinFish()
    {
        float rotationSpeed = 200f;
        while (true)
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
