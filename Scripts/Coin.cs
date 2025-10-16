using Godot;using System;

public partial class Coin : Area2D
{
	private GameManager _gameManager;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_gameManager = GetNode<GameManager>("%GameManager");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}

	public void OnBodyEntered(Node2D body)
	{
		GD.Print("Coin collected!");
		_gameManager.IncreaseScore(1);
		QueueFree();
	}
}
