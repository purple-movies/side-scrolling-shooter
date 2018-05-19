using com.draconianmarshmallows.boilerplate;
using com.draconianmarshmallows.boilerplate.controllers;
using com.draconianmarshmallows.boilerplate.managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : BaseUIController, IUpdateable
{
	[SerializeField] private PlayerController playerController;

	private float verticalAxis = 0f;

    protected override void Start()
    {
        base.Start();

    }

    public override void OnLevelStarted(BaseLevelController levelController)
    {
        Debug.Log("Started level...");
        UpdateManager.Instance.AddUpdateable(this);
    }

    public void OnUpdate()
    {
        verticalAxis = Input.GetAxis(InputConstants.VERTICAL);

        if (verticalAxis != 0)
            playerController.moveVertically(verticalAxis);

        if (Input.GetButtonDown(InputConstants.FIRE_1))
            playerController.fireWeaponA();
    }
}
