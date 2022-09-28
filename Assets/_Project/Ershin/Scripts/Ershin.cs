using Bezoro.Core;
using UnityEngine;
using Bezoro.StateMachines;
using KinematicCharacterController;
using Bezoro.Character.StateMachine;

namespace Bezoro.Character.Controller
{
	[SelectionBase, DisallowMultipleComponent]
	[RequireComponent(typeof(KinematicCharacterMotor))]
	public sealed class Ershin : KinematicCharacter<ErshinStateMachine> { }

	public abstract class KinematicCharacter<TStateMachine> : Tickable,
		ICharacterController
	where TStateMachine : KinematicCharacterStateMachine, new()
	{
		[field: SerializeField]
		public KinematicCharacterMotor CharacterMotor { get; private set; }

		[field: SerializeField, HideInInspector]
		public KinematicCharacterStateMachine StateMachine { get; private set; } =
			new TStateMachine();

		protected virtual void Awake()
		{
			CharacterMotor.CharacterController = this;
			StateMachine.Init(this, CharacterMotor);
		}

		public override void Tick() =>
			StateMachine.Tick();

		public override void FixedTick() =>
			StateMachine.FixedTick();

		public override void LateTick() =>
			StateMachine.LateTick();

		#region KCC Methods

		public virtual void UpdateRotation(ref Quaternion currentRotation, float deltaTime) =>
			StateMachine.UpdateRotation(ref currentRotation, deltaTime);

		public virtual void UpdateVelocity(ref Vector3 currentVelocity, float deltaTime) =>
			StateMachine.UpdateVelocity(ref currentVelocity, deltaTime);

		public virtual void BeforeCharacterUpdate(float deltaTime) =>
			StateMachine.BeforeCharacterUpdate(deltaTime);

		public virtual void PostGroundingUpdate(float deltaTime) =>
			StateMachine.PostGroundingUpdate(deltaTime);

		public virtual void AfterCharacterUpdate(float deltaTime) =>
			StateMachine.AfterCharacterUpdate(deltaTime);

		public virtual bool IsColliderValidForCollisions(Collider coll) =>
			StateMachine.IsColliderValidForCollisions(coll);

		public virtual void OnGroundHit
		(
			Collider hitCollider,
			Vector3 hitNormal,
			Vector3 hitPoint,
			ref HitStabilityReport hitStabilityReport
		) =>
			StateMachine.OnGroundHit(hitCollider, hitNormal, hitPoint, ref hitStabilityReport);

		public virtual void OnMovementHit
		(
			Collider hitCollider,
			Vector3 hitNormal,
			Vector3 hitPoint,
			ref HitStabilityReport hitStabilityReport
		) =>
			StateMachine.OnMovementHit(hitCollider, hitNormal, hitPoint, ref hitStabilityReport);

		public virtual void ProcessHitStabilityReport
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

		public virtual void OnDiscreteCollisionDetected(Collider hitCollider) =>
			StateMachine.OnDiscreteCollisionDetected(hitCollider);

		#endregion
	}
}