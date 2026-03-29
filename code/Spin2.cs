public sealed class Spin2 : Component
{
	private Spin _spin;
 
	protected override void OnStart()
	{
		_spin = GameObject.GetComponent<Spin>();
 
		if ( _spin is null )
			Log.Warning( "Spin2: no Spin component found on this GameObject" );
	}
 
	protected override void OnUpdate()
	{
		var warningText = _spin is not null && _spin.IsSpinning ? "you've been warned" : "FLICKER WARNING";
		_spin.Hud.DrawText( new TextRendering.Scope( warningText, Color.Red, 32 ), new Vector2( 50f, 50f ) );
	}

	protected override void OnFixedUpdate()
	{
		LocalRotation *= Rotation.FromYaw(Time.Delta * 30f);
	}
}