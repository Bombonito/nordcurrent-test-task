using UnityEngine;
using Zenject;

namespace Tank.Team
{
    public class TeamInstaller : MonoInstaller
    {
        [SerializeField] private string _team;

        public override void InstallBindings()
        {
            var team = new SimpleTeam(_team);
            Container.BindInterfacesAndSelfTo<ITeam>().FromInstance(team).AsSingle().NonLazy();
        }
    }
}