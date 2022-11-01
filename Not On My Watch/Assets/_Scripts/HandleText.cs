using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HandleText : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro _titleStart;
    [SerializeField]
    private TextMeshPro _titleLost;
    [SerializeField]
    private TextMeshPro _titleEnd;

    float cornStart;
    float cornLost;
    float cornEnd;

    // Start is called before the first frame update
    void Start()
    {
        cornStart = MainManager.Instance.cornStart;
        cornLost = MainManager.Instance.cornLost;
        cornEnd = MainManager.Instance.cornStart - MainManager.Instance.cornLost;

        _titleStart.text = "Corn Planted: " + cornStart;
        _titleLost.text = "Corn Eaten: " + cornLost;
        _titleEnd.text = "Corn Harvested: " + cornEnd;

        MainManager.Instance.cornStart = cornEnd * 1.5f;
    }
}
