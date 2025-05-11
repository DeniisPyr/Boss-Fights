using Sandbox;

public sealed class ZombieStats : Component
{
	[Property] public GameObject Player { get; set; }
	[Property] public float Speed { get; set; } = 300f;
	[Property] public float MaxSpeed { get; set; } = 400f;
	[Property] public Rigidbody Rb { get; set; }

	protected override void OnUpdate()
	{
		if ( Player == null || Rb == null ) return;

		Vector3 playerPos = Player.Transform.Position;
		Vector3 zombiePos = Transform.Position;
		Vector3 direction = (playerPos - zombiePos);

		float distance = direction.Length;

		direction = direction.Normal;

		//DebugOverlay.Line( zombiePos, playerPos, Color.Red, duration: 0 ); DEBUG

		if ( Rb.Velocity.Length < MaxSpeed )
		{
			Rb.ApplyForce(direction * Speed);
		}
	}
}
