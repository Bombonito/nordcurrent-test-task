using System.Collections;
using Save_System.Data;
using Save_System.Types;
using Tank.Team;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Save_System.Adapters
{
    public class TankSaveAdapter : MonoBehaviour, ISaveAdapter<TankSaveData>
    {
        [Inject] public SaveSystem SaveSystem { get; }
        [Inject] public NavMeshAgent Tank { get; }
        [Inject] public ITeam Team { get; }
        
        public TankSaveData Extract()
        {
            var entityType = Team.Team switch
            {
                "player" => EntityType.PlayerTank,
                "bot" => EntityType.BotTank,
                _ => EntityType.None
            };
            
            return new TankSaveData(entityType, Tank.transform.position, Tank.transform.rotation);
        }

        public IEnumerator ApplyCoroutine(TankSaveData saveData)
        {
            Tank.transform.position = saveData.Position;
            Tank.transform.rotation = saveData.Rotation;
            yield return null;
        }
    }
}