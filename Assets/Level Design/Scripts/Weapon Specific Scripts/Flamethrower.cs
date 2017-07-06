using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : Photon.MonoBehaviour {

    ParticleSystem.EmissionModule flamet;
    public bool flameState;
	void Start () {
        flameState = false;
        flamet = this.gameObject.GetComponent<ParticleSystem>().emission;
        flamet.enabled = flameState;       
    }

    // Update is called once per frame
    void Update()
    {
        flamet.enabled = flameState;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(flameState);
        }
        else
        {
            flameState=(bool)stream.ReceiveNext();
        }

    }
    public void SwitchFlame()
    {
        flameState= !flameState;
        flamet.enabled = flameState;
    }
    public void TurnOffFlame()
    {
        flameState = false;
        flamet.enabled = flameState;
    }
    void OnParticleCollision(GameObject pl)
    {
        if(pl.transform.root.gameObject.name=="TheDrone(Clone)")
            pl.transform.root.gameObject.GetComponent<PhotonView>().RPC("TakeDamage", PhotonTargets.All, 0.1f);
    }
}
