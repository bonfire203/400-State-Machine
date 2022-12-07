using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;
public class XRGrabNetworkInteractable : XRGrabInteractable
{
    private PhotonView photonView;
    public Material mat;
    void Start(){
        photonView = GetComponent<PhotonView>();
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        photonView.RequestOwnership();
        base.OnSelectEntered(args);

        if(this.gameObject.tag == "colorChange")
        {
            this.gameObject.GetComponent<MeshRenderer>().material = mat;
            Debug.Log("Changing Color!");
        }
    }
}
