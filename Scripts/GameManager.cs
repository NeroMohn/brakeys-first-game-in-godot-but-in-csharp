using Godot;
using System;

public partial class GameManager : Node
{

	public int score;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		score = 0;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void IncreaseScore(int amount)
	{
		score += amount;
		GD.Print($"Score: {score}" );
	}
}
