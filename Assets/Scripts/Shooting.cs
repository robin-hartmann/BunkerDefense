using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject muzzleFlash;
    public VRTK.VRTK_ControllerEvents controllerEvents;

    void Start()
    {
        StopShooting(null, new VRTK.ControllerInteractionEventArgs());
        controllerEvents.TriggerPressed += StartShooting;
        controllerEvents.TriggerReleased += StopShooting;
    }

    private void StartShooting(object sender, VRTK.ControllerInteractionEventArgs e)
    {
        muzzleFlash.SetActive(true);
    }

    private void StopShooting(object sender, VRTK.ControllerInteractionEventArgs e)
    {
        muzzleFlash.SetActive(false);
    }
}
