using Sandbox;
using Sandbox.Rendering;
using Sandbox.UI;

public sealed class Spin : Component
{
	// <summary>
	// I wont cache alot of stuff because alot of it will only be used once, if it's used more than once then it will be cached, if not then it wont be cached 
	// </summary>
	[Property] public SoundEvent SpinSound { get; set; }

	private readonly Color tint = Color.Red;
	private readonly Color nottint = Color.White;

	public bool IsSpinning { get; set; }

	private Vector2 textPos;
	private Vector2 textTarget;

	private IEnumerable<SkyBox2D> _skyboxes;
	private IEnumerable<ModelRenderer> _renderers;
	private Material _spinSkyMaterial;
	private Material _defaultSkyMaterial;

	private float counter = 0f;

	private SoundHandle _spinSound;

	public HudPainter Hud => Scene.Camera.Hud;

	protected override void OnStart()
	{
		_skyboxes = Scene.GetAllComponents<SkyBox2D>();
		_renderers = Scene.GetAllComponents<ModelRenderer>();
		_spinSkyMaterial = Cloud.Material( "https://sbox.game/polyhaven/kloppenheim_03_puresky" );
		_defaultSkyMaterial = Material.Load( "materials/skybox/skybox_day_01.vmat" );
	}

	protected override void OnUpdate()
	{
		if ( Input.Released( "Jump" ) && _spinSound.IsValid() )
			_spinSound.Stop();

		if ( Input.Down( "Jump" ) )
			Spiny();
		else
			Idle();

		Hud.DrawText( new TextRendering.Scope( counter.ToString( "F1" ), Color.White, 42 ),
	new Vector2( Screen.Width * 0.5f, Screen.Height * 0.5f ) );
	}

	private void Idle()
	{
		Hud.DrawText( new TextRendering.Scope( "Don't hold space your ears wont like it", Color.White, 42 ),
			new Vector2( Screen.Width * 0.2f, Screen.Height * 0.2f ) );

		ResetSkyboxes();
		IsSpinning = false;
	}

	private void Spiny()
	{
		if ( !_spinSound.IsValid() || !_spinSound.IsPlaying )
			_spinSound = GameObject.PlaySound( SpinSound );

		float spin = Time.Delta * 1000f;
		WorldRotation *= Rotation.From( spin, spin, spin );

		counter += Time.Delta;

		if ( counter >= 10f )
		{
			TimerComplete();
		}

		foreach ( var renderer in _renderers )
			renderer.Tint = tint;

		if ( textPos.Distance( textTarget ) < 25f )
			textTarget = new Vector2( Game.Random.Float( 50f, Screen.Width - 20f ), Game.Random.Float( 50f, Screen.Height - 50f ) );

		textPos = Vector2.Lerp( textPos, textTarget, Time.Delta * 100f );
		Hud.DrawText( new TextRendering.Scope( "dingus", Color.Red, 64 ), textPos );

		foreach ( var skybox in _skyboxes )
			skybox.SkyMaterial = _spinSkyMaterial;

		IsSpinning = true;
	}

	public void TimerComplete()
	{
		Log.Info( "timer complete" );
	}

	private void ResetSkyboxes()
	{
		foreach ( var skybox in _skyboxes )
			skybox.SkyMaterial = _defaultSkyMaterial;

		foreach ( var renderer in _renderers )
			renderer.Tint = nottint;
	}
}