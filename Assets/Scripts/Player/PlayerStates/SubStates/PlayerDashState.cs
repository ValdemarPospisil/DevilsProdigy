using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerAbilityState {
	public bool CanDash { get; private set; }
	private bool isHolding;
	private bool dashInputStop;

	private float lastDashTime;

	private Vector2 dashDirection;
	private Vector2 dashDirectionInput;
	private Vector2 lastAIPos;

	public PlayerDashState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, SoundManager soundManager, string animBoolName) 
	: base(player, stateMachine, playerData, soundManager, animBoolName) {
	}
	public override void Enter() {
		base.Enter();

		CanDash = false;
		player.InputHandler.UseDashInput();

		isHolding = true;
		dashDirection = Vector2.right * Movement.FacingDirection;
		soundManager.Play("Dash");

	//	Time.timeScale = playerData.holdTimeScale;
		startTime = Time.unscaledTime;

		//player.DashDirectionIndicator.gameObject.SetActive(true);

	}

	public override void Exit() {
		base.Exit();

		if (Movement?.CurrentVelocity.y > 0) {
			Movement?.SetVelocityY(Movement.CurrentVelocity.y * playerData.dashEndYMultiplier);
		}
	}

	public override void LogicUpdate() {
		base.LogicUpdate();

		if (!isExitingState) {

			player.Anim.SetFloat("yVelocity", Movement.CurrentVelocity.y);
			player.Anim.SetFloat("xVelocity", Mathf.Abs(Movement.CurrentVelocity.x));


			if (isHolding) {
				

				

					isHolding = false;
					startTime = Time.time;
					Movement?.CheckIfShouldFlip(Mathf.RoundToInt(dashDirection.x));
					player.RB.linearDamping = playerData.drag;
					Movement?.SetVelocity(playerData.dashVelocity, dashDirection);
					PlaceAfterImage();
				
			} else {
				

				Movement?.SetVelocity(playerData.dashVelocity, dashDirection);
				CheckIfShouldPlaceAfterImage();

				if (Time.time >= startTime + playerData.dashTime) {
					player.RB.linearDamping = 0f;
					isAbilityDone = true;
					lastDashTime = Time.time;
				}
			}
		}
	}

	private void CheckIfShouldPlaceAfterImage() {
		if (Vector2.Distance(player.transform.position, lastAIPos) >= playerData.distBetweenAfterImages) {
			PlaceAfterImage();
		}
	}

	private void PlaceAfterImage() {
		PlayerAfterImagePool.Instance.GetFromPool();
		lastAIPos = player.transform.position;
	}

	public bool CheckIfCanDash() {
		return CanDash && Time.time >= lastDashTime + playerData.dashCooldown;
	}

	public void ResetCanDash() => CanDash = true;

}