using UnityEngine;
using Bezoro.StateMachines;
using Bezoro.Character.Controller;
using KinematicCharacterController;

namespace Bezoro.Character.States
{
	public class ErshinIdle : KinematicCharacterState<Ershin>
	{
		protected override void OnInit() { }

		protected override void OnEnter() { }

		protected override void OnTick() { }

		protected override void OnFixedTick() { }

		protected override void OnLateTick() { }

		protected override void OnUpdateRotation
		(
			ref Quaternion currentRotation,
			float deltaTime
		) { }

		protected override void OnUpdateVelocity(ref Vector3 currentVelocity, float deltaTime) { }

		protected override void OnBeforeCharacterUpdate(float deltaTime) { }

		protected override void OnPostGroundingUpdate(float deltaTime) { }

		protected override void OnAfterCharacterUpdate(float deltaTime) { }

		protected override void OnGroundHit
		(
			Collider hitCollider,
			Vector3 hitNormal,
			Vector3 hitPoint,
			ref HitStabilityReport hitStabilityReport
		) { }

		protected override void OnMovementHit
		(
			Collider hitCollider,
			Vector3 hitNormal,
			Vector3 hitPoint,
			ref HitStabilityReport hitStabilityReport
		) { }

		protected override void OnProcessHitStabilityReport
		(
			Collider hitCollider,
			Vector3 hitNormal,
			Vector3 hitPoint,
			Vector3 atCharacterPosition,
			Quaternion atCharacterRotation,
			ref HitStabilityReport hitStabilityReport
		) { }

		protected override void OnDiscreteCollisionDetected(Collider hitCollider) { }

		protected override void OnExit() { throw new System.NotImplementedException(); }
	}
}