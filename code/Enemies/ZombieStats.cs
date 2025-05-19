using Sandbox;

public sealed class ZombieStats : Component 
{
	#region vars
	[Property, Group( "Reference" )] public GameObject Player { get; set; }
	[Property, Group( "Reference" )] public Rigidbody Rb { get; set; }
	[Property, Group( "Movement" )] public float Exp { get; set; } = 1.5f;
	[Property, Group( "Movement" )] public float SnapDistance { get; set; } = 1000f;
	#endregion

	#region Logic
	protected void MoveControl()
	{
		Vector3 playerPos = Player.Transform.Position;
		Vector3 zombiePos = Transform.Position;
		Vector3 direction = (playerPos - zombiePos).Normal;

		float distance = Vector3.DistanceBetween( playerPos, zombiePos );

		float scaledImpulse = MathF.Pow( 500, Exp );

		DebugOverlay.Line( zombiePos, playerPos, Color.Red, 0 ); // Debug line for checking "position detection" logic

		Rb.ApplyImpulse( direction * scaledImpulse );

		if ( distance > SnapDistance )
		{
			Rb.Velocity = direction * 1000;
		}
	}
	#endregion

	#region Component
	protected override void OnUpdate()
	{
		if ( Player == null || Rb == null ) return;
		MoveControl();
	}
	#endregion
}

