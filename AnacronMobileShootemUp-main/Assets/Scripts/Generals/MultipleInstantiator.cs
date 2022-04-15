using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleInstantiator : MonoBehaviour
{
    [SerializeField] private List<Instantiator> instantiators;
    [SerializeField] private float cadence;

    public void InstantiateInSequence()
    {
        StartCoroutine(SequenceInstantiator());
    }

    private IEnumerator SequenceInstantiator()
    {
        foreach (var instantiator in instantiators)
        {
            instantiator.DoInstantiate();
            yield return new WaitForSeconds(cadence);
        }
    }

}
