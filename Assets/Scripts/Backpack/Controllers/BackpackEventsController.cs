using System;
using Cysharp.Threading.Tasks;
using ManeraiTest.Backpack.Models;
using ManeraiTest.Backpack.Views;
using ManeraiTest.Item.Configs;
using ManeraiTest.ServerInteraction;
using UnityEngine;
using VContainer.Unity;

namespace ManeraiTest.Backpack.Controllers
{
    public class BackpackEventsController : IInitializable, IDisposable
    {
        private const string StoreEventType = "Item Stored";
        private const string TakenEventType = "Item Taken";

        private readonly BackpackView _backpackView;
        private readonly BackpackModel _backpackModel;
        private readonly ServerInteractionService _serverInteractionService;

        public BackpackEventsController(BackpackView backpackView, BackpackModel backpackModel,
            ServerInteractionService serverInteractionService)
        {
            _backpackView = backpackView;
            _backpackModel = backpackModel;
            _serverInteractionService = serverInteractionService;
        }

        public void Initialize()
        {
            _backpackModel.ItemStored += SendItemStoredEvent;
            _backpackModel.ItemTaken += SendItemTakenEvent;
        }

        public void Dispose()
        {
            _backpackModel.ItemStored -= SendItemStoredEvent;
            _backpackModel.ItemTaken -= SendItemTakenEvent;
        }

        private void SendItemStoredEvent(ItemConfig itemConfig)
        {
            _backpackView.OnItemStored(itemConfig);

            var data = CreateEventData(itemConfig, StoreEventType);

            _serverInteractionService.SendRequest(ConvertEventDataToJson(data)).Forget();
        }

        private void SendItemTakenEvent(ItemConfig itemConfig)
        {
            _backpackView.OnItemTaken(itemConfig);

            var data = CreateEventData(itemConfig, TakenEventType);

            _serverInteractionService.SendRequest(ConvertEventDataToJson(data)).Forget();
        }

        private EventData CreateEventData(ItemConfig itemConfig, string eventType)
        {
            return new EventData(itemConfig.Id, eventType);
        }

        private string ConvertEventDataToJson(EventData eventData)
        {
            return JsonUtility.ToJson(eventData);
        }
    }
}