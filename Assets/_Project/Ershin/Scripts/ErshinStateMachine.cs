using Bezoro.Character.States;
using Bezoro.StateMachines;

namespace Bezoro.Character.StateMachine
{
	public class ErshinStateMachine : KinematicCharacterStateMachine
	{
		protected override void SetUp() { RegisterState<ErshinIdle>(out var idle); }
	}
}