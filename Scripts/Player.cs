using Godot;
using System;
using static Godot.GD;

public class Player : KinematicBody2D
{
	private Vector2 velocity = Vector2.Zero;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	public override void _PhysicsProcess(float delta)
	{
		velocity.y += 2;
		if (Input.IsActionPressed("move_right"))
		{
			velocity.x = 10;
		}
		else if (Input.IsActionPressed("move_left"))
		{
			velocity.x = -10;
		}
		else
		{
			velocity.x = 0;
		}
		velocity = MoveAndSlide(velocity);
	}

}
