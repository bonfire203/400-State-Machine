using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public float cornStart;
    public float cornLost;
    public float cornEnd;

    private void Awake(){
        if(Instance != null){
            Destroy(gameObject);
            return;
        }

        Instance = this;
        this.cornStart = 20;
        this.cornLost = 0;
        this.cornEnd = 20;
        DontDestroyOnLoad(gameObject);
    }
}
