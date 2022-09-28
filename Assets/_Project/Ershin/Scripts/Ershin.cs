using Bezoro.Core;
using UnityEngine;
using KinematicCharacterController;
using Bezoro.Character.StateMachine;

namespace Bezoro.Character.Controller
{
	[SelectionBase, DisallowMultipleComponent]
	[RequireComponent(typeof(KinematicCharacterMotor))]
	public sealed class Ershin : Tickable,
		ICharacterController
	{
		[field: SerializeField]
		public KinematicCharacterMotor CharacterMotor { get; private set; }

		[field: SerializeField, HideInInspector]
		public ErshinStateMachine StateMachine { get; private set; } = new();

		private void Awake()
		{
			CharacterMotor.CharacterController = this;

			StateMachine.Init(this, CharacterMotor);
		}

		public override void Tick() { StateMachine.Tick(); }

		public override void FixedTick() { StateMachine.FixedTick(); }

		public override void LateTick() { StateMachine.LateTick(); }

		#region KCC Methods

		public void UpdateRotation(ref Quaternion currentRotation, float deltaTime) =>
			StateMachine.UpdateRotation(ref currentRotation, deltaTime);

		public void UpdateVelocity(ref Vector3 currentVelocity, float deltaTime) =>
			StateMachine.UpdateVelocity(ref currentVelocity, deltaTime);

		public void BeforeCharacterUpdate(float deltaTime) =>
			StateMachine.BeforeCharacterUpdate(deltaTime);

		public void PostGroundingUpdate(float deltaTime) =>
			StateMachine.PostGroundingUpdate(deltaTime);

		public void AfterCharacterUpdate(float deltaTime) =>
			StateMachine.AfterCharacterUpdate(deltaTime);

		public bool IsColliderValidForCollisions(Collider coll) =>
			StateMachine.IsColliderValidForCollisions(coll);

		public void OnGroundHit
		(
			Collider hitCollider,
			Vector3 hitNormal,
			Vector3 hitPoint,
			ref HitStabilityReport hitStabilityReport
		) =>
			StateMachine.OnGroundHit(hitCollider, hitNormal, hitPoint, ref hitStabilityReport);

		public void OnMovementHit
		(
			Collider hitCollider,
			Vector3 hitNormal,
			Vector3 hitPoint,
			ref HitStabilityReport hitStabilityReport
		) =>
			StateMachine.OnMovementHit(hitCollider, hitNormal, hitPoint, ref hitStabilityReport);

		public void ProcessHitStabilityReport
		(
			Collider hitCollider,
			Vector3 hitNormal,
			Vector3 hitPoint,
			Vector3 atCharacterPosition,
			Quaternion atCharacterRotation,
			ref HitStabilityReport hitStabilityReport
		) =>
			StateMachine.ProcessHitStabilityReport
				(
				 hitCollider,
				 hitNormal,
				 hitPoint,
				 atCharacterPosition,
				 atCharacterRotation,
				 ref hitStabilityReport
				);

		public void OnDiscreteCollisionDetected(Collider hitCollider) =>
			StateMachine.OnDiscreteCollisionDetected(hitCollider);

		#endregion
	}
}