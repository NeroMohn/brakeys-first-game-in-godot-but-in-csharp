using Godot;
using System;
using static Godot.TextServer;

public partial class Player : CharacterBody2D
{
	public const float Speed = 130.0f;
	public const float JumpVelocity = -300.0f;

	private AnimatedSprite2D _playerSprite;

	public override void _Ready()
	{
		_playerSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("Jump") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}

		// Get the input direction and handle the movement/deceleration.
		Vector2 direction = Input.GetVector("MoveLeft", "MoveRight", "ui_up", "ui_down");

		//Flip the animation
		if (direction.X > 0)
		{
			_playerSprite.FlipH = false;
		}
		else if (direction.X < 0)
		{
			_playerSprite.FlipH = true;
		}

		AnimationControll(direction);

		if (direction != Vector2.Zero)
			velocity.X = direction.X * Speed;
		else
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		
		Velocity = velocity;
		MoveAndSlide();
	}

	private void AnimationControll(Vector2 direction)
	{
		if (IsOnFloor())
		{
			if (direction.X == 0f)
				_playerSprite.Animation = "Idle";
			else
				_playerSprite.Animation = "Run";
		}
		else
			_playerSprite.Animation = "Jump";
	}
}
