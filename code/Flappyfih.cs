using Sandbox;

public sealed class Flappyfih : Component
{
	private float Force = 100f;
	Rigidbody body;
	protected override void OnStart()
	{
		body = Components.Get<Rigidbody>();
	}
	protected override void OnUpdate()
	{
		if ( Input.Down( "Forward" ) )
		{
			body.PhysicsBody.SmoothMove( LocalTransform.Position + Vector3.Backward * Force, Time.Delta, 0.1f );
			body.PhysicsBody.SmoothRotate( LocalTransform.Rotation * Rotation.From( 0f, 0f, 90f ), Time.Delta, 0.1f );
		}
		if ( Input.Down( "Back" ) )
		{
			body.PhysicsBody.SmoothMove( LocalTransform.Position + Vector3.Forward * Force, Time.Delta, 0.1f );
			body.PhysicsBody.SmoothRotate( LocalTransform.Rotation * Rotation.From( 0f, 0f, 90f ), Time.Delta, 0.1f );
		}
		if ( Input.Down( "Jump" ) )
		{
			body.PhysicsBody.SmoothMove( LocalTransform.Position + Vector3.Up * Force, Time.Delta, 0.1f );
		}
		if ( Input.Down("Left" ) )
		{
			body.PhysicsBody.SmoothMove( LocalTransform.Position + Vector3.Right * Force, Time.Delta, 0.1f );
			body.PhysicsBody.SmoothRotate( LocalTransform.Rotation * Rotation.From( 0f, 0f, 10f ), Time.Delta, 0.1f );
		}
		if ( Input.Down("Right" ) )
		{
			body.PhysicsBody.SmoothMove( LocalTransform.Position + Vector3.Left * Force, Time.Delta, 0.1f );
			body.PhysicsBody.SmoothRotate( LocalTransform.Rotation * Rotation.From( 0f, 0f, -10f ), Time.Delta, 0.1f );
		}
	}
}
