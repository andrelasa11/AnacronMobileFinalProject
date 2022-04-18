using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleInstantiator : MonoBehaviour
{
    [SerializeField] private List<Instantiator> instantiators;
    [SerializeField] private float cadence;

    public int InstantiatorsCount
    {
        get { return instantiators.Count; }
    }

    public void InstantiateInSequence()
    {
        StartCoroutine(SequenceInstantiator());
    }

    public void InstantiateByIndex(int index)
    {
        if (index < 0 || index >= InstantiatorsCount)
        {
            Debug.LogErrorFormat("Can't instantiate with index {0}, Indicate an index between 0 and {1}", index, InstantiatorsCount);
            return;
        }

        var instantiator = instantiators[index];
        instantiator.DoInstantiate();
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
