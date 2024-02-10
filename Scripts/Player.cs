using Godot;
using System;
using static Godot.GD;

public class Player : KinematicBody2D
{
	private Vector2 velocity = Vector2.Zero;
	[Export]
	private float speed = 10;
	[Export]
	private float gravity = 4;
	[Export]
	private float jumpForce = -130;
	[Export]
	private float jumpReleaseForce = -70;
	[Export]
	private float frictionAmount = 10;
	[Export]
	private float accelerationAmount = 10;
	public override void _PhysicsProcess(float delta)
	{
		ApplyGravity();
		Vector2 input = Vector2.Zero;
		input.x = Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left");

		if (input.x == 0)
		{
			ApplyFriction();
		}
		else
		{
			ApplyAcceleration(input.x);
		}

		if (Input.IsActionJustPressed("jump") && IsOnFloor())
		{
			velocity.y = jumpForce;
		}
		else
		{
			if (Input.IsActionJustReleased("jump") && velocity.y < jumpReleaseForce)
			{
				velocity.y = jumpReleaseForce;
			}

			if (velocity.y > 0)
			{
				velocity.y += gravity;
			}
		}
		velocity = MoveAndSlide(velocity, Vector2.Up);
	}


	private void ApplyGravity()
	{
		velocity.y += gravity;
	}
	private void ApplyAcceleration(float amount)
	{
		velocity.x = Mathf.MoveToward(velocity.x, speed * amount, accelerationAmount);
	}

	private void ApplyFriction()
	{
		velocity.x = Mathf.MoveToward(velocity.x, 0, frictionAmount);
	}


}
