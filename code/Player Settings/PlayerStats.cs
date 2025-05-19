public sealed class PlayerStats : Component {
	
	#region Vars 
	[Property, Group( "Reference" )] public PlayerController ply { get; set; }
	[Property, Group( "Reference" )] public Vector3 RespawnPosition { get; set; }

	[Property, Group("Stats")] public float playerHealth { get; set; } = 100f;
	[Property, Group("Stats")] public float playerArmor { get; set; } = 0f;
	private float _oldPlayerHealth { get; set; }

	[Property, Group( "Perks" )] public int perkJump { get; set; } = 0;   
	[Property, Group( "Perks" )] public int perkSpeed { get; set; } = 0;  
	[Property, Group( "Perks" )] public int perkHealth { get; set; } = 0;  
	[Property, Group( "Perks" )] public int perkArmor { get; set; } = 0;  
	[Property, Group( "Perks" )] public int perkDamage { get; set; } = 0; 
	#endregion


	#region Logic
	public void TakeDamage(float damage)
	{
		playerHealth -= damage;
	}
	private void HealtLogic(){
		if (playerHealth <= 0)
		{
			ply.Transform.Position = RespawnPosition;
			playerHealth = _oldPlayerHealth;

		}

	}

	/*
	* Perks logic 
	*/
	private void PerkSpeedRework(){
		if ( perkSpeed <= 0 ) perkSpeed = 1;
		ply.RunSpeed = MathF.Round(ply.RunSpeed * perkSpeed / 2); // change the perk calculation algorithm
	}
	private void PerkJumpRework(){
		if ( perkJump <= 0 ) perkJump = 1;
		ply.JumpSpeed = MathF.Round( ply.JumpSpeed * perkJump / 2 ); // change the perk calculation algorithm
	}
	private void PerkHealthRework(){
		if ( perkHealth <= 0 ) perkHealth = 1;

	}
	private void PerkArmorRework(){
		if ( perkArmor <= 0 ) perkArmor = 1;

	}
	private void PerkDamageRework(){
		if ( perkDamage <= 0 ) perkDamage = 1;

	}

	#endregion

	#region Component
	protected override void OnStart()
	{
		// if( ply == null ) return;
		_oldPlayerHealth = playerHealth;
		PerkSpeedRework();
		PerkJumpRework();

	}

	protected override void OnUpdate()
	{
		HealtLogic();
	}
	#endregion
}
