using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;

public class Powerup : XRGrabInteractable
{
    public GameObject cameraoffset;
    // Start is called before the first frame update
    private PhotonView photonView;
    public Material mat;
    void Start()
    {
        photonView = GetComponent<PhotonView>();
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        photonView.RequestOwnership();
        base.OnSelectEntered(args);
        cameraoffset.transform.position = new Vector3(0, 4, 0);
    }
}
