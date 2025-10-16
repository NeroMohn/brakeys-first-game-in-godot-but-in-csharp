using Godot;
using System;

public partial class GreenSlime : Node2D
{
	private const float _speed = 60.0f;
	private float _direction = 1.0f;

	private RayCast2D _rayCastRight;
	private RayCast2D _rayCastLeft;
	private AnimatedSprite2D _sprite;

	public override void _Ready()
	{
		_rayCastRight = GetNode<RayCast2D>("RayCastRight");
		_rayCastLeft = GetNode<RayCast2D>("RayCastLeft");
		_sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (_rayCastRight.IsColliding())
		{
			_direction = -1.0f;
			_sprite.FlipH = true;
		}

		if (_rayCastLeft.IsColliding())
		{
			_direction = 1.0f;
			_sprite.FlipH = false;
		}

		Position += new Vector2((_speed * _direction) * (float)delta, 0);
	}
}
