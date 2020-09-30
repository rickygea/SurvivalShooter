using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    public abstract void Execute();
    public abstract void UnExecute();
}

public class MoveCommand : Command
{
    PlayerMovement playerMovement;
    float h, v;

    public MoveCommand(PlayerMovement _playerMovement, float _h, float _v)
    {
        this.playerMovement = _playerMovement;
        this.h = _h;
        this.v = _v;
    }
    
    public override void Execute()
    {
        playerMovement.Gerak(h, v);
        playerMovement.animasikan(h, v);
    }

    public override void UnExecute()
    {
        playerMovement.Gerak(-h, -v);
        playerMovement.animasikan(h, v);
    }
}

public class ShootCommand : Command
{

    PlayerShooting playerShooting;

    public ShootCommand(PlayerShooting _playerShooting)
    {
        playerShooting = _playerShooting;
    }

    public override void Execute()
    {
        playerShooting.Shoot();
    }

    public override void UnExecute()
    {
        
    }
}
