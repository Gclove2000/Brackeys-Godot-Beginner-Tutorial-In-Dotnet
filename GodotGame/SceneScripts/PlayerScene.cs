using Godot;
using GodotGame.SceneModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GodotGame.SceneScripts
{
    public partial class PlayerScene :Node2D
    {

        public PlayerSceneModel Model { get; set; } 

        public PlayerScene()
        {
            Model = Program.Services.GetService<PlayerSceneModel>();
            Model.Scene = this;
        }

        public override void _Ready()
        {
            base._Ready();
            Model.Ready();
        }

        public override void _Process(double delta)
        {
            base._Process(delta);
            Model.Process(delta);
        }
    }
}
