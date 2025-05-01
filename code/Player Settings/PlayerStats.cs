public sealed class PlayerStats : Component {
	#region Vars 
	[Property, Group("Stats")] public float playerHealth { get; set; } = 100f;
	[Property, Group("Stats")] public float playerArmor { get; set; } = 0f;

	[Property, Group( "Perks" )] public int perkJump { get; set; } = 0;
	[Property, Group( "Perks" )] public int perkSpeed { get; set; } = 0;
	[Property, Group( "Perks" )] public int perkHealth { get; set; } = 0;
	[Property, Group( "Perks" )] public int perkArmor { get; set; } = 0;
	[Property, Group( "Perks" )] public int perkDamage { get; set; } = 0;
	#endregion
}
