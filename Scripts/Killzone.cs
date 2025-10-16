using Godot;
using System;

public partial class Killzone : Area2D
{

	private Timer _timer;

	public override void _Ready()
	{
		_timer = GetNode<Timer>("Timer");
	}

	private void OnBodyEntered(Node2D body)
	{
		GD.Print("You died lol");
		Engine.TimeScale = 0.3f;
		body.GetNode<CollisionShape2D>("CollisionShape2D").QueueFree();

		_timer.Start();
	}

	private void OnTimerTimeout()
	{
		Engine.TimeScale = 1f;

		GetTree().ReloadCurrentScene();
	}
	
}
