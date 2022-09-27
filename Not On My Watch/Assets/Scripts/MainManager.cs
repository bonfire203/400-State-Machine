using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public float cornStart;
    public int cornEnd;

    private void Awake(){
        if(Instance != null){
            Destroy(gameObject);
            return;
        }

        Instance = this;
        this.cornStart = 20;
        Debug.Log(this.cornStart);
        DontDestroyOnLoad(gameObject);
    }
}
