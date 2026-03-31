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
		var localPos = LocalTransform.Position;
		var localRot = LocalTransform.Rotation;
		if ( Input.Down( "Forward" ) )
		{
			body.PhysicsBody.SmoothMove( localPos + localRot * Vector3.Forward * Force, Time.Delta, 0.1f );
			body.PhysicsBody.SmoothRotate( localRot * Rotation.From( 0f, 0f, 90f ), Time.Delta, 0.1f );
		}
		if ( Input.Down( "Back" ) )
		{
			body.PhysicsBody.SmoothMove( localPos + localRot * Vector3.Backward * Force, Time.Delta, 0.1f );
			body.PhysicsBody.SmoothRotate( localRot * Rotation.From( 0f, 0f, 90f ), Time.Delta, 0.1f );
		}
		if ( Input.Down( "Jump" ) )
		{
			body.PhysicsBody.SmoothMove( localPos + localRot * Vector3.Up * Force, Time.Delta, 0.1f );
		}
		if ( Input.Down("Left" ) )
		{
			body.PhysicsBody.SmoothMove( localPos + localRot * Vector3.Left * Force, Time.Delta, 0.1f );
			body.PhysicsBody.SmoothRotate( localRot * Rotation.From( 0f, 0f, 10f ), Time.Delta, 0.1f );
		}
		if ( Input.Down("Right" ) )
		{
			body.PhysicsBody.SmoothMove( localPos + localRot * Vector3.Right * Force, Time.Delta, 0.1f );
			body.PhysicsBody.SmoothRotate( localRot * Rotation.From( 0f, 0f, -10f ), Time.Delta, 0.1f );
		}
	}
}
