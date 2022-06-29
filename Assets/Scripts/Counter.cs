using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]

public class Counter : MonoBehaviour
{
    [SerializeField] private Transform _rats;

    private Text _text;
    private int _count;

    private void Start()
    {
        _text = GetComponent<Text>();
        StartCoroutine(UpdateRatCount());
    }

    private void OnDestroy()
    {
        StopCoroutine(UpdateRatCount());
    }

    private IEnumerator UpdateRatCount()
    {
        const float UpdateFrequency = 1f;

        yield return new WaitForSeconds(UpdateFrequency);
        _text.text = "Rats: " + _rats.childCount;
        StartCoroutine(UpdateRatCount());
    }
}
