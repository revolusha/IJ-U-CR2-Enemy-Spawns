using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private Transform _rats;

    private Text _text;
    private int _count;

    private void Start()
    {
        _text = GetComponent<Text>();
    }

    private void Update()
    {
        _count = _rats.childCount;
        _text.text = "Rats: " + _count;
    }
}
